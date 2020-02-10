using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext dbContext = new MyDbContext();
            IQueryable<NewStudent> quary = dbContext.Set<NewStudent>().AsNoTracking();


            List<NewStudent> list = quary.ToList();

            foreach(NewStudent s in list)
            {
                Console.WriteLine(s.xm);
            }

            Console.ReadKey();

        }
    }
}
