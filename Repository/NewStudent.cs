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
    public class NewStudent
    {
        protected static readonly IDbConnection db = new SQLiteConnection("Data Source=db.db; Integrated Security=True");

        public List<Entity.NewStudent> GetList(string where)
        {
            string sql = "select * from [NewStudent]";

            if (where.Trim() != string.Empty)
            {
                sql += " where " + where;
            }

            List<Entity.NewStudent> students = db.Query<Entity.NewStudent>(sql).ToList<Entity.NewStudent>();

            return students;
        }

        public int Add(Entity.NewStudent s)
        {
            string sql = "insert into [NewStudent](zkzh,xm,bmdz,bmxs,bmxx,bmhkdz,sjsydz,ywcj,wlhxcj,sxcj,ddyfzlscj,wycj,zcj,tycj,sfzh,xjh,sy,zb,xb,csrq,bj,kstz,zzmm,hkxz,txdz,lxdh,yzbm,fqxm,fqsfzh,fqzb,fqhkxz,fqlxdh,fqgzdw,mqxm,mqsfzh,mqzb,mqhkxz,mqlxdh,mqgzdw,lqss,lqxx,sfwk,sfbd) ";
            sql += "values (@zkzh,@xm,@bmdz,@bmxs,@bmxx,@bmhkdz,@sjsydz,@ywcj,@wlhxcj,@sxcj,@ddyfzlscj,@wycj,@zcj,@tycj,@sfzh,@xjh,@sy,@zb,@xb,@csrq,@bj,@kstz,@zzmm,@hkxz,@txdz,@lxdh,@yzbm,@fqxm,@fqsfzh,@fqzb,@fqhkxz,@fqlxdh,@fqgzdw,@mqxm,@mqsfzh,@mqzb,@mqhkxz,@mqlxdh,@mqgzdw,@lqss,@lqxx,@sfwk,@sfbd)";

            int ret = db.Execute(sql, s);

            return ret;
        }

        public void Clear()
        {
            if(db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute("delete from [NewStudent];", transaction);
                db.Execute("update sqlite_sequence set seq=0 where name='NewStudent';", transaction);
                db.Execute("delete from [StudentClass]");
                transaction.Commit();
            }
        }

        public int SetLiberalArts(int id, bool flag)
        {
            // flag
            // true：文科
            // false：理科
            string sql = "update [NewStudent] set sfwk=" + flag + " where ID=" + id.ToString();
            int ret = db.Execute(sql);

            return ret;
        }


        public void SetEnrollment(int id, string time)
        {
            // flag
            // true：已报到
            // false：未报到
            string sql1 = "update [newstudent] set sfbd=1 where ID=" + id.ToString();
            string sql2 = "insert into [Enrollment] set EnrollmentTime='" + time + "',NewStudentId=" + id.ToString();


            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute(sql1, transaction);
                db.Execute(sql2, transaction);
                transaction.Commit();
            }
        }

        public void DeSetEnrollment(int id)
        {
            // flag
            // true：已报到
            // false：未报到
            string sql1 = "update [newstudent] set sfbd=0 where ID=" + id.ToString();
            string sql2 = "delete from [Enrollment] where NewStudentId=" + id.ToString();


            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute(sql1, transaction);
                db.Execute(sql2, transaction);
                transaction.Commit();
            }
        }

    }
}
