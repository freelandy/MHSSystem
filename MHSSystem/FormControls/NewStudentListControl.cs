using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Repository;

namespace MHSSystem.FormControls
{
    public partial class NewStudentListControl : DevExpress.XtraEditors.XtraUserControl
    {
        
        public NewStudentListControl()
        {
            InitializeComponent();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("导入数据需要几分钟时间，原有数据将被清空。\n是否确认？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            

            // 读取excel，插入数据库，然后再说别的
            Repository.NewStudent repoNewStudent = new NewStudent();

            // 清空原有记录
            repoNewStudent.Clear();

            int cnt = 0;
            DataTable dt = Utils.ExcelHelper.ExcelToDataTableFormPath(this.txtFileName.EditValue.ToString(), true, 1); //学生数据须为第一张sheet
            foreach (DataRow dr in dt.Rows)
            {
                Repository.Entity.NewStudent s = new Repository.Entity.NewStudent();
                s.zkzh = dr["准考证号"] == null ? "" : dr["准考证号"].ToString();
                s.xm = dr["姓名"] == null ? "" : dr["姓名"].ToString();
                s.bmdz = dr["报名地州"] == null ? "" : dr["报名地州"].ToString();
                s.bmxs = dr["报名县市"] == null ? "" : dr["报名县市"].ToString();
                s.bmxx = dr["报名学校"] == null ? "" : dr["报名学校"].ToString();
                s.bmhkdz = dr["报名户口地州"] == null ? "" : dr["报名户口地州"].ToString();
                s.sjsydz = dr["实际生源地州"] == null ? "" : dr["实际生源地州"].ToString();
                s.ywcj = dr["语文成绩"] == null ? 0 : float.Parse(dr["语文成绩"].ToString());
                s.wlhxcj = dr["物理、化学成绩"] == null ? 0 : float.Parse(dr["物理、化学成绩"].ToString());
                s.sxcj = dr["数学成绩"] == null ? 0 : float.Parse(dr["数学成绩"].ToString());
                s.ddyfzlscj = dr["道德与法治、历史成绩"] == null ? 0 : float.Parse(dr["道德与法治、历史成绩"].ToString());
                s.wycj = dr["外语成绩"] == null ? 0 : float.Parse(dr["外语成绩"].ToString());
                s.zcj = dr["总成绩(不加体育)"] == null ? 0 : float.Parse(dr["总成绩(不加体育)"].ToString());
                s.tycj = dr["体育是否合格"] == null ? "" : dr["体育是否合格"].ToString();
                s.sfzh = dr["身份证号"] == null ? "" : dr["身份证号"].ToString();
                s.xjh = dr["学籍号"] == null ? "" : dr["学籍号"].ToString();
                s.sy = dr["生源"] == null ? "" : dr["生源"].ToString();
                s.zb = dr["族别"] == null ? "" : dr["族别"].ToString();
                s.xb = dr["性别"] == null ? "" : dr["性别"].ToString();
                s.csrq = dr["出生日期"] == null ? DateTime.Today : DateTime.Parse(dr["出生日期"].ToString());
                s.bj = dr["班级"] == null ? "" : dr["班级"].ToString();
                s.kstz = dr["考生特征"] == null ? "" : dr["考生特征"].ToString();
                s.zzmm = dr["政治面貌"] == null ? "" : dr["政治面貌"].ToString();
                s.hkxz = dr["户口性质"] == null ? "" : dr["户口性质"].ToString();
                s.txdz = dr["通讯地址"] == null ? "" : dr["通讯地址"].ToString();
                s.lxdh = dr["联系电话"] == null ? "" : dr["联系电话"].ToString();
                s.yzbm = dr["邮政编码"] == null ? "" : dr["邮政编码"].ToString();
                s.fqxm = dr["父亲姓名"] == null ? "" : dr["父亲姓名"].ToString();
                s.fqsfzh = dr["父亲身份证号"] == null ? "" : dr["父亲身份证号"].ToString();
                s.fqzb = dr["父亲族别"] == null ? "" : dr["父亲族别"].ToString();
                s.fqhkxz = dr["父亲户口性质"] == null ? "" : dr["父亲户口性质"].ToString();
                s.fqlxdh = dr["父亲联系电话"] == null ? "" : dr["父亲联系电话"].ToString();
                s.fqgzdw = dr["父亲工作单位"] == null ? "" : dr["父亲工作单位"].ToString();
                s.mqxm = dr["母亲姓名"] == null ? "" : dr["母亲姓名"].ToString();
                s.mqsfzh = dr["母亲身份证号"] == null ? "" : dr["母亲身份证号"].ToString();
                s.mqzb = dr["母亲族别"] == null ? "" : dr["母亲族别"].ToString();
                s.mqhkxz = dr["母亲户口性质"] == null ? "" : dr["母亲户口性质"].ToString();
                s.mqlxdh = dr["母亲联系电话"] == null ? "" : dr["母亲联系电话"].ToString();
                s.mqgzdw = dr["母亲工作单位"] == null ? "" : dr["母亲工作单位"].ToString();
                s.lqss = dr["录取省市"] == null ? "" : dr["录取省市"].ToString();
                s.lqxx = dr["录取学校"] == null ? "" : dr["录取学校"].ToString();
                

                try
                {
                    repoNewStudent.Add(s);
                    cnt++;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("数据导入错误。\n第" + (cnt + 1).ToString() + "行。\n" + ex.Message + "\n请查看出错数据并尝试重新导入。");
                    return;
                }
            }

            XtraMessageBox.Show("导入完成。共导入" + cnt + "条记录。");

            this.BindNewStudent();
        }

        private void BindNewStudent()
        {

            Repository.NewStudent repoNewStudent = new NewStudent();
            List<Repository.Entity.NewStudent> students = repoNewStudent.GetList("");

            this.gridControl1.DataSource = students;
            
            //this.lblTotalStudents.Text = students.Count.ToString();
        }


        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraOpenFileDialog dlg = new XtraOpenFileDialog();
            dlg.Filter = "Excel工作簿(*.xls,*.xlsx)|*.xls;*.xlsx";
            dlg.Multiselect = false;
            dlg.InitialDirectory = Environment.CurrentDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.EditValue = dlg.FileName;
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.BindNewStudent();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void NewStudentListControl_Load(object sender, EventArgs e)
        {
            this.BindNewStudent();
        }
    }
}
