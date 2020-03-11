using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enrollment
    {
        public int ID { set; get; }

        public int StudentId { set; get; } 

        public DateTime EnrollmentTime { set; get; }

        public string Memo1 { set; get; }

        public string Memo2 { set; get; }
    }
}
