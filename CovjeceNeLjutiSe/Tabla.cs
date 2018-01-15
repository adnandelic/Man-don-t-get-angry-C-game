using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Resources;

namespace CovjeceNeLjutiSe
{
    public partial class Tabla : Form
    {
        public Tabla()
        {
            InitializeComponent();
        }

        Igrac igrac0, igrac1, igrac2, igrac3;

        PictureBox[] tabla;

        Image[] slikeKockeImg;

        Button[] buttonIgr0, buttonIgr1, buttonIgr2, buttonIgr3;
        Button[][] xButton = new Button[4][];

        Bitmap[] slikeKockeBmp = new Bitmap[7] { Properties.Resources.kocka_0, Properties.Resources.kocka_1, Properties.Resources.kocka_2, 
        Properties.Resources.kocka_3, Properties.Resources.kocka_4, Properties.Resources.kocka_5, Properties.Resources.kocka_6 };


        Bitmap[][] xBitmap = new Bitmap[16][];

        int reda = 0, brIgr = 0;
        bool startStop = true;

        int locX0=27, locY0=30, locX1=195, locY1=30, locX2=27, locY2=195, locX3=195, locY3=195;

        SoundPlayer zvukKocke = new SoundPlayer();
        SoundPlayer kretanje = new SoundPlayer();
        SoundPlayer pojediIgraca = new SoundPlayer();
        SoundPlayer parkiraj = new SoundPlayer();
        SoundPlayer ubaciIgraca = new SoundPlayer();
        SoundPlayer proslavaPobjede = new SoundPlayer();

        ResourceManager LocRM = OdaberiJezik.LocRM;

        private void Tabla_Load(object sender, EventArgs e)
        {
            igrac0 = new Igrac();
            igrac1 = new Igrac();
            igrac2 = new Igrac();
            igrac3 = new Igrac();

            brIgr = Prijava.brIgraca;

            for (int i = 0; i <= 3; i++)
            {
                //startne pozicije igraca, igrac0 po default-u ima pozicije postavljene na nulu
                igrac1.PozicijaIgrac[i] = 12;
                igrac2.PozicijaIgrac[i] = 24;
                igrac3.PozicijaIgrac[i] = 36;
            }

            // pozicije za svakog igraca od startne pa do kraja njegovog kretanja po tabli ukljucujuci i parking
            igrac0.PozicijaNaTabli = new int[52] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 
                                         26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51 };
            igrac1.PozicijaNaTabli = new int[52] { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 
                                         36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 52, 53, 54, 55 };
            igrac2.PozicijaNaTabli = new int[52] { 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 
                                         0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 56, 57, 58, 59 };
            igrac3.PozicijaNaTabli = new int[52] { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 
                                         14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 60, 61, 62, 63 };

            buttonIgr0 = new Button[4] { buttonR0, buttonR1, buttonR2, buttonR3 };
            buttonIgr1 = new Button[4] { buttonY0, buttonY1, buttonY2, buttonY3 };
            buttonIgr2 = new Button[4] { buttonB0, buttonB1, buttonB2, buttonB3 };
            buttonIgr3 = new Button[4] { buttonG0, buttonG1, buttonG2, buttonG3 };


            // niz nizova dugmadi(figura kojim se igra 4x4)
            xButton[0] = buttonIgr0;
            xButton[1] = buttonIgr1;
            xButton[2] = buttonIgr2;
            xButton[3] = buttonIgr3;


            slikeKockeImg = new Image[7];

            for (int i = 0; i < slikeKockeImg.Length; i++)
                slikeKockeImg[i] = slikeKockeBmp[i];

            tabla = new PictureBox[64];

            int x = 404, y = 12;

            for (int i = 0; i <= 47; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Size = new Size(50, 50);
                tabla[i].BackColor = Color.WhiteSmoke;


                if ((i >= 1 && i <= 5) || (i >= 11 && i <= 12) || (i >= 18 && i <= 22))
                    y += 50 + 6;
                if ((i >= 6 && i <= 10) || (i >= 37 && i <= 41) || (i >= 47))
                    x += 50 + 6;
                if ((i >= 13 && i <= 17) || (i >= 23 && i <= 24) || (i >= 30 && i <= 34))
                    x -= 50 + 6;
                if ((i >= 25 && i <= 29) || (i >= 35 && i <= 36) || (i >= 42 && i <= 46))
                    y -= 50 + 6;

                tabla[i].Location = new Point(x, y);

                if (i == 0){
                    tabla[i].BackgroundImage = Properties.Resources.down;
                    tabla[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (i == 12){
                    tabla[i].BackgroundImage = Properties.Resources.left;
                    tabla[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (i == 24){
                    tabla[i].BackgroundImage = Properties.Resources.up;
                    tabla[i].BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (i == 36){
                    tabla[i].BackgroundImage = Properties.Resources.right;
                    tabla[i].BackgroundImageLayout = ImageLayout.Stretch;
                }

                this.Controls.Add(tabla[i]);
            }

            tabla[48] = pictureBox1;
            tabla[49] = pictureBox2;
            tabla[50] = pictureBox3;
            tabla[51] = pictureBox4;

            tabla[52] = pictureBox5;
            tabla[53] = pictureBox6;
            tabla[54] = pictureBox7;
            tabla[55] = pictureBox8;

            tabla[56] = pictureBox9;
            tabla[57] = pictureBox10;
            tabla[58] = pictureBox11;
            tabla[59] = pictureBox12;

            tabla[60] = pictureBox13;
            tabla[61] = pictureBox14;
            tabla[62] = pictureBox15;
            tabla[63] = pictureBox16;

            PostaviFigure(Prijava.figura);

            zvukKocke.Stream = Properties.Resources.zavrtiKocku;
            kretanje.Stream = Properties.Resources.tap;
            pojediIgraca.Stream = Properties.Resources.pojediIgraca;
            parkiraj.Stream = Properties.Resources.migmigParking;
            ubaciIgraca.Stream = Properties.Resources.ubaciIgraca;
            proslavaPobjede.Stream = Properties.Resources.pobjednikTuskiMars;

            panelKockaEnabDisab.SendToBack();

            PostaviImenaIgraca(Prijava.crveni, labelImeR);
            PostaviImenaIgraca(Prijava.zuti, labelImeY);
            PostaviImenaIgraca(Prijava.plavi, labelImeB);
            PostaviImenaIgraca(Prijava.zeleni, labelImeG);


            toolTip.SetToolTip(buttonReda0, LocRM.GetString("tTolTipB"));
            toolTip.SetToolTip(buttonReda1, LocRM.GetString("tTolTipB"));
            toolTip.SetToolTip(buttonReda2, LocRM.GetString("tTolTipB"));
            toolTip.SetToolTip(buttonReda3, LocRM.GetString("tTolTipB"));

            toolTip.SetToolTip(labelTrenIgrac0, LocRM.GetString("tTolTipL0"));
            toolTip.SetToolTip(labelTrenIgrac1, LocRM.GetString("tTolTipL1"));
            toolTip.SetToolTip(labelTrenIgrac2, LocRM.GetString("tTolTipL2"));
            toolTip.SetToolTip(labelTrenIgrac3, LocRM.GetString("tTolTipL3"));

            this.Text = LocRM.GetString("pNazivForme");
        }

        public void ZavrtiKocku()
        {
            if (startStop)
            {
                startStop = false;
                timerZavrtiKocku.Start();
                zvukKocke.PlayLooping();
            }
            else
            {
                startStop = true;
                timerZavrtiKocku.Stop();
                zvukKocke.Stop();
            }
        }

        private void timerZavrtiKocku_Tick(object sender, EventArgs e)
        {
            if (reda == 0)
                igrac0.SimulacijaVrtenja(pictureBoxKocka, slikeKockeImg);
            else if (reda == 1)
                igrac1.SimulacijaVrtenja(pictureBoxKocka, slikeKockeImg);   
            else if (reda == 2)
                igrac2.SimulacijaVrtenja(pictureBoxKocka, slikeKockeImg);
            else
                igrac3.SimulacijaVrtenja(pictureBoxKocka, slikeKockeImg);
        }

        private void pictureBoxKocka_Click(object sender, EventArgs e)
        {
            ZavrtiKocku();

            if (reda == 0 && timerZavrtiKocku.Enabled == false)
                EnableDisableButtons(igrac0, buttonIgr0, buttonIgr1, buttonIgr2, buttonIgr3, 'R');

            else if (reda == 1 && timerZavrtiKocku.Enabled == false)
                EnableDisableButtons(igrac1, buttonIgr1, buttonIgr0, buttonIgr2, buttonIgr3, 'Y');

            else if (reda == 2 && timerZavrtiKocku.Enabled == false)
                EnableDisableButtons(igrac2, buttonIgr2, buttonIgr0, buttonIgr1, buttonIgr3, 'B');

            else if (reda == 3 && timerZavrtiKocku.Enabled == false)
                EnableDisableButtons(igrac3, buttonIgr3, buttonIgr0, buttonIgr1, buttonIgr2, 'G');
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
            if (reda == 0)
            {
                if (ProvjeriIgraca(igrac0, b))
                {
                    b.Parent.Controls.Remove(b);
                    this.Controls.Add(b);
                    b.BringToFront();
                }
            }
            else if (reda == 1)
            {
                if (ProvjeriIgraca(igrac1, b))
                {
                    b.Parent.Controls.Remove(b);
                    this.Controls.Add(b);
                    b.BringToFront();
                }
            }
            else if (reda == 2)
            {
                if (ProvjeriIgraca(igrac2, b))
                {
                    b.Parent.Controls.Remove(b);
                    this.Controls.Add(b);
                    b.BringToFront();
                }
            }
            else
            {
                if (ProvjeriIgraca(igrac3, b))
                {
                    b.Parent.Controls.Remove(b);
                    this.Controls.Add(b);
                    b.BringToFront();
                }
            }
        }

        private void buttonPromijeniRedu_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char dugme = b.Name[b.Name.Length - 1];

            reda++;
            if (reda == brIgr + 1)
                reda = 0;

            b.Visible = false;
            pictureBoxKocka.Enabled = true;
            panelKockaEnabDisab.BackColor = Color.Green;
            pictureBoxKocka_Click(null, null);

            if (brIgr == 1)
            {
                if(dugme == '0')
                { labelTrenIgrac0.Visible = false; labelTrenIgrac1.Visible = true; }
                else if(dugme == '1')
                { labelTrenIgrac1.Visible = false; labelTrenIgrac0.Visible = true; }
            }
            else if(brIgr == 2)
            {
                if(dugme == '0')
                { labelTrenIgrac0.Visible = false; labelTrenIgrac1.Visible = true; }
                else if(dugme == '1')
                { labelTrenIgrac1.Visible = false; labelTrenIgrac2.Visible = true; }
                else if(dugme == '2')
                { labelTrenIgrac2.Visible = false; labelTrenIgrac0.Visible = true; }
            }
            else
            {
                if(dugme == '0')
                { labelTrenIgrac0.Visible = false; labelTrenIgrac1.Visible = true; }
                else if(dugme == '1')
                { labelTrenIgrac1.Visible = false; labelTrenIgrac2.Visible = true; }
                else if(dugme == '2')
                { labelTrenIgrac2.Visible = false; labelTrenIgrac3.Visible = true; }
                else if(dugme == '3')
                { labelTrenIgrac3.Visible = false; labelTrenIgrac0.Visible = true; }
            }
        }

        private bool ProvjeriIgraca(Igrac igr, Button dugme)
        {
            int index = Convert.ToInt32(dugme.Name[dugme.Name.Length - 1].ToString());
            char c = dugme.Name[dugme.Name.Length - 2];

            //Ako je 6-tica i nije na tabli postavi ga na startnu poziciju
            if (index == 0 && igr.BrojKocke == 6 && igr.StartIgr[index] == true)
            {
                igr.StartIgr[index] = false;
                igr.BrojacIgrac[index] = 0;
                dugme.Location = new Point(tabla[igr.PozicijaIgrac[index]].Location.X, tabla[igr.PozicijaIgrac[index]].Location.Y);
                ubaciIgraca.Play();

                PojediIgraca(igrac0, igrac1, igrac2, igrac3, c, index);

                DisableButtonsIgrac(c);
                DisableEnableButtonReda(igr, c);
                return true;
            }
            else if (index == 1 && igr.BrojKocke == 6 && igr.StartIgr[index] == true)
            {
                igr.StartIgr[index] = false;
                igr.BrojacIgrac[index] = 0;
                dugme.Location = new Point(tabla[igr.PozicijaIgrac[index]].Location.X, tabla[igr.PozicijaIgrac[index]].Location.Y);
                ubaciIgraca.Play();

                PojediIgraca(igrac0, igrac1, igrac2, igrac3, c, index);

                DisableButtonsIgrac(c);
                DisableEnableButtonReda(igr, c);
                return true;
            }
            else if (index == 2 && igr.BrojKocke == 6 && igr.StartIgr[index] == true)
            {
                igr.StartIgr[index] = false;
                igr.BrojacIgrac[index] = 0;
                dugme.Location = new Point(tabla[igr.PozicijaIgrac[index]].Location.X, tabla[igr.PozicijaIgrac[index]].Location.Y);
                ubaciIgraca.Play();

                PojediIgraca(igrac0, igrac1, igrac2, igrac3, c, index);

                DisableButtonsIgrac(c);
                DisableEnableButtonReda(igr, c);
                return true;
            }
            else if (index == 3 && igr.BrojKocke == 6 && igr.StartIgr[index] == true)
            {
                igr.StartIgr[index] = false;
                igr.BrojacIgrac[index] = 0;
                dugme.Location = new Point(tabla[igr.PozicijaIgrac[index]].Location.X, tabla[igr.PozicijaIgrac[index]].Location.Y);
                ubaciIgraca.Play();

                PojediIgraca(igrac0, igrac1, igrac2, igrac3, c, index);

                DisableButtonsIgrac(c);
                DisableEnableButtonReda(igr, c);
                return true;
            }
            else
            {
                int[] kopija = (int[])igr.BrojacIgrac.Clone();

                Array.Sort(kopija);

                int poredbenaPomak = igr.BrojacIgrac[index] + igr.BrojKocke;
                int poredbena = kopija[Array.IndexOf(kopija, igr.BrojacIgrac[index]) + 1];

                if (ProvjeriRazmak(igr, kopija) && igr.BrojKocke == 6 && Array.Exists(igr.StartIgr, element => element == true))
                {
                    return false;
                }
                else if (poredbenaPomak >= poredbena)
                {
                    return false;
                }
                else
                {
                    int privremenaZaPokret = igr.BrojacIgrac[index];
                    igr.BrojacIgrac[index] += igr.BrojKocke;

                    igr.PozicijaIgrac[index] = igr.PozicijaNaTabli[igr.BrojacIgrac[index]];

                    DisableButtonsIgrac(c);

                    #region Simulacija kretanja igraca po tabli
                    for (int i = privremenaZaPokret + 1; i <= igr.BrojacIgrac[index]; i++)
                    {
                        dugme.Location = new Point(tabla[igr.PozicijaNaTabli[i]].Location.X, tabla[igr.PozicijaNaTabli[i]].Location.Y);

                        if (i >= 48)
                            parkiraj.Play();
                        else
                            kretanje.Play();

                        Application.DoEvents();
                        Thread.Sleep(200);
                    }
                    #endregion

                    PojediIgraca(igrac0, igrac1, igrac2, igrac3, c, index);

                    DisableEnableButtonReda(igr, c);

                    //provjera da li je igrac pobijedio
                    int[] kopijaZaPobjedu = (int[])igr.BrojacIgrac.Clone();
                    Array.Sort(kopijaZaPobjedu);
                    ProvjeriPobjednika(kopijaZaPobjedu, c);

                    return true;
                }
            }
        }

        private void PojediIgraca(Igrac igr0, Igrac igr1, Igrac igr2, Igrac igr3, char boja, int index)
        {
            int indexXY=0, tackaX=0, tackaY=0, brojac=0;
            bool pojedi = false;

            if (boja == 'R')
            {
                for (int i = 0; i <= 3; i++)
                {
                    //ako je pozicija figure igraca koji trenutno igra jednaka nekoj poziciji figure od drugog igraca
                    // i ta figura u polju zapamti njegov index i pripremi figuru da se ukloni sa polja
                    if (igr0.PozicijaIgrac[index] == igr1.PozicijaIgrac[i] && igr1.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 1;
                        pojedi = true;

                        igr1.BrojacIgrac[i] = 52;
                        igr1.PozicijaIgrac[i] = 12;
                        igr1.StartIgr[i] = true;
                        igr1.PomocParking[i] = true;
                        break;
                    }
                    if (igr0.PozicijaIgrac[index] == igr2.PozicijaIgrac[i] && igr2.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 2;
                        pojedi = true;

                        igr2.BrojacIgrac[i] = 52;
                        igr2.PozicijaIgrac[i] = 24;
                        igr2.StartIgr[i] = true;
                        igr2.PomocParking[i] = true;
                        break;
                    }
                    if (igr0.PozicijaIgrac[index] == igr3.PozicijaIgrac[i] && igr3.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 3;
                        pojedi = true;

                        igr3.BrojacIgrac[i] = 52;
                        igr3.PozicijaIgrac[i] = 36;
                        igr3.StartIgr[i] = true;
                        igr3.PomocParking[i] = true;
                        break;
                    }
                }
            }
            else if (boja == 'Y')
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (igr1.PozicijaIgrac[index] == igr0.PozicijaIgrac[i] && igr0.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 0;
                        pojedi = true;

                        igr0.BrojacIgrac[i] = 52;
                        igr0.PozicijaIgrac[i] = 0;
                        igr0.StartIgr[i] = true;
                        igr0.PomocParking[i] = true;
                        break;
                    }
                    if (igr1.PozicijaIgrac[index] == igr2.PozicijaIgrac[i] && igr2.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 2;
                        pojedi = true;

                        igr2.BrojacIgrac[i] = 52;
                        igr2.PozicijaIgrac[i] = 24;
                        igr2.StartIgr[i] = true;
                        igr2.PomocParking[i] = true;
                        break;
                    }
                    if (igr1.PozicijaIgrac[index] == igr3.PozicijaIgrac[i] && igr3.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 3;
                        pojedi = true;

                        igr3.BrojacIgrac[i] = 52;
                        igr3.PozicijaIgrac[i] = 36;
                        igr3.StartIgr[i] = true;
                        igr3.PomocParking[i] = true;
                        break;
                    }
                }
            }
            else if (boja == 'B')
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (igr2.PozicijaIgrac[index] == igr0.PozicijaIgrac[i] && igr0.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 0;
                        pojedi = true;

                        igr0.BrojacIgrac[i] = 52;
                        igr0.PozicijaIgrac[i] = 0;
                        igr0.StartIgr[i] = true;
                        igr0.PomocParking[i] = true;
                        break;
                    }
                    if (igr2.PozicijaIgrac[index] == igr1.PozicijaIgrac[i] && igr1.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 1;
                        pojedi = true;

                        igr1.BrojacIgrac[i] = 52;
                        igr1.PozicijaIgrac[i] = 12;
                        igr1.StartIgr[i] = true;
                        igr1.PomocParking[i] = true;
                        break;
                    }
                    if (igr2.PozicijaIgrac[index] == igr3.PozicijaIgrac[i] && igr3.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 3;
                        pojedi = true;

                        igr3.BrojacIgrac[i] = 52;
                        igr3.PozicijaIgrac[i] = 36;
                        igr3.StartIgr[i] = true;
                        igr3.PomocParking[i] = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (igr3.PozicijaIgrac[index] == igr0.PozicijaIgrac[i] && igr0.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 0;
                        pojedi = true;

                        igr0.BrojacIgrac[i] = 52;
                        igr0.PozicijaIgrac[i] = 0;
                        igr0.StartIgr[i] = true;
                        igr0.PomocParking[i] = true;
                        break;
                    }
                    if (igr3.PozicijaIgrac[index] == igr1.PozicijaIgrac[i] && igr1.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 1;
                        pojedi = true;

                        igr1.BrojacIgrac[i] = 52;
                        igr1.PozicijaIgrac[i] = 12;
                        igr1.StartIgr[i] = true;
                        igr1.PomocParking[i] = true;
                        break;
                    }
                    if (igr3.PozicijaIgrac[index] == igr2.PozicijaIgrac[i] && igr2.StartIgr[i] == false)
                    {
                        indexXY = i;
                        brojac = 2;
                        pojedi = true;

                        igr2.BrojacIgrac[i] = 52;
                        igr2.PozicijaIgrac[i] = 24;
                        igr2.StartIgr[i] = true;
                        igr2.PomocParking[i] = true;
                        break;
                    }
                }
            }
            //uslov kada je figura izbacena iz igre
            if (pojedi)
            {
                //postavljanje pravilne lokacije figure nekog igraca kada se ukloni sa polja odnosno kad se izbaci iz igre
                if (indexXY == 0)
                {
                    tackaX = this.locX0; tackaY = this.locY0;
                }
                else if (indexXY == 1)
                {
                    tackaX = this.locX1; tackaY = this.locY1;
                }
                else if (indexXY == 2)
                {
                    tackaX = this.locX2; tackaY = this.locY2;
                }
                else if (indexXY == 3)
                {
                    tackaX = this.locX3; tackaY = this.locY3;
                }

                if (brojac == 0)    //slucaj kad je izbacena jedna figura od igraca 0
                {
                    buttonIgr0[indexXY].Location = new Point(tackaX, tackaY);

                    this.Controls.Remove(buttonIgr0[indexXY]);
                    panel0.Controls.Add(buttonIgr0[indexXY]);
                    buttonIgr0[indexXY].BringToFront();
                    
                    pojediIgraca.Play();
                }
                else if (brojac == 1)   //slucaj kad je izbacena jedna figura od igraca 1
                {
                    buttonIgr1[indexXY].Location = new Point(tackaX, tackaY);
                    
                    this.Controls.Remove(buttonIgr1[indexXY]);
                    panel1.Controls.Add(buttonIgr1[indexXY]);
                    buttonIgr1[indexXY].BringToFront();

                    pojediIgraca.Play();
                }
                else if (brojac == 2)   //slucaj kad je izbacena jedna figura od igraca 2
                {
                    buttonIgr2[indexXY].Location = new Point(tackaX, tackaY);

                    this.Controls.Remove(buttonIgr2[indexXY]);
                    panel2.Controls.Add(buttonIgr2[indexXY]);
                    buttonIgr2[indexXY].BringToFront();

                    pojediIgraca.Play();
                }
                else   //slucaj kad je izbacena jedna figura od igraca 3
                {
                    buttonIgr3[indexXY].Location = new Point(tackaX, tackaY);

                    this.Controls.Remove(buttonIgr3[indexXY]);
                    panel3.Controls.Add(buttonIgr3[indexXY]);
                    buttonIgr3[indexXY].BringToFront();

                    pojediIgraca.Play();
                }
            }
        }

        private void ProvjeriPobjednika(int[] niz, char boja)
        {
            if (niz[0] == 48 && niz[1] == 49 && niz[2] == 50 && niz[3] == 51)
            {
                OdaberiJezik start = new OdaberiJezik();

                if (boja == 'R')
                {
                    DisableKrajIgre();
                    ProslavaPobjede(igrac0.PozicijaNaTabli, buttonIgr0);

                    Prijava.brIgraca = 0;
                    this.Hide();
                    start.Show();
                }
                else if (boja == 'Y')
                {
                    DisableKrajIgre();
                    ProslavaPobjede(igrac1.PozicijaNaTabli, buttonIgr1);
                    
                    Prijava.brIgraca = 0;
                    this.Hide();
                    start.Show();
                }
                else if (boja == 'B')
                {
                    DisableKrajIgre();
                    ProslavaPobjede(igrac2.PozicijaNaTabli, buttonIgr2);
                    
                    Prijava.brIgraca = 0;
                    this.Hide();
                    start.Show();
                }
                else
                {
                    DisableKrajIgre();
                    ProslavaPobjede(igrac3.PozicijaNaTabli, buttonIgr3);
                    
                    Prijava.brIgraca = 0;
                    this.Hide();
                    start.Show();
                }
            }
        }

        private void DisableKrajIgre()
        {
            buttonReda0.Visible = false;
            buttonReda1.Visible = false;
            buttonReda2.Visible = false;
            buttonReda3.Visible = false;
            
            pictureBoxKocka.Enabled = false;
        }


        private void ProslavaPobjede(int[] niz, Button[] b)
        {
            proslavaPobjede.Play();

            int poz0=0, poz1=0, poz2=0, poz3=0;

            for (int i = 0; i < niz.Length; i++)
            {
                poz0 = i;
                b[0].BringToFront();
                b[0].Location = new Point(tabla[niz[poz0]].Location.X, tabla[niz[poz0]].Location.Y);
                b[0].BringToFront();
                if (i >= 1)
                {
                    poz1 = poz0-1;
                    b[1].BringToFront();
                    b[1].Location = new Point(tabla[niz[poz1]].Location.X, tabla[niz[poz1]].Location.Y);
                }
                if (i >= 2)
                {
                    poz2 = poz1-1;
                    b[2].BringToFront();
                    b[2].Location = new Point(tabla[niz[poz2]].Location.X, tabla[niz[poz2]].Location.Y);
                }
                if (i >= 3)
                {
                    poz3 = poz2-1;
                    b[3].BringToFront();
                    b[3].Location = new Point(tabla[niz[poz3]].Location.X, tabla[niz[poz3]].Location.Y);
                }

                Thread.Sleep(800);
            }
        }

        private void DisableButtonsIgrac(char boja)
        {
            // kad odigra igrac i nema uvjeta da ponovo zavrti uradi njegov disable
            if (boja == 'R')
                DisableButtIgrac(buttonIgr0);
            if (boja == 'Y')
                DisableButtIgrac(buttonIgr1);
            if (boja == 'B')
                DisableButtIgrac(buttonIgr2);
            if (boja == 'G')
                DisableButtIgrac(buttonIgr3);
        }

        private void DisableButtIgrac(Button[] buttonDisable)
        {
            for (int i = 0; i <= 3; i++)
                buttonDisable[i].Enabled = false;
        }

        private void DisableEnableButtonReda(Igrac ig, char boja)
        {
            if (ig.BrojKocke != 6)     //ako nije 6-tica omoguci prebacivanje rede na sljedeceg igraca
                DisableEnableReda(boja);
            else
            {
                pictureBoxKocka.Enabled = true; //u suprotnom ostavi redu na istom igracu da ponovo vrti jer je bila 6-tica
                panelKockaEnabDisab.BackColor = Color.Green;
            }
        }

        private void DisableEnableReda(char boja)
        {
            if (boja == 'R')
            {
                buttonReda0.Visible = true; buttonReda1.Visible = false; buttonReda2.Visible = false; buttonReda3.Visible = false;
            }
            else if (boja == 'Y')
            {
                buttonReda0.Visible = false; buttonReda1.Visible = true; buttonReda2.Visible = false; buttonReda3.Visible = false;
            }
            else if (boja == 'B')
            {
                buttonReda0.Visible = false; buttonReda1.Visible = false; buttonReda2.Visible = true; buttonReda3.Visible = false;
            }
            else if (boja == 'G')
            {
                buttonReda0.Visible = false; buttonReda1.Visible = false; buttonReda2.Visible = false; buttonReda3.Visible = true;
            }
        }

        private void EnableDisableButtons(Igrac igr, Button[] buttonEnable, Button[] buttonDis1, Button[] buttonDis2, Button[] buttonDis3, char boja)
        {
            int[] kopija = (int[])igr.BrojacIgrac.Clone();
            Array.Sort(kopija);

            for (int i = 0; i <= 3; i++)
            {
                if (igr.BrojKocke == 6)
                {
                    if (ProvjeriRazmak(igr, kopija) && ProvjeriSveNaTerenu(igr,igr.StartIgr))
                    {
                        DisableButtonsIgrac(boja);
                        pictureBoxKocka.Enabled = true;
                        panelKockaEnabDisab.BackColor = Color.Green;
                        goto Kraj;
                    }
                    else if (Array.Exists(igr.BrojacIgrac, element => element == 0))
                    {
                        if (igr.StartIgr[i] == false) // ako je 6-tica i zauzeta pocetna dozvoli samo onima u polju
                            buttonEnable[i].Enabled = true;
                    }
                    else if (!Array.Exists(igr.BrojacIgrac, element => element == 0))
                        buttonEnable[i].Enabled = true;   //ako je 6-tica i nije zauzeta pocetna dozvoli svima
                }
                else if (igr.BrojKocke != 6)
                {
                    if (ProvjeriRazmak(igr, kopija))
                    {
                        DisableButtonsIgrac(boja);
                        DisableEnableReda(boja);
                        break;
                    }
                    else if (igr.StartIgr[i] == false) //ako nije 6-tica dozvoli samo onima u polju
                        buttonEnable[i].Enabled = true;
                    else if (igr.StartIgr[0] == true && igr.StartIgr[1] == true && igr.StartIgr[2] == true && igr.StartIgr[3] == true)
                    {
                        DisableEnableReda(boja);  //ako nije 6-tica i svi u kucici zabrani svima onog igraca koji igra
                        break;
                    }
                }
            }
            
            pictureBoxKocka.Enabled = false;
            panelKockaEnabDisab.BackColor = Color.Red;

            Kraj: ;
        }

        private bool ProvjeriRazmak(Igrac ig, int[] niz)
        {
            // provjerava razmak izmedju igraca radi otkrivanja mogucnosti kretanja, ako se ne mogu kretati figure nekog igraca vraca true
            for (int i = 0; i <= 3; i++)
                if (niz[i] + ig.BrojKocke < niz[i + 1])
                    return false;

            return true;
        }

        private bool ProvjeriSveNaTerenu(Igrac ig, bool[] niz)
        {
            // provjerava da li su na terenu sve figure nekog igraca, ako jesu vraca true
            for (int i = 0; i <= 3; i++)
                if (niz[i] == true)
                    return false;

            return true;
        }

        private void PostaviImenaIgraca(string imeIgraca, Label labelImeIgraca)
        {
            for (int i = 0; i <= imeIgraca.Length-1; i++)
            {
                if (i==imeIgraca.Length - 1)
                    labelImeIgraca.Text += imeIgraca[i].ToString();
                else
                    labelImeIgraca.Text += imeIgraca[i].ToString() + "\n";
            }
        }

        private void PostaviFigure(int[] figNiz)
        {
            int pozicija = 0;
            for (int i = 0; i < figNiz.Length; i++)
            {
                if (i == 0)
                    pozicija = 0;
                else if (i == 1)
                    pozicija = 4;
                else if (i == 2)
                    pozicija = 8;
                else if (i == 3)
                    pozicija = 12;

                if(figNiz[i] != -1)
                    for (int j = 0; j < xButton.Length; j++)
                        xButton[i][j].BackgroundImage = xBitmap[figNiz[i] + pozicija][j];
            }
        }

        private void Tabla_FormClosing(object sender, FormClosingEventArgs e)
        {
            zvukKocke.Stop();
            this.Dispose();
        }
    }
}