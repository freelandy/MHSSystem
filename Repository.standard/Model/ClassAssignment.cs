using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    public class ClassAssignment
    {
        [Key]
        [Column("ClassAssignment")]
        public int ClassAssignmentId { set; get; }

        public int NewStudentId { set; get; }

        public int ClassId { set; get; }
    }
}
