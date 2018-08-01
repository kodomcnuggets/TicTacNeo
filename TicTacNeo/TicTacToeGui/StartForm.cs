using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGui
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gameID = txtGameId.Text;
            var gameBoard = new Form1(txtGameId.Text);
            if(Application.OpenForms[gameBoard.Name] == null)
            {
                gameBoard.Show();
            }
            else
            {
                Application.OpenForms[gameBoard.Name].Activate();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }
    }
}
