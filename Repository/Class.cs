using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Repository
{
    public class Class
    {
        protected static readonly IDbConnection db = new SQLiteConnection("Data Source=db.db; Integrated Security=True");

        public List<Entity.Class> GetList(string where)
        {
            string sql = "select * from [class]";

            if (where.Trim() != string.Empty)
            {
                sql += " where " + where;
            }

            List<Entity.Class> classes = db.Query<Entity.Class>(sql).ToList<Entity.Class>();

            return classes;
        }

        public int Add(Entity.Class c)
        {
            string sql = "insert into [class](bjmc, bzrxm, bjlb) values('" + c.bjmc + "','" + c.bzrxm + "','" + c.bjlb + "')";

            int ret = db.Execute(sql);

            return ret;
        }

        public int Delete(int id)
        {
            string sql1 = "delete from [class] where ID=" + id.ToString();
            string sql2 = "delete from [classassignment] where bjbh=" + id.ToString();

            if(db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            IDbTransaction trans = db.BeginTransaction();
            try
            {
                int ret = db.Execute(sql1, trans);
                db.Execute(sql2, trans);
                trans.Commit();

                return ret;
            }
            catch(Exception ex)
            {
                trans.Rollback();

                return 0;
            }

        }

        public int Update(Entity.Class c)
        {
            string sql = "update [class] set bjmc='" + c.bjmc + "', bzrxm='" + c.bzrxm + "', bjlb='" + c.bjlb + "' where ID=" + c.ID;

            int ret = db.Execute(sql);

            return ret;
        }

        public void Clear()
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute("delete from [Class];", transaction);
                db.Execute("update sqlite_sequence set seq=0 where name='Class';", transaction);
                db.Execute("delete from [classassignment]");
                transaction.Commit();
            }
        }
    }
}
