using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHSSystem.Model
{
    public class StudentClass
    {
        [Key]
        [Column("ID")]
        public int StudentClassId { set; get; }

        public int StudentId { set; get; }

        public NewStudent NewStudent { set; get; }
        public int ClassId { set; get; }

        public Class Class { set; get; }

    }
}
