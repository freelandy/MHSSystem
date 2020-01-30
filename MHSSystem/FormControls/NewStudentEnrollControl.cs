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
            // record top row index
            int topRowIdx = this.gridView1.TopRowIndex;
            int focusedRowHandle = this.gridView1.GetSelectedRows()[0];

            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.SetEnrollment(newStudent.ID, DateTime.Now.ToString()); 

                this.BindNewStudent();
            }

            // locate the recorded row
            this.gridView1.TopRowIndex = topRowIdx;

            // select current row
            this.gridView1.SelectRow(focusedRowHandle);
        }

        private void btnDeSetEnrollment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("取消选中学生的已报道状态?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // record top row index
            int topRowIdx = this.gridView1.TopRowIndex;
            int focusedRowHandle = this.gridView1.GetSelectedRows()[0];

            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.DeSetEnrollment(newStudent.ID); // false would be enrollment

                this.BindNewStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", newStudent.ID);
            }

            // locate the recorded row
            this.gridView1.TopRowIndex = topRowIdx;

            // select current row
            this.gridView1.SelectRow(focusedRowHandle);
        }

        private void btnSetLiberalArts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // record top row index
            int topRowIdx = this.gridView1.TopRowIndex;
            int focusedRowHandle = this.gridView1.GetSelectedRows()[0];

            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.SetLiberalArts(newStudent.ID, true); // true would be liberal arts

                this.BindNewStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", newStudent.ID);
            }

            // locate the recorded row
            this.gridView1.TopRowIndex = topRowIdx;

            // select current row
            this.gridView1.SelectRow(focusedRowHandle);
        }

        private void btnSetScience_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // record top row index
            int topRowIdx = this.gridView1.TopRowIndex;
            int focusedRowHandle = this.gridView1.GetSelectedRows()[0];

            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent != null)
            {
                this.repoNewStudent.SetLiberalArts(newStudent.ID, false); // false would be science

                this.BindNewStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", newStudent.ID);
            }

            // locate the recorded row
            this.gridView1.TopRowIndex = topRowIdx;

            // select current row
            this.gridView1.SelectRow(focusedRowHandle);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Equals(this.sfbd))
            {
                e.DisplayText = e.CellValue.ToString() == "1" ? "是" : "否";
            }

            if (e.Column.Equals(this.sfwk))
            {
                e.DisplayText = e.CellValue.ToString() == "1" ? "文科" : "理科";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // get data 
            Repository.Entity.NewStudent newStudent = (Repository.Entity.NewStudent)this.gridView1.GetFocusedRow();

            if (newStudent == null)
            {
                return;
            }

            // set summary fields
            this.txtXm.Text = newStudent.xm;
            this.txtCsrq.Text = newStudent.csrq.ToString("yyyy-MM-dd");
            this.txtBdsj.Text = newStudent.sfbd == 1 ? "是" : "否";
            this.txtSfwk.Text = newStudent.sfwk == 1 ? "文科" : "理科";
            this.txtSfzh.Text = newStudent.sfzh;
            this.txtXb.Text = newStudent.xb;
            this.txtZb.Text = newStudent.zb;
            this.txtZkzh.Text = newStudent.zkzh;


            // set buttons enable/disable
            if (newStudent.sfbd == 1)
            {
                this.btnSetEnrollment.Enabled = false;
                this.btnDeSetEnrollment.Enabled = true;
            }
            else
            {
                this.btnSetEnrollment.Enabled = true;
                this.btnDeSetEnrollment.Enabled = false;
            }

            if (newStudent.sfwk == 1)
            {
                this.btnSetLiberalArts.Enabled = false;
                this.btnSetScience.Enabled = true;
            }
            else
            {
                this.btnSetLiberalArts.Enabled = true;
                this.btnSetScience.Enabled = false;
            }

            // set photo
        }
    }
}
