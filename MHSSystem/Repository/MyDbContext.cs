using System;
using MHSSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace MHSSystem.Repository
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        ///// <summary>
        ///// 外部参数
        ///// </summary>
        ///// <param name="options">外部传入的配置参数（这样子的话，我们就可以通过外部来控制传入的参数值，用以决定使用哪个数据库）</param>
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        //{

        //}


        public MyDbContext() { }

        public DbSet<Model.NewStudent> NewStudent { set; get; } //属性名必须与数据库表名相同，除非在实体类上用[Table("")]标记
        public DbSet<Model.Enrollment> Enrollment { set; get; }
        public DbSet<Model.Class> Class { set; get; }
        public DbSet<Model.StudentClass> StudentClass { set; get; }
        public DbSet<Model.Teacher> Teacher { set; get; }
        public DbSet<Model.ClassType> ClassType { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=db.db");
            optionsBuilder.EnableSensitiveDataLogging();
            
            
#pragma warning disable CS0612 // 类型或成员已过时
            optionsBuilder.UseLoggerFactory(LoggerFactory);
#pragma warning restore CS0612 // 类型或成员已过时

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 1-1 relation
            //modelBuilder.Entity<Model.NewStudent>().HasKey(n => n.NewStudentId);
            //modelBuilder.Entity<Model.NewStudent>().Property(n => n.NewStudentId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Model.NewStudent>() // begin to configure NewStudent
                .HasOne<Model.Enrollment>(n => n.Enrollment) // each NewStudent Has One Enrollment
                .WithOne(en => en.NewStudent) // another end (Enrollment) Has One NewStudent
                .HasForeignKey<Model.Enrollment>(en => en.NewStudentId);

            // n-n relation
            //modelBuilder.Entity<Model.StudentClass>().HasKey(sc => sc.StudentClassId);
            //modelBuilder.Entity<Model.StudentClass>().Property(sc => sc.StudentClassId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Model.StudentClass>()
                .HasOne<Model.NewStudent>(sc => sc.NewStudent)
                .WithMany(n => n.StudentClasses)
                .HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<Model.StudentClass>()
                .HasOne<Model.Class>(sc => sc.Class)
                .WithMany(c => c.StudentClasses)
                .HasForeignKey(sc => sc.ClassId);

            

        }

    }
}
