using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Covid_19_Game
{
    class Viruses
    {

        PictureBox virusesPB;
        public Viruses(int goLeft, int goTop, Bitmap Imagefile)
        {
            virusesPB = new PictureBox();
            virusesPB.Image = Imagefile;
            virusesPB.Left = goLeft;
            virusesPB.Top = goTop;
            virusesPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public PictureBox VirusesPB
        {
            get { return virusesPB; }
            set { virusesPB = value; }
        }
        public System.Drawing.Rectangle
        Bounds
        { get; set; }

        public void moveUpDown(int direction, int distance)
        {
            virusesPB.Top = virusesPB.Top + (direction * distance);
        }
        public void moveRightLeft(int direction, int distance)
        {
            virusesPB.Left = virusesPB.Left + (direction * distance);
        }
    }
}

