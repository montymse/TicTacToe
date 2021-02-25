using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        enum states { Win, Draw, None }

        Boolean turn = true;
        int counter = 0;
        states result = states.None;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                b.Text = turn ? "X" : "O";
                b.Enabled = false;

                turn = !turn;
                counter++;

                checkgame();

            } catch {}           
        }

        private void checkgame()


        {
            if (counter==9) result = states.Draw;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && !A3.Enabled) result = states.Win;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && !B3.Enabled) result = states.Win;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && !C3.Enabled) result = states.Win;

            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && !C1.Enabled) result = states.Win;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && !C2.Enabled) result = states.Win;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && !C3.Enabled) result = states.Win;

            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && !C3.Enabled) result = states.Win;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && !C1.Enabled) result = states.Win;

            if (result==states.Draw) { MessageBox.Show("Draw"); }
            if (result==states.Win)
            {
                disableGame();
                string winner = turn ? "O" : "X";
                MessageBox.Show(winner + " wins!");
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            turn = true;
            counter = 0;
            result = states.None;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }

            }
        }

        private void disableGame()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch {}

            }
        }

        private void mouseEnter(object sender, EventArgs e)
        {
                Button b = (Button)sender;
                if (b.Enabled)
                {
                    b.Text = turn ? "X" : "O";
                }
        }

        private void mouseLeave(object sender, EventArgs e)
        {
                Button b = (Button)sender;
                if (b.Enabled)
                {
                    b.Text = "";
                }         
        }

    }
}
