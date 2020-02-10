using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository.NewStudent repo = new Repository.NewStudent();

            List<Repository.Model.NewStudent> list = repo.GetList();

            foreach (Repository.Model.NewStudent s in list)
            {
                Console.WriteLine(s.xm);
            }

            Console.ReadKey();
        }
    }
}
