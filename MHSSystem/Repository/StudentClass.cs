using System;
using System.Collections.Generic;
using System.Linq;
using MHSSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MHSSystem.Repository
{
    public class StudentClass
    {
        private readonly MyDbContext dbContext = new MyDbContext();

        public StudentClass()
        {
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        public void AddStudentToClass(Model.NewStudent s, Model.Class c)
        {
            Model.StudentClass studentClass = new Model.StudentClass();
            studentClass.ClassId = c.ClassId;
            studentClass.StudentId = s.NewStudentId;

            try
            {
                this.dbContext.Set<Model.StudentClass>().Add(studentClass);
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
                Model.StudentClass studentClass = this.dbContext.Set<Model.StudentClass>().Single(x => x.ClassId == c.ClassId && x.StudentId == s.NewStudentId);
                this.dbContext.Set<Model.StudentClass>().Remove(studentClass);
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
                Model.StudentClass studentClass = this.dbContext.Set<Model.StudentClass>().Single(x => x.ClassId == oldClass.ClassId && x.StudentId == s.NewStudentId);
                studentClass.ClassId = newClass.ClassId;                
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
