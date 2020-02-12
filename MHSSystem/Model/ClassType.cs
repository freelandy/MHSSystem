using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHSSystem.Model
{
    public class ClassType
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("ID")]
        [Key]
        public int ClassTypeId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassTypeName { set; get; }
    }
}
