using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HighRollers_CSharp
{
    public partial class frmHighRollers : Form
    {
        public Random random = new Random();
        const int MONEY_GOAL = 20000;
        int roll1 = 0;
        int roll2 = 0;
        int player1Money = 5000;
        int player2Money = 5000;
        int betMoney = 500;
        int turnCounter = 1;
        int rollTotal = 0;

        public frmHighRollers()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            roll1 = rnd.Next(1, 6);
            roll2 = rnd.Next(1, 6);
            rollTotal = roll1 + roll2;

            picDice11.Visible = false;
            picDice21.Visible = false;
            picDice31.Visible = false;
            picDice41.Visible = false;
            picDice51.Visible = false;
            picDice61.Visible = false;

            picDice12.Visible = false;
            picDice22.Visible = false;
            picDice32.Visible = false;
            picDice42.Visible = false;
            picDice52.Visible = false;
            picDice62.Visible = false;

            switch (roll1)
            {
                case 1:
                    picDice11.Visible = true;
                    break;
                case 2:
                    picDice21.Visible = true;
                    break;
                case 3:
                    picDice31.Visible = true;
                    break;
                case 4:
                    picDice41.Visible = true;
                    break;
                case 5:
                    picDice51.Visible = true;
                    break;
                case 6:
                    picDice61.Visible = true;
                    break;
            }

            switch (roll2)
            {
                case 1:
                    picDice12.Visible = true;
                    break;
                case 2:
                    picDice22.Visible = true;
                    break;
                case 3:
                    picDice32.Visible = true;
                    break;
                case 4:
                    picDice42.Visible = true;
                    break;
                case 5:
                    picDice52.Visible = true;
                    break;
                case 6:
                    picDice62.Visible = true;
                    break;
            }

            moneyManage();
            if (turnCounter == 1)
            {
                turnCounter += 1;
                lblPlayer.Text = "Player Two's Turn";
            }
            else
            {
                turnCounter -= 1;
                lblPlayer.Text = "Player One's Turn";
            }
        }

        public void moneyManage()
        {
            if(turnCounter == 1)
            {
                if(rollTotal % 2 == 0 && rollTotal != 2)
                {
                    player1Money = player1Money - betMoney;
                    lblStatus.Text = "Bad Roll!";
                }
                else if(rollTotal % 2 != 0 && rollTotal != 7)
                {
                    player1Money = player1Money + betMoney;
                    lblStatus.Text = "Nice Roll!";
                }
                else if(rollTotal == 2)
                {
                    player1Money = player1Money - (betMoney * 5);
                    lblStatus.Text = "Ouch!!";
                }
                else if(rollTotal == 7)
                {
                    player1Money = player1Money + (betMoney * 2);
                    lblStatus.Text = "Wow!";
                }
                lblP1Money.Text = "P1: $" + player1Money;
            }

            if (turnCounter == 2)
            {
                if (rollTotal % 2 == 0 && rollTotal != 2)
                {
                    player2Money = player2Money - betMoney;
                    lblStatus.Text = "Bad Roll!";
                }
                else if (rollTotal % 2 != 0 && rollTotal != 7)
                {
                    player2Money = player2Money + betMoney;
                    lblStatus.Text = "Nice Roll!";
                }
                else if (rollTotal == 2)
                {
                    player2Money = player2Money - (betMoney * 4);
                    lblStatus.Text = "Ouch!!";
                }
                else if (rollTotal == 7)
                {
                    player2Money = player2Money + (betMoney * 3);
                    lblStatus.Text = "Wow!";
                }
                lblP2Money.Text = "P2: $" + player2Money;
            }

            if (player1Money >= MONEY_GOAL || player2Money <= 0)
            {
                lblStatus.Text = "P1 Wins!";
                btnRoll.Enabled = false;
            }
            else if (player2Money >= MONEY_GOAL || player1Money <= 0)
            {
                lblStatus.Text = "P2 Wins!";
                btnRoll.Enabled = false;
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if(betMoney <= 4500)
            {
                betMoney += 500;
                lblBets.Text = "$" + betMoney.ToString();
            }
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            if (betMoney >= 1000)
            {
                betMoney -= 500;
                lblBets.Text = "$" + betMoney.ToString();
            }
        }
    }
}
