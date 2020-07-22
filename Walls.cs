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
        PictureBox wallPB;//It's for displaying an image
        public Walls(int goLeft, int goTop, Bitmap Imagefile)
        {
            wallPB = new PictureBox();//Makes a new instance of the picturebox
            wallPB.Image = Imagefile;//Gets or sets the chosen picture for the wall from the picturebox
            wallPB.Left = goLeft;
            wallPB.Top = goTop;
            wallPB.SizeMode = PictureBoxSizeMode.StretchImage;//It makes the picture of the wall to fit the size of the picturebox
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
