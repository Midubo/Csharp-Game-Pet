using Pet.Properties;
using System.Windows;
using System.Windows.Controls;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_SelectPet.xaml
    /// </summary>
    public partial class UserControl_SelectPet : UserControl
    {
        #region LOADING

        public UserControl_SelectPet()
        {
            InitializeComponent();

            AgeChoice1.Checked += AgeChoice_CheckedChanged;
            AgeChoice2.Checked += AgeChoice_CheckedChanged;
            AgeChoice3.Checked += AgeChoice_CheckedChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            wins = (int)Settings.Default["wins"];

            tblc_Intro.Text = "Wins: " + wins;

            if (wins >= 1)
            {
                AgeChoice2.IsEnabled = true;

                if (wins >= 2)
                {
                    AgeChoice3.IsEnabled = true;

                    if (wins >= 5)
                    {
                        stackPanel_Kitty.IsEnabled = true;

                        if (wins >= 10)
                        {
                            stackPanel_Parrot.IsEnabled = true;

                            if (wins >= 15)
                            {
                                stackPanel_Hamster.IsEnabled = true;

                                if (wins >= 20)
                                {
                                    stackPanel_Panda.IsEnabled = true;
                                }
                            }
                        }
                    }
                }
            }

            tb_Name.Text = (string)Settings.Default["defaultName"];
        }

        #endregion

        #region VARIABLES

        int wins, Days = 15, HungerModifier = 2, happiness = 15, HapBonus = 0, hunger;
        string PetName;

        #endregion

        #region SECONDARY BUTTONS

        #region RESTART

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        void RestartGame()
        {
            this.Content = new UserControl_SelectPet();
        }

        #endregion

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Content = new UserControl_MainMenu();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        private void AddWin_Click(object sender, RoutedEventArgs e)
        {
            wins++;
            Settings.Default["wins"] = wins;
            Settings.Default.Save();
            tblc_Intro.Text = "Wins: " + wins;
            RestartGame();
        }

        private void btn_Erase_Click(object sender, RoutedEventArgs e)
        {
            wins = 0;
            tblc_Intro.Text = "Wins: " + wins;
            Settings.Default["wins"] = wins;
            Settings.Default.Save();
        }

        private void AgeChoice_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (AgeChoice1.IsChecked == true)
            {
                tblc_Effect.Text = "Effect: +1 Day, +1% hunger";
            }
            else if (AgeChoice2.IsChecked == true)
            {
                tblc_Effect.Text = "Effect: None";
            }
            else if (AgeChoice3.IsChecked == true)
            {
                tblc_Effect.Text = "Effect: +1% ♥, -1 Day";
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text.Length > 0)
            {
                string pet = "";

                string description = "Pet effect: ";
                if (choiceA.IsChecked == true)
                {
                    pet = "puppy";
                    description += "None";
                }
                else if (choiceB.IsChecked == true)
                {
                    Days += 1;
                    pet = "kitty";
                    description += "+1 Day";
                }
                else if (choiceC.IsChecked == true)
                {
                    HungerModifier -= 1;
                    pet = "parrot";
                    description += "Hunger 50% weaker";
                }
                else if (choiceD.IsChecked == true)
                {
                    happiness += 10;
                    Days -= 1;
                    pet = "hamster";
                    description += "+10 ♥\n-1 Day";
                }
                else if (choicePanda.IsChecked == true)
                {
                    HapBonus += 1;
                    pet = "panda";
                    description += "+1 ♥ every day";
                }

                description += "\nAge:";
                if (AgeChoice1.IsChecked == true)
                {
                    Days += 1;
                    hunger += 1;
                    description += "1 month";
                }
                else if (AgeChoice2.IsChecked == true)
                {
                    description += "6 months";
                }
                else if (AgeChoice3.IsChecked == true)
                {
                    Days -= 1;
                    happiness++;
                    description += "12 months";
                }

                PetName = tb_Name.Text;
                description += "\nAge " + tblc_Effect.Text;

                this.Content = new UserControl_Game(PetName, Days, happiness, HapBonus, hunger, HungerModifier, pet, description);
            }
            else
                tblc_WarningName.Visibility = Visibility.Visible;
        }


    }
}
