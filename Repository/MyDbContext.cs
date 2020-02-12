using System;
using Repository.Model;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Debug;

namespace Repository
{
    //[DbConfigurationType("Repository.MyDbConfiguration, Repository")] // MyDbConfiguration和MyDbContext在同一程序集中时可以省略
    public class MyDbContext : DbContext
    {
        public static readonly string dbFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, "db.db");

        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

 
        public MyDbContext() :base("Conn") 
        /*
        public MyDbContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = dbFilePath
            }.ConnectionString
        }, true)
        */
        { }

        public DbSet<Model.NewStudent> NewStudent { set; get; } //属性名必须与数据库表名相同，除非在实体类上用[Table("")]标记
        public DbSet<Model.Enrollment> Enrollment { set; get; }
        public DbSet<Model.Class> Class { set; get; }
        public DbSet<Model.ClassAssignment> ClassAssignment { set; get; }
        public DbSet<Model.Teacher> Teacher { set; get; }
        public DbSet<Model.ClassType> ClassType { set; get; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //非常重要！否则会按照实体类名NewStudent去找NewStudents表（在不进行配置的情况下）

            modelBuilder.Entity<Model.NewStudent>().ToTable("NewStudent"); //设置实体类对应的表名
            modelBuilder.Entity<Model.NewStudent>().Ignore(x => x.Enrollment); //设置Enrollment属性不映射到数据库中
            modelBuilder.Entity<Model.NewStudent>().Ignore(x => x.Class);

            // Map one-to-zero or one relationship
            modelBuilder.Entity<Model.Enrollment>().HasRequired(x => x.NewStudent).WithOptional(x => x.Enrollment); // 一个NewStudent可以有一个或没有Enrollment
            // Map one - to - many relationship
            //modelBuilder.Entity<Model.NewStudent>().HasMany(x => x.Class).WithOptional(x => x.Enrollment); // 一个NewStudent可以有一个或没有Enrollment

        }

    }
}
