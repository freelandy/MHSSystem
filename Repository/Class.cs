using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Model;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Repository
{
    public class Class
    {
        private readonly MyDbContext dbContext = new MyDbContext();

        public Class()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderExp"></param>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Model.Class> GetList(Expression<Func<Model.Class, dynamic>> orderExp = null, Expression<Func<Model.Class, bool>> predicate = null, string orderBy = "asc")
        {
            try
            {
                IQueryable<Model.Class> quary = this.dbContext.Set<Model.Class>().AsNoTracking();

                quary = quary.Include(x => x.ClassType);
                quary = quary.Include(x => x.HeadTeacher);

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
        /// <param name="cls"></param>
        public void Add(Model.Class cls)
        {
            try
            {
                this.dbContext.Set<Model.Class>().Add(cls);
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
        /// <param name="cls"></param>
        public void Update(Model.Class cls)
        {
            try
            {
                //this.dbContext.Set<Model.Class>().Update(cls);
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
        /// <param name="cls"></param>
        public void Delete(Model.Class cls)
        {
            try
            {
                this.dbContext.Set<Model.Class>().Remove(cls);
                this.dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
