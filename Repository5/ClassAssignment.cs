using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class ClassAssignment
    {
        private readonly MyDbContext dbContext = new MyDbContext();

        public ClassAssignment()
        {
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        public void AddStudentToClass(Model.NewStudent s, Model.Class c)
        {
            Model.ClassAssignment assignment = new Model.ClassAssignment();
            assignment.ClassId = c.ClassId;
            assignment.NewStudentId = s.NewStudentId;

            try
            {
                this.dbContext.Set<Model.ClassAssignment>().Add(assignment);
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
        /// <param name="s"></param>
        /// <param name="c"></param>
        public void RemoveStudentFromClass(Model.NewStudent s, Model.Class c)
        {
            try
            {
                Model.ClassAssignment assignment = this.dbContext.Set<Model.ClassAssignment>().Single(x => x.ClassId == c.ClassId && x.NewStudentId == s.NewStudentId);
                this.dbContext.Set<Model.ClassAssignment>().Remove(assignment);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



        public void ChangeStudentClass(Model.NewStudent s, Model.Class newClass, Model.Class oldClass)
        {
            try
            {
                Model.ClassAssignment assignment = this.dbContext.Set<Model.ClassAssignment>().Single(x => x.ClassId == oldClass.ClassId && x.NewStudentId == s.NewStudentId);
                assignment.ClassId = newClass.ClassId;                
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
