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
        //Declares the string for the name of the user which will show up on the MainForm
        public MainForm(string text) 
        {
            InitializeComponent();
            //This shows up on the left side of the form as an output for the user's name
            lblUser.Text = ("Name: " + text); 

        }
        //Declares the integer
        int count;
        //Makes a new instance of a random class
        Random rand = new Random();
        //Makes a new instance of the timer
        Timer gameTimer = new Timer();

        //It declares the number of sanitizers for the program which is 5
        const int numberOfsanitizers = 5;
        //An array for the 'sanitizer'
        Characters[] sanitizer = new Characters[numberOfsanitizers]; 
        Characters person;

        //To find the resources for the 'person'
        Bitmap personImage = Properties.Resources.person;
        //To find the resources for the 'sanitizer'
        Bitmap sanitizerImage = Properties.Resources.sanitizer;

        //It declares the number of walls for the program which is 8
        const int numberOfwalls = 8;
        //An array for the 'walls'
        Walls[] wall = new Walls[numberOfwalls];

        //To find the resources for the 'wall'
        Bitmap wallImage = Properties.Resources.wall;

        //It declares the number of viruses on the program which is 3
        const int numberOfvirus = 3;
        //An array for the 'virus'
        Viruses[] virus = new Viruses[numberOfvirus];

        //To find the resources for the 'virus'
        Bitmap virusImage = Properties.Resources.virus; 
        private void Form1_Load(object sender, EventArgs e)
        {
            //This loops the 'sanitizers' and in this case, there would be 5 sanitizers
            for (int i = 0; i < sanitizer.Length; i++)
            {
                //This randomizes the 'sanitizers' and it also deletes the number of pixels 
                //so that the 'sanitizers' stays inside the 'MainForm'
                int xCoordinate = rand.Next(this.Width - 150);
                int yCoordinate = rand.Next(this.Height - 150);

                //Sets up the location for the 'sanitizer'
                sanitizer[i] = new Characters(xCoordinate, yCoordinate, sanitizerImage); 

                Controls.Add(sanitizer[i].CharacterPB);
            }
            //Sets up the location for the 'person'
            person = new Characters(200, 200, personImage);
            Controls.Add(person.CharacterPB);

            //Enables the timer
            gameTimer.Enabled = true; 
            gameTimer.Interval = 500;

            //This creates the timer event
            gameTimer.Tick += new EventHandler(timer_Tick);

            //This creates the keyDown event
            KeyDown += new KeyEventHandler(Form1_KeyDown);


            for (int i = 0; i < wall.Length; i++)
            {
                //Sets up the locations for each 'wall'
                wall[0] = new Walls(50, 100, wallImage);
                wall[1] = new Walls(30, 250, wallImage);
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
                //Sets up the locations for each 'virus'
                virus[0] = new Viruses(50, 150, virusImage);
                virus[1] = new Viruses(200, 350, virusImage);
                virus[2] = new Viruses(500, 150, virusImage);

                Controls.Add(virus[i].VirusesPB);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Declares the integers for the directions
            int right = 1;
            int left = -1;
            int up = -1;
            int down = 1;

            //Declares the integer for the 'distance'
            int Distance = 15; 

            //These are the control keys for the 'person': 'Up' arrow - up, 'Down' arrow - down, 
            //'Right' arrow - right, 'Left' arrow - left
            //If user wants to go up, then 'person' moves up
            if (e.KeyCode == Keys.Up)
            {
                //'person' moves up
                person.moveUpDown(up, Distance); 
            }
            //If user wants to go down, then 'person' moves down
            if (e.KeyCode == Keys.Down)
            {
                //'person' moves down
                person.moveUpDown(down, Distance);
            }
            //If user wants to go right, then 'person' moves right
            if (e.KeyCode == Keys.Right)
            {
                //'person' moves right
                person.moveRightLeft(right, Distance);
            }
            //If user wants to go left, then 'person' moves left
            if (e.KeyCode == Keys.Left)
            {
                //'person' moves left
                person.moveRightLeft(left, Distance);
            }

            //These are the codes for when the 'person' intersects with the 'wall'
            for (int i = 0; i < wall.Length; i++)
            {
                if (person.CharacterPB.Bounds.IntersectsWith(wall[i].WallPB.Bounds))
                {
                    //If the 'person' goes up and intersects the 'wall', then it will have to go to other directions
                    if (e.KeyCode == Keys.Up)
                    {
                        person.moveUpDown(down, Distance);
                    }
                    //If the 'person' goes down and intersects the 'wall', then it will have to go to other directions
                    if (e.KeyCode == Keys.Down)
                    {
                        person.moveUpDown(up, Distance);
                    }
                    //If the 'person' goes right and intersects the 'wall', then it will have to go to other directions
                    if (e.KeyCode == Keys.Right)
                    {
                        person.moveRightLeft(left, Distance);
                    }
                    //If the 'person' goes left and intersects the 'wall', then it will have to go to other directions
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
                if (person.CharacterPB.Bounds.IntersectsWith(virus[i].VirusesPB.Bounds)) //If the 'person' intersects the 'virus', then game is over
                {
                    //Timer stops
                    gameTimer.Stop();
                    //Shows that the game is over on the label once the 'person' intersects with the 'virus'
                    lblOutput.Text = ("Game Over!");

                    //This messagebox will show up when the game is over and that it also provides the user a 'yes' or 'no' options
                    DialogResult result = MessageBox.Show("You lose! Try again? ", "GAME OVER! ", MessageBoxButtons.YesNo);
                    //If user clicks 'yes', then program restarts
                    if (result == DialogResult.Yes) 
                    {
                        //Program restarts
                        Application.Restart(); 
                    }
                    //If user clicks 'no', then program stops running
                    else if (result == DialogResult.No)
                    {
                        //Program stops running
                        Application.Exit();
                    }
                    
                }
            }
            for (int i = 0; i < sanitizer.Length; i++)
            {
                //If 'person' intersects with the 'sanitizer', then it is collected inside the 'count' variable
                if (person.CharacterPB.Bounds.IntersectsWith(sanitizer[i].CharacterPB.Bounds))
                {
                    //This stores each 'sanitizer' that's collected by the 'person'
                    count++;
                    sanitizer[i].CharacterPB.Top = 1000;
                    sanitizer[i].CharacterPB.Left = 1000;
                    //Shows the number of sanitizers collected during the game
                    lblOutput.Text = ("Sanitizers Collected: " + count);

                    //If number of sanitizers collected by the user is equal to the number of sanitizers in the game, 
                    //then user wins which is shown by a messagebox and a label
                    if (count == numberOfsanitizers) 
                    {
                        //Shows up when the user collects all sanitizers, indicating that the user won
                        lblOutput.Text = ("Good job!"); 

                        //This messagebox shows up when the user wins and it also provides a 'yes' or 'no' options 
                        DialogResult result = MessageBox.Show("You win! Try again? ", "Congratulations! ", MessageBoxButtons.YesNo);
                        //If user clicks 'yes', then program restarts
                        if (result == DialogResult.Yes)
                        {
                            //Program restarts
                            Application.Restart(); 
                        }
                        //If user clicks 'no', then program stops running
                        else if (result == DialogResult.No)
                        {
                            //Program stops running
                            Application.Exit();
                        }

                    }

                }
            }
        }

    }
   
}
    




