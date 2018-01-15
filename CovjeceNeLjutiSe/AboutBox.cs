using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;

namespace CovjeceNeLjutiSe
{
    partial class AboutBox : Form
    {
        ResourceManager LocRM = OdaberiJezik.LocRM;

        public AboutBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
