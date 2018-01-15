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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        ResourceManager LocRM = OdaberiJezik.LocRM;

        private void Prijava_Load(object sender, EventArgs e)
        {
            checkBoxR.Text = LocRM.GetString("pCheckBoxR");
            checkBoxY.Text = LocRM.GetString("pCheckBoxY");
            checkBoxB.Text = LocRM.GetString("pCheckBoxB");
            checkBoxG.Text = LocRM.GetString("pCheckBoxG");
            label1.Text = LocRM.GetString("pLabel1");
            label2.Text = LocRM.GetString("pLabel2");
            label3.Text = LocRM.GetString("pLabel3");
            label4.Text = LocRM.GetString("pLabel4");
            buttonStart.Text = LocRM.GetString("pDugmeStart");
            this.Text = LocRM.GetString("pNazivForme");
        }

        public static int brIgraca;
        public static int[] figura = new int[4] { -1, -1, -1, -1 };
        public static string crveni = "X", zuti = "X", plavi = "X", zeleni = "X";

        private void buttonStart_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if(checkBoxR.Checked==true && textBoxR.Text == "")
                errorProvider.SetError(textBoxR, LocRM.GetString("pPorukaCrveni"));
            else if(checkBoxY.Checked==true && textBoxY.Text == "")
                errorProvider.SetError(textBoxY, LocRM.GetString("pPorukaZuti"));
            else if (checkBoxB.Checked == true && textBoxB.Text == "")
                errorProvider.SetError(textBoxB, LocRM.GetString("pPorukaPlavi"));
            else if (checkBoxG.Checked == true && textBoxG.Text == "")
                errorProvider.SetError(textBoxG, LocRM.GetString("pPorukaZeleni"));
            else if (brIgraca < 1)
                errorProvider.SetError(buttonStart, LocRM.GetString("pPorukaStart"));
            else
            {
                if(textBoxR.Text!=string.Empty)
                    crveni = textBoxR.Text;
                if(textBoxY.Text!=string.Empty)
                zuti = textBoxY.Text;
                if (textBoxB.Text != string.Empty)
                plavi = textBoxB.Text;
                if (textBoxG.Text != string.Empty)
                zeleni = textBoxG.Text;

                Tabla t = new Tabla();
                this.Hide();
                t.Show();
            }
        }

        private void PostaviIgrace(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, 
                                    TextBox tb1, TextBox tb2,TextBox tb3,TextBox tb4,
                                    
                                    Color aktivan, Color neaktivan, int brIg1, int brIg2, bool r, bool y, bool b, bool g)
        {
            errorProvider.Clear();

            if (cb1.Checked == true)
            {
                tb1.Enabled = true;
                tb1.BackColor = aktivan;
                
                if(y) cb2.Enabled = true;
                brIgraca = brIg1;
            }
            else
            {
                if (r)
                {
                    tb1.BackColor = neaktivan;
                    tb1.Enabled = false;
                    tb1.Text = string.Empty;
                }
                if (y)
                {
                    cb2.Enabled = false;
                    tb2.Enabled = false;
                    tb2.Text = string.Empty;
                }
                if (b)
                {
                    cb3.Enabled = false;
                    tb3.Enabled = false;
                    tb3.Text = string.Empty;
                }
                if (g)
                {
                    cb4.Enabled = false;
                    tb4.Enabled = false;
                    tb4.Text = string.Empty;
                }

                if(y) cb2.Checked = false;
                if(b) cb3.Checked = false;
                if(g) cb4.Checked = false;

                
                brIgraca = brIg2;
            }
        }

        private void checkBoxR_CheckedChanged(object sender, EventArgs e)
        {
            PostaviIgrace(checkBoxR, checkBoxY, checkBoxB, checkBoxG,
                                    textBoxR, textBoxY, textBoxB, textBoxG,
                                   
                                    Color.LightCoral, SystemColors.Control, 0, 0, true, true, true, true);
        }

        private void checkBoxY_CheckedChanged(object sender, EventArgs e)
        {
            PostaviIgrace(checkBoxY, checkBoxB, checkBoxG, null,
                             textBoxY, textBoxB, textBoxG, null,
                             
                             Color.Orange, SystemColors.Control, 1, 0, true, true, true, false);
        }

        private void checkBoxB_CheckedChanged(object sender, EventArgs e)
        {
            PostaviIgrace(checkBoxB, checkBoxG, null, null,
                            textBoxB, textBoxG, null, null,
                            
                            Color.SteelBlue, SystemColors.Control, 2, 1, true, true, false, false);
        }

        private void checkBoxG_CheckedChanged(object sender, EventArgs e)
        {
            PostaviIgrace(checkBoxG, null, null, null,
                           textBoxG, null, null, null,
                           
                           Color.DarkSeaGreen, SystemColors.Control, 3, 2, true, false, false, false);
        }
    }
}