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
        //Declares the global variable
        PictureBox wallPB;
        public Walls(int goLeft, int goTop, Bitmap Imagefile)
        {
            //Sets up the picturebox for the 'wall'
            wallPB = new PictureBox();
            wallPB.Image = Imagefile;
            wallPB.Left = goLeft;
            wallPB.Top = goTop;
            //It makes the picture of the wall to fit the size of the picturebox
            wallPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //This is the public accessor for the picturebox for the 'wall' so that it can be seen on the MainForm
        public PictureBox WallPB 
        {
            get { return wallPB; }
            set { wallPB = value; }
        }

        //Gets or sets the size of the object
        public System.Drawing.Rectangle
        Bounds
        { get; set; }
    }
}
