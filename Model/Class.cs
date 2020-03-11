using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Class
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { set; get; }

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
    }
}
