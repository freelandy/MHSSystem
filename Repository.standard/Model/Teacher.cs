using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    public class Teacher
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("ID")]
        [Key]
        public int TeacherId { set; get; }

        /// <summary>
        /// 教师工号
        /// </summary>
        public string TeacherSerialNo { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { set; get; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { set; get; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { set; get; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 职称
        /// </summary>
        public string ProfessionalTitle { set; get; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int Deleted { set; get; }
    }
}
