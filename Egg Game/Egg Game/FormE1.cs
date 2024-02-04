using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arcade.Properties;

namespace arcade
{
    public partial class FormE1 : Form
    {
        
        Label labelscore = new Label();
        Label labelmissed = new Label();
        PictureBox eggs1 = new PictureBox();
        PictureBox eggs2 = new PictureBox();
        PictureBox eggs3 = new PictureBox();
        PictureBox splash = new PictureBox();
        PictureBox player = new PictureBox();
        Timer timer = new Timer();

        bool goLeft, goRight;
        int speed = 6;
        int score = 0;
        int missed= 0;
        Random rndX = new Random();
        Random rndY = new Random();


        public FormE1()
        {
            InitializeComponent();
            RestartGame();
        }
        

        private void FormE1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
            this.Controls.Add(labelscore);
            this.Controls.Add(labelmissed);
            this.Controls.Add(eggs1);
            this.Controls.Add(eggs2);
            this.Controls.Add(eggs3);
            this.Controls.Add(player);
            
            

            this.Size = new Size(600, 670);
            this.BackColor = Color.SandyBrown;
            this.Text = "Save The Eggs Game";
            this.MaximizeBox = false;

            labelscore.Text = "Score : 0";
            labelscore.Font = new Font("Bold", 14);
            labelscore.Location = new Point(30, 20);
  
            labelmissed.Text = " Missed : 0";
            labelmissed.Font = new Font("Bold", 14);
            labelmissed.Location = new Point(450, 20);
       
            eggs1.Size = new Size(40, 50);
            eggs1.Location = new Point(100, 120);
            eggs1.Image = Resources.egg;
            eggs1.SizeMode = PictureBoxSizeMode.StretchImage;
            eggs1.Tag = "eggs";

            eggs2.Size = new Size(40, 50);
            eggs2.Location = new Point(250, 120);
            eggs2.Image = Resources.egg;
            eggs2.SizeMode = PictureBoxSizeMode.StretchImage;
            eggs2.Tag = "eggs";

            eggs3.Size = new Size(40, 50);
            eggs3.Location = new Point(400, 120);
            eggs3.Image = Resources.egg;
            eggs3.SizeMode = PictureBoxSizeMode.StretchImage;
            eggs3.Tag = "eggs";

            player.Size = new Size(80, 80);
            player.Location = new Point(250, 550);
            player.Image = Resources.chicken_normal;
            player.SizeMode = PictureBoxSizeMode.StretchImage;

            timer.Interval = 20;
            timer.Tick += new EventHandler(GameTimer);
            timer.Enabled = true;

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                goLeft=true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight=true;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void GameTimer(object sender, EventArgs e)
        {
            labelscore.Text = "Score : " + score;
            labelmissed.Text = " Missed : " + missed;
            if (goLeft == true && player.Left > 5)
            {
                player.Left -= 14;
                player.Image = Resources.chicken_normal2;
            }
            if (goRight == true && player.Left + player.Width < 600)
            {
                player.Left += 14;
                player.Image = Resources.chicken_normal;
            }


            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && ((String)control.Tag == "eggs"))
                {
                    control.Top += speed;


                    if (control.Top + control.Height > this.ClientSize.Height)
                    {
                        splash.Image = Resources.splash;
                        splash.SizeMode=PictureBoxSizeMode.StretchImage;
                        splash.Location = control.Location;
                        splash.Size =new Size (40,50);
                        splash.BackColor = Color.Transparent;

                        this.Controls.Add(splash);


                        control.Top = rndX.Next(80, 300) * -1;
                        control.Left = rndX.Next(5, 595);
                        missed += 1;
                        player.Image= Resources.chicken_hurt;
                    }

                    if (player.Bounds.IntersectsWith(control.Bounds))
                    {

                        control.Top = rndX.Next(80, 300) * -1;
                        control.Left = rndX.Next(5, 595);
                        score += 1;
                    }
                }
            }
            if (score > 10)
            {
                speed = 10;
            }
            if (missed > 4) 
            {
                timer.Stop();
                MessageBox.Show("Game Over!");
                RestartGame();
            }

        }
        private void RestartGame()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && ((String)control.Tag=="eggs")) 
                {
                    control.Top = rndY.Next(80, 300) * -1;
                    control.Left = rndX.Next(5, 595);
                }
            }
            player.Left = this.Width / 2;
            player.Image= Resources.chicken_normal;
            score = 0;
            missed = 0;
            speed = 6;
            goLeft = false;
            goRight = false;
            timer.Start();
        }
    }
}
