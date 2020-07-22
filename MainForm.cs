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
            lblUser.Text = ("Name: " + text);

        }
        int count;
        Random rand = new Random();
        Timer gameTimer = new Timer();

        const int numberOfsanitizers = 5;
        Characters[] sanitizer = new Characters[numberOfsanitizers];
        Characters person;

        Bitmap personImage = Properties.Resources.person;
        Bitmap sanitizerImage = Properties.Resources.sanitizer;

        const int numberOfwalls = 8;
        Walls[] wall = new Walls[numberOfwalls];

        Bitmap wallImage = Properties.Resources.wall;

        const int numberOfvirus = 3;
        Viruses[] virus = new Viruses[numberOfvirus];

        Bitmap virusImage = Properties.Resources.virus;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sanitizer.Length; i++)
            {
                int xCoordinate = rand.Next(this.Width - 100);
                int yCoordinate = rand.Next(this.Height - 100);

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
                wall[0] = new Walls(40, 100, wallImage);
                wall[1] = new Walls(40, 250, wallImage);
                wall[2] = new Walls(300, 200, wallImage);
                wall[3] = new Walls(300, 350, wallImage);
                wall[4] = new Walls(550, 100, wallImage);
                wall[5] = new Walls(550, 250, wallImage);
                wall[6] = new Walls(750, 200, wallImage);
                wall[7] = new Walls(750, 350, wallImage);

                Controls.Add(wall[i].WallPB);
            }
            for (int i = 0; i < virus.Length; i++)
            {
                virus[0] = new Viruses(50, 150, virusImage);
                virus[1] = new Viruses(200, 350, virusImage);
                virus[2] = new Viruses(500, 150, virusImage);

                Controls.Add(virus[i].VirusesPB);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int right = 1;
            int left = -1;
            int up = -1;
            int down = 1;

            int Distance = 15;

            if (e.KeyCode == Keys.Up)//If user wants to go up, then 'person' moves up
            {
                person.moveUpDown(up, Distance); //'person' moves up
            }
            if (e.KeyCode == Keys.Down)//If user wants to go down, then 'person' moves down
            {
                person.moveUpDown(down, Distance);
            }
            if (e.KeyCode == Keys.Right)//If user wants to go right, then 'person' moves right
            {
                person.moveRightLeft(right, Distance);
            }
            if (e.KeyCode == Keys.Left)//If user wants to go left, then 'person' moves left
            {
                person.moveRightLeft(left, Distance);
            }

            //These are the codes for when the 'person' intersects with the 'wall'
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
            for (int i = 0; i < virus.Length; i++)
            {
                if (person.CharacterPB.Bounds.IntersectsWith(virus[i].VirusesPB.Bounds))
                {
                    gameTimer.Stop();//Timer stops
                    lblOutput.Text = ("Game Over!");//Shows that the game is over on the label once the 'person' intersects with the 'virus'

                    //This messagebox will show up when the game is over and that it also provides the user a 'yes' or 'no' options
                    DialogResult result = MessageBox.Show("You lose! Try again? ", "GAME OVER! ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) //If user clicks 'yes', then program restarts
                    {
                     Application.Restart(); //Program restarts
                    }
                     else if (result == DialogResult.No) //If user clicks 'no', then program stops running
                    {
                            Application.Exit();//Program stops running
                    }
                    
                }
            }
            for (int i = 0; i < sanitizer.Length; i++)
            {
                if (person.CharacterPB.Bounds.IntersectsWith(sanitizer[i].CharacterPB.Bounds))
                {
                    count++;//Stores the number of sanitizers collected
                    sanitizer[i].CharacterPB.Top = 1000;
                    sanitizer[i].CharacterPB.Left = 1000;
                    lblOutput.Text = ("Sanitizers Collected: " + count);//Shows the number of sanitizers collected during the game

                    if (count == numberOfsanitizers) //If number of sanitizers collected by the user is equal to the number of sanitizers in the game, then user wins which is shown by a messagebox and a label
                    {
                        lblOutput.Text = ("Good job!"); //Shows up when the user collects all sanitizers, indicating that the user won
                        //This messagebox shows up when the user wins and it also provides a 'yes' or 'no' options 
                        DialogResult result = MessageBox.Show("You win! Try again? ", "Congratulations! ", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)//If user clicks 'yes', then program restarts
                        {
                            Application.Restart(); //Program restarts
                        }
                        else if (result == DialogResult.No) //If user clicks 'no', then program stops running
                        {
                            Application.Exit();//Program stops running
                        }

                    }

                }
            }
        }

    }
}
    




