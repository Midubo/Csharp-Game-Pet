using Pet.Properties;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_Game.xaml
    /// </summary>
    public partial class UserControl_Game : UserControl, IDisposable
    {
        void IDisposable.Dispose() { }

        #region VARIABLES

        /// <summary>
        /// The number of days in the game. The game balance should rely on this number. Cannot be negative.
        /// </summary>
        int mTotalDays = 15;

        int mCurrentDay = 1, mHappiness = 15, mHappinessBonus = 0, mHunger = 0, mHungerModifier = 2, mMoney = 1;

        /// <summary>
        /// The number of free hours available. Cannot be negative.
        /// </summary>
        int mFreeHours = 1;

        int mWins = 0, mHappinessforWalk = 13;

        int mPriceBone = 14, mPriceToy = 4, mPriceVegetables = 10, mPriceFruits = 2;

        /// <summary>
        /// Indicates whether item "Big Bone" was purchased
        /// </summary>
        bool mBigBonePurchased = false;

        bool mDailyChoice3Available = false;

        Queue qu = new Queue();

        Random rnd = new Random();

        string mPetName;

        /// <summary>
        /// Comments from a resx file
        /// </summary>
        string[] mComments = {
            Properties.Resources.comment1,
            Properties.Resources.comment2,
            Properties.Resources.comment3,
            Properties.Resources.comment4,
            Properties.Resources.comment5,
            Properties.Resources.comment6,
            Properties.Resources.comment7,
            Properties.Resources.comment8,
            Properties.Resources.comment9,
            Properties.Resources.comment10,
            Properties.Resources.comment11,
            Properties.Resources.comment12,
            Properties.Resources.comment13,
            Properties.Resources.comment14,
            Properties.Resources.comment15,
            Properties.Resources.comment16,
        };

        bool mDailyCommentsEnabled;

        private MediaPlayer mediaPlayer = new MediaPlayer();

        #endregion

        #region LOADING

        public UserControl_Game(string _petName, int _Days, int _happiness, int _HapBonus, int _hunger, int _HungerModifier, string pet, string description_pet, string age, string description_age)
        {
            InitializeComponent();

            mPetName = _petName;
            mTotalDays = _Days;
            mHappiness = _happiness;
            mHappinessBonus = _HapBonus;
            mHunger = _hunger;
            mHungerModifier = _HungerModifier;

            tblc_pet.Text = pet;
            tblc_description.Text = description_pet;

            tblc_age.Text = age;
            tblc_description_age.Text = description_age;

            ImageSourceConverter imgs = new ImageSourceConverter();
            img_Pet.SetValue(Image.SourceProperty, imgs.ConvertFromString(string.Format("pack://application:,,,/Images/{0}.png", pet)));

            mediaPlayer.Open(new Uri(string.Format("{0}\\Rainbow_Forest.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
            if ((bool)Settings.Default["music"] == true)
            {
                mediaPlayer.Play();
            }

            // Show buttons to buy items the can be afforded
            CheckItemsAvailability();
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

            #region writing daily comments

            mDailyCommentsEnabled = (bool)Settings.Default["dailyComments"];

            if (mDailyCommentsEnabled == true)
            {
                ArrayList lst = new ArrayList();
                lst.AddRange(mComments);

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

            tblc_day.Text = string.Format("{0}/{1}", mCurrentDay, mTotalDays);

            tblc_PetName.Text = mPetName;
            tblc_currentHappiness.Text = string.Format("{0}", mHappiness);
            tblc_currentHunger.Text = string.Format("{0}", mHunger);
            tblc_currentMoney.Text = string.Format("{0}", mMoney);
            tblc_currentFreeHours.Text = string.Format("{0}", mFreeHours);

            if (qu.Count > 0) tblc_DailyMessage.Text = qu.Dequeue().ToString();

            DailyChoice1.Content = string.Format("Take {0} for a walk ( + {1} ♥, -1 free hour", mPetName, mHappinessforWalk);
            DailyChoice2.Content = "Feed your pet with vegetables (+5 ♥, -1 hunger, -$1)";
        }

        #endregion

        #region MENU

        void RestartGame()
        {
            mediaPlayer.Stop();
            (Parent as Window).Content = new UserControl_SelectPet();
        }

        private void ShowMenu(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.4;
            this.Effect = new BlurEffect();

            Window_Menu w = new Window_Menu()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };
            if (w.ShowDialog() == false)
            {
                string command = w.command;

                this.Opacity = 1;
                this.Effect = null;
                (Parent as Window).ShowInTaskbar = true;

                if ((bool)Settings.Default["music"] == false)
                {
                    mediaPlayer.Stop();
                }
                else
                {
                    mediaPlayer.Position = TimeSpan.Zero;
                    mediaPlayer.Play();
                }

                if (command == "restart")
                {
                    RestartGame();
                }
                else if (command == "mainmenu")
                {
                    mediaPlayer.Stop();
                    (Parent as Window).Content = new UserControl_MainMenu();
                }
                else
                {

                }
            }
        }

        #endregion

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (DailyChoice1.IsChecked == true && mFreeHours >= 1)
            {
                mHappiness += mHappinessforWalk;
                mFreeHours--;
            }
            else if (DailyChoice2.IsChecked == true && mMoney >= 1)
            {
                mHappiness += 5;
                mMoney--;
                mHunger--;
            }
            else if (DailyChoice3.IsChecked == true && mDailyChoice3Available == true && mFreeHours >= 2)
            {
                mHappiness += 15;
                mFreeHours -= 2;
            }

            rnd = new Random();
            if (mHunger > 0)
            {
                mHappiness -= (mHunger * mHungerModifier) + rnd.Next(0, 2);
            }

            if (mBigBonePurchased == false)
            {
                mHunger += 1;
            }

            if (mHunger < 0)
            {
                mHunger = 0;
            }

            mHappiness += mHappinessBonus;
            mMoney++;
            mFreeHours++;
            Play();
        }

        void Play()
        {
            DailyChoice3.Visibility = Visibility.Hidden;

            tblc_currentHappiness.Text = mHappiness.ToString();
            tblc_currentHunger.Text = mHunger.ToString();
            tblc_currentMoney.Text = mMoney.ToString();
            tblc_currentFreeHours.Text = mFreeHours.ToString();
            pb_days.Value = ((double)mCurrentDay / mTotalDays) * 100;

            mCurrentDay++;
            if (mCurrentDay > mTotalDays) Final();
            else
            {
                tblc_day.Text = string.Format("{0}/{1}", mCurrentDay, mTotalDays);

                if (mCurrentDay == mTotalDays) tblc_LastDay.Visibility = Visibility.Visible;

                if (qu.Count > 0)
                {
                    tblc_DailyMessage.Text = qu.Dequeue().ToString();
                }

                if (rnd.Next(0, 6) == 1)
                {
                    DailyChoice3.Visibility = Visibility.Visible;
                    mDailyChoice3Available = true;

                    if (mFreeHours < 2)
                        DailyChoice3.IsEnabled = false;
                    else DailyChoice3.IsEnabled = true;
                }
                else
                {
                    if (DailyChoice3.IsChecked == true)
                    {
                        DailyChoice1.IsChecked = true;
                    }
                }
            }

            CheckItemsAvailability();
        }

        void CheckItemsAvailability()
        {
            btn_BuyBone.Visibility = btn_BuyToy.Visibility = btn_BuyForage.Visibility = btn_BuyFruit.Visibility = Visibility.Hidden;

            if (mMoney >= mPriceBone)
                btn_BuyBone.Visibility = Visibility.Visible;

            if (mMoney >= mPriceToy)
                btn_BuyToy.Visibility = Visibility.Visible;

            if (mMoney >= mPriceVegetables)
                btn_BuyForage.Visibility = Visibility.Visible;

            if (mMoney >= mPriceFruits)
                btn_BuyFruit.Visibility = Visibility.Visible;
        }

        void Final()
        {
            btn_Next.Visibility = Visibility.Hidden;

            this.Opacity = 0.4;
            this.Effect = new BlurEffect();

            Window_Final w = new Window_Final(mHappiness)
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };
            w.ShowDialog();

            this.Opacity = 1;
            this.Effect = null;
            (Parent as Window).ShowInTaskbar = true;
            RestartGame();
        }

        private void BtnBuyBone_Click(object sender, RoutedEventArgs e)
        {
            if (mBigBonePurchased == false && mMoney >= mPriceBone)
            {
                btn_BuyBone.Background = Brushes.DeepSkyBlue;
                btn_BuyBone.Content = "Purchased";
                mBigBonePurchased = true;
                mHunger = 0;
                mMoney -= mPriceBone;
                btn_BuyBone.IsEnabled = false;
                tblc_currentHunger.Text = mHunger.ToString();
                tblc_currentMoney.Text = mMoney.ToString();

                CheckItemsAvailability();
            }
        }

        private void btnBuyToy_Click(object sender, RoutedEventArgs e)
        {
            if (mMoney >= mPriceToy)
            {
                mHappinessBonus += 1;
                mMoney -= mPriceToy;
                tblc_currentMoney.Text = mMoney.ToString();

                if (mHappinessBonus > 2)
                {
                    btn_BuyToy.Content = "Purchased";
                    btn_BuyToy.Background = Brushes.DodgerBlue;
                    btn_BuyToy.IsEnabled = false;
                }

                CheckItemsAvailability();
            }
        }

        private void BtnBuyForage_Click(object sender, RoutedEventArgs e)
        {
            if (mMoney >= mPriceVegetables)
            {
                btn_BuyForage.Background = Brushes.SteelBlue;
                btn_BuyForage.Content = "Purchased";
                mHungerModifier -= 1;
                mMoney -= mPriceVegetables;
                btn_BuyForage.IsEnabled = false;
                tblc_currentMoney.Text = mMoney.ToString();

                CheckItemsAvailability();
            }
        }

        private void btnBuyFruit_Click(object sender, RoutedEventArgs e)
        {
            if (mMoney >= mPriceFruits)
            {
                mHunger -= 2;
                mMoney -= mPriceFruits;
                tblc_currentMoney.Text = mMoney.ToString();
                tblc_currentHunger.Text = mHunger.ToString();

                CheckItemsAvailability();
            }
        }
    }
}
