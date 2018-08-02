using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;

namespace TicTacToeGui
{
    public partial class Form1 : Form
    {
        int turn = 1;
        string winner = "";
        
        public Form1(string gameID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            GameIDLabel.Text += gameID;

        }

        public void turnCounter()
        {
            if (turn % 2 != 0)
            {
                lblTurn.Text = "Player X";
            }
            else
            {
                lblTurn.Text = "Player O";
            }
        }

        public void isWInner(string player)
        {
            if(btn0.Text == player && btn1.Text == player && btn2.Text == player)
            {
                MessageBox.Show(player + " is the winner");
            }
            else if(btn0.Text == player && btn3.Text == player && btn6.Text == player)
            {
                MessageBox.Show(player + " is the winner");
            }
            else if(btn0.Text == player && btn4.Text == player && btn8.Text == player)
            {
                MessageBox.Show(player + " is the winner");
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if(btn0.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn0.Text = "X";
                    winner = "X";
                }
                else
                {
                    btn0.Text = "O";
                    winner = "O";
                }
                turn++;

                isWInner(winner);
            }
            else
            {
                btn0.Text = btn0.Text;
            }

            turnCounter();
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn1.Text = "X";
                }
                else
                {
                    btn1.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn1.Text = btn1.Text;
            }
            turnCounter();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn2.Text = "X";
                }
                else
                {
                    btn2.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn2.Text = btn2.Text;
            }
            turnCounter();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn3.Text = "X";
                }
                else
                {
                    btn3.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn3.Text = btn3.Text;
            }
            turnCounter();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn4.Text = "X";
                }
                else
                {
                    btn4.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn4.Text = btn4.Text;
            }
            turnCounter();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn5.Text = "X";
                }
                else
                {
                    btn5.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn5.Text = btn5.Text;
            }
            turnCounter();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn6.Text = "X";
                }
                else
                {
                    btn6.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn6.Text = btn6.Text;
            }
            turnCounter();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn7.Text = "X";
                }
                else
                {
                    btn7.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn7.Text = btn7.Text;
            }
            turnCounter();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text == "")
            {
                if (turn % 2 != 0)
                {
                    btn8.Text = "X";
                }
                else
                {
                    btn8.Text = "O";
                }
                turn++;
                isWInner(winner);
            }
            else
            {
                btn8.Text = btn8.Text;
            }
            turnCounter();
        }
    }
}
