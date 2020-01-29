using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHSSystem.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BaseForm.defaultLookAndFeel.LookAndFeel.SkinName = "The Bezier";

            LoginForm loginForm = new LoginForm();

            //if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
                // show splash form
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Forms.SplashForm));

                // do something time-comsuming
                foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    this.cbStyle.Properties.Items.Add(skin.SkinName);
                }

                //FormControls.StudentControl c = new FormControls.StudentControl();
                //c.Dock = DockStyle.Fill;
                //this.xtraTabControl1.TabPages[0].Controls.Add(c);
            //}
        }

        private void CbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseForm.defaultLookAndFeel.LookAndFeel.SkinName = this.cbStyle.SelectedItem.ToString();
        }

        private void btnNewStudentListMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentListControl c = new FormControls.NewStudentListControl();
            c.Dock = DockStyle.Fill;
            this.xtraTabControl1.TabPages[0].Controls.Add(c);
        }

        private void BtnNewStudentEnrollMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentEnrollControl c = new FormControls.NewStudentEnrollControl();
            c.Dock = DockStyle.Fill;
            this.xtraTabControl1.TabPages[1].Controls.Add(c);
        }

        private void btnNewStudentAssignClassMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentAssignClassControl c = new FormControls.NewStudentAssignClassControl();
            c.Dock = DockStyle.Fill;
            this.xtraTabControl1.TabPages[2].Controls.Add(c);
        }
    }
}
