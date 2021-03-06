﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        [Column("ID")]
        public int EnrollmentId { set; get; }

        public int NewStudentId { set; get; } 
     
        public DateTime EnrollmentTime { set; get; }

        public string Memo1 { set; get; }

        public string Memo2 { set; get; }

        public NewStudent NewStudent { set; get; }
    }
}
