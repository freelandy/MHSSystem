using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        { 
            Repository.NewStudent repo = new Repository.NewStudent();

            List<Repository.Model.NewStudent> newStudents = repo.GetList();


            Console.WriteLine(newStudents[0].Enrollment.EnrollmentTime);
            
        }


        [TestMethod]
        public void TestSetEnrollment()
        {
            Repository.NewStudent repo = new Repository.NewStudent();
            List<Repository.Model.NewStudent> newStudents = repo.GetList();

            foreach(Repository.Model.NewStudent s in newStudents)
            {
                Console.WriteLine(repo.IsEnroll(s));
            }

            //foreach(Repository.Model.NewStudent s in newStudents)
            //{
            //    Repository.Model.Enrollment e = new Repository.Model.Enrollment();
            //    e.EnrollmentTime = DateTime.Now;
            //    e.Memo1 = s.GetHashCode().ToString();

            //    repo.SetAsEnroll(s, e);

            //    Console.WriteLine(repo.IsEnroll(s));
            //}
        }

        [TestMethod]
        public void TestSetLiberalArts()
        {
            Repository.NewStudent repo = new Repository.NewStudent();
            List<Repository.Model.NewStudent> newStudents = repo.GetList();

            foreach (Repository.Model.NewStudent s in newStudents)
            {
                repo.SetAsLiberalArts(s);
            }

            foreach (Repository.Model.NewStudent s in newStudents)
            {
                Console.WriteLine(s.sfwk);
            }
        }
    }
}
