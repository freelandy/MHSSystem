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
            if (MessageBox.Show("导入数据需要几分钟时间，原有数据将被清空。\n是否确认？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 读取excel，插入数据库，然后再说别的
            Repository.NewStudent repoStudent = new NewStudent();

            // 清空原有记录
            repoStudent.Clear();

            int cnt = 0;
            DataTable dt = ExcelHelper.ExcelToDataTableFormPath(this.txtFileName.Text, true, 0); //学生数据须为第一张sheet
            foreach (DataRow dr in dt.Rows)
            {
                Repository.Entity.Student s = new Repository.Entity.Student();
                s.bddd = dr["bddd"] == null ? "" : dr["bddd"].ToString();
                s.bdrq = dr["bdrq"] == null ? DateTime.Today : DateTime.Parse(dr["bdrq"].ToString());
                s.csrq = dr["csrq"] == null ? DateTime.Today : DateTime.Parse(dr["csrq"].ToString());
                s.czbyxx = dr["czbyxx"] == null ? "" : dr["czbyxx"].ToString();
                s.dq = dr["dq"] == null ? "" : dr["dq"].ToString();
                s.fqxm = dr["fqxm"] == null ? "" : dr["fqxm"].ToString();
                s.gzlqsj = dr["gzlqsj"] == null ? DateTime.Today : DateTime.Parse(dr["gzlqsj"].ToString());
                s.gzlqxxdm = dr["gzlqxxdm"] == null ? "" : dr["gzlqxxdm"].ToString();
                s.gzlqxx = dr["gzlqxx"] == null ? "" : dr["gzlqxx"].ToString();
                s.hkxz = dr["hkxz"] == null ? "" : dr["hkxz"].ToString();
                s.hx = dr["hx"] == null ? 0 : float.Parse(dr["hx"].ToString());
                s.jtcs = dr["jtcs"] == null ? "" : dr["jtcs"].ToString();
                s.kslb = dr["kslb"] == null ? "" : dr["kslb"].ToString();
                s.kstz = dr["kstz"] == null ? "" : dr["kstz"].ToString();
                s.ksyz = dr["ksyz"] == null ? "" : dr["ksyz"].ToString();
                s.ksztdm = dr["ksztdm"] == null ? "" : dr["ksztdm"].ToString();
                s.lxdh = dr["lxdh"] == null ? "" : dr["lxdh"].ToString();
                s.mqxm = dr["mqxm"] == null ? "" : dr["mqxm"].ToString();
                s.mz = dr["mz"] == null ? "" : dr["mz"].ToString();
                //s.sfbd = dr["sfbd"] == null ? "" : dr["sfbd"].ToString();
                //s.sfwk = dr["sfwk"] == null ? "" : dr["sfwk"].ToString();
                s.sfzh = dr["sfzh"] == null ? "" : dr["sfzh"].ToString();
                s.sx = dr["sx"] == null ? 0 : float.Parse(dr["sx"].ToString());
                s.txdz = dr["txdz"] == null ? "" : dr["txdz"].ToString();
                s.tzf = dr["tzf"] == null ? 0 : float.Parse(dr["tzf"].ToString());
                s.wl = dr["wl"] == null ? 0 : float.Parse(dr["wl"].ToString());
                s.wy = dr["wy"] == null ? 0 : float.Parse(dr["wy"].ToString());
                s.xb = dr["xb"] == null ? "" : dr["xb"].ToString();
                s.xjh = dr["xjh"] == null ? "" : dr["xjh"].ToString();
                s.xm = dr["xm"] == null ? "" : dr["xm"].ToString();
                s.xq = dr["xq"] == null ? "" : dr["xq"].ToString();
                s.yw = dr["yw"] == null ? 0 : float.Parse(dr["yw"].ToString());
                s.yzbm = dr["yzbm"] == null ? "" : dr["yzbm"].ToString();
                s.zf = dr["zf"] == null ? 0 : float.Parse(dr["zf"].ToString());
                s.zkksh = dr["zkksh"] == null ? "" : dr["zkksh"].ToString();
                s.zz = dr["zz"] == null ? 0 : float.Parse(dr["zz"].ToString());
                s.zzmm = dr["zzmm"] == null ? "" : dr["zzmm"].ToString();

                try
                {
                    repoStudent.Add(s);
                    cnt++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据导入错误。\n第" + (cnt + 1).ToString() + "行。\n" + ex.Message + "\n请查看出错数据并尝试重新导入。");
                    return;
                }
            }

            MessageBox.Show("导入完成。共导入" + cnt + "条记录。");

            //this.BindStudent();
            //this.lblTotalStudents.Text = ((List<Repository.Entity.Student>)this.dgStudent.DataSource).Count.ToString();
        }
    }
}
