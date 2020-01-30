using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Enrollment
    {
        public int ID { set; get; }

        public int NewStudentId { set; get; }

        public DateTime EnromentTime { set; get; }

        public string Memo1 { set; get; }

        public string Memo2 { set; get; }
    }
}
