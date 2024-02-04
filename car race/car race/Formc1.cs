using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arcade;

namespace arcade
{
    public partial class Formc1 : Form
    {
        int roadSpeed;
        int trafficSpeed;
        int playerSpeed = 15;
        int Score;
        int carimage;

        Random rand = new Random();
        Random carposition = new Random();

        bool GoLeft, GoRight;
        
        public Formc1()
        {
            InitializeComponent();
            Resetgame();
        }

        Panel panel = new Panel();
        PictureBox car1 = new PictureBox();
        PictureBox car2 = new PictureBox();
        PictureBox explosion = new PictureBox();
        PictureBox roadtrack = new PictureBox();
        PictureBox roadtrack2 = new PictureBox();
        PictureBox player = new PictureBox();
        Label l_score = new Label();
        Label newgame = new Label();
        PictureBox Gameover = new PictureBox();
        Timer gametimer = new Timer();

        private void Formc1_load(object sender, EventArgs e)
        {
            
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.ClientSize = new Size(499, 543);
            this.BackColor = Color.Black;
            Icon = Resource.icon;
            this.Text = "car race";
            this.KeyDown += new KeyEventHandler(keyisdown);
            this.KeyUp += new KeyEventHandler(keyisup);
            this.Controls.Add(panel);
            this.Controls.Add(l_score);
            this.Controls.Add(newgame);
            panel.Controls.Add(Gameover);
            panel.Controls.Add(car1);
            panel.Controls.Add(car2);
            panel.Controls.Add(explosion);
            panel.Controls.Add(roadtrack);
            panel.Controls.Add(roadtrack2);
            panel.Controls.Add(player);



            //panel
            panel.BackColor = Color.Black;
            panel.Location = new Point(12, 12);
            panel.Name = "panel1";
            panel.Size = new Size(475, 519);
            //car1
            car1.Image = Resource.CarRed;
            car1.Location = new Point(422, 62);
            car1.Name = "car1";
            car1.SizeMode = PictureBoxSizeMode.AutoSize;
            car1.Tag = "carRight";
            //car 2
            car2.Image = Resource.carOrange;
            car2.Location = new Point(76, 62);
            car2.Name = "car2";
            car2.SizeMode = PictureBoxSizeMode.AutoSize;
            car2.Tag = "carLeft";
            
            //explosion
            explosion.Image = Resource.explosion;
            explosion.Location = new Point(76, 375);
            explosion.Name = "explosion";
            explosion.SizeMode = PictureBoxSizeMode.AutoSize;

            //player
            player.Image = Resource.carGreen;
            player.Location = new Point(210, 402);
            player.Name = "player";
            player.Size =new Size(50 , 99);
            player.SizeMode = PictureBoxSizeMode.AutoSize;

            //roadtrack
            roadtrack.Image = Resource.roadtrack;
            roadtrack.Location = new Point(0, 0);
            roadtrack.Size = new Size(475, 519);
            roadtrack.Name = "roadtrack";
            roadtrack.SizeMode = PictureBoxSizeMode.StretchImage;
            roadtrack.SendToBack();

            //roadtrack2
            roadtrack2.Image = Resource.roadtrack2;
            roadtrack2.Location = new Point(0, 519);
            roadtrack2.Size = new Size(475, 519);
            roadtrack2.Name = "roadtrack2";
            roadtrack2.SizeMode = PictureBoxSizeMode.StretchImage;
            roadtrack2.SendToBack();

            //l_Gameover
            Gameover.Location = new Point(100, 200);
            Gameover.Image = Resource.pngimg;
            Gameover.SizeMode = PictureBoxSizeMode.AutoSize;
            Gameover.BringToFront();
            Gameover.Visible = false;
            //l_score2
            l_score.Location = new Point(178, 270);
            l_score.BackColor = Color.Black;
            l_score.ForeColor = Color.White;
            l_score.Text = "Score : ";
            l_score.Font = new Font("l_score2.Font", 20f);
            l_score.BringToFront();
            l_score.Visible = false;
            
            //start new game
            newgame.Location = new Point(155, 310);
            newgame.AutoSize = true;
            newgame.BackColor = Color.Black;
            newgame.ForeColor = Color.White;
            newgame.Text = "press Enter to start new game";
            newgame.Font = new Font("l_score2.Font", 10f);
            newgame.BringToFront();
            newgame.Visible = false;

            //timer
            gametimer.Interval = 20;
            gametimer.Tick += new EventHandler(gametimerEvent);

        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                GoRight = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Resetgame();
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                GoRight = false;
            }
            
        }
        private void gametimerEvent(object sender, EventArgs e)
        {
            Score++;

            if (GoLeft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (GoRight == true && player.Right < 415)
            {
                player.Left += playerSpeed;
            }

            roadtrack.Top += roadSpeed;
            roadtrack2.Top += roadSpeed;

            if (roadtrack2.Top > 519)
            {
                roadtrack2.Top = -519;
            }
            if (roadtrack.Top > 519)
            {
                roadtrack.Top = -519;
            }

            car1.Top += trafficSpeed;
            car2.Top += trafficSpeed;

            if (car1.Top > 530)
            {
                changeAIcars(car1);
            }
            if (car2.Top > 530)
            {
                changeAIcars(car2);
            }
            if (player.Bounds.IntersectsWith(car1.Bounds) || player.Bounds.IntersectsWith(car2.Bounds))
            {
                gameover();
            }
            if (Score > 500 && Score < 2000)
            {
                roadSpeed = 20;
                trafficSpeed = 22;
            }
            if (Score > 2000)
            {
                trafficSpeed = 27;
                roadSpeed = 25;
                
            }

            


            this.Invalidate();

        }

        private void gameover()
        {
            playsound();
            gametimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;
            
            Gameover.Visible = true; 
            Gameover.Enabled = true;
            l_score.Text += Score;
            l_score.AutoSize = true;
            l_score.Visible = true;
            l_score.Enabled = true;
            newgame.Visible = true;

        }

        private void changeAIcars(PictureBox tempcar)
        {
            carimage = rand.Next(1, 9);
            switch (carimage)
            {
                case 1:
                    tempcar.Image = Resource.ambulance;
                    break;
                case 2:
                    tempcar.Image = Resource.carGrey;
                    break;
                case 3:
                    tempcar.Image = Resource.carPink;
                    break;
                case 4:
                    tempcar.Image = Resource.carOrange;
                    break;
                case 5:
                    tempcar.Image = Resource.carGreen;
                    break;
                case 6:
                    tempcar.Image = Resource.carYellow;
                    break;
                case 7:
                    tempcar.Image = Resource.CarRed;
                    break;
                case 8:
                    tempcar.Image = Resource.TruckBlue;
                    break;
                case 9:
                    tempcar.Image = Resource.TruckWhite;
                    break;


            }
            tempcar.Top = carposition.Next(100, 400) * -1;

            if ((string)tempcar.Tag == "carLeft")
            {
                tempcar.Left = carposition.Next(5, 200);
            }
            if ((string)tempcar.Tag == "carRight")
            {
                tempcar.Left = carposition.Next(245, 422);
            }
        }
        private void Resetgame()
        {
            explosion.Visible = false;
            GoLeft = false;
            GoRight = false;
            Score = 0;
            roadSpeed = 12;
            trafficSpeed = 15;
            l_score.Text = "Score : ";
            car1.Top = carposition.Next(200, 500) * -1;
            car1.Left = carposition.Next(5, 200);
            car2.Top = carposition.Next(200, 500) * -1;
            car2.Left = carposition.Next(245, 422);
            gametimer.Start();
            Gameover.Visible = false;
            l_score.Visible = false;
            newgame.Visible = false;
        }
 
        private void playsound()
        {
            SoundPlayer crash = new SoundPlayer(Resource.car_crash_sound_eefect___mp3cut_net_);
            crash.Play();
            
        }
    }
}

