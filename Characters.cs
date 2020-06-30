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
        internal Point Location;

        public Characters(int goLeft, int goTop, Bitmap Imagefile)
        {
            characterPB = new PictureBox();
            characterPB.Image = Imagefile;
            characterPB.Left = goLeft;
            characterPB.Top = goTop;
            characterPB.SizeMode = PictureBoxSizeMode.StretchImage;
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

