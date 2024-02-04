using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using arcade;

namespace arcade
{
    public partial class Formt2 : Form
    {
        public bool com = false;
        public Formt2()
        {
            InitializeComponent();
        }

        private void player_info_Load(object sender, EventArgs e)
        {
            
        }
        
        private void name1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void B_play_Click_1(object sender, EventArgs e)
        {
            if (name2.Text.ToUpper() == "COMPUTER")
            {

            }
            Formt1.set_names(name1.Text, name2.Text);
            this.Close();
        }
        private void name2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                B_play.PerformClick();
                e.Handled = true;
            }
        }

        private void name1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                name2.Focus();
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void name2_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

    }
}
