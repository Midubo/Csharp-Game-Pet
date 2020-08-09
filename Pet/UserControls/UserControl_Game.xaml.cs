using Pet.Properties;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_Game.xaml
    /// </summary>
    public partial class UserControl_Game : UserControl, IDisposable
    {
        void IDisposable.Dispose() { }

        #region VARIABLES

        int mDays = 20, CurDay = 1, happiness = 15, HapBonus = 0, hunger = 0, HungerModifier = 2, money = 1, freeHour = 1;

        int wins = 0, HappinessforWalk = 13, PriceToy = 4, PriceFood2 = 2, PriceBone = 14;

        bool BigBone = false, mDailyChoice3Available = false;

        Queue qu = new Queue();

        Random rnd = new Random();

        string PetName;

        string[] s1 = { "Your pet dreamt of you tonight.", "Play more and win to unlock other pets.", "Consider taking a break.", "There's a secret pet.", "You can always erase your statistics. (but what for?)", "Your pet have met another pet for the first time", "Your pet has woken up.", "Your pet wants to go for a walk.", "Your pet loves you.", "A big bone is very useful if you're tired of feeding your pet.", "Your pet tore your jacket.", "Never kick your pet.", "The name is very important (e.g. a parrot called Rex is aggressive)." };

        bool dailyComments;

        #endregion

        #region LOADING

        public UserControl_Game(string _petName, int _Days, int _happiness, int _HapBonus, int _hunger, int _HungerModifier, string pet, string description, string age, string description_age)
        {
            InitializeComponent();

            PetName = _petName;
            mDays = _Days;
            happiness = _happiness;
            HapBonus = _HapBonus;
            hunger = _hunger;
            HungerModifier = _HungerModifier;

            ImageSourceConverter imgs = new ImageSourceConverter();
            img_Pet.SetValue(Image.SourceProperty, imgs.ConvertFromString(string.Format("pack://application:,,,/Images/{0}.png", pet)));

            tblc_description.Text = description;
        }

        private void ShowMenu(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            wins = (int)Settings.Default["wins"];

            #region writing daily comments

            dailyComments = (bool)Settings.Default["dailyComments"];

            if (dailyComments == true)
            {
                ArrayList lst = new ArrayList();
                lst.AddRange(s1);

                while (lst.Count > 0)
                {
                    int ran = rnd.Next(0, lst.Count);

                    string s = lst[ran].ToString();

                    lst.RemoveAt(ran);
                    qu.Enqueue(s);
                }
            }
            else tblc_DailyMessage.Visibility = Visibility.Hidden;

            #endregion


            tblc_PetName.Text = PetName;
            tblc_currentHappiness.Text = string.Format("♥: {0}", happiness);
            tblc_currentHunger.Text = string.Format("Hunger: {0}", hunger);
            tblc_currentMoney.Text = string.Format("$: {0}", money);
            tblc_currentFreeHours.Text = string.Format("Free hours: {0}", freeHour);

            if (qu.Count > 0) tblc_DailyMessage.Text = qu.Dequeue().ToString();

            DailyChoice1.Content = string.Format("Take {0} for a walk ( + {1} ♥, -1 free hour", PetName, HappinessforWalk);
            DailyChoice2.Content = "Feed your pet with vegetables (+5 ♥, -1 hunger, -$1)";
            DailyChoice3.Content = "Play with your pet (+15 ♥)";
        }

        #endregion

        #region UPPER BUTTONS

        #region RESTART

        private void btn_Restart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RestartGame();
        }

        void RestartGame()
        {
            this.Content = new UserControl_SelectPet();
        }

        #endregion

        private void btn_MainMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Content = new UserControl_MainMenu();
        }

        private void btn_Exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        private void BtnNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DailyChoice1.IsChecked == true && freeHour >= 1)
            {
                happiness += HappinessforWalk;
                freeHour--;
            }
            if (DailyChoice2.IsChecked == true && money >= 1)
            {
                happiness += 5;
                money--;
                hunger--;
            }
            if (DailyChoice3.IsChecked == true && mDailyChoice3Available == true)
            {
                happiness += 15;
            }

            rnd = new Random();
            if (hunger > 0)
            {
                happiness -= (hunger * HungerModifier) + rnd.Next(0, 2);
            }

            if (BigBone == false)
            {
                hunger += 1;
            }

            if (hunger < 0)
            {
                hunger = 0;
            }

            happiness += HapBonus;
            money++;
            freeHour++;
            Play();
        }

        void Play()
        {
            DailyChoice3.Visibility = Visibility.Hidden;

            tblc_currentHappiness.Text = "♥: " + happiness;
            tblc_currentHunger.Text = "Hunger: " + hunger;
            tblc_currentMoney.Text = "$: " + money;
            tblc_currentFreeHours.Text = "Free hours: " + freeHour;

            CurDay++;
            if (CurDay > mDays) Final();
            else
            {


                if (CurDay == mDays) tblc_LastDay.Visibility = Visibility.Visible;

                if (qu.Count > 0)
                {
                    tblc_DailyMessage.Text = qu.Dequeue().ToString();
                }

                if (rnd.Next(0, 6) == 1)
                {
                    DailyChoice3.Visibility = Visibility.Visible;
                    mDailyChoice3Available = true;
                }
                else
                {
                    if (DailyChoice3.IsChecked == true)
                    {
                        DailyChoice1.IsChecked = true;
                    }
                }

            }
        }

        void Final()
        {
            btn_Next.Visibility = Visibility.Hidden;


            if (happiness >= 100)
            {
                wins++;
                Settings.Default["wins"] = wins;
                Settings.Default.Save();



            }
            else
            {

            }
        }

        private void BtnBuyBone_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BigBone == false && money >= PriceBone)
            {
                btn_BuyBone.Background = Brushes.DeepSkyBlue;
                btn_BuyBone.Content = "Purchased";
                BigBone = true;
                hunger = 0;
                money -= PriceBone;
                btn_BuyBone.IsEnabled = false;
                tblc_currentHunger.Text = "Hunger: " + hunger + "%";
                tblc_currentMoney.Text = "$: " + money;
            }
        }

        private void btnBuyToy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (money >= PriceToy)
            {
                HapBonus += 1;
                money -= PriceToy;
                tblc_currentMoney.Text = "$: " + money;

                if (HapBonus > 2)
                {
                    btn_BuyToy.Content = "Purchased";
                    btn_BuyToy.Background = Brushes.DodgerBlue;
                    btn_BuyToy.IsEnabled = false;
                }
            }
        }

        private void BtnBuyForage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (money >= 10)
            {
                btn_BuyForage.Background = Brushes.SteelBlue;
                btn_BuyForage.Content = "Purchased";
                HungerModifier -= 1;
                money -= 10;
                btn_BuyForage.IsEnabled = false;
                tblc_currentMoney.Text = "$: " + money;
            }
        }

        private void btnBuyFruit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (money >= PriceFood2)
            {
                hunger -= 2;
                money -= PriceFood2;
                tblc_currentMoney.Text = "$: " + money;
                tblc_currentHunger.Text = "Hunger: " + hunger + "%";
            }
        }

    }
}
