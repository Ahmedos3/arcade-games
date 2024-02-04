using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arcade;

namespace arcade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox tic_tac_toe = new PictureBox();
        PictureBox car = new PictureBox();
        PictureBox Egg = new PictureBox();
        PictureBox flabbyBird = new PictureBox();


        private void Form1_Load(object sender, EventArgs e)
        { 
            this.BackColor = Color.DarkGray;
            this.Size = new Size(650, 670);
            this.Text = "Arcede Games";
            this.Icon = Resource.arcede_icon;
            this.Controls.Add(tic_tac_toe);
            this.Controls.Add(car);
            this.Controls.Add(Egg);
            this.Controls.Add(flabbyBird);

            

            tic_tac_toe.Location = new Point(10, 10);
            tic_tac_toe.Size = new Size(300, 300);
            tic_tac_toe.SizeMode = PictureBoxSizeMode.StretchImage;
            tic_tac_toe.Image = Resource.tic_tac_toe;
            tic_tac_toe.Click += new EventHandler(tic_tac_toe_click);

            car.Location = new Point(320, 10);
            car.Size = new Size(300, 300);
            car.SizeMode = PictureBoxSizeMode.StretchImage;
            car.Image = Resource.car;
            car.Click += new EventHandler(car_click);

            Egg.Location = new Point(320, 320);
            Egg.Size = new Size(300, 300);
            Egg.SizeMode = PictureBoxSizeMode.StretchImage;
            Egg.Image = Resource.Egg;
            Egg.Click += new EventHandler(Egg_click);


            flabbyBird.Location = new Point(10, 320);
            flabbyBird.Size = new Size(300, 300);
            flabbyBird.SizeMode = PictureBoxSizeMode.StretchImage;
            flabbyBird.Image = Resource.flappybird1;
            flabbyBird.Click += new EventHandler(Flabbybird_click);

        }
        private void tic_tac_toe_click(object sender, EventArgs e)
        {
            this.Hide();
            Formt1 tic_tac_toe = new Formt1();
            tic_tac_toe.ShowDialog();
            this.Close();

        }

        private void car_click (object sender, EventArgs e)
        {
            this.Hide();
            Formc1 car = new Formc1();
            car.ShowDialog();
            this.Close();
        }

        private void Egg_click(object sender, EventArgs e)
        {
            this.Hide();
            FormE1 Egg = new FormE1();
            Egg.ShowDialog();
            this.Close();
        }

        private void Flabbybird_click(object sender, EventArgs e)
        {
            this.Hide();
            FormF1 flabbyBird = new FormF1();
            flabbyBird.ShowDialog();
            this.Close();

        }
    }
}
