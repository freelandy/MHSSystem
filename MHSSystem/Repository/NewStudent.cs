using System;
using System.Collections.Generic;
using System.Linq;
using MHSSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace MHSSystem.Repository
{
    public class NewStudent
    {
        // private readonly MyDbContext dbContext = new MyDbContext();

        public NewStudent()
        {

        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderExp">排序条件</param>
        /// <param name="expression">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="includes">关联表</param>
        /// <returns></returns>
        public List<Model.NewStudent> GetList(Expression<Func<Model.NewStudent, dynamic>> orderExp = null, Expression<Func<Model.NewStudent, bool>> predicate = null, string orderBy = "asc" , string[] includes = null)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                IQueryable<Model.NewStudent> quary = dbContext.Set<Model.NewStudent>().AsNoTracking();


                if (includes != null && includes.Any())
                {
                    foreach (var include in includes)
                    {
                        quary = quary.Include(include);
                    }
                }



                if (predicate != null)
                {
                    quary = quary.Where(predicate);
                }

                if (orderExp != null)
                {
                    quary = orderBy == "desc" ? quary.OrderByDescending(orderExp) : quary.OrderBy(orderExp);
                }

                return quary.ToList();


            }                      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Add(Model.NewStudent newStudent)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Set<Model.NewStudent>().Add(newStudent);
                int flag = dbContext.SaveChanges();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Update(Model.NewStudent newStudent)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Set<Model.NewStudent>().Update(newStudent);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Delete(Model.NewStudent newStudent)
        {
            //1. 删除student
            //2. 删除报到信息
            using (MyDbContext dbContext = new MyDbContext())
            {
                dbContext.Set<Model.NewStudent>().Remove(newStudent);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        /// <param name="enrollment"></param>
        public void SetAsEnroll(Model.NewStudent newStudent, Model.Enrollment enrollment)
        {
            enrollment.NewStudentId = newStudent.NewStudentId;
            enrollment.EnrollmentTime = DateTime.Now;
            newStudent.sfbd = 1;

            using (MyDbContext dbContext = new MyDbContext())
            {
                using (IDbContextTransaction trans = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Set<Model.Enrollment>().Add(enrollment);
                        dbContext.Set<Model.NewStudent>().Update(newStudent);
                        dbContext.SaveChanges();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsNotEnroll(Model.NewStudent newStudent)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Model.Enrollment enrollment = dbContext.Set<Model.Enrollment>().Single(x => x.EnrollmentId == newStudent.NewStudentId);

                if (enrollment != null)
                {
                    dbContext.Set<Model.Enrollment>().Remove(enrollment);
                    dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsLiberalArts(Model.NewStudent newStudent)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                newStudent.sfwk = 1;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsScience(Model.NewStudent newStudent)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                newStudent.sfwk = 0;
                dbContext.SaveChanges();
            }
        }

        public bool IsEnroll(Model.NewStudent newStudent)
        {
            return newStudent.Enrollment != null;
        }

        public void Clear()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                using (IDbContextTransaction trans = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Database.ExecuteSqlRaw("delete from NewStudent");
                        dbContext.Database.ExecuteSqlRaw("update sqlite_sequence set seq=0 where name='NewStudent'");
                        dbContext.Database.ExecuteSqlRaw("delete from Enrollment");
                        dbContext.Database.ExecuteSqlRaw("update sqlite_sequence set seq=0 where name='Enrollment'");

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }
    }
}
