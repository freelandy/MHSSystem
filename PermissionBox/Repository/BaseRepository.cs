using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Data.SQLite;
using PermissionBox.Dapper;

namespace PermissionBox.Repository
{
    public class BaseRepository<T> where T: class
    {
        protected readonly IDbConnection db = new SQLiteConnection("Data Source=db.db; Integrated Security=True");

        public List<T> Get(string where)
        {
            string sql = "select * from " + typeof(T).ToString();
            if(where != "")
            {
                sql += " where " + where;
            }

            List<T> records = db.Query<T>(sql).ToList();

            return records;
        }

        public List<T> GetAll()
        {
            return Get("");
        }

        public bool Update(T record)
        {
            Type type = typeof(T);
            string tableName = type.ToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update {0} set ", tableName);

            // get properties of T
            List<PropertyInfo> properties = type.GetProperties().ToList();

            // get key property
            PropertyInfo idProp = properties.Find(p => string.Equals(p.Name, "id", StringComparison.CurrentCultureIgnoreCase));

            // get non-key property
            List<PropertyInfo> valueProps = properties.Except(new List<PropertyInfo>() { idProp}).ToList();


            for (int i = 0; i < valueProps.Count; i++)
            {
                sb.AppendFormat("[{0}] = @{1}", valueProps[i].Name, valueProps[i].Name);
                if (i < valueProps.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" where id=@ID");

            int ret = db.Execute(sb.ToString(), record);


            return ret > 0;
        }

        public int Insert(T record)
        {
            Type type = typeof(T);
            string tableName = type.ToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into {0}(", tableName);

            // get properties of T
            List<PropertyInfo> properties = type.GetProperties().ToList();

            // get non-key property
            List<PropertyInfo> valueProps = properties.Where(p => !string.Equals(p.Name, "id", StringComparison.CurrentCultureIgnoreCase)).ToList();


            for (int i = 0; i < valueProps.Count; i++)
            {             
                sb.AppendFormat("[{0}]", valueProps[i].Name);
                if (i < valueProps.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(") values(");

            for (int i = 0; i < valueProps.Count; i++)
            {
                sb.AppendFormat("@{0}", valueProps[i].Name);
                if (i < valueProps.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(");select SCOPE_IDENTITY() id");

            Dapper.SqlMapper.GridReader reader = db.QueryMultiple(sb.ToString(), record);

            var first = reader.Read().FirstOrDefault();
            int id = 0;
            if (first != null && first.id != null)
            {
                id = (int)first.id;
            }

            return id;

        }

        public bool Delete(int id)
        {
            Type type = typeof(T);
            string tableName = type.ToString();

            string sql = "delete from " + tableName.ToString() + " where id=" + id.ToString();
            int ret = db.Execute(sql);

            return ret > 0;
        }
    }
}
