using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBot.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score: " + score;
            if (pipeBot.Left < -150)
            {
                pipeBot.Left = 900;
                score++;         
            }
            if(pipeTop.Left <-180)
            {
                pipeTop.Left = 920;
                score++;
            }

            if(FlappyBird.Bounds.IntersectsWith(pipeBot.Bounds) || FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || FlappyBird.Bounds.IntersectsWith(ground.Bounds) || FlappyBird.Top < -25)
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 10;
            }
            if(score > 10)
            {
                pipeSpeed = 12;
            }
            if(score > 15)
            {
                pipeSpeed = 14;
            }
            if(score > 20)
            {
                pipeSpeed = 16;
            }
            if(score > 25)
            {
                pipeSpeed = 18;
            }
            if(score > 30)
            {
                pipeSpeed = 20; 
            }         
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            GameTimer.Stop();
            ScoreText.Text += "Game over!!!";
        }
    }
}
