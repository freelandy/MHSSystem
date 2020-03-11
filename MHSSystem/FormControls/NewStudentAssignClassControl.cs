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
using DevExpress.XtraLayout;

namespace MHSSystem.FormControls
{
    public partial class NewStudentAssignClassControl : DevExpress.XtraEditors.XtraUserControl
    {
        // repos
        private readonly Repository.ClassType repoClassType = new Repository.ClassType();
        private readonly Repository.Student repoStudent = new Repository.Student();
        private readonly Repository.StudentClass repoStudentClass = new Repository.StudentClass();
        private readonly Repository.Class repoClass = new Repository.Class();

        // class types to add
        private List<Model.ClassType> classTypes = new List<Model.ClassType>();
        private List<UserControls.ClassItem> items = new List<UserControls.ClassItem>();
        private int itemCount = 0;
        public NewStudentAssignClassControl()
        {
            InitializeComponent();
        }


        private void btnAddClass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(this.classTypes == null || this.classTypes.Count == 0) // 没有待添加的班级类型就什么都不做
            {
                return;
            }

            UserControls.ClassItem item = new UserControls.ClassItem();
            item.Name = "classItem" + this.itemCount;
            item.Order = this.itemCount;
            // 设置待添加的班级类型
            item.ClassTypes = this.classTypes;
            item.BindClassType();
            //this.classTypes.RemoveAt(0); //从头开始添加
            // 计算起始排名，简单起见，从上一个的结束开始
            //item.StartScore = this.itemCount + 1;//不要贱嗖嗖的替别人做事
            

            RowDefinition row = this.layoutControlGroup2.OptionsTableLayoutGroup.AddRow();
            row.SizeType = SizeType.Absolute;
            row.Height = 30;
            //row.SizeType = SizeType.AutoSize;

            LayoutControlItem i = this.layoutControlGroup2.AddItem();
            i.Name = "classItemLayoutItem" + this.itemCount;
            i.Control = item;
            i.ContentVertAlignment = DevExpress.Utils.VertAlignment.Top;

            i.OptionsTableLayoutItem.ColumnIndex = 0;
            i.OptionsTableLayoutItem.RowIndex = this.itemCount + 1; // 第0行显示提示文本
            i.OptionsTableLayoutItem.ColumnSpan = 4;

            this.itemCount++;
        }


        public void MoveUp(UserControls.ClassItem itemToMove)
        {
            // MoveUp实际上是与它上面的交换位置
            if(itemToMove.Order == 0) //已经是最上面一个了
            {
                return;
            }
            // 1.找到他上面一个
            LayoutControl layoutControl = this.Controls["layoutControl1"] as LayoutControl;
            LayoutControlItem layoutControlItemUpperOne = layoutControl.Items.FindByName("classItemLayoutItem" + (itemToMove.Order - 1)) as LayoutControlItem;
            UserControls.ClassItem itemUpper = layoutControlItemUpperOne.Control as UserControls.ClassItem;

            // 2.交换
            this.Switch(itemUpper, itemToMove);
        }


        public void MoveDown(UserControls.ClassItem itemToMove)
        {
            // MoveUp实际上是与它下面的交换位置
            if (itemToMove.Order == this.itemCount - 1) //已经是最下面一个了
            {
                return;
            }
            // 1.找到他下面一个
            LayoutControl layoutControl = this.Controls["layoutControl1"] as LayoutControl;
            LayoutControlItem layoutControlItemUpperOne = layoutControl.Items.FindByName("classItemLayoutItem" + (itemToMove.Order + 1)) as LayoutControlItem;
            UserControls.ClassItem itemLower = layoutControlItemUpperOne.Control as UserControls.ClassItem;

            // 2.交换
            this.Switch(itemToMove, itemLower);
        }


        public void Switch(UserControls.ClassItem upperOne, UserControls.ClassItem lowerOne)
        {
            //1.找到装这俩控件的LayoutItem
            LayoutControl layoutControl = this.Controls["layoutControl1"] as LayoutControl;
            LayoutControlItem layoutControlItemUpperOne = layoutControl.Items.FindByName("classItemLayoutItem" + upperOne.Order) as LayoutControlItem;
            LayoutControlItem layoutControlItemLowerOne = layoutControl.Items.FindByName("classItemLayoutItem" + lowerOne.Order) as LayoutControlItem;

            //2.交换
            //int temp = lowerOne.Order;
            //lowerOne.Order = upperOne.Order;
            //upperOne.Order = temp;
            upperOne.Order++;
            lowerOne.Order--;

            //temp = layoutControlItemUpperOne.OptionsTableLayoutItem.RowIndex;
            //layoutControlItemUpperOne.OptionsTableLayoutItem.RowIndex = layoutControlItemLowerOne.OptionsTableLayoutItem.RowIndex;
            //layoutControlItemLowerOne.OptionsTableLayoutItem.RowIndex = temp;
            layoutControlItemUpperOne.OptionsTableLayoutItem.RowIndex++;
            layoutControlItemLowerOne.OptionsTableLayoutItem.RowIndex--;
            
            //3.名字也要改，避免以后找不到
            upperOne.Name = "classItem" + upperOne.Order;
            lowerOne.Name = "classItem" + lowerOne.Order;

            layoutControlItemUpperOne.Name = "classItemLayoutItem" + upperOne.Order;
            layoutControlItemLowerOne.Name = "classItemLayoutItem" + lowerOne.Order;

            
        }


        public void RemoveClassItem(int index) // index就是order
        {
            
            LayoutControl layoutControl = this.Controls["layoutControl1"] as LayoutControl;
            LayoutControlItem layoutControlItem = layoutControl.Items.FindByName("classItemLayoutItem" + index) as LayoutControlItem;
            UserControls.ClassItem itemToRemove = layoutControlItem.Control as UserControls.ClassItem;

            // 调整后面内容的位置
            for (int i = index + 1; i < this.itemCount; i++) //后面逐个向上移动
            {
                LayoutControlItem followLayoutItem = layoutControl.Items.FindByName("classItemLayoutItem" + i) as LayoutControlItem;
                UserControls.ClassItem followerClassItem = followLayoutItem.Control as UserControls.ClassItem;

                this.MoveUp(followerClassItem);
            }



            // 1.移除用户控件
            itemToRemove.Dispose();

            // 2. 移除layoutitem
            this.layoutControlGroup2.Remove(layoutControlItem);

            // 3. 移除行
            this.layoutControlGroup2.OptionsTableLayoutGroup.RemoveRowAt(itemCount); // 移除最后一行
            this.itemCount--;
        }

        private void NewStudentAssignClassControl_Load(object sender, EventArgs e)
        {
            // 加载所有班级类型
            this.classTypes = this.repoClassType.GetList(orderBy: "ID");

            this.BindStudentClass();
        }

        

        private void btnAutoAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("自动分班需要数分钟时间，并将清空原有分班信息。是否继续？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 清空原有分班信息
            this.btnClear_ItemClick(sender, null);

            // 待分班的学生
            List<Model.Student> students = this.repoStudent.GetList();
            // 按总分排序
            students.Sort((x, y) => -x.zcj.CompareTo(y.zcj));

            // 分班方式
            int autoAssignType;
            switch (this.cbAutoAssignType.EditValue.ToString())
            {
                case "平行":
                    autoAssignType = 0;
                    break;
                case "蛇形":
                    autoAssignType = 1;
                    break;
                case "随机":
                    autoAssignType = 2;
                    break;
                default:
                    autoAssignType = 1;
                    break;
            }

           
            // 创建好的班级
            LayoutControl layoutControl = this.Controls["layoutControl1"] as LayoutControl;
            int classCount = 1;
            int scienceStudentIndex = 0;
            int liberalArtsStudentIndex = 0;
            for (int i = 0; i < this.itemCount; i++)
            {
                // 获得控件
                LayoutControlItem layoutControlItem = layoutControl.Items.FindByName("classItemLayoutItem" + i) as LayoutControlItem;
                UserControls.ClassItem item = layoutControlItem.Control as UserControls.ClassItem;

                // 建立该类型下所有班级
                for (int j = 0; j < item.ClassNum; j++)
                {
                    Model.Class cls = new Model.Class();
                    cls.ClassName = "高中" + DateTime.Today.Year.ToString() + "级(" + classCount + ")班";
                    cls.ClassTypeId = item.ClassTypeId;
                    cls.Grade = DateTime.Today.Year.ToString();
                    // 班主任信息需要在班级管理中设置

                    // 班级先入库，否则没有班级ID
                    this.repoClass.Add(cls);
                    classCount++;
                }

                // 自动分该类型的班
                List<Model.Student> stu;
                if(item.IsLiberalArts == 1)
                {
                    stu = students.Where(x => x.sfwk == 1).ToList();
                    int totalStudent = item.StudentNumPerClass * item.ClassNum;
                    int startIdx = liberalArtsStudentIndex;
                    int endIdx = startIdx + totalStudent - 1;
                    stu = stu.Skip(startIdx).ToList().Take(totalStudent).ToList();

                    List<Model.Class> classes = this.repoClass.GetList(predicate: "ClassTypeId=" + item.ClassTypeId + " and Grade='" + DateTime.Now.Year.ToString() + "'");

                    this.repoStudentClass.AutoAssign(stu, classes, autoAssignType);

                    liberalArtsStudentIndex = endIdx + 1;
                }
                else
                {
                    stu = students.Where(x => x.sfwk == 0).ToList();
                    int totalStudent = item.StudentNumPerClass * item.ClassNum;
                    int startIdx = scienceStudentIndex;
                    int endIdx = startIdx + totalStudent - 1;
                    stu = stu.Skip(startIdx).ToList().Take(totalStudent).ToList();

                    List<Model.Class> classes = this.repoClass.GetList(predicate: "ClassTypeId=" + item.ClassTypeId + " and Grade='" + DateTime.Now.Year.ToString() + "'");

                    this.repoStudentClass.AutoAssign(stu, classes, autoAssignType);

                    scienceStudentIndex = endIdx + 1;
                }

                
            }


            XtraMessageBox.Show("自动分班完成。\n 请前往“班级管理”完善班级其它信息。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

            // 分完了，查询出来
            this.BindStudentClass();

        }


        private void BindStudentClass()
        {
            List<Model.Class> classes = this.repoClass.GetList();

            this.gridControl1.DataSource = classes;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // 想办法得到当前行的ClassId
            Model.Class cls = ((List<Model.Class>)this.gridView1.DataSource)[e.RowHandle];

            // 绑定班级类型
            if (e.Column.Equals(this.ClassTypeName))
            {
                List<Model.ClassType> classTypes = this.repoClassType.GetList(predicate: "ID=" + cls.ClassTypeId);
                e.DisplayText = classTypes[0].ClassTypeName.ToString();

            }
            else
            {
                // 绑定班级人数
                List<Model.Student> students = this.repoClass.GetStudents(cls.ID);

                if (e.Column.Equals(this.NoStudents))
                {
                    e.DisplayText = students.Count.ToString();
                }

                if (e.Column.Equals(this.NoBoys))
                {
                    e.DisplayText = students.Where(x => x.xb == "男").Count().ToString();
                }

                if (e.Column.Equals(this.NoGirls))
                {
                    e.DisplayText = students.Where(x => x.xb == "女").Count().ToString();
                }

                if (e.Column.Equals(this.MaxScore))
                {
                    e.DisplayText = students.Count > 0 ? students.Max(x => x.zcj).ToString() : "0";
                }

                if (e.Column.Equals(this.MinScore))
                {
                    e.DisplayText = students.Count > 0 ? students.Min(x => x.zcj).ToString() : "0";
                }

                if (e.Column.Equals(this.AverageScore))
                {
                    e.DisplayText = students.Count > 0 ? students.Average(x => x.zcj).ToString() : "0";
                }
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("是否清空分班信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(DateTime.Now.Month <= 9) // 假设分班只能在每年9月之前进行
                {
                    this.repoStudentClass.Clear();
                    this.repoClass.Clear();

                    this.BindStudentClass();
                }
                else
                {
                    XtraMessageBox.Show("当前时间不能进行此操作。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            
        }
    }
}
