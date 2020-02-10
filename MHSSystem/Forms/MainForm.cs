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


        private void CreareAndSelectTabPage(Control control, string caption, string tag)
        {
            DevExpress.XtraTab.XtraTabPage page = null;
            bool flag = false;

            // if this page alread exist, activate it
            foreach (DevExpress.XtraTab.XtraTabPage p in this.xtraTabControl1.TabPages)
            {
                if (p.Tag.ToString() == tag)
                {
                    page = p;
                    flag = true;
                    break;
                }
            }

            // else create a page
            if (!flag)
            {
                page = new DevExpress.XtraTab.XtraTabPage();
                page.Tag = tag;
                page.Text = caption;
                control.Dock = DockStyle.Fill;
                page.Controls.Add(control);

                this.xtraTabControl1.TabPages.Add(page);
            }

            // activate
            this.xtraTabControl1.SelectedTabPage = page;
        }
        private void btnNewStudentListMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentListControl c = new FormControls.NewStudentListControl();
            this.CreareAndSelectTabPage(c, e.Link.Item.Caption, e.Link.Item.Name);
        }

        private void BtnNewStudentEnrollMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentEnrollControl c = new FormControls.NewStudentEnrollControl();
            this.CreareAndSelectTabPage(c, e.Link.Item.Caption, e.Link.Item.Name);
        }

        private void btnNewStudentAssignClassMgr_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormControls.NewStudentAssignClassControl c = new FormControls.NewStudentAssignClassControl();
            this.CreareAndSelectTabPage(c, e.Link.Item.Caption, e.Link.Item.Name);
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            DevExpress.XtraTab.XtraTabPage page = arg.Page as DevExpress.XtraTab.XtraTabPage;

            page.Controls.Clear();
            this.xtraTabControl1.TabPages.Remove(page);
            page.Dispose();
        }
    }
}
