﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MHSSystem.Forms
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        public static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}