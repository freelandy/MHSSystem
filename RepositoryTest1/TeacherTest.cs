using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class TeacherTest
    {
        public TeacherTest()
        {
        }



        


        [TestMethod]
        public void TestAdd()
        {
            Repository.Teacher repo = new Repository.Teacher();

            RandomNameGeneratorLibrary.PersonNameGenerator personNameGenerator = new RandomNameGeneratorLibrary.PersonNameGenerator();
            


            for(int i=0;i<100;i++)
            {
                Repository.Model.Teacher t = new Repository.Model.Teacher();

                Random r = new Random();
                int a = r.Next(0, 2);

                if (a == 0)
                {
                    t.TeacherName = personNameGenerator.GenerateRandomFemaleFirstAndLastName();
                    t.Gender = "女";
                }
                else
                {
                    t.TeacherName = personNameGenerator.GenerateRandomMaleFirstAndLastName();
                    t.Gender = "男";
                }

                repo.Add(t);
            }


            List<Repository.Model.Teacher> teachers = repo.GetList();

            foreach(Repository.Model.Teacher t in teachers)
            {
                Console.WriteLine(t.TeacherName);
            }
        }


        
    }
}
