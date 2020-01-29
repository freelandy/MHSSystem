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
    public class ClassAssignment
    {
        protected static readonly IDbConnection db = new SQLiteConnection("Data Source=db.db; Integrated Security=True");


        public List<Entity.Student> GetClassStudents(int cID)
        {
            string sql = "select * ";
            sql += "from [student], [class], [classassignment] ";
            sql += "where student.id=classassignment.xsbh ";
            sql += "and class.id=classassignment.bjbh ";
            sql += "and class.id=" + cID;
            sql += " order by zf desc";

            List<Entity.Student> students = db.Query<Entity.Student>(sql).ToList<Entity.Student>();

            return students;
        }

        public List<Entity.Student> GetNoClassStudents(string where)
        {
            string sql = "select * from [student] ";
            sql += "where ID not in (select xsbh from classassignment)";

            if(where.Trim() != string.Empty)
            {
                sql += " and " + where;
            }

            List<Entity.Student> students = db.Query<Entity.Student>(sql).ToList<Entity.Student>();

            return students;
        }

        public int AddStudentToClass(Entity.Student s, Entity.Class c)
        {
            string sql = "insert into [classassignment](xsbh, bjbh) values(" + s.ID + ", " + c.ID + ")";

            int ret = db.Execute(sql);

            return ret;
        }

        public int RemoveStudentFromClass(Entity.Student s, Entity.Class c)
        {
            string sql = "delete from [classassignment] where xsbh=" + s.ID + " and bjbh=" + c.ID;

            int ret = db.Execute(sql);

            return ret;
        }

        public void AutoAssign(List<Entity.Student> students, List<Entity.Class> classes, int method)
        {
            // method:
            // 1:平行
            // 2:蛇形平行
            // 3:随机平行


            // 分别查询出男女生
            List<Entity.Student> boys = students.Where(x => x.xb == "男").ToList<Entity.Student>();
            List<Entity.Student> girls = students.Where(x => x.xb == "女").ToList<Entity.Student>();

            // 男女生分别按总分排序
            boys.Sort((x, y) => -x.zf.CompareTo(y.zf));
            girls.Sort((x, y) => -x.zf.CompareTo(y.zf));

            // 根据班级数计算每班最大可能男女生人数
            int boysPerClass = (int)Math.Ceiling(((double)boys.Count) / classes.Count);
            int girlsPerClass = (int)Math.Ceiling(((double)girls.Count) / classes.Count);


            // 分男生
            // 生成班级序列
            List<int> classIdx = GenerateClassRank(classes.Count, boys.Count, method);
            for (int i = 0; i < boys.Count; i++)
            {
                this.AddStudentToClass(boys[i], classes[classIdx[i]]);
            }

            // 分女生
            // 生成班级序列
            classIdx = GenerateClassRank(classes.Count, girls.Count, method);
            for (int i = 0; i < girls.Count; i++)
            {
                this.AddStudentToClass(girls[i], classes[classIdx[i]]);
            }

        }



        public List<int> GenerateClassRank(int numClasses, int numStudents, int method)
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

        public List<int> EqualRank(int numClasses, int numStudents)
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

        public List<int> SnakeRank(int numClasses, int numStudents)
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


        
        public List<int> RandomRank(int numClasses, int numStudents)
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
                db.Execute("delete from [ClassAssignment];", transaction);
                db.Execute("update sqlite_sequence set seq=0 where name='ClassAssignment';", transaction);
                transaction.Commit();
            }
        }
    }
}
