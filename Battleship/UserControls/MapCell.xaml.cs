using Battleship.Models;
using Battleship.Views;
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

namespace Battleship.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class MapCell : UserControl
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int x;
        private int y;
        private Button button;
        #endregion

        #region Properties
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Button Button
        {
            get { return button; }
            set { button = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MapCell()
        {
            InitializeComponent();
            this.Button = this.button_cell;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("button clicked :" + this.X + "," + this.Y);
            Game game = Game.Instance;
            Shot shotPlayer = new Shot();
            shotPlayer.X = this.X;
            shotPlayer.Y = this.Y;
            game.Player.Shots.Add(shotPlayer);
            game.Currentplayer = game.PlayerIa;
            Grid grid = this.Parent as Grid;        

            MapCell shootCell = grid.Children.Cast<MapCell>()
                            .FirstOrDefault(fc => Grid.GetColumn(fc) == shotPlayer.X && Grid.GetRow(fc) == shotPlayer.Y);
            Grid parentGrid = grid.Parent as Grid;
            GamePage gamePage = parentGrid.Parent as GamePage;
            System.Console.WriteLine("shoot cell : " + shootCell.X + "," + shootCell.Y);
            if (gamePage.occupiedCellsIA.Contains(shootCell)){
                shootCell.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            } else
            {
                shootCell.Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            // todo change color MapCell
            // todo disable MapCell
            new SolidColorBrush(Color.FromRgb(255, 0, 255));

            // IA Turn
            Shot shotIa = new Shot();
            shotPlayer.X = this.X;
            shotPlayer.Y = this.Y;
            
        }
    }
}
