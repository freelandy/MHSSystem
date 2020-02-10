using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Debug;

namespace ConsoleApp2
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static readonly string dbFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, "db.db");

        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        ///// <summary>
        ///// 外部参数
        ///// </summary>
        ///// <param name="options">外部传入的配置参数（这样子的话，我们就可以通过外部来控制传入的参数值，用以决定使用哪个数据库）</param>
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        //{

        //}
        public MyDbContext() { }

        public DbSet<NewStudent> NewStudent { set; get; } //属性名必须与数据库表名相同，除非在实体类上用[Table("")]标记

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dbFilePath);
            //optionsBuilder.UseSqlite("Filename=db.db");
            /*            
            #pragma warning disable CS0612 // 类型或成员已过时
                        optionsBuilder.UseLoggerFactory(LoggerFactory);
            #pragma warning restore CS0612 // 类型或成员已过时
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
