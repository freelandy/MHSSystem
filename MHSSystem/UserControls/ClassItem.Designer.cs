namespace MHSSystem.UserControls
{
    partial class ClassItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition7 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition8 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lookupClassType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEndScore = new DevExpress.XtraEditors.TextEdit();
            this.txtStartScore = new DevExpress.XtraEditors.TextEdit();
            this.txtStudentNumPerClass = new DevExpress.XtraEditors.TextEdit();
            this.txtClassNum = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupClassType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndScore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartScore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentNumPerClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookupClassType);
            this.layoutControl1.Controls.Add(this.btnDown);
            this.layoutControl1.Controls.Add(this.btnUp);
            this.layoutControl1.Controls.Add(this.txtEndScore);
            this.layoutControl1.Controls.Add(this.txtStartScore);
            this.layoutControl1.Controls.Add(this.txtStudentNumPerClass);
            this.layoutControl1.Controls.Add(this.txtClassNum);
            this.layoutControl1.Controls.Add(this.btnRemove);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(880, 26);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookupClassType
            // 
            this.lookupClassType.EditValue = "蛇形";
            this.lookupClassType.Location = new System.Drawing.Point(80, 2);
            this.lookupClassType.Name = "lookupClassType";
            this.lookupClassType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupClassType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClassTypeName", "班级类型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsLiberalArts", "文科/理科")});
            this.lookupClassType.Properties.NullText = "";
            this.lookupClassType.Size = new System.Drawing.Size(104, 20);
            this.lookupClassType.StyleController = this.layoutControl1;
            this.lookupClassType.TabIndex = 13;
            this.lookupClassType.CustomDrawCell += new DevExpress.XtraEditors.Popup.LookUpCustomDrawCellEventHandler(this.lookupClassType_CustomDrawCell);
            // 
            // txtEndScore
            // 
            this.txtEndScore.Location = new System.Drawing.Point(728, 2);
            this.txtEndScore.Name = "txtEndScore";
            this.txtEndScore.Properties.NullValuePrompt = "非必填项";
            this.txtEndScore.Size = new System.Drawing.Size(98, 20);
            this.txtEndScore.StyleController = this.layoutControl1;
            this.txtEndScore.TabIndex = 10;
            // 
            // txtStartScore
            // 
            this.txtStartScore.Location = new System.Drawing.Point(568, 2);
            this.txtStartScore.Name = "txtStartScore";
            this.txtStartScore.Properties.NullValuePrompt = "非必填项";
            this.txtStartScore.Size = new System.Drawing.Size(96, 20);
            this.txtStartScore.StyleController = this.layoutControl1;
            this.txtStartScore.TabIndex = 9;
            this.txtStartScore.EditValueChanged += new System.EventHandler(this.txtStartScore_EditValueChanged);
            // 
            // txtStudentNumPerClass
            // 
            this.txtStudentNumPerClass.Location = new System.Drawing.Point(408, 2);
            this.txtStudentNumPerClass.Name = "txtStudentNumPerClass";
            this.txtStudentNumPerClass.Size = new System.Drawing.Size(96, 20);
            this.txtStudentNumPerClass.StyleController = this.layoutControl1;
            this.txtStudentNumPerClass.TabIndex = 8;
            this.txtStudentNumPerClass.EditValueChanged += new System.EventHandler(this.txtStudentNumPerClass_EditValueChanged);
            // 
            // txtClassNum
            // 
            this.txtClassNum.Location = new System.Drawing.Point(248, 2);
            this.txtClassNum.Name = "txtClassNum";
            this.txtClassNum.Size = new System.Drawing.Size(96, 20);
            this.txtClassNum.StyleController = this.layoutControl1;
            this.txtClassNum.TabIndex = 7;
            this.txtClassNum.EditValueChanged += new System.EventHandler(this.txtClassNum_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem2});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 4;
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 26D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 20D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 20D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition4.Width = 20D;
            columnDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition5.Width = 20D;
            columnDefinition6.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition6.Width = 20D;
            columnDefinition7.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition7.Width = 26D;
            columnDefinition8.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition8.Width = 26D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3,
            columnDefinition4,
            columnDefinition5,
            columnDefinition6,
            columnDefinition7,
            columnDefinition8});
            rowDefinition1.Height = 26D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.AutoSize;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(880, 26);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtClassNum;
            this.layoutControlItem4.Location = new System.Drawing.Point(186, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem4.Text = "班级数量";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtStudentNumPerClass;
            this.layoutControlItem5.Location = new System.Drawing.Point(346, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 3;
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem5.Text = "每班人数";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtStartScore;
            this.layoutControlItem6.Location = new System.Drawing.Point(506, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 4;
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem6.Text = "起始排名";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtEndScore;
            this.layoutControlItem7.Location = new System.Drawing.Point(666, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.OptionsTableLayoutItem.ColumnIndex = 5;
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(162, 26);
            this.layoutControlItem7.Text = "结束排名";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookupClassType;
            this.layoutControlItem2.Location = new System.Drawing.Point(26, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem2.Text = "班级类别";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // btnDown
            // 
            this.btnDown.ImageOptions.Image = global::MHSSystem.Properties.Resources.next_16x16;
            this.btnDown.Location = new System.Drawing.Point(856, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDown.Size = new System.Drawing.Size(22, 22);
            this.btnDown.StyleController = this.layoutControl1;
            this.btnDown.TabIndex = 12;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.ImageOptions.Image = global::MHSSystem.Properties.Resources.previous_16x16;
            this.btnUp.Location = new System.Drawing.Point(830, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUp.Size = new System.Drawing.Size(22, 22);
            this.btnUp.StyleController = this.layoutControl1;
            this.btnUp.TabIndex = 11;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = global::MHSSystem.Properties.Resources.cancel_16x161;
            this.btnRemove.Location = new System.Drawing.Point(2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.StyleController = this.layoutControl1;
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnRemove;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnUp;
            this.layoutControlItem8.Location = new System.Drawing.Point(828, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 6;
            this.layoutControlItem8.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnDown;
            this.layoutControlItem9.Location = new System.Drawing.Point(854, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(26, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.OptionsTableLayoutItem.ColumnIndex = 7;
            this.layoutControlItem9.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // ClassItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ClassItem";
            this.Size = new System.Drawing.Size(880, 26);
            this.Load += new System.EventHandler(this.ClassItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupClassType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndScore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartScore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentNumPerClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtClassNum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtEndScore;
        private DevExpress.XtraEditors.TextEdit txtStartScore;
        private DevExpress.XtraEditors.TextEdit txtStudentNumPerClass;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit lookupClassType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
