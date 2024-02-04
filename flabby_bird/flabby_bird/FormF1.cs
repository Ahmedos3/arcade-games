using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arcade
{
    public partial class FormF1 : Form
    {
        public FormF1()
        {
            InitializeComponent();
            //timer1.Start();
        }

        int gravity = 20;
        int speed = 15;
        Random r = new Random();
        int score = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += gravity;
            pictureBox3.Left -= speed;
            pictureBox2.Left -= speed;
            pictureBox5.Left -= speed;
            pictureBox6.Left -= speed;

            label1.Text = $"your score is{score}";
            if (pictureBox3.Left < 0)
            {
                pictureBox3.Left = r.Next(300, 700);
                score++;
            }
            //if (pictureBox5.Left < 0)
            //{
            //    pictureBox6.Left = r.Next(300, 500);
            //    score++;
            //}
            //if (pictureBox6.Left < 0)
            //{
            //    pictureBox6.Left = r.Next(300, 500);
            //    score++;
            //}
            if (pictureBox2.Left < 0)
            {
                pictureBox2.Left = r.Next(300, 700);
                score++;
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) ||
                pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds) ||
                    pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds)
                     //pictureBox1.Bounds.IntersectsWith(pictureBox5.Bounds) ||
                     //pictureBox1.Bounds.IntersectsWith(pictureBox6.Bounds)

                     )
            {
                timer1.Stop();
                label1.Text = $"game over your score is{score}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    timer1.Start();
                    pictureBox1.Top = 50;
                    pictureBox3.Left = r.Next(500, 700);
                    pictureBox2.Left = r.Next(500, 700);
                    pictureBox5.Left = r.Next(300, 500);
                    pictureBox6.Left = r.Next(300, 500);
                    score = 0;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
            if (pictureBox1.Top < 2)
            {
                pictureBox1.Top = 15;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
