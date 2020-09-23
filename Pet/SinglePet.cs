namespace Pet
{
    public class SinglePet
    {
        public string petName;

        /// <summary>
        /// The number of days in the game. The game balance should rely on this number. Cannot be negative.
        /// </summary>
        public int totalDays = 15;

        public int happiness = 15;
        public int happinessBonus;
        public int hunger;
        public int hungerModifier = 2;
        public string pet;
        public string petDescription;
        public string age;
        public string ageDescription;
    }
}
