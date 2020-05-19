using Pet.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Days = 20, happiness = 15, hunger = 0, HungerModifier = 2, money = 1, freeHour = 1, HapBonus = 0, CurDay = 1;

        int wins = 0, HapforWalk = 13, PriceToy = 4, PriceFood2 = 2, PriceBone = 14;

        bool BigBone = false, mDailyChoice3Available = false;

        Queue qu = new Queue();

        Random rnd = new Random();

        string PetName;

        string[] s1 = { "Your pet dreamt of you tonight.", "Play more and win to unlock other pets.", "Consider taking a break.",
            "There's a secret pet.", "You can always erase your statistics. (but what for?)", "Your pet have met another pet for the first time",
            "Your pet has woken up.", "Your pet wants to go for a walk.", "Your pet loves you.",
            "A big bone is very useful if you're tired of feeding your pet.", "Your pet tore your jacket.", "Never kick your pet.",
            "The name is very important (e.g. a parrot called Rex is aggressive)."
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            wins = (int)Settings.Default["wins"];

            ArrayList lst = new ArrayList();
            lst.AddRange(s1);

            while (lst.Count > 0)
            {
                int ran = rnd.Next(0, lst.Count);

                string s = lst[ran].ToString();

                lst.RemoveAt(ran);
                qu.Enqueue(s);
            }

            if (wins >= 1)
            {
                AgeChoice2.Enabled = true;

                if (wins >= 2)
                {
                    AgeChoice3.Enabled = true;

                    if (wins >= 5)
                    {
                        choiceB.Enabled = true;

                        if (wins >= 10)
                        {
                            choiceC.Enabled = true;

                            if (wins >= 15)
                            {
                                choiceD.Enabled = true;

                                if (wins >= 20)
                                {
                                    choicePanda.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }

            IntroLbl.Text = "You won " + wins + " times.";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default["wins"] = wins;
            Settings.Default.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Play()
        {
            DailyChoice3.Visible = false;

            DayHlabel.Text = "♥: " + happiness;
            DayHunlabel.Text = "Hunger: " + hunger + "%";
            DayMlabel.Text = "$: " + money;
            DayFHlabel.Text = "Free hours: " + freeHour;

            if (CurDay == Days)
            {
                lblLastDay.Visible = true;
            }

            if (CurDay > Days)
            {
                Final();
            }

            else
            {
                DayGroupBox.Text = "Day: " + CurDay + "/" + Days;
                CurDay++;
                if (qu.Count > 0)
                {
                    DailyMessage.Text = qu.Dequeue().ToString();
                }

                DailyChoice1.Text = "Take " + PetName + " for a walk (" + HapforWalk + "% ♥, -1 free hour)";
                DailyChoice2.Text = "Feed your pet with vegetables (+5% ♥, -1% hunger, -$1";
                if (rnd.Next(0, 6) == 1)
                {
                    DailyChoice3.Visible = true;

                    DailyChoice3.Text = "Play with your pet (+15% ♥)";
                    mDailyChoice3Available = true;
                }
            }
        }

        void Final()
        {
            BtnNext.Visible = false;
            lblFinal.Visible = true;
            lblResult.Visible = true;
            lblFinal.Text = "Final ♥: " + happiness + "%";

            if (happiness >= 100)
            {
                wins++;
                IntroLbl.Text = "You won " + wins + " times.";
                lblResult.Text = "You won!";
            }
            else
            {
                lblResult.Text = "You lost. Your pet is sad.";
            }
        }

        private void BtnErase_Click(object sender, EventArgs e)
        {
            wins = 0;
            IntroLbl.Text = "You won 0 times.";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                EffectLbl.Text = "Effect: +1 Day, +1 % hunger";
            }
            else if (AgeChoice2.Checked == true)
            {
                EffectLbl.Text = "Effect: None";
            }
            else if (AgeChoice3.Checked == true)
            {
                EffectLbl.Text = "Effect: +1% ♥, -1 Day";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (NameBox.Text.Length > 0)
            {
                //Pet choice
                if (choiceA.Checked == true)
                {
                    happiness += 5;
                }
                else if (choiceB.Checked == true)
                {
                    Days += 1;
                }
                else if (choiceC.Checked == true)
                {
                    HungerModifier -= 1;
                }
                else if (choiceD.Checked == true)
                {
                    happiness += 10;
                    Days -= 1;
                }
                else if (choicePanda.Checked == true)
                {
                    HapBonus += 1;
                }
                //age choice
                if (radioButton1.Checked == true)
                {
                    Days += 1;
                    hunger += 1;
                }
                else if (AgeChoice3.Checked == true)
                {
                    Days -= 1;
                    happiness++;
                }

                PetName = NameBox.Text;

                PropertiesBox.Enabled = false;
                DayGroupBox.Visible = true;
                Play();
                BtnStart.Visible = false;
            }
            else
                lblWarningName.Visible = true;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(DailyChoice1.Checked == true && freeHour > 0)
            {
                happiness += HapforWalk;
                freeHour--;
            }
            if (DailyChoice2.Checked == true && money > 0)
            {
                happiness += 5;
                money--;
                hunger--;
            }
            if (DailyChoice3.Checked == true)
            {
                if(mDailyChoice3Available == true)
                {
                    happiness += 15;
                }
            }

            if(hunger > 0)
            {
                happiness -= hunger * HungerModifier;
            }

            if(BigBone == false)
            {
                hunger++;
            }

            if(hunger <0)
            {
                hunger = 0;
            }

            happiness += HapBonus;
            money++;
            freeHour++;
            Play();
        }

        private void BtnBuyBone_Click(object sender, EventArgs e)
        {
            if(BigBone == false && money >= PriceBone)
            {
                BtnBuyBone.BackColor = Color.DeepSkyBlue;
                BtnBuyBone.Text = "Purchased";
                BigBone = true;
                hunger = 0;
                money -= PriceBone;
                BtnBuyBone.Enabled = false;
                DayHunlabel.Text = "Hunger: " + hunger + "%";
                DayMlabel.Text = "$: " + money;
            }
        }

        private void BtnBuyToy_Click(object sender, EventArgs e)
        {
            if (money >= PriceToy)
            {
                HapBonus += 1;
                money -= PriceToy;
                DayMlabel.Text = "$: " + money;

                if(HapBonus > 2)
                {
                    BtnBuyToy.Text = "Purchased";
                    BtnBuyToy.BackColor = Color.DodgerBlue;
                    BtnBuyToy.Enabled = false;
                }                
            }
        }

        private void BtnBuyForage_Click(object sender, EventArgs e)
        {
            if(money >= 10)
            {
                BtnBuyForage.BackColor = Color.SteelBlue;
                BtnBuyForage.Text = "Purchased";
                HungerModifier -= 1;
                money -= 10;
                BtnBuyForage.Enabled = false;
                DayMlabel.Text = "$: " + money;
            }
        }

        private void BtnBuyFruits_Click(object sender, EventArgs e)
        {
            if (money >= PriceFood2)
            {
                hunger -= 2;
                money -= PriceFood2;
                DayMlabel.Text = "$: " + money;
                DayHunlabel.Text = "Hunger: " + hunger + "%";
            }
        }

        //RESTART
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Days = 20; happiness = 15; hunger = 0; HungerModifier = 2; money = 1; freeHour = 1; HapBonus = 0; CurDay = 1;

            if (wins >= 1)
            {
                AgeChoice2.Enabled = true;

                if (wins >= 2)
                {
                    AgeChoice3.Enabled = true;

                    if (wins >= 5)
                    {
                        choiceB.Enabled = true;

                        if (wins >= 10)
                        {
                            choiceC.Enabled = true;

                            if (wins >= 15)
                            {
                                choiceD.Enabled = true;

                                if (wins >= 20)
                                {
                                    choicePanda.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }

            BigBone = false; mDailyChoice3Available = false;
            PropertiesBox.Enabled = true;
            DayGroupBox.Visible = false;
            BtnStart.Visible = true;
            lblWarningName.Visible = false;
            lblFinal.Visible = false;
            lblLastDay.Visible = false;
            lblResult.Visible = false;
            BtnBuyBone.Enabled = true;
            BtnBuyForage.Enabled = true;
            BtnBuyToy.Enabled = true;
            BtnNext.Visible = true;

            BtnBuyBone.BackColor = Color.Empty;
            BtnBuyBone.Text = "Buy";
            BtnBuyToy.BackColor = Color.Empty;
            BtnBuyToy.Text = "Buy";
            BtnBuyForage.BackColor = Color.Empty;
            BtnBuyForage.Text = "Buy";
            //write daily comments
            ArrayList lst = new ArrayList();
            lst.AddRange(s1);

            while(lst.Count > 0)
            {
                int ran = rnd.Next(0, lst.Count);

                string s = lst[ran].ToString();
                lst.RemoveAt(ran);
                qu.Enqueue(s);
            }
        }

        private void AddWin_Click(object sender, EventArgs e)
        {
            wins++;
            IntroLbl.Text = "You won " + wins + " times.";
            lblResult.Text = "You won!";

            restartToolStripMenuItem_Click(sender, e);
        }
    }
}
