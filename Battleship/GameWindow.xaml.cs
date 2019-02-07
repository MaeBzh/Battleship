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
using System.Windows.Shapes;

namespace Battleship
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private Player player1;
        private Player player2;
        private Array player1Cells;
        private Array player2Cells;
        private Array player1TouchableCells;
        private Array player2TouchableCells;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public Game GetConfiguration() {
            Game game = Game.Instance;
            return game;
        }

        

        #endregion

        #region Events
        #endregion


    }
}
