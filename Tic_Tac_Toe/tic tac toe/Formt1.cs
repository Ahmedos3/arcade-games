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
    public partial class Formt1 : Form
    {
        static bool vscom = false;
        static string player1 = "";
        static string player2 = "";
        int countx = 0;
        int county = 0;
        int drew = 0;
        int Trun_count = 0;
        bool turn = true; //true for x false for y
        int turn_count;
        Label name = new Label();
        Label player_turn = new Label();
        Label game_state = new Label();
        Label x_win_count = new Label();
        Label o_win_count = new Label();

        Label Drew = new Label();

        Button[,] GameBoard = new Button[3, 3];
        Button reset = new Button();

        Panel p1 = new Panel(); //not used
        public Formt1()
        {
            InitializeComponent();
        }

        private void Formt1_Load(object sender, EventArgs e)
        {
            // game_mode g = new game_mode();
            Formt2 f2 = new Formt2();
            //Form1 f1 = new Form1();
            //g.ShowDialog();

            f2.ShowDialog();
            this.StartPosition = FormStartPosition.CenterScreen;


            this.Text = "Tic Tac Toe";
            this.Size = new Size(500, 500);
            name.Location = new Point(150, 20);
            name.Size = new Size(100, 20);
            name.Text = "Tic Tac Toe";


            x_win_count.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            x_win_count.Location = new Point(100, 250);
            x_win_count.BackColor = Color.BurlyWood;



            o_win_count.Location = new Point(200, 250);
            o_win_count.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            o_win_count.BackColor = Color.BurlyWood;




            Drew.Location = new Point(300, 250);
            Drew.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            Drew.BackColor = Color.BurlyWood;


            player_turn.Location = new Point(150, 50);
            player_turn.Size = new Size(100, 20);
            player_turn.Text = "player turn ";  // palyer's name required

            game_state.Location = new Point(50, 230);
            game_state.Size = new Size(100, 20);

            reset.Location = new Point(150, 290);
            reset.Size = new Size(100, 35);
            reset.Text = "reset";  // event required
            reset.BackColor = Color.CadetBlue;
            reset.Click += reset_click; // Add the event handler

            p1.Location = new Point(0, 0);
            p1.Size = new Size(500, 500);
            p1.BackColor = Color.BurlyWood;



            x_win_count.Text = player1 + " wins: ";
            o_win_count.Text = player2 + " wins: ";
            x_win_count.MinimumSize = new Size(146, 24);
            o_win_count.MinimumSize = new Size(146, 24);
            x_win_count.MaximumSize = new Size(146, 24);
            o_win_count.MinimumSize = new Size(146, 24);
            Drew.Text = "Draws: " + drew;

            this.Controls.Add(p1);
            this.Controls.Add(name);
            this.Controls.Add(player_turn);
            this.Controls.Add(game_state);
            this.Controls.Add(reset);
            p1.Controls.Add(name);
            p1.Controls.Add(reset);
            p1.Controls.Add(game_state);
            p1.Controls.Add(player_turn);
            p1.Controls.Add(x_win_count);
            p1.Controls.Add(o_win_count);
            p1.Controls.Add(Drew);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = new Button();
                    GameBoard[i, j].Location = new Point(130 + (j * 50), 80 + (i * 50)); // Swap i and j
                    GameBoard[i, j].Size = new Size(50, 50);
                    GameBoard[i, j].Click += button_click;
                    GameBoard[i, j].MouseEnter += button_MouseEnter;
                    GameBoard[i, j].MouseLeave += button_Mouseleave;
                    this.Controls.Add(GameBoard[i, j]);
                    p1.Controls.Add(GameBoard[i, j]);
                }
            }

        }
        public static void set_names(string Player1, string Player2)
        {
            player1 = Player1;
            player2 = Player2;

            if (player2.ToUpper() == "COMPUTER")
            {
                vscom = true;
            }


        }
        private void button_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                b.BackColor = Color.YellowGreen;

            }
            else
            {
                b.Text = "O";
                b.BackColor = Color.DarkSeaGreen;
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;


            if (!turn && vscom)
            {
                computer_move();
            }


            check_for_winner();
        }
        private void computer_move()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = Win_or_Lose("O"); //look for win
            if (move == null)
            {
                move = Win_or_Lose("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }//end if
                }//end if
            }//end if

            move.PerformClick();
        }
        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }
        private Button Win_or_Lose(string mark)
        {
            // Check rows for a winning move or a blocking move
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i, 0].Text == GameBoard[i, 1].Text &&
                    GameBoard[i, 1].Text == mark &&
                    GameBoard[i, 2].Text == "" &&
                    GameBoard[i, 2].Enabled) // Check if the spot is empty and enabled
                {
                    return GameBoard[i, 2]; // Return the button for the winning/blocking move
                }
                else if (GameBoard[i, 1].Text == GameBoard[i, 2].Text &&
                         GameBoard[i, 1].Text == mark &&
                         GameBoard[i, 0].Text == "" &&
                         GameBoard[i, 0].Enabled)
                {
                    return GameBoard[i, 0]; // Return the button for the winning/blocking move
                }
                else if (GameBoard[i, 0].Text == GameBoard[i, 2].Text &&
                         GameBoard[i, 0].Text == mark &&
                         GameBoard[i, 1].Text == "" &&
                         GameBoard[i, 1].Enabled)
                {
                    return GameBoard[i, 1]; // Return the button for the winning/blocking move
                }
            }

            // Check columns for a winning move or a blocking move
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[0, i].Text == GameBoard[1, i].Text &&
                    GameBoard[1, i].Text == mark &&
                    GameBoard[2, i].Text == "" &&
                    GameBoard[2, i].Enabled) // Check if the spot is empty and enabled
                {
                    return GameBoard[2, i]; // Return the button for the winning/blocking move
                }
                else if (GameBoard[1, i].Text == GameBoard[2, i].Text &&
                         GameBoard[1, i].Text == mark &&
                         GameBoard[0, i].Text == "" &&
                         GameBoard[0, i].Enabled)
                {
                    return GameBoard[0, i]; // Return the button for the winning/blocking move
                }
                else if (GameBoard[0, i].Text == GameBoard[2, i].Text &&
                         GameBoard[0, i].Text == mark &&
                         GameBoard[1, i].Text == "" &&
                         GameBoard[1, i].Enabled)
                {
                    return GameBoard[1, i]; // Return the button for the winning/blocking move
                }
            }

            // Check main diagonal
            if (GameBoard[0, 0].Text == GameBoard[1, 1].Text &&
                GameBoard[1, 1].Text == mark && GameBoard[2, 2].Text == "" &&
                !GameBoard[0, 0].Enabled)
            {
                return GameBoard[2, 2];
            }

            // Check secondary diagonal
            if (GameBoard[0, 2].Text == GameBoard[1, 1].Text &&
                GameBoard[1, 1].Text == mark && GameBoard[2, 0].Text == "" &&
                !GameBoard[0, 2].Enabled)
            {
                return GameBoard[2, 0];
            }


            return null;

        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "X";
                    b.BackColor = Color.YellowGreen;

                }
                else
                {
                    b.Text = "O";
                    b.BackColor = Color.DarkSeaGreen;
                }
            }
        }
        private void button_Mouseleave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "";
                    b.BackColor = Color.Empty;

                }
                else
                {
                    b.Text = "";
                    b.BackColor = Color.Empty;
                }
            }
        }
        private void reset_click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j].Enabled = true;
                    GameBoard[i, j].Text = "";
                    GameBoard[i, j].BackColor = default(Color);

                }
            }
            countx = 0;
            county = 0;
            drew = 0;
            ResetGame();
        }
        private Button look_for_corner()
        {
            if (GameBoard[0, 0].Text == "")
                return GameBoard[0, 0];
            if (GameBoard[0, 2].Text == "")
                return GameBoard[0, 2];
            if (GameBoard[2, 0].Text == "")
                return GameBoard[2, 0];
            if (GameBoard[2, 2].Text == "")
                return GameBoard[2, 2];

            return null;
        }
        private void ResetGame()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j].Enabled = true;
                    GameBoard[i, j].Text = "";
                    GameBoard[i, j].BackColor = default(Color);

                }
            }
            turn_count = 0;
        }
        private void check_for_winner()
        {
            string winner = "";

            // Check horizontal lines
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i, 0].Text == GameBoard[i, 1].Text &&
                    GameBoard[i, 1].Text == GameBoard[i, 2].Text &&
                    !GameBoard[i, 0].Enabled)
                {
                    winner = GameBoard[i, 0].Text;
                    break;
                }
            }

            // Check vertical lines
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[0, i].Text == GameBoard[1, i].Text &&
                    GameBoard[1, i].Text == GameBoard[2, i].Text &&
                    !GameBoard[0, i].Enabled)
                {
                    winner = GameBoard[0, i].Text;

                    break;
                }
            }

            // Check main diagonal
            if (GameBoard[0, 0].Text == GameBoard[1, 1].Text &&
                GameBoard[1, 1].Text == GameBoard[2, 2].Text &&
                !GameBoard[0, 0].Enabled)
            {
                winner = GameBoard[0, 0].Text;
            }

            // Check secondary diagonal
            if (GameBoard[0, 2].Text == GameBoard[1, 1].Text &&
                GameBoard[1, 1].Text == GameBoard[2, 0].Text &&
                !GameBoard[0, 2].Enabled)
            {
                winner = GameBoard[0, 2].Text;
            }
            if (!string.IsNullOrEmpty(winner))
            {
                winner = winner.ToUpper(); // Convert to uppercase
                if (winner == "X")
                {
                    countx++;
                }
                else if (winner == "O")
                {
                    county++;
                }
                if (winner == "X")
                {
                    winner = player1;
                }
                else winner = player2;
                x_win_count.Text = player1 + " wins: ";
                o_win_count.Text = player2 + " wins: ";

                MessageBox.Show(winner + " wins!");
                ResetGame();
            }
            else if (turn_count == 9)
            {
                MessageBox.Show("It's a draw");
                drew++;


                Drew.Text = "Draws: " + drew;

                ResetGame();
            }

        }
    }
}
