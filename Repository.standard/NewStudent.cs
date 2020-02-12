using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class NewStudent
    {
        private readonly MyDbContext dbContext = new MyDbContext();

        public NewStudent()
        {
            //Batteries.Init();
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
            try
            {
                IQueryable<Model.NewStudent> quary = this.dbContext.Set<Model.NewStudent>().AsNoTracking();

                
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
            catch (Exception ex)
            {
                // write log file

                //return null;
                throw (ex);
            }                        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Add(Model.NewStudent newStudent)
        {
            try
            {
                this.dbContext.Set<Model.NewStudent>().Add(newStudent);
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Update(Model.NewStudent newStudent)
        {
            try
            {
                this.dbContext.Set<Model.NewStudent>().Update(newStudent);
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
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
            try
            {
                this.dbContext.Set<Model.NewStudent>().Remove(newStudent);
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
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
            try
            {
                this.dbContext.Set<Model.Enrollment>().Add(enrollment);
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsNotEnroll(Model.NewStudent newStudent)
        {
            try
            {
                Model.Enrollment enrollment = this.dbContext.Set<Model.Enrollment>().Single(x => x.EnrollmentId == newStudent.NewStudentId);

                if (enrollment != null)
                {
                    this.dbContext.Set<Model.Enrollment>().Remove(enrollment);
                    this.dbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsLiberalArts(Model.NewStudent newStudent)
        {
            try
            {
                newStudent.sfwk = 1;
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void SetAsScience(Model.NewStudent newStudent)
        {
            try
            {
                newStudent.sfwk = 0;
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool IsEnroll(Model.NewStudent newStudent)
        {
            return newStudent.Enrollment != null;
        }

        public void Clear()
        {
            using (var transaction = this.dbContext.Database.BeginTransaction())
            {
                try
                {
                    this.dbContext.Set<Model.NewStudent>().FromSqlRaw("delete from [NewStudent];");
                    this.dbContext.Set<Model.NewStudent>().FromSqlRaw("update sqlite_sequence set seq=0 where name='NewStudent';");
                    this.dbContext.Set<Model.NewStudent>().FromSqlRaw("delete from [ClassAssignment];");
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
            }
        }
    }
}
