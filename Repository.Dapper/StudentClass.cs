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
    public class StudentClass
    {
        protected readonly IDbConnection db = new SQLiteConnection(@"Data Source=D:\Projects\MHSSystem\db\db.db; Integrated Security=True");


        public int AddStudentToClass(int newStudentId, int classId)
        {
            Model.StudentClass sc = new Model.StudentClass() { StudentId=newStudentId,ClassId=classId};
            string sql = "insert into [StudentClass](StudentId, ClassId) values(@StudentId,@ClassId)";

            int ret = db.Execute(sql, sc);

            return ret;
        }

        public int RemoveStudentFromClass(int newStudentId, int classId)
        {
            string sql = "delete from [StudentClass] where StudentId=" + newStudentId + " and ClassId=" + classId;

            int ret = db.Execute(sql);

            return ret;
        }

        public void AutoAssign(List<Model.Student> students, List<Model.Class> classes, int method)
        {
            // method:
            // 1:平行
            // 2:蛇形平行
            // 3:随机平行


            // 分别查询出男女生
            List<Model.Student> boys = students.Where(x => x.xb == "男").ToList<Model.Student>();
            List<Model.Student> girls = students.Where(x => x.xb == "女").ToList<Model.Student>();

            // 男女生分别按总分排序
            boys.Sort((x, y) => -x.zcj.CompareTo(y.zcj));
            girls.Sort((x, y) => -x.zcj.CompareTo(y.zcj));

            // 根据班级数计算每班最大可能男女生人数
            int boysPerClass = (int)Math.Ceiling(((double)boys.Count) / classes.Count);
            int girlsPerClass = (int)Math.Ceiling(((double)girls.Count) / classes.Count);


            // 分男生
            // 生成班级序列
            List<int> classIdx = GenerateClassRank(classes.Count, boys.Count, method);
            for (int i = 0; i < boys.Count; i++)
            {
                this.AddStudentToClass(boys[i].ID, classes[classIdx[i]].ID);
            }

            // 分女生
            // 生成班级序列
            classIdx = GenerateClassRank(classes.Count, girls.Count, method);
            for (int i = 0; i < girls.Count; i++)
            {
                this.AddStudentToClass(girls[i].ID, classes[classIdx[i]].ID);
            }

        }



        private List<int> GenerateClassRank(int numClasses, int numStudents, int method)
        {
            switch(method)
            {
                case 0: // 平行
                    return EqualRank(numClasses, numStudents);
                case 1: // 蛇形
                    return SnakeRank(numClasses, numStudents);
                case 2: // 随机
                    return RandomRank(numClasses, numStudents);
                default:
                    return SnakeRank(numClasses, numStudents);
            }
        }

        private List<int> EqualRank(int numClasses, int numStudents)
        {
            // 代表班级的索引list
            int extendedNumStudents = numStudents;
            if (numStudents % numClasses != 0)
            {
                extendedNumStudents = numStudents + (numClasses - numStudents % numClasses);
            }


            List<int> classIdx = new List<int>(extendedNumStudents);

            for(int i=0;i<extendedNumStudents;)
            {
                for(int j = 0;j<numClasses;j++)
                {
                    classIdx.Insert(i, j);
                    i++;
                }
            }

            return classIdx;
        }

        private List<int> SnakeRank(int numClasses, int numStudents)
        {
            // 代表班级的索引list
            int extendedNumStudents = numStudents;
            if (numStudents % numClasses != 0)
            {
                extendedNumStudents = numStudents + (numClasses - numStudents % numClasses);
            }


            List<int> classIdx = new List<int>(extendedNumStudents);

            bool isOdd = true;
            for (int i = 0; i < extendedNumStudents;)
            {
                for (int j = 0; j < numClasses; j++)
                {
                    classIdx.Insert(i,isOdd?j:numClasses-j-1);
                    i++;
                }
                isOdd = !isOdd;
            }

            return classIdx;
        }


        
        private List<int> RandomRank(int numClasses, int numStudents)
        {
            // 代表班级的索引list
            int extendedNumStudents = numStudents;
            if (numStudents % numClasses != 0)
            {
                extendedNumStudents = numStudents + (numClasses - numStudents % numClasses);
            }


            List<int> classIdx = new List<int>(extendedNumStudents);
            Random random = new Random();
            List<int> tempIdx = new List<int>(numClasses);
            for (int i = 0; i < extendedNumStudents;)
            {
                int cnt = 0;
                int value = 0;
                tempIdx.Clear();
                while(cnt < numClasses)
                {
                    value = random.Next(numClasses);
                    if (tempIdx.IndexOf(value) >= 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempIdx.Insert(cnt, value);
                        cnt++;
                    }
                }
                for (int j = 0; j < numClasses; j++)
                {
                    classIdx.Insert(i, tempIdx[j]);
                    i++;
                }
            }

            return classIdx;
        }

        public void Clear()
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            using (var transaction = db.BeginTransaction())
            {
                db.Execute("delete from [StudentClass] where ClassId in (select ID from [Class] where Grade='" + DateTime.Now.Year.ToString() + "');", transaction);
                db.Execute("update sqlite_sequence set seq=0 where name='StudentClass'", transaction);
                transaction.Commit();
            }
        }

        public List<Model.Student> GetStudentIdsWithNoClass()
        {
            string sql = @"select ID,zkzh,xm,bmdz,bmxs,bmxx,bmhkdz,sjsydz,ywcj,wlhxcj,sxcj,ddyfzlscj,wycj,zcj,tycj,sfzh,xjh,sy,zb,xb,csrq,bj,kstz,zzmm,hkxz,txdz,lxdh,yzbm,fqxm,fqsfzh,fqzb,fqhkxz,fqlxdh,fqgzdw,mqxm,mqsfzh,mqzb,mqhkxz,mqlxdh,mqgzdw,lqss,lqxx,sfwk,sfbd";
            sql += " from [Student]";
            sql += " where ID not in (select StudentId from [StudentClass])";

            List<Model.Student> ret = db.Query<Model.Student>(sql).ToList<Model.Student>();

            return ret;
        }
    }
}
