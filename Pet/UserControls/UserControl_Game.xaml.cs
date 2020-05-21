using System.Windows.Controls;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_Game.xaml
    /// </summary>
    public partial class UserControl_Game : UserControl
    {
        public UserControl_Game(string _petName, int _Days, int _happiness, int _HapBonus, int _hunger, int _HungerModifier, string pet, string description)
        {
            InitializeComponent();
        }
    }
}
