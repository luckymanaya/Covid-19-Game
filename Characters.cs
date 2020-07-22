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
        PictureBox characterPB;
        public Characters(int goLeft, int goTop, Bitmap Imagefile)
        {
            characterPB = new PictureBox();//Makes a new instance of the picturebox
            characterPB.Image = Imagefile;//Gets or set the picture of the sanitizer and the person from the picturebox
            characterPB.Left = goLeft;
            characterPB.Top = goTop;
            characterPB.SizeMode = PictureBoxSizeMode.StretchImage;//It makes the pictures for both the sanitizers and the person to fit the size of the picturebox
        }
        public PictureBox CharacterPB
        {
            get { return characterPB; }
            set { characterPB = value; }
        }
        public System.Drawing.Rectangle
        Bounds
        { get; set; }

        public void moveUpDown(int direction, int distance)
        {
            characterPB.Top = characterPB.Top + (direction * distance);
        }
        public void moveRightLeft(int direction, int distance)
        {
            characterPB.Left = characterPB.Left + (direction * distance);
        }
    }
}

