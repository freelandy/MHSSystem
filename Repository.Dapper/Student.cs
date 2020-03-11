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
    public class Student
    {
        protected readonly IDbConnection db = new SQLiteConnection(@"Data Source=D:\Projects\MHSSystem\db\db.db; Integrated Security=True");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Model.Student> GetList(string predicate = null, string orderBy = null)
        {
            string sql = @"select ID,zkzh,xm,bmdz,bmxs,bmxx,bmhkdz,sjsydz,ywcj,wlhxcj,sxcj,ddyfzlscj,wycj,zcj,tycj,sfzh,xjh,sy,zb,xb,csrq,bj,kstz,zzmm,hkxz,txdz,lxdh,yzbm,fqxm,fqsfzh,fqzb,fqhkxz,fqlxdh,fqgzdw,mqxm,mqsfzh,mqzb,mqhkxz,mqlxdh,mqgzdw,lqss,lqxx,sfwk,sfbd";
            sql += " from [Student]";

            if(!string.IsNullOrEmpty(predicate))
            {
                sql += " where " + predicate;
            }

            if(!string.IsNullOrEmpty(orderBy))
            {
                sql += " order by " + orderBy + " asc";
            }

            List<Model.Student> list = db.Query<Model.Student>(sql).ToList<Model.Student>();

            return list;

        }

        public int Add(Model.Student s)
        {
            string sql = "insert into [Student](zkzh,xm,bmdz,bmxs,bmxx,bmhkdz,sjsydz,ywcj,wlhxcj,sxcj,ddyfzlscj,wycj,zcj,tycj,sfzh,xjh,sy,zb,xb,csrq,bj,kstz,zzmm,hkxz,txdz,lxdh,yzbm,fqxm,fqsfzh,fqzb,fqhkxz,fqlxdh,fqgzdw,mqxm,mqsfzh,mqzb,mqhkxz,mqlxdh,mqgzdw,lqss,lqxx,sfwk,sfbd) ";
            sql += "values (@zkzh,@xm,@bmdz,@bmxs,@bmxx,@bmhkdz,@sjsydz,@ywcj,@wlhxcj,@sxcj,@ddyfzlscj,@wycj,@zcj,@tycj,@sfzh,@xjh,@sy,@zb,@xb,@csrq,@bj,@kstz,@zzmm,@hkxz,@txdz,@lxdh,@yzbm,@fqxm,@fqsfzh,@fqzb,@fqhkxz,@fqlxdh,@fqgzdw,@mqxm,@mqsfzh,@mqzb,@mqhkxz,@mqlxdh,@mqgzdw,@lqss,@lqxx,@sfwk,@sfbd)";

            int ret = db.Execute(sql, s);

            return ret;
        }

        public void Clear()
        {
            string sql1 = "delete from [Enrollment] where StudentId in (select ID from [Student]);";
            string sql2 = "delete from [StudentClass] where StudentId in (select ID from [Student]);";
            string sql3 = "delete from [Student];";
            string sql4 = "update sqlite_sequence set seq=0 where name='Student';";

            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {    
                db.Execute(sql1, transaction);
                db.Execute(sql2, transaction);
                db.Execute(sql3, transaction);
                db.Execute(sql4, transaction);

                transaction.Commit();
            }
        }

        public int SetAsLiberalArts(int studentId)
        {
            string sql = "update [Student] set sfwk=1 where ID=" + studentId.ToString();
            int ret = db.Execute(sql);

            return ret;
        }

        public int SetAsScience(int studentId)
        {
            string sql = "update [Student] set sfwk=0 where ID=" + studentId.ToString();
            int ret = db.Execute(sql);

            return ret;
        }


        public void SetAsEnrollment(int studentId, string memo1, string memo2)
        {
            string sql1 = "update [Student] set sfbd=1 where ID=" + studentId.ToString();
            string sql2 = "insert into [Enrollment](EnrollmentTime,StudentId,Memo1,Memo2) values(@EnrollmentTime,@StudentId,@Memo1,@Memo2)";

            Model.Enrollment e = new Model.Enrollment() { EnrollmentTime = DateTime.Now, StudentId = studentId, Memo1 = memo1, Memo2 = memo2 };

            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute(sql1, transaction);
                db.Execute(sql2, e, transaction);

                transaction.Commit();
            }
        }

        public void SetNotEnrollment(int studentId)
        {
            string sql1 = "update [Student] set sfbd=0 where ID=" + studentId.ToString();
            string sql2 = "delete from [Enrollment] where StudentId=" + studentId.ToString();

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

        public Model.Enrollment GetEnrollment(int studentId)
        {
            string sql = "select * from [Enrollment] where StudentId=" + studentId.ToString();

            Model.Enrollment enrollment = db.QuerySingleOrDefault<Model.Enrollment>(sql);

            return enrollment;
        }

        public Model.Class GetClass(int studentId)
        {
            string sql = "select c.ID,c.ClassName,c.Grade,c.ClassTypeId,c.HeadTeacherId,sc.ClassId,sc.StudentId from [Class] as c,[StudentClass] as sc";
            sql += " where c.ID=sc.ClassId";
            sql += " and sc.StudentId=" + studentId.ToString();

            Model.Class cls = db.QuerySingleOrDefault<Model.Class>(sql);

            return cls;
        }

    }

}
