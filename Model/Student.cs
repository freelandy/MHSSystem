using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { set; get; } 

        /// <summary>
        /// 准考证号
        /// </summary>
        public string zkzh { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string xm { set; get; }

        /// <summary>
        /// 报名地州
        /// </summary>
        public string bmdz { set; get; }

        /// <summary>
        /// 报名县市
        /// </summary>
        public string bmxs { set; get; }

        /// <summary>
        /// 报名学校
        /// </summary>
        public string bmxx { set; get; }

        /// <summary>
        /// 报名户口地州
        /// </summary>
        public string bmhkdz { set; get; }

        /// <summary>
        /// 实际生源地州
        /// </summary>
        public string sjsydz { set; get; }

        /// <summary>
        /// 语文成绩
        /// </summary>
        public float ywcj { set; get; }

        /// <summary>
        /// 物理/化学成绩
        /// </summary>
        public float wlhxcj { set; get; }

        /// <summary>
        /// 数学成绩
        /// </summary>
        public float sxcj { set; get; }


        /// <summary>
        /// 道德与法治/历史成绩
        /// </summary>
        public float ddyfzlscj { set; get; }

        /// <summary>
        /// 外语成绩
        /// </summary>
        public float wycj { set; get; }

        /// <summary>
        /// 总成绩
        /// </summary>
        public float zcj { set; get; }

        /// <summary>
        /// 体育成绩
        /// </summary>
        public string tycj { set; get; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string sfzh { set; get; }

        /// <summary>
        /// 学籍号
        /// </summary>
        public string xjh { set; get; }

        /// <summary>
        /// 生源
        /// </summary>
        public string sy { set; get; }

        /// <summary>
        /// 族别
        /// </summary>
        public string zb { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string xb { set; get; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime csrq { set; get; }

        /// <summary>
        /// 班级
        /// </summary>
        public string bj { set; get; }

        /// <summary>
        /// 考生特征
        /// </summary>
        public string kstz { set; get; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string zzmm { set; get; }

        /// <summary>
        /// 户口性质
        /// </summary>
        public string hkxz { set; get; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        public string txdz { set; get; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string lxdh { set; get; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string yzbm { set; get; }

        /// <summary>
        /// 父亲姓名
        /// </summary>
        public string fqxm { set; get; }

        /// <summary>
        /// 父亲身份证号
        /// </summary>
        public string fqsfzh { set; get; }

        /// <summary>
        /// 父亲族别
        /// </summary>
        public string fqzb { set; get; }

        /// <summary>
        /// 父亲户口性质
        /// </summary>
        public string fqhkxz { set; get; }

        /// <summary>
        /// 父亲联系电话
        /// </summary>
        public string fqlxdh { set; get; }

        /// <summary>
        /// 父亲工作单位
        /// </summary>
        public string fqgzdw { set; get; }

        /// <summary>
        /// 母亲姓名
        /// </summary>
        public string mqxm { set; get; }

        /// <summary>
        /// 母亲身份证号
        /// </summary>
        public string mqsfzh { set; get; }

        /// <summary>
        /// 母亲族别
        /// </summary>
        public string mqzb { set; get; }

        /// <summary>
        /// 母亲户口性质
        /// </summary>
        public string mqhkxz { set; get; }

        /// <summary>
        /// 母亲联系电话
        /// </summary>
        public string mqlxdh { set; get; }

        /// <summary>
        /// 母亲工作单位
        /// </summary>
        public string mqgzdw { set; get; }

        /// <summary>
        /// 录取省市
        /// </summary>
        public string lqss { set; get; }

        /// <summary>
        /// 录取学校
        /// </summary>
        public string lqxx { set; get; }

        /// <summary>
        /// 文科/理科
        /// </summary>
        public int sfwk { set; get; }

        /// <summary>
        /// 未报到/已报到
        /// </summary>
        public int sfbd { set; get; }

        /// <summary>
        /// 报到信息导航属性
        /// </summary>
        public Enrollment Enrollment { set; get; }


        /// <summary>
        /// 班级信息导航属性
        /// </summary>
        public Class Class { set; get; }
    }
}
