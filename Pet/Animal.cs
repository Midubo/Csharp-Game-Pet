﻿using System.ComponentModel;

namespace Pet
{
    public enum PetType { Puppy, Kitty, Parrot, Hamster, Panda }

    public enum AgeType { One, Six, Twelve }

    public class Animal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string propertyName) { var handlers = PropertyChanged; handlers(this, new PropertyChangedEventArgs(propertyName)); }

        private PetType _Type;
        public PetType Type
        {
            get { return _Type; }

            set
            {
                _Type = value;
                ChangeToType(value);
                RaisePropertyChanged("Type");
            }
        }

        public string ImageSource { get; set; }
        public string Special { get; set; }
        public string AgeSpecial { get; set; }

        public int Days { get; set; }

        public int StartHunger { get; set; }
        public int StartHappiness { get; set; }

        public int DailyHappy { get; set; }
        public int DailyHunger { get; set; }


        public string Description { get; set; }

        void ChangeToType(PetType type)
        {
            if (type == PetType.Puppy)
            {
                Days = 0;
                DailyHunger = 0;
                StartHappiness = 0;
                DailyHappy = 0;
                Special = "None";
                ImageSource = "pack://application:,,,/Images/puppy.png";
                Description = "Puppy! Cute, loyal and playful! And clever, too: dogs understand up to 250 words, and even a small puppy is a great weather forecaster. As a bonus, you will switch from walking to running: the fastest dog runs at the speed of 67.32 km per hour. When you get a puppy, you get a friend for a long time: some dogs live up to 30 years old. Puppies start seeing as adult dogs only after a month. Did you know? While puppies have 28 teeth, dogs have 42! And remember: chocolate is a great danger to any dog!";
            }
            else if (type == PetType.Kitty)
            {
                Days = 1;
                DailyHunger = 0;
                StartHappiness = 0;
                DailyHappy = 0;
                Special = "+1 Day";
                ImageSource = "pack://application:,,,/Images/kitty.png";
                Description = "Meow here, meow there - kitty goes everywhere. Keep an eye on that soft ball, feed it but not too much - big bossy lazy cats go nowhere: 2/3 of a day they sleep. Energetic cats can run at 50 km per hour for some time. A cat will run even faster if you try to wash a cat. Cats meow only to talk to people, they don't meow with other cats. Your kitty is talking to you! Give your kitten something tasty and put it a bit aside because cats often don't see near objects. When you kitty turns into a cat, you will see that the eye color is different!";
            }
            else if (type == PetType.Parrot)
            {
                Days = 0;
                DailyHunger = -1;
                StartHappiness = 0;
                DailyHappy = 0;
                Special = "Hunger 50% weaker";
                ImageSource = "pack://application:,,,/Images/parrot.png";
                Description = "Be careful with what you say! Be careful with what you say! Your parrot repeats! A parrot knows up to 400 words in a few languages. A parrot can be a great musical producer but decided to be your pet. Parrots often dance when they hear music. And when you open the cage, you let out a helicopter! Small parrots can live up to 25 years, and big parrots can live up to 100 years! Remember: never give your parrot soda!";
            }
            else if (type == PetType.Hamster)
            {
                Days = -1;
                DailyHunger = 0;
                StartHappiness = 10;
                DailyHappy = 0;
                Special = "+10 ♥\n-1 Day";
                ImageSource = "pack://application:,,,/Images/hamster.png";
                Description = "Hamsters are very popular. You don't need much time and money to have a hamster. A lot of people often take a hamster as the first pet. Your hamster can eat corn, grass, insects and even a piece of boiled chicken BUT it must necessarily be cooked without salt or spices. You need only one hamster-friend in one cage, because two of them often fight with each other. Hamsters like to run - put a wheel in the cage, and your hamster will run 10km the same day!";
            }
            else if (type == PetType.Panda)
            {
                Days = 0;
                DailyHunger = 0;
                StartHappiness = 0;
                DailyHappy = 1;
                Special = "+1 ♥ every day";
                ImageSource = "pack://application:,,,/Images/panda.png";
                Description = "A panda is not actually a pet. A black and white panda is an exotic animal which lives in forests in China. But imagine that you can have a little panda! Little pandas are white. They don't see anything and don't have teeth. After a month, they become large and get nice black spots. When pandas have free time, they eat. Pandas usually eat only bamboo. These animals are very cute but big. They are so big that other animals can't hurt them. There are also red pandas.";
            }
            RaisePropertyChanged("ImageSource");
            RaisePropertyChanged("Special");
            RaisePropertyChanged("Description");
        }
    }
}
