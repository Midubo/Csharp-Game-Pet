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

        int mCurrentDay = 1, mMoney = 1;

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

        private SinglePet mSinglePet;

        #endregion

        #region LOADING

        public UserControl_Game(SinglePet singlePet)
        {
            InitializeComponent();

            mSinglePet = singlePet;

            tblc_pet.Text = mSinglePet.pet;
            tblc_description.Text = mSinglePet.petDescription;

            tblc_age.Text = mSinglePet.age;
            tblc_description_age.Text = mSinglePet.ageDescription;

            ImageSourceConverter imgs = new ImageSourceConverter();
            img_Pet.SetValue(Image.SourceProperty, imgs.ConvertFromString(string.Format("pack://application:,,,/Images/{0}.png", mSinglePet.pet)));

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

            tblc_day.Text = string.Format("{0}/{1}", mCurrentDay, mSinglePet.totalDays);

            tblc_PetName.Text = mSinglePet.petName;
            tblc_currentHappiness.Text = string.Format("{0}", mSinglePet.happiness);
            tblc_currentHunger.Text = string.Format("{0}", mSinglePet.hunger);
            tblc_currentMoney.Text = string.Format("{0}", mMoney);
            tblc_currentFreeHours.Text = string.Format("{0}", mFreeHours);

            if (qu.Count > 0) tblc_DailyMessage.Text = qu.Dequeue().ToString();

            DailyChoice1.Content = string.Format("Take {0} for a walk ( + {1} ♥, -1 free hour", mSinglePet.petName, mHappinessforWalk);
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
                mSinglePet.happiness += mHappinessforWalk;
                mFreeHours--;
            }
            else if (DailyChoice2.IsChecked == true && mMoney >= 1)
            {
                mSinglePet.happiness += 5;
                mMoney--;
                mSinglePet.hunger--;
            }
            else if (DailyChoice3.IsChecked == true && mDailyChoice3Available == true && mFreeHours >= 2)
            {
                mSinglePet.happiness += 15;
                mFreeHours -= 2;
            }

            rnd = new Random();
            if (mSinglePet.hunger > 0)
            {
                mSinglePet.happiness -= (mSinglePet.hunger * mSinglePet.hungerModifier) + rnd.Next(0, 2);
            }

            if (mBigBonePurchased == false)
            {
                mSinglePet.hunger += 1;
            }

            if (mSinglePet.hunger < 0)
            {
                mSinglePet.hunger = 0;
            }

            mSinglePet.happiness += mSinglePet.happinessBonus;
            mMoney++;
            mFreeHours++;
            Play();
        }

        void Play()
        {
            DailyChoice3.Visibility = Visibility.Hidden;

            tblc_currentHappiness.Text = mSinglePet.happiness.ToString();
            tblc_currentHunger.Text = mSinglePet.hunger.ToString();
            tblc_currentMoney.Text = mMoney.ToString();
            tblc_currentFreeHours.Text = mFreeHours.ToString();
            pb_days.Value = ((double)mCurrentDay / mSinglePet.totalDays) * 100;

            mCurrentDay++;
            if (mCurrentDay > mSinglePet.totalDays) Final();
            else
            {
                tblc_day.Text = string.Format("{0}/{1}", mCurrentDay, mSinglePet.totalDays);

                if (mCurrentDay == mSinglePet.totalDays) tblc_LastDay.Visibility = Visibility.Visible;

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

            Window_Final w = new Window_Final(mSinglePet.happiness)
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
                mSinglePet.hunger = 0;
                mMoney -= mPriceBone;
                btn_BuyBone.IsEnabled = false;
                tblc_currentHunger.Text = mSinglePet.hunger.ToString();
                tblc_currentMoney.Text = mMoney.ToString();

                CheckItemsAvailability();
            }
        }

        private void btnBuyToy_Click(object sender, RoutedEventArgs e)
        {
            if (mMoney >= mPriceToy)
            {
                mSinglePet.happinessBonus += 1;
                mMoney -= mPriceToy;
                tblc_currentMoney.Text = mMoney.ToString();

                if (mSinglePet.happinessBonus > 2)
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
                mSinglePet.hungerModifier -= 1;
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
                mSinglePet.hunger -= 2;
                mMoney -= mPriceFruits;
                tblc_currentMoney.Text = mMoney.ToString();
                tblc_currentHunger.Text = mSinglePet.hunger.ToString();

                CheckItemsAvailability();
            }
        }
    }
}
