using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHSSystem.UserControls
{
    public class ClassAssignmentItem
    {
        public int Order { set; get; }
        public int ClassTypeId { set; get; }
        public string ClassTypeName { set; get; }
        public int ClassNum { set; get; }
        public int StudentNumPerClass { set; get; }
        public int StartScore { set; get; }
        public int EndScore { set; get; }
    }
}
