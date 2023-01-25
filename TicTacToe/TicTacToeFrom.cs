using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BImAssignment1
{
    public partial class TicTacToeFrom : Form
    {
        // Taking pictures from Properties
        Image O = BImAssignment1.Properties.Resources.o;
        Image X = BImAssignment1.Properties.Resources.x;

        // Checking turn
        bool Turn = true;
        // It helps to count of turn to 9
        int TurnCount = 0;
        // for checking winneer
        bool winner = false;

        public TicTacToeFrom()
        {
            InitializeComponent();
        }

        // This method is called when user click picture box
        private void pbClick(object sender, EventArgs e)
        {
            // Casting sender's data type to PictureBox data type
            PictureBox pictureBox = (PictureBox)sender;

            // This statement help to start with 'X'
            if (Turn)
            {
                pictureBox.Image = X;
            }
            else
            {
                pictureBox.Image = O;
            }

            Turn = !Turn;
            TurnCount++;
            // selected picturebox cannot be selected again
            pictureBox.Enabled = false;

            // Everytime user click one picturebox checks whether there is a winner
            Winner();

            // If there is a winner, this statement makes this game to initialize
            if (winner || (!winner && TurnCount == 9))
                Initialize();
        }

        private void Winner()
        {
            // Check winner by hoizontal line
            if(A1.Image == A2.Image && A2.Image == A3.Image && !A1.Enabled)
            {
                winner = true;
            }
            else if (B1.Image == B2.Image && B2.Image == B3.Image && !B1.Enabled)
            {
                winner = true;
            }
            else if (C1.Image == C2.Image && C2.Image == C3.Image && !C1.Enabled)
            {
                winner = true;
            }

            // Check winner by vertical line
            else if (A1.Image == B1.Image && B1.Image == C1.Image && !A1.Enabled)
            {
                winner = true;
            }
            else if (A2.Image == B2.Image && B2.Image == C2.Image && !A2.Enabled)
            {
                winner = true;
            }
            else if (A3.Image == B3.Image && B3.Image == C3.Image && !A3.Enabled)
            {
                winner = true;
            }

            // Check winner by diagonal line
            else if (A1.Image == B2.Image && B2.Image == C3.Image && !A1.Enabled)
            {
                winner = true;
            }
            else if (A3.Image == B2.Image && B2.Image == C1.Image && !A3.Enabled)
            {
                winner = true;
            }

            // Show messagebox whether there is a winner or not
            if(winner)
            {
                if(Turn)
                    MessageBox.Show("The winner is O");
                else if (!Turn)
                    MessageBox.Show("The winner is X");
            }
            else if(!winner && TurnCount == 9)
            {
                MessageBox.Show("Draw");
            }

        }

        // This method is for initializing this game
        private void Initialize()
        {
            // Remove image
            A1.Image = null;
            A2.Image = null;
            A3.Image = null;
            B1.Image = null;
            B2.Image = null;
            B3.Image = null;
            C1.Image = null;
            C2.Image = null;
            C3.Image = null;

            // Enable picture boxes
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;

            // Initializing variables
            Turn = true;
            TurnCount = 0;
            winner = false;
        }
    }
}
