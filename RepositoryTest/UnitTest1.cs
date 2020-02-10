using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepositoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Repository.NewStudent repo = new Repository.NewStudent();

            List<Repository.Model.NewStudent> list = repo.GetList();

            foreach(Repository.Model.NewStudent s in list)
            {
                Console.WriteLine(s.xm);
            }
        }
    }
}
