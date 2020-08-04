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

        private bool buttonClicked = false; //Declares a bool that's initially false
        private void Intro_Load(object sender, EventArgs e)
        {
        }
        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText("Textfile.txt");//This reads the file as one string
            string[] output = System.IO.File.ReadAllLines("Textfile.txt");//This reads each line of the file

            for (int i = 0; i < output.Length; i++)
            {
                MainForm f2 = new MainForm(txtbxInput.Text);//Declares f2 as the MainForm which shows up if textbox is not empty
                if (string.IsNullOrWhiteSpace(txtbxInput.Text))//If textbox is empty, a messagebox will show up and the MainForm won't show up
                {
                    f2.Hide();//Hides f2 which is the MainForm
                    MessageBox.Show("What's your name?");//Shows up when textbox is empty
                }
                else if (buttonClicked == false) //If the 'done' button is not selected, then a messagebox will show up and the MainForm will not show up
                {
                    f2.Hide();//Hides the MainForm
                    MessageBox.Show("Did you write your name?", "Select the 'Done' button");//Shows up when the 'Done' button is not selected
                }
                else //An 'else' code for when the textbox is not empty and the 'done' button is selected
                {
                    f2.Show(); //The MainForm will show up
                    Hide();//This hides the current form which is the Intro form
                    //This messagebox shows up once the 'play' button is clicked as it is the instructions for the game
                    MessageBox.Show("Mission: The goal is to collect all the sanitizers and most importantly... " + "\r\n" + "STAY AWAY FROM THE VIRUS!" + "\r\n" + "Use the arrow keys on the keyboard to move.", "Instructions:"); 
                }
            }
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            buttonClicked = true;//Makes it true for when the 'done' button is selected 
            string info = txtbxInput.Text; //Declares a string to a file
            System.IO.File.WriteAllText("Textfile.txt", info);//This creates a file and then writes a string to the file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Textfile.txt", true)) //If the file exists, then a new text can be appended to. If not, then it creates a new file
            {
                file.WriteLine(info); //This writes a line to the file
            }
        }
    }
}
