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

        private bool buttonClicked = false;
        private void Intro_Load(object sender, EventArgs e)
        {
        }
        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText("Textfile.txt");
            string[] output = System.IO.File.ReadAllLines("Textfile.txt");

            for (int i = 0; i < output.Length; i++)
            {
                MainForm f2 = new MainForm(txtbxInput.Text);
                if (string.IsNullOrWhiteSpace(txtbxInput.Text))
                {
                    f2.Hide();
                    MessageBox.Show("What's your name?");
                }
                else if (buttonClicked == false)
                {
                    f2.Hide();
                    MessageBox.Show("Did you write your name?");
                }
                else
                {
                    f2.Show();
                    Hide();
                }
            }
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            buttonClicked = true;
            string info = txtbxInput.Text;
            System.IO.File.WriteAllText("Textfile.txt", info);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Textfile.txt", true))
            {
                file.WriteLine(info);
            }
        }
    }
}
