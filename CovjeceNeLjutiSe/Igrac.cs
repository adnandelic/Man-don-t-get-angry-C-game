using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CovjeceNeLjutiSe
{
    class Igrac
    {
        int brojKocke;
        int[] brojacIgrac, pozicijaIgrac, pozicijaNaTabli;
        bool[] startIgr;
        bool[] pomocParking;
        Random slucajni;

        public Igrac()
        {
            brojacIgrac = new int[5] { 52, 52, 52, 52, 52 };
            pozicijaIgrac = new int[4] { 0, 0, 0, 0 };

            startIgr = new bool[4] { true, true, true, true };
            pomocParking = new bool[4] { true, true, true, true };
            slucajni = new Random();
        }

        public int BrojKocke
        {
            set { brojKocke = value; }
            get { return brojKocke; }
        }

        public bool[] StartIgr
        {
            set { startIgr = value; }
            get { return startIgr; }
        }

        public bool[] PomocParking
        {
            set { pomocParking = value; }
            get { return pomocParking; }
        }

        public int[] BrojacIgrac
        {
            set { brojacIgrac = value; }
            get { return brojacIgrac; }
        }

        public int[] PozicijaIgrac
        {
            set { pozicijaIgrac = value; }
            get { return pozicijaIgrac; }
        }

        public int[] PozicijaNaTabli
        {
            set { pozicijaNaTabli = value; }
            get { return pozicijaNaTabli; }
        }

        public void SimulacijaVrtenja(PictureBox pictBox, Image[] image6)
        {
            brojKocke = slucajni.Next(1, 7);
            pictBox.Image = image6[brojKocke];
        }
    }
}
