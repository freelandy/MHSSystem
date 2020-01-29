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
using Emgu;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Repository;

namespace MHSSystem.FormControls
{
    public partial class NewStudentEnrollControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly Repository.NewStudent repoNewStudent = new NewStudent();

        public NewStudentEnrollControl()
        {
            InitializeComponent();
        }

        private void NewStudentEnrollControl_Load(object sender, EventArgs e)
        {
            this.layoutControl1.BestFit();


            this.BindNewStudent();
        }

        private void BindNewStudent()
        {

            Repository.NewStudent repoNewStudent = new NewStudent();
            List<Repository.Entity.NewStudent> students = repoNewStudent.GetList("");

            this.gridControl1.DataSource = students;

            //this.lblTotalStudents.Text = students.Count.ToString();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnSetEnrollment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.SetEnrollment(newStudent.ID, 1); // 1 would be enrollment

                this.BindNewStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", newStudent.ID);
            }
        }

        private void btnDeSetEnrollment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("取消选中学生的已报道状态?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.SetEnrollment(newStudent.ID, 0); // 0 would be enrollment

                this.BindNewStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", newStudent.ID);
            }
        }
    }
}
