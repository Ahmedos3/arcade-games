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
    public partial class game_mode : Form
    {
        public bool bClick = false;
        public game_mode()
        {
            InitializeComponent();
        }

        private void Muliti_Click(object sender, EventArgs e)
        {
            game_mode gamemode = new game_mode();
            Formt2 f2 = new Formt2();
            f2.ShowDialog();

            bClick = true;

        }
        private void game_mode_Load(object sender, EventArgs e)
        {
            //this.Close();
            if (bClick)
            {

                this.Hide();
                this.Close();

            }
        }

        private void computerMode_Click_1(object sender, EventArgs e)
        {

        }

    }
}
