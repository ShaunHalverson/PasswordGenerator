using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        int currentPasswordLength = 0;
        Random character = new Random();

        private void passwordGenerator(int passwordLength)
        {
            String allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&$";
            String randomPassword = "";

            for(int i=0; i < passwordLength; i++)
            {
                int randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum];
            }
            passwordLabel.Text = randomPassword;
        }

        public Form1()
        {
            InitializeComponent();
            passwordLengthSlider.Minimum = 5;
            passwordLengthSlider.Maximum = 20;
            passwordGenerator(5);
        }

        private void CopyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordLabel.Text);
        }

        private void passwordLengthSlider_Scroll(object sender, EventArgs e)
        {
            PasswordLengthLabel.Text = "Password Length: " + passwordLengthSlider.Value.ToString();
            currentPasswordLength = passwordLengthSlider.Value;
            passwordGenerator(currentPasswordLength);
        }
    }
}
