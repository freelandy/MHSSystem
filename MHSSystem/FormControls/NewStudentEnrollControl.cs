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
        public NewStudentEnrollControl()
        {
            InitializeComponent();
        }

        private void NewStudentEnrollControl_Load(object sender, EventArgs e)
        {
            this.layoutControl1.BestFit();
            //this.gridView1.BestFitColumns();
        }
    }
}
