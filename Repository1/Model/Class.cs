﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    public class Class
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("ID")]
        [Key]
        public int ClassId { set; get; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { set; get; }

        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { set; get; }

        /// <summary>
        /// 班级类别ID
        /// </summary>
        public int ClassTypeId { set; get; }

        /// <summary>
        /// 班主任ID
        /// </summary>
        public int HeadTeacherId { set; get; }

        /// <summary>
        /// 班级类型导航属性
        /// </summary>
        public ClassType ClassType { set; get; }

        /// <summary>
        /// 班主任导航属性
        /// </summary>
        public Teacher HeadTeacher { set; get; }
    }
}
