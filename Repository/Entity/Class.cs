using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Class
    {
        public int ID { set; get; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string bjmc { set; get; }

        /// <summary>
        /// 班主任姓名
        /// </summary>
        public string bzrxm { set; get; }

        /// <summary>
        /// 班级类别
        /// </summary>
        public string bjlb { set; get; }
    }
}
