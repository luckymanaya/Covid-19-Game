using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_19_Game
{
    public partial class MainForm : Form
    {
        public MainForm(string text)
        {
            InitializeComponent();
            lblUser.Text = text;
        }
       
        int count;
        Random rand = new Random();
        Timer gameTimer = new Timer();

        const int numberOfsanitizers = 5;
        Characters[] sanitizer = new Characters[numberOfsanitizers];
        Characters person;

        Bitmap personImage = Properties.Resources.person;
        Bitmap sanitizerImage = Properties.Resources.sanitizer;


        const int numberOfwalls = 4;
        Walls[] wall = new Walls[numberOfwalls];

        Bitmap wallImage = Properties.Resources.wall;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sanitizer.Length; i++)
            {
                int xCoordinate = rand.Next(this.Width - 50);
                int yCoordinate = rand.Next(this.Height - 50);

                sanitizer[i] = new Characters(xCoordinate, yCoordinate, sanitizerImage);
                Controls.Add(sanitizer[i].CharacterPB);
            }
            person = new Characters(200, 200, personImage);
            Controls.Add(person.CharacterPB);

            gameTimer.Enabled = true;
            gameTimer.Interval = 500;

            gameTimer.Tick += new EventHandler(timer_Tick);
            KeyDown += new KeyEventHandler(Form1_KeyDown);

            for (int i = 0; i < wall.Length; i++)
            {
                int xCoordinate = rand.Next(this.Width - 20);
                int yCoordicate = rand.Next(this.Height - 20);

                wall[i] = new Walls(xCoordinate, yCoordicate, wallImage);
                Controls.Add(wall[i].WallPB);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int right = 1;
            int left = -1;
            int up = -1;
            int down = 1;

            int Distance = 15;

            if (e.KeyCode == Keys.Up)
            {
                person.moveUpDown(up, Distance);
            }
            if (e.KeyCode == Keys.Down)
            {
                person.moveUpDown(down, Distance);
            }
            if (e.KeyCode == Keys.Right)
            {
                person.moveRightLeft(right, Distance);
            }
            if (e.KeyCode == Keys.Left)
            {
                person.moveRightLeft(left, Distance);
            }


            for (int i = 0; i < wall.Length; i++)
            {
                if (person.CharacterPB.Bounds.IntersectsWith(wall[i].WallPB.Bounds))
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        person.moveUpDown(down, Distance);
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        person.moveUpDown(up, Distance);
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        person.moveRightLeft(left, Distance);
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        person.moveRightLeft(right, Distance);
                    }
                }
            }
        }
    

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < sanitizer.Length; i++)
            {
                if (person.CharacterPB.Bounds.IntersectsWith(sanitizer[i].CharacterPB.Bounds))
                {
                    count++;
                    sanitizer[i].CharacterPB.Top = 1000;
                    sanitizer[i].CharacterPB.Left = 1000;
                    lblOutput.Text = "Sanitizers Collected: " + count;

                    if (count == numberOfsanitizers)
                    {
                        DialogResult result = MessageBox.Show("You win! Try again? ", "Congratulations! ", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (result == DialogResult.No)
                        {
                            Application.Exit();
                        }

                    }

                }
            }

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}
    




