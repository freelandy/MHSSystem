using System;
using System.Collections.Generic;
using System.Linq;
using MHSSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MHSSystem.Repository
{
    public class Teacher
    {
        private readonly MyDbContext dbContext = new MyDbContext();

        public Teacher()
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
        public List<Model.Teacher> GetList(Expression<Func<Model.Teacher, dynamic>> orderExp = null, Expression<Func<Model.Teacher, bool>> predicate = null, string orderBy = "asc", string[] includes = null)
        {
            try
            {
                IQueryable<Model.Teacher> quary = this.dbContext.Set<Model.Teacher>().AsNoTracking();


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

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        public void Add(Model.Teacher teacher)
        {
            try
            {
                this.dbContext.Set<Model.Teacher>().Add(teacher);
                this.dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        public void Update(Model.Teacher teacher)
        {
            try
            {
                this.dbContext.Set<Model.Teacher>().Update(teacher);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 删除记录，并非真正删除
        /// </summary>
        /// <param name="teacher"></param>
        public void Delete(Model.Teacher teacher)
        {
            try
            {
                teacher.Deleted = 1;
                this.dbContext.Set<Model.Teacher>().Update(teacher);
                this.dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 撤销删除
        /// </summary>
        /// <param name="teacher"></param>
        public void UnDelete(Model.Teacher teacher)
        {
            try
            {
                teacher.Deleted = 0;
                this.dbContext.Set<Model.Teacher>().Update(teacher);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
