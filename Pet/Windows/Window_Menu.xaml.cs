using Pet.Properties;
using System.IO;
using System.Windows;

namespace Pet
{

    public partial class Window_Menu : Window
    {
        public string command;

        #region Private members

        private SinglePet mSinglePet;

        private int mCoins;

        private int mFreeHours;

        private int mCurrentDay;

        /// <summary>
        /// Indicates whether item "Vegetables" was purchased
        /// </summary>
        private bool mVegetablesPurchased;

        /// <summary>
        /// Indicates whether item "Big Bone" was purchased
        /// </summary>
        private bool mBigBonePurchased;

        private bool mDailyChoice3Available;

        #endregion

        public Window_Menu(SinglePet singlePet, int coins, int freeHours, int currentDay, bool vegetablesPurchased, bool bigBonePurchased, bool dailyChoice3Available)
        {
            InitializeComponent();

            mSinglePet = singlePet;

            mCoins = coins;
            mFreeHours = freeHours;
            mCurrentDay = currentDay;

            mVegetablesPurchased = vegetablesPurchased;
            mBigBonePurchased = bigBonePurchased;

            mDailyChoice3Available = dailyChoice3Available;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkBox_Music.IsChecked = (bool)Settings.Default["music"];
        }

        private void Button_Continue(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            command = "restart";
            Close();
        }

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            command = "mainmenu";
            Close();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Settings.Default["music"] = checkBox_Music.IsChecked;

            Settings.Default.Save();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            // Create new file
            using (StreamWriter sw = File.CreateText($"save.sav"))
            {
                sw.WriteLine(mSinglePet.petName);
                sw.WriteLine(mSinglePet.totalDays);
                sw.WriteLine(mSinglePet.happiness);
                sw.WriteLine(mSinglePet.happinessBonus);
                sw.WriteLine(mSinglePet.hunger);
                sw.WriteLine(mSinglePet.hungerModifier);
                sw.WriteLine(mSinglePet.pet);
                sw.WriteLine(mSinglePet.petDescription);
                sw.WriteLine(mSinglePet.age);
                sw.WriteLine(mSinglePet.ageDescription);

                sw.WriteLine(mCoins);
                sw.WriteLine(mFreeHours);
                sw.WriteLine(mCurrentDay);

                sw.WriteLine(mVegetablesPurchased);
                sw.WriteLine(mBigBonePurchased);

                sw.WriteLine(mDailyChoice3Available);
            }

            Close();
        }
    }
}
