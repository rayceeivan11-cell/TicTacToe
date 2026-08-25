using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private const string PLAYER = "X";
        private const string CPU = "O";

        private int playerScore = 0;
        private int cpuScore = 0;

        private Button[] buttons;

        private int[][] winningCombinations = new int[][]
        {
            new int[] { 1, 2, 3 }, // Row 1
            new int[] { 4, 5, 6 }, // Row 2
            new int[] { 7, 8, 9 }, // Row 3

            new int[] { 1, 4, 7 }, // Column 1
            new int[] { 2, 5, 8 }, // Column 2
            new int[] { 3, 6, 9 }, // Column 3
            
            new int[] { 1, 5, 9 }, // Diagonal 1
            new int[] { 3, 5, 7 }  // Diagonal 2
        };

        public Form1()
        {
            InitializeComponent();
            buttons = new[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            foreach (var btn in buttons)
                btn.Click += PlayerMove;

            ClearGame();
        }


        private void PlayerMove(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn is Button)
                Hit(btn, PLAYER);
        }

        private void Hit(Button btn, string val)
        {
            btn.Text = val;
            btn.Enabled = false;
            btn.Update();

            if (!CheckWinner() && val == PLAYER)
            {
                Thread.Sleep(500);
                Prio1();
            }

            if (val == CPU)
            {
                CheckWinner();
            }
        }

        private void Prio1()
        {
            // HORIZONTAL
            if (b1.Text == CPU && b2.Text == CPU && b3.Text == "") Hit(b3, CPU);
            else if (b1.Text == CPU && b2.Text == "" && b3.Text == CPU) Hit(b2, CPU);
            else if (b1.Text == "" && b2.Text == CPU && b3.Text == CPU) Hit(b1, CPU);

            else if (b4.Text == CPU && b5.Text == CPU && b6.Text == "") Hit(b6, CPU);
            else if (b4.Text == CPU && b5.Text == "" && b6.Text == CPU) Hit(b5, CPU);
            else if (b4.Text == "" && b5.Text == CPU && b6.Text == CPU) Hit(b4, CPU);

            else if (b7.Text == CPU && b8.Text == CPU && b9.Text == "") Hit(b9, CPU);
            else if (b7.Text == CPU && b8.Text == "" && b9.Text == CPU) Hit(b8, CPU);
            else if (b7.Text == "" && b8.Text == CPU && b9.Text == CPU) Hit(b7, CPU);

            // VERTICAL
            else if (b1.Text == CPU && b4.Text == CPU && b7.Text == "") Hit(b7, CPU);
            else if (b1.Text == CPU && b4.Text == "" && b7.Text == CPU) Hit(b4, CPU);
            else if (b1.Text == "" && b4.Text == CPU && b7.Text == CPU) Hit(b1, CPU);

            else if (b2.Text == CPU && b5.Text == CPU && b8.Text == "") Hit(b8, CPU);
            else if (b2.Text == CPU && b5.Text == "" && b8.Text == CPU) Hit(b5, CPU);
            else if (b2.Text == "" && b5.Text == CPU && b8.Text == CPU) Hit(b2, CPU);

            else if (b3.Text == CPU && b6.Text == CPU && b9.Text == "") Hit(b9, CPU);
            else if (b3.Text == CPU && b6.Text == "" && b9.Text == CPU) Hit(b6, CPU);
            else if (b3.Text == "" && b6.Text == CPU && b9.Text == CPU) Hit(b3, CPU);

            // DIAGONAL
            else if (b1.Text == CPU && b5.Text == CPU && b9.Text == "") Hit(b9, CPU);
            else if (b1.Text == CPU && b5.Text == "" && b9.Text == CPU) Hit(b5, CPU);
            else if (b1.Text == "" && b5.Text == CPU && b9.Text == CPU) Hit(b1, CPU);

            else if (b3.Text == CPU && b5.Text == CPU && b7.Text == "") Hit(b7, CPU);
            else if (b3.Text == CPU && b5.Text == "" && b7.Text == CPU) Hit(b5, CPU);
            else if (b3.Text == "" && b5.Text == CPU && b7.Text == CPU) Hit(b3, CPU);

            else Prio2();
        }

        private void Prio2()
        {
            // HORIZONTAL
            if (b1.Text == PLAYER && b2.Text == PLAYER && b3.Text == "") Hit(b3, CPU);
            else if (b1.Text == PLAYER && b2.Text == "" && b3.Text == PLAYER) Hit(b2, CPU);
            else if (b1.Text == "" && b2.Text == PLAYER && b3.Text == PLAYER) Hit(b1, CPU);

            else if (b4.Text == PLAYER && b5.Text == PLAYER && b6.Text == "") Hit(b6, CPU);
            else if (b4.Text == PLAYER && b5.Text == "" && b6.Text == PLAYER) Hit(b5, CPU);
            else if (b4.Text == "" && b5.Text == PLAYER && b6.Text == PLAYER) Hit(b4, CPU);

            else if (b7.Text == PLAYER && b8.Text == PLAYER && b9.Text == "") Hit(b9, CPU);
            else if (b7.Text == PLAYER && b8.Text == "" && b9.Text == PLAYER) Hit(b8, CPU);
            else if (b7.Text == "" && b8.Text == PLAYER && b9.Text == PLAYER) Hit(b7, CPU);

            // VERTICAL
            else if (b1.Text == PLAYER && b4.Text == PLAYER && b7.Text == "") Hit(b7, CPU);
            else if (b1.Text == PLAYER && b4.Text == "" && b7.Text == PLAYER) Hit(b4, CPU);
            else if (b1.Text == "" && b4.Text == PLAYER && b7.Text == PLAYER) Hit(b1, CPU);

            else if (b2.Text == PLAYER && b5.Text == PLAYER && b8.Text == "") Hit(b8, CPU);
            else if (b2.Text == PLAYER && b5.Text == "" && b8.Text == PLAYER) Hit(b5, CPU);
            else if (b2.Text == "" && b5.Text == PLAYER && b8.Text == PLAYER) Hit(b2, CPU);

            else if (b3.Text == PLAYER && b6.Text == PLAYER && b9.Text == "") Hit(b9, CPU);
            else if (b3.Text == PLAYER && b6.Text == "" && b9.Text == PLAYER) Hit(b6, CPU);
            else if (b3.Text == "" && b6.Text == PLAYER && b9.Text == PLAYER) Hit(b3, CPU);

            // DIAGONAL
            else if (b1.Text == PLAYER && b5.Text == PLAYER && b9.Text == "") Hit(b9, CPU);
            else if (b1.Text == PLAYER && b5.Text == "" && b9.Text == PLAYER) Hit(b5, CPU);
            else if (b1.Text == "" && b5.Text == PLAYER && b9.Text == PLAYER) Hit(b1, CPU);

            else if (b3.Text == PLAYER && b5.Text == PLAYER && b7.Text == "") Hit(b7, CPU);
            else if (b3.Text == PLAYER && b5.Text == "" && b7.Text == PLAYER) Hit(b5, CPU);
            else if (b3.Text == "" && b5.Text == PLAYER && b7.Text == PLAYER) Hit(b3, CPU);

            else Prio3();

        }

        private void Prio3()
        {
            var vacantBtn = buttons.Where(btn => btn.Text == "").ToList();

            if (vacantBtn.Any())
            {
                var random = new Random();
                var btn = vacantBtn[random.Next(vacantBtn.Count)];
                Hit(btn, CPU);
            }
        }

        private bool CheckWinner()
        {
            foreach (var combo in winningCombinations)
            {
                //Player Win
                if (combo.All(i => buttons[i - 1].Text == PLAYER))
                {
                    HighlightWinningCombination(combo);
                    CountWin(PLAYER);
                    return true;
                }

                //CPU Win
                if (combo.All(i => buttons[i - 1].Text == CPU))
                {
                    HighlightWinningCombination(combo);
                    CountWin(CPU);
                    return true;
                }
            }

            if (buttons.All(btn => btn.Text != ""))
            {
                MessageBox.Show("It's a Draw!");
                ClearGame();
                return true;
            }

            return false;
        }

        private void HighlightWinningCombination(int[] combo)
        {
            foreach (var i in combo)
                buttons[i - 1].BackColor = Color.HotPink;

            Application.DoEvents();
            Thread.Sleep(2000);

            foreach (var i in combo)
                buttons[i - 1].BackColor = Color.LightGreen;
        }

        private void CountWin(string winner)
        {
            if (winner == PLAYER) playerScore++;
            else if (winner == CPU) cpuScore++;
            lbl_PlayerScore.Text = playerScore.ToString();
            lbl_Computer.Text = cpuScore.ToString();

            if (playerScore == 3 || cpuScore == 3)
            {
                string message = playerScore == 3 ? "Player Wins the Game!" : "Computer Wins the Game!";
                MessageBox.Show(message);
                playerScore = 0;
                cpuScore = 0;
                lbl_PlayerScore.Text = playerScore.ToString();
                lbl_Computer.Text = cpuScore.ToString();
                Thread.Sleep(1000);
            }

            ClearGame();
        }

        private void ClearGame()
        {
            foreach (var button in buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }
        }
    }
}