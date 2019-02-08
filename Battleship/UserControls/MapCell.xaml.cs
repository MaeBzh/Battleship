using Battleship.Models;
using Battleship.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public void resolveShot()
        {
            Game game = Game.Instance;
            Grid grid = this.Parent as Grid;
            Grid parentGrid = grid.Parent as Grid;
            Grid playerGrid = parentGrid.FindName("playerGrid") as Grid;
            Grid iaGrid = parentGrid.FindName("iaGrid") as Grid;
            GamePage gamePage = parentGrid.Parent as GamePage;


            //Player turn
            //show text block "your turn"
            System.Console.WriteLine("Player turn");

            Shot shotPlayer = new Shot();
            shotPlayer.X = this.X;
            shotPlayer.Y = this.Y;
            game.Player.Shots.Add(shotPlayer);
            if (grid == iaGrid)
            {
                MapCell shootCellIa = iaGrid.Children.Cast<MapCell>()
                                .FirstOrDefault(fc => Grid.GetColumn(fc) == shotPlayer.X && Grid.GetRow(fc) == shotPlayer.Y);
                
                if (gamePage.occupiedCellsIA.Contains(shootCellIa))
                {
                    shootCellIa.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    foreach (Boat boat in gamePage.boatsPlayerIa)
                    {
                        foreach (int[] cell in boat.getHitBox())
                        {
                            MapCell mapCell = iaGrid.Children.Cast<MapCell>()
                                   .FirstOrDefault(fc => Grid.GetColumn(fc) == cell[0] && Grid.GetRow(fc) == cell[1]);
                            if (mapCell == shootCellIa)
                            {
                                gamePage.touchedBoatIA.Add(boat);
                                gamePage.touchedCellsIA.Add(shootCellIa);                           
                                System.Console.WriteLine(boat.BoatType.Name + " touché");
                                gamePage.checkForSankBoat(boat);
                            }
                        }
                    }
                }
                else
                {
                    shootCellIa.Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                game.Currentplayer = game.PlayerIa;
            }

            // IA Turn
            //show text block "ia turn"
            System.Console.WriteLine("IA turn");

            Shot shotIa = new Shot();
            Random random = new Random();
            shotIa.X = random.Next(0, game.Width);
            shotIa.Y = random.Next(0, game.Height);
            game.PlayerIa.Shots.Add(shotIa);
            MapCell shootCellPlayer = playerGrid.Children.Cast<MapCell>()
                           .FirstOrDefault(fc => Grid.GetColumn(fc) == shotIa.X && Grid.GetRow(fc) == shotIa.Y);
            if (gamePage.occupiedCellsPlayer.Contains(shootCellPlayer))
            {
                shootCellPlayer.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            }
            else
            {
                shootCellPlayer.Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            };
            game.Currentplayer = game.Player;
        }

        #endregion

        #region Events
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.resolveShot();
        }

    }
}
