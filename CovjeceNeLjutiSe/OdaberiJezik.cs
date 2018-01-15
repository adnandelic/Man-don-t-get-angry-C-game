using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace CovjeceNeLjutiSe
{
    public partial class OdaberiJezik : Form
    {
        public OdaberiJezik()
        {
            InitializeComponent();
        }

        public static ResourceManager LocRM;

        private void buttonBos_Click(object sender, EventArgs e)
        {
            LocRM = new ResourceManager("CovjeceNeLjutiSe.Jezik-bs-BS", typeof(OdaberiJezik).Assembly);

            Prijava pr = new Prijava();
            //this.Hide();
            pr.Show();
        }

        private void buttonEng_Click(object sender, EventArgs e)
        {
            LocRM = new ResourceManager("CovjeceNeLjutiSe.Jezik-en-EN", typeof(OdaberiJezik).Assembly);

            Prijava pr = new Prijava();
            //this.Hide();
            pr.Show();
        }

        private void buttonGer_Click(object sender, EventArgs e)
        {
            LocRM = new ResourceManager("CovjeceNeLjutiSe.Jezik-de-DE", typeof(OdaberiJezik).Assembly);

            Prijava pr = new Prijava();
            //this.Hide();
            pr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
