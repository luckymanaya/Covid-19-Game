using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Covid_19_Game
{
    class Characters
    {
        //It declares the global variable
        PictureBox characterPB; 
        public Characters(int goLeft, int goTop, Bitmap Imagefile)
        {
            //This sets up the picturebox for the 'sanitizers' and the 'person'
            characterPB = new PictureBox();
            characterPB.Image = Imagefile;
            characterPB.Left = goLeft;
            characterPB.Top = goTop;

            //It makes the pictures for both the 'sanitizers' and the 'person' to fit the size of the picturebox
            characterPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //This is the public accessor for the 'sanitizers' and the 'person' 
        //so that the picturebox can be seen on the MainForm
        public PictureBox CharacterPB 
        {
            get { return characterPB; }
            set { characterPB = value; }
        }
        //Gets or sets the size of the object
        public System.Drawing.Rectangle
        Bounds
        { get; set; }

        //This is the method for moving up and down
        public void moveUpDown(int direction, int distance)
        {
            characterPB.Top = characterPB.Top + (direction * distance);
        }
        //This is the method for moving right and left
        public void moveRightLeft(int direction, int distance)
        {
            characterPB.Left = characterPB.Left + (direction * distance);
        }
    }
}

