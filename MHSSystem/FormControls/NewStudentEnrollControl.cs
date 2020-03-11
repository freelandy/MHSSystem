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

namespace MHSSystem.FormControls
{
    public partial class NewStudentEnrollControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly Repository.Student repoNewStudent = new Repository.Student();

        public NewStudentEnrollControl()
        {
            InitializeComponent();
        }

        
        private void NewStudentEnrollControl_Load(object sender, EventArgs e)
        {
            this.layoutControl1.BestFit();


            this.BindStudent();
        }

        private void BindStudent()
        {
            List<Model.Student> students = this.repoNewStudent.GetList();

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
            Model.Student student = (Model.Student)this.gridView1.GetFocusedRow();

            if (student != null)
            {
                this.repoNewStudent.SetAsEnrollment(student.ID, "","");

                this.BindStudent();
            }

            // locate the recorded row
            this.gridView1.TopRowIndex = topRowIdx;

            // select current row
            this.gridView1.SelectRow(focusedRowHandle);
        }

        private void btnDeSetEnrollment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("取消选中学生的已报道状态?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // record top row index
            int topRowIdx = this.gridView1.TopRowIndex;
            int focusedRowHandle = this.gridView1.GetSelectedRows()[0];

            // get data 
            Model.Student student = (Model.Student)this.gridView1.GetFocusedRow();

            if (student != null)
            {
                this.repoNewStudent.SetNotEnrollment(student.ID); 

                this.BindStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", student.ID);
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
            Model.Student student = (Model.Student)this.gridView1.GetFocusedRow();

            if (student != null)
            {
                this.repoNewStudent.SetAsLiberalArts(student.ID); 

                this.BindStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", student.ID);
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
            Model.Student student = (Model.Student)this.gridView1.GetFocusedRow();

            if (student != null)
            {
                this.repoNewStudent.SetAsScience(student.ID); 

                this.BindStudent();

                // locate the modified row
                this.gridView1.FocusedRowHandle = this.gridView1.LocateByValue("ID", student.ID);
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
            Model.Student student = (Model.Student)this.gridView1.GetFocusedRow();

            if (student == null)
            {
                return;
            }

            // set summary fields
            this.txtXm.Text = student.xm;
            this.txtCsrq.Text = student.csrq.ToString("yyyy-MM-dd");
            this.txtSfbd.Text = student.sfbd == 1 ? "是" : "否";
            this.txtSfwk.Text = student.sfwk == 1 ? "文科" : "理科";
            this.txtSfzh.Text = student.sfzh;
            this.txtXb.Text = student.xb;
            this.txtZb.Text = student.zb;
            this.txtZkzh.Text = student.zkzh;


            // set buttons enable/disable
            if (student.sfbd == 1)
            {
                this.btnSetEnrollment.Enabled = false;
                this.btnDeSetEnrollment.Enabled = true;
            }
            else
            {
                this.btnSetEnrollment.Enabled = true;
                this.btnDeSetEnrollment.Enabled = false;
            }

            if (student.sfwk == 1)
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

        private void chkShowNotEnrolled_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // get data 
            List<Model.Student> students = (List<Model.Student>)this.gridControl1.DataSource;

            List<Model.Student> temp = new List<Model.Student>();

            if(students != null)
            {
                if(this.chkShowNotEnrolled.Checked)
                {
                    temp = students.Where<Model.Student>(x => x.sfbd == 0).ToList();
                }
            }
            else
            {
                temp = students;
            }

            this.gridControl1.DataSource = temp;
        }
    }
}
