using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Covid_19_Game
{
    class Walls
    {
        PictureBox wallPB;
        public Walls(int goLeft, int goTop, Bitmap Imagefile)
        {
            wallPB = new PictureBox();
            wallPB.Image = Imagefile;
            wallPB.Left = goLeft;
            wallPB.Top = goTop;
            wallPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }
            public PictureBox WallPB
        {
            get { return wallPB; }
            set { wallPB = value; }
        }
        public System.Drawing.Rectangle
        Bounds
        { get; set; }
    }
}
