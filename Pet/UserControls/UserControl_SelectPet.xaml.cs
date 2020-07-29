using Pet.Properties;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_SelectPet.xaml
    /// </summary>
    public partial class UserControl_SelectPet : UserControl
    {

        #region VARIABLES

        private int mWins;

        /// <summary>
        /// The total number of days in the game by default. The game balance relies heavily on this. Cannot be negative.
        /// </summary>
        private int mTotalDays = 15;

        private int mHungerModifier = 2, mHappiness = 15, mHappinessBonus = 0, mHunger;
        string mPetName;

        private MediaPlayer mediaPlayer = new MediaPlayer();

        #endregion

        public Animal SelectedPet { get; set; }

        #region LOADING

        public UserControl_SelectPet()
        {
            SelectedPet = new Animal();

            InitializeComponent();

            AgeChoice1.Checked += AgeChoice_CheckedChanged;
            AgeChoice2.Checked += AgeChoice_CheckedChanged;
            AgeChoice3.Checked += AgeChoice_CheckedChanged;

            mediaPlayer.Open(new Uri(string.Format("{0}\\Run_Little_Chicken.mp3", AppDomain.CurrentDomain.BaseDirectory)));

            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            if ((bool)Settings.Default["music"] == true)
            {
                mediaPlayer.Play();
            }

            DataContext = this;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mediaPlayer.Position = TimeSpan.Zero;

                mediaPlayer.Play();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            mWins = (int)Settings.Default["wins"];

            tblc_Intro.Text = "Wins: " + mWins;

            if (mWins >= 1)
            {
                AgeChoice2.IsEnabled = true;

                if (mWins >= 2)
                {
                    AgeChoice3.IsEnabled = true;

                    if (mWins >= 3)
                    {
                        stackPanel_Kitty.IsEnabled = true;

                        if (mWins >= 4)
                        {
                            stackPanel_Parrot.IsEnabled = true;

                            if (mWins >= 5)
                            {
                                stackPanel_Hamster.IsEnabled = true;

                                if (mWins >= 6)
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

        private void AddWin_Click(object sender, RoutedEventArgs e)
        {
            mWins++;
            Settings.Default["wins"] = mWins;
            Settings.Default.Save();
            tblc_Intro.Text = "Wins: " + mWins;
            RestartGame();
        }

        private void btn_Erase_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to erase your results and achievements?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                mWins = 0;
                tblc_Intro.Text = "Wins: " + mWins;
                Settings.Default["wins"] = mWins;
                Settings.Default.Save();
            }
        }

        private void AgeChoice_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (AgeChoice1.IsChecked == true)
            {
                tblc_Effect.Text = "+1 Day\n+1 hunger";
            }
            else if (AgeChoice2.IsChecked == true)
            {
                tblc_Effect.Text = "None";
            }
            else if (AgeChoice3.IsChecked == true)
            {
                tblc_Effect.Text = "+1 ♥\n-1 Day";
            }
        }

        private void ChangedPet(object sender, RoutedEventArgs e)
        {
            if (choicePuppy.IsChecked == true)
            {
                SelectedPet.Type = PetType.Puppy;
            }

            else if (choiceKitty.IsChecked == true)
            {
                SelectedPet.Type = PetType.Kitty;
            }

            else if (choiceParrot.IsChecked == true)
            {
                SelectedPet.Type = PetType.Parrot;
            }

            else if (choiceHamster.IsChecked == true)
            {
                SelectedPet.Type = PetType.Hamster;
            }

            else if (choicePanda.IsChecked == true)
            {
                SelectedPet.Type = PetType.Panda;
            }
        }



        #region NAVIGATION BUTTONS

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text.Length > 0)
            {
                mPetName = tb_Name.Text;
                string pet = "";

                string description = "";
                if (choicePuppy.IsChecked == true)
                {
                    pet = "puppy";
                    description += "None";
                }
                else if (choiceKitty.IsChecked == true)
                {
                    mTotalDays += 1;
                    pet = "kitty";
                    description += "+1 Day";
                }
                else if (choiceParrot.IsChecked == true)
                {
                    mHungerModifier -= 1;
                    pet = "parrot";
                    description += "Hunger 50% weaker";
                }
                else if (choiceHamster.IsChecked == true)
                {
                    mHappiness += 10;
                    mTotalDays -= 1;
                    pet = "hamster";
                    description += "+10 ♥, -1 Day";
                }
                else if (choicePanda.IsChecked == true)
                {
                    mHappinessBonus += 1;
                    pet = "panda";
                    description += "+1 ♥ every day";
                }

                string age = "";

                if (AgeChoice1.IsChecked == true)
                {
                    mTotalDays += 1;
                    mHunger += 1;
                    age += "1 month";
                }
                else if (AgeChoice2.IsChecked == true)
                {
                    age += "6 months";
                }
                else if (AgeChoice3.IsChecked == true)
                {
                    mTotalDays -= 1;
                    mHappiness++;
                    age += "12 months";
                }

                string description_age = tblc_Effect.Text.Replace("\n", ", ");

                mediaPlayer.Stop();

                (Parent as Window).Content = new UserControl_Game(mPetName, mTotalDays, mHappiness, mHappinessBonus, mHunger, mHungerModifier, pet, description, age, description_age);
            }
            else
                tblc_WarningName.Visibility = Visibility.Visible;
        }

        #region RESTART

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            RestartGame();
        }

        void RestartGame()
        {
            (Parent as Window).Content = new UserControl_SelectPet();
        }

        #endregion

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            (Parent as Window).Content = new UserControl_MainMenu();
        }



        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
