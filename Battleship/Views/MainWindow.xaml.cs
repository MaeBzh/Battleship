using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();
     

            Settings settings = new Settings();
            settings.game = Game.Instance;
            Boat boat = settings.game.Player1.Boats[0];
            System.Console.WriteLine("boat : " + boat);
            this.Content = new GamePage();

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions

       
     
        #endregion

        #region Events
        #endregion



    }
}
