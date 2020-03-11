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
        protected readonly IDbConnection db = new SQLiteConnection(@"Data Source=D:\Projects\MHSSystem\db\db.db; Integrated Security=True");

        public List<Model.Class> GetList(string predicate=null, string orderBy=null)
        {
            string sql = "select * from [Class]";

            if (!string.IsNullOrEmpty(predicate))
            {
                sql += " where " + predicate;
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += " order by " + orderBy + " asc";
            }

            List<Model.Class> list = db.Query<Model.Class>(sql).ToList<Model.Class>();

            return list;
        }

        public int Add(Model.Class c)
        {
            string sql = "insert into [Class](ClassName, Grade, ClassTypeId, HeadTeacherId)";
            sql += " values(@ClassName, @Grade, @ClassTypeId, @HeadTeacherId)";

            int ret = db.Execute(sql, c);

            return ret;
        }

        public void Delete(int classId)
        {
            string sql1 = "delete from [StudentClass] where ClassId in (select ID from [Class] where ID=" + classId.ToString() + ")";
            string sql2 = "delete from [Class] where ID=" + classId.ToString();
            

            if(db.State == ConnectionState.Closed)
            {
                db.Open();
            }

            using (IDbTransaction trans = db.BeginTransaction())
            {
                db.Execute(sql1, trans);
                db.Execute(sql2, trans);

                trans.Commit();
            }
        }

        public int Update(Model.Class c)
        {
            string sql = "update [Class] set ClassName=@ClassName, Grade=@Grade, ClassTypeId=@ClassTypeId, HeadTeacherId=@HeadTeacherId";

            int ret = db.Execute(sql, c);

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
                db.Execute("delete from [StudentClass] where ClassId in (select ID from [Class])", transaction);
                db.Execute("delete from [Class];", transaction);
                db.Execute("update sqlite_sequence set seq=0 where name='Class';", transaction);
                
                transaction.Commit();
            }
        }

        public List<Model.Student> GetStudents(int classId)
        {
            string sql = "select n.ID,zkzh,xm,bmdz,bmxs,bmxx,bmhkdz,sjsydz,ywcj,wlhxcj,sxcj,ddyfzlscj,wycj,zcj,tycj,sfzh,xjh,sy,zb,xb,csrq,bj,kstz,zzmm,hkxz,txdz,lxdh,yzbm,fqxm,fqsfzh,fqzb,fqhkxz,fqlxdh,fqgzdw,mqxm,mqsfzh,mqzb,mqhkxz,mqlxdh,mqgzdw,lqss,lqxx,sfwk,sfbd,";
            sql += " c.ID, sc.StudentId, sc.ClassId";
            sql += " from [Student] as n, [Class] as c, [StudentClass] as sc";
            sql += " where n.ID=sc.StudentId";
            sql += " and c.ID=sc.ClassId";
            sql += " and c.ID=" + classId;

            List<Model.Student> students = db.Query<Model.Student>(sql).ToList<Model.Student>();

            return students;
        }

        public int IsLiceralArts(int classId)
        {
            string sql = "select IsLiberalArts from ClassType,Class";
            sql += " where ClassTypeId=ClassType.ID";
            sql += " and Class.ID=" + classId;

            int ret = db.ExecuteScalar<int>(sql);

            return ret;
        }

    }
}
