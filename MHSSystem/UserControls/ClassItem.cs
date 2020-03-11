using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MHSSystem.UserControls
{
    public partial class ClassItem : XtraUserControl
    {
        public List<Model.ClassType> ClassTypes { set; get; }
        public int Order { set; get; }
        public int ClassTypeId
        {
            set
            {

            }
            get
            {
                return int.Parse(this.lookupClassType.EditValue.ToString());
            }
        }
        public string ClassTypeName 
        {
            set
            {
                
            }
            get
            {
                return this.lookupClassType.Text;
            }
        }

        public int IsLiberalArts
        {
            get
            {
                return ((Model.ClassType)this.lookupClassType.GetSelectedDataRow()).IsLiberalArts;
            }
        }
        public int ClassNum
        {
            set
            {
                int.TryParse(value.ToString(), out int i);
                this.txtClassNum.Text = i.ToString();
            }
            get
            {
                int.TryParse(this.txtClassNum.Text, out int i);
                return i;
            }
        }
        public int StudentNumPerClass
        {
            set
            {
                int.TryParse(value.ToString(), out int i);
                this.txtStudentNumPerClass.Text = i.ToString();
            }
            get
            {
                int.TryParse(this.txtStudentNumPerClass.Text, out int i);
                return i;
            }
        }
        public int StartScore
        {
            set
            {
                int.TryParse(value.ToString(), out int i);
                this.txtStartScore.Text = i.ToString();
            }
            get
            {
                int.TryParse(this.txtStartScore.Text, out int i);
                return i;
            }
        }
        public int EndScore
        {
            set
            {
                int.TryParse(value.ToString(), out int i);
                this.txtEndScore.Text = i.ToString();
            }
            get
            {
                int.TryParse(this.txtEndScore.Text, out int i);
                return i;
            }
        }

        public ClassItem()
        {
            InitializeComponent();
        }

        private void ClassItem_Load(object sender, EventArgs e)
        {

        }


        public void BindClassType()
        {
            this.lookupClassType.Properties.DataSource = this.ClassTypes;
            this.lookupClassType.Properties.DisplayMember = "ClassTypeName";
            this.lookupClassType.Properties.ValueMember = "ID";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MHSSystem.FormControls.NewStudentAssignClassControl parent = this.Parent.Parent as MHSSystem.FormControls.NewStudentAssignClassControl;

            parent.RemoveClassItem(this.Order);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MHSSystem.FormControls.NewStudentAssignClassControl parent = this.Parent.Parent as MHSSystem.FormControls.NewStudentAssignClassControl;

            parent.MoveUp(this);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MHSSystem.FormControls.NewStudentAssignClassControl parent = this.Parent.Parent as MHSSystem.FormControls.NewStudentAssignClassControl;

            parent.MoveDown(this);
        }

        private void txtStudentNumPerClass_EditValueChanged(object sender, EventArgs e)
        {
            //计算结束排名
            if (this.ClassNum != 0 && this.StartScore != 0 && this.StudentNumPerClass != 0)
            {
                this.txtEndScore.EditValue = this.StartScore + this.ClassNum * this.StudentNumPerClass - 1;
            }
        }

        private void txtStartScore_EditValueChanged(object sender, EventArgs e)
        {
            //计算结束排名
            if (this.ClassNum != 0 && this.StartScore != 0 && this.StudentNumPerClass != 0)
            {
                this.txtEndScore.EditValue = this.StartScore + this.ClassNum * this.StudentNumPerClass - 1;
            }
        }

        private void txtClassNum_EditValueChanged(object sender, EventArgs e)
        {
            //计算结束排名
            if (this.ClassNum != 0 && this.StartScore != 0 && this.StudentNumPerClass != 0)
            {
                this.txtEndScore.EditValue = this.StartScore + this.ClassNum * this.StudentNumPerClass - 1;
            }
        }

        private void lookupClassType_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            if (e.Column.Equals(this.lookupClassType.Properties.Columns["IsLiberalArts"]))
            {
                e.DisplayText = e.DisplayText == "1" ? "文科" : "理科";
            }
        }
    }
}
