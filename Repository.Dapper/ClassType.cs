using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassType
    {
        protected readonly IDbConnection db = new SQLiteConnection(@"Data Source=D:\Projects\MHSSystem\db\db.db; Integrated Security=True");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Model.ClassType> GetList(string predicate = null, string orderBy = null)
        {
            string sql = @"select ID,ClassTypeName,IsLiberalArts";
            sql += " from [ClassType]";

            if (!string.IsNullOrEmpty(predicate))
            {
                sql += " where " + predicate;
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += " order by " + orderBy + " asc";
            }

            List<Model.ClassType> list = db.Query<Model.ClassType>(sql).ToList<Model.ClassType>();

            return list;

        }

        public int Add(Model.ClassType ct)
        {
            string sql = "insert into [ClassType](ClassTypeName,IsLiberalArts)";
            sql += "values (@ClassTypeName,@IsLiberalArts)";

            int ret = db.Execute(sql, ct);

            return ret;
        }

        public int Delete(int classTypeId)
        {
            string sql = "delete from [ClassType] where ID=" + classTypeId.ToString();

            int ret = db.Execute(sql);

            return ret;
        }

        public int Update(Model.ClassType ct)
        {
            string sql = "update [ClassType] set ClassTypeName=@ClassTypeName,IsLiberalArts=@IsLiberalArts";

            int ret = db.Execute(sql, ct);

            return ret;
        }


    }
}
