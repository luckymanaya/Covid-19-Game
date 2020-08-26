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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }
        //Declares a bool that's initially false
        private bool buttonClicked = false; 
        private void Intro_Load(object sender, EventArgs e)
        {
        }
        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            //This reads the file as one string
            string text = System.IO.File.ReadAllText("Textfile.txt");
            //This reads each line of the file
            string[] output = System.IO.File.ReadAllLines("Textfile.txt");

            for (int i = 0; i < output.Length; i++)
            {
                //Declares f2 as the MainForm which shows up if textbox is not empty
                MainForm f2 = new MainForm(txtbxInput.Text);
                //If textbox is empty, a messagebox will show up and the MainForm won't show up
                if (string.IsNullOrWhiteSpace(txtbxInput.Text))
                {
                    //Hides f2 which is the MainForm
                    f2.Hide();
                    //Shows up when textbox is empty
                    MessageBox.Show("What's your name?");
                }
                //If the 'done' button is not selected, then a messagebox will show up and the MainForm will not show up
                else if (buttonClicked == false) 
                {
                    //Hides the MainForm
                    f2.Hide();
                    //Shows up when the 'Done' button is not selected
                    MessageBox.Show("Did you write your name?", "Select the 'Done' button");
                }
                //An 'else' code for when the textbox is not empty and the 'done' button is selected
                else
                {
                    //The MainForm will show up
                    f2.Show();
                    //This hides the current form which is the Intro form
                    Hide();
                    //This messagebox shows up once the 'play' button is clicked as it is the instructions for the game
                    MessageBox.Show("Mission: The goal is to collect all the sanitizers and most importantly... " + "\r\n" + "STAY AWAY FROM THE VIRUS!" + "\r\n" + "Use the arrow keys on the keyboard to move.", "Instructions:"); 
                }
            }
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            //Makes it true for when the 'done' button is selected 
            buttonClicked = true;
            //Declares a string to a file
            string info = txtbxInput.Text;
            //This creates a file and then writes a string to the file
            System.IO.File.WriteAllText("Textfile.txt", info);
            //If the file exists, then a new text can be appended to. If not, then it creates a new file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Textfile.txt", true)) 
            {
                //This writes a line to the file
                file.WriteLine(info); 
            }
        }
    }
}
