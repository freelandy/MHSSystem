﻿namespace MHSSystem.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbStyle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSystemSetup = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnNewStudentListMgr = new DevExpress.XtraNavBar.NavBarItem();
            this.btnNewStudentEnrollMgr = new DevExpress.XtraNavBar.NavBarItem();
            this.btnNewStudentAssignClassMgr = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnOldStudentListMgr = new DevExpress.XtraNavBar.NavBarItem();
            this.btnOldStudentRegistrationMgr = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbStyle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 72);
            this.panel1.TabIndex = 0;
            // 
            // cbStyle
            // 
            this.cbStyle.Location = new System.Drawing.Point(321, 23);
            this.cbStyle.MenuManager = this.barManager1;
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStyle.Size = new System.Drawing.Size(292, 20);
            this.cbStyle.TabIndex = 0;
            this.cbStyle.SelectedIndexChanged += new System.EventHandler(this.CbStyle_SelectedIndexChanged);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(933, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(933, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 505);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(933, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 505);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnNewStudentListMgr,
            this.btnNewStudentEnrollMgr,
            this.btnNewStudentAssignClassMgr,
            this.btnOldStudentListMgr,
            this.btnOldStudentRegistrationMgr,
            this.btnSystemSetup});
            this.navBarControl1.Location = new System.Drawing.Point(0, 72);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 163;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(163, 433);
            this.navBarControl1.TabIndex = 5;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "系统";
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSystemSetup)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // btnSystemSetup
            // 
            this.btnSystemSetup.Caption = "设置";
            this.btnSystemSetup.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.properties;
            this.btnSystemSetup.Name = "btnSystemSetup";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "新生信息管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnNewStudentListMgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnNewStudentEnrollMgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnNewStudentAssignClassMgr)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnNewStudentListMgr
            // 
            this.btnNewStudentListMgr.Caption = "新生名单管理";
            this.btnNewStudentListMgr.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.allowuserstoeditranges;
            this.btnNewStudentListMgr.Name = "btnNewStudentListMgr";
            this.btnNewStudentListMgr.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnNewStudentListMgr_LinkClicked);
            // 
            // btnNewStudentEnrollMgr
            // 
            this.btnNewStudentEnrollMgr.Caption = "新生报到管理";
            this.btnNewStudentEnrollMgr.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.itemtypechecked;
            this.btnNewStudentEnrollMgr.Name = "btnNewStudentEnrollMgr";
            // 
            // btnNewStudentAssignClassMgr
            // 
            this.btnNewStudentAssignClassMgr.Caption = "新生分班管理";
            this.btnNewStudentAssignClassMgr.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.editrules;
            this.btnNewStudentAssignClassMgr.Name = "btnNewStudentAssignClassMgr";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "老生信息管理";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnOldStudentListMgr),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnOldStudentRegistrationMgr)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnOldStudentListMgr
            // 
            this.btnOldStudentListMgr.Caption = "老生名单管理";
            this.btnOldStudentListMgr.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.allowuserstoeditranges1;
            this.btnOldStudentListMgr.Name = "btnOldStudentListMgr";
            // 
            // btnOldStudentRegistrationMgr
            // 
            this.btnOldStudentRegistrationMgr.Caption = "老生报到管理";
            this.btnOldStudentRegistrationMgr.ImageOptions.SvgImage = global::MHSSystem.Properties.Resources.itemtypechecked1;
            this.btnOldStudentRegistrationMgr.Name = "btnOldStudentRegistrationMgr";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(163, 72);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(770, 433);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabPage1.Size = new System.Drawing.Size(768, 407);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(768, 407);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnOldStudentListMgr;
        private DevExpress.XtraNavBar.NavBarItem btnOldStudentRegistrationMgr;
        private DevExpress.XtraNavBar.NavBarItem btnNewStudentListMgr;
        private DevExpress.XtraNavBar.NavBarItem btnNewStudentEnrollMgr;
        private DevExpress.XtraNavBar.NavBarItem btnNewStudentAssignClassMgr;
        private DevExpress.XtraEditors.ComboBoxEdit cbStyle;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem btnSystemSetup;
    }
}