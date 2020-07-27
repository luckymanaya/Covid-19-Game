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

        PictureBox virusesPB; //Declares the global variable
        public Viruses(int goLeft, int goTop, Bitmap Imagefile)
        {
            //Sets up the picturebox for the 'virus'
            virusesPB = new PictureBox();
            virusesPB.Image = Imagefile;
            virusesPB.Left = goLeft;
            virusesPB.Top = goTop;
            virusesPB.SizeMode = PictureBoxSizeMode.StretchImage;//It makes the image for the 'virus' to fit the size of the picturebox by stretching or shrinking it
        }
        public PictureBox VirusesPB //Public accessor for the picturebox for the 'virus' so that it can be seen on the MainForm
        {
            get { return virusesPB; }
            set { virusesPB = value; }
        }

        //Gets or sets the size of the object
        public System.Drawing.Rectangle
        Bounds
        { get; set; }
    }
}
    


