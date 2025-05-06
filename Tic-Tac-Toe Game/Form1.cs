using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
     
        stGame game;
        enPlayer PlayerTurn = enPlayer.ePlayer1;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.Gray;
            
            Pen pen=new Pen(Black);
            pen.Width=10;

            pen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen,400,100,400,400);
            e.Graphics.DrawLine(pen, 520, 100, 520, 400);
            e.Graphics.DrawLine(pen, 300, 200, 625, 200);
            e.Graphics.DrawLine(pen, 300, 300, 625, 300);
        }
  enum enPlayer { ePlayer1, ePlayer2 };

        enum enWinner { eWPlayer1, eWPlayer2,ewDraw, GameInProgress };

        struct stGame 
        {
        public    enWinner Winnerr;
          public  bool GameOver;
          public  short GameCount;

        }
        public void EndGame()
        {
            labTurn.Text = "Game Over";

            switch(game.Winnerr)
            {
                case enWinner.eWPlayer1:
                    labWinner.Text = "player1";
                    break;
                    case enWinner.eWPlayer2:
                    labWinner.Text = "player2";
                    break;
                default:
                    labWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("game over","game as",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckValue(PictureBox pb1, PictureBox pBQ2, PictureBox pBQ3)
        {
            if (pb1.Tag.ToString()!="?"&&pb1.Tag.ToString()== pBQ2.Tag.ToString()&&pb1.Tag.ToString()== pBQ3.Tag.ToString())
            {
                pb1.BackColor = Color.YellowGreen;
                pBQ2.BackColor = Color.YellowGreen;
                pBQ3.BackColor = Color.YellowGreen;

                if(pb1.Tag.ToString()=="x")
                {
                    game.Winnerr = enWinner.eWPlayer1;
                    labWinner.Text = "Player1";
                    game.GameOver = true;
                    EndGame();
                    return true;

                }
                else
                {
                    game.Winnerr = enWinner.eWPlayer2;
                    labWinner.Text = "Player2";
                    game.GameOver = true;
                    EndGame();
                    return true;

                }
            }
            game.GameOver = false;

            return false;
        }
        public void CheckWinner()
        {if (CheckValue( pBQ1,  pBQ4,  pBQ7))

                return;
           if (CheckValue( pBQ2,  pBQ5,  pBQ8))

                    return;
           if (CheckValue( pBQ3,  pBQ6,  pBQ9))

                    return;
            if (CheckValue( pBQ1,  pBQ2,  pBQ3))

                return;
            if (CheckValue( pBQ4,  pBQ5,  pBQ6))

                return;
            if (CheckValue( pBQ7,  pBQ8,  pBQ9))

                return;
            if (CheckValue( pBQ1,  pBQ5,  pBQ9))

                return;
            if (CheckValue( pBQ7,  pBQ5,  pBQ3))

                return;
        }
       
     public void Changimg(PictureBox pBq)
        {

            if (pBq.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.ePlayer1:
                        pBq.Image = Properties.Resources.X;
                        PlayerTurn = enPlayer.ePlayer2;
                        labTurn.Text = "Player2";
                        pBq.Tag = "x";
                        game.GameCount++;
                        CheckWinner();
                        break;

                    case enPlayer.ePlayer2:
                        pBq.Image = Properties.Resources.O;
                        PlayerTurn = enPlayer.ePlayer1;
                        labTurn.Text = "Player1";
                        pBq.Tag = "o";
                        game.GameCount++;
                        CheckWinner();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Worng Choice","Worng",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(game.GameCount == 9)
            {
                game.GameOver = true;
                game.Winnerr = enWinner.ewDraw;
                EndGame();
            }

        }

        public void ReToDefule(PictureBox pBQ)
        {
            pBQ.Image = Properties.Resources.question_mark_96;
            pBQ.Tag = "?";
            pBQ.BackColor = Color.LightBlue;
        }
        public void RestartGame()
        {
            ReToDefule(pBQ1);
            ReToDefule(pBQ2);
            ReToDefule(pBQ3);
            ReToDefule(pBQ4);
            ReToDefule(pBQ5);
            ReToDefule(pBQ6);
            ReToDefule(pBQ7);
            ReToDefule(pBQ8);
            ReToDefule(pBQ9);
            PlayerTurn= enPlayer.ePlayer1;
            labTurn.Text = "player1";
            game.GameCount = 0;
            game.GameOver= false;
            game.Winnerr= enWinner.GameInProgress;
            labWinner.Text = "InProgress";
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pBQ1_Click(object sender, EventArgs e)
        {
            Changimg(pBQ1);
        }

        private void pBQ2_Click(object sender, EventArgs e)
        {
            Changimg(pBQ2);

        }

        private void pBQ3_Click(object sender, EventArgs e)
        {

            Changimg(pBQ3);
        }

        private void pBQ4_Click(object sender, EventArgs e)
        {
            Changimg(pBQ4);
        }


        private void butGAmReast_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void pBQ5_Click_1(object sender, EventArgs e)
        {
            Changimg(pBQ5);
        }

        private void pBQ6_Click_1(object sender, EventArgs e)
        {
            Changimg(pBQ6);
        }

        private void pBQ7_Click_1(object sender, EventArgs e)
        {
            Changimg(pBQ7);
        }

        private void pBQ8_Click_1(object sender, EventArgs e)
        {
            Changimg(pBQ8);
        }

        private void pBQ9_Click_1(object sender, EventArgs e)
        {
            Changimg(pBQ9);
        }
    }
}
