using Battleship.Models;
using Battleship.Views;
using System;
using System.Linq;
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
            this.button_cell.Background = new SolidColorBrush(Color.FromRgb(66, 66, 66));
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions 
        /// <summary>
        /// When human player play, check if th shot touched a boat.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="grid"></param>
        /// <param name="iaGrid"></param>
        /// <param name="gamePage"></param>
        public void playerTurn(Game game, Grid grid, Grid iaGrid, GamePage gamePage)
        {
            //Player turn
            //todo : show text block "your turn"
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
                    Boolean boatFound = false;
                    foreach (Boat boat in gamePage.boatsPlayerIa)
                    {
                        foreach (int[] cell in boat.getHitBox())
                        {
                            MapCell mapCell = iaGrid.Children.Cast<MapCell>()
                                   .FirstOrDefault(fc => Grid.GetColumn(fc) == cell[0] && Grid.GetRow(fc) == cell[1]);
                            if (mapCell == shootCellIa)
                            {
                                boatFound = true;
                                gamePage.touchedCellsIA.Add(shootCellIa);
                                System.Console.WriteLine(boat.BoatType.Name + " touché");
                                gamePage.shots.Items.Insert(0, "Vous : " + boat.BoatType.Name + " touché !");
                                shootCellIa.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                                if (gamePage.checkForSankBoat(boat))
                                {
                                    System.Console.WriteLine(boat.BoatType.Name + " coulé ");
                                    gamePage.shots.Items.Insert(0, "Vous : " + boat.BoatType.Name + " coulé !");
                                }

                                break;
                            }
                        }

                        if (boatFound)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("A l'eau !");
                    gamePage.shots.Items.Insert(0, "Vous : A l'eau !");
                    shootCellIa.Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }

                game.Currentplayer = game.PlayerIa;
                System.Console.WriteLine("IA turn");
                gamePage.turn.Text = "Au tour de l'IA";

            }
        }
        /// <summary>
        /// When ia player play, add random coordinates and check if the shot touched a boat.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="grid"></param>
        /// <param name="playerGrid"></param>
        /// <param name="gamePage"></param>
        public void iaTurn(Game game, Grid grid, Grid playerGrid, GamePage gamePage)
        {
            // IA Turn
            //todo : show text block "ia turn"

            Shot shotIa = new Shot();
            Random random = new Random();
            shotIa.X = random.Next(0, game.Width);
            shotIa.Y = random.Next(0, game.Height);
            game.PlayerIa.Shots.Add(shotIa);
            MapCell shootCellPlayer = playerGrid.Children.Cast<MapCell>()
                           .FirstOrDefault(fc => Grid.GetColumn(fc) == shotIa.X && Grid.GetRow(fc) == shotIa.Y);
            if (gamePage.occupiedCellsPlayer.Contains(shootCellPlayer))
            {
                Boolean boatFound = false;
                foreach (Boat boat in gamePage.boatsPlayer)
                {
                    foreach (int[] cell in boat.getHitBox())
                    {
                        MapCell mapCell = playerGrid.Children.Cast<MapCell>()
                               .FirstOrDefault(fc => Grid.GetColumn(fc) == cell[0] && Grid.GetRow(fc) == cell[1]);
                        if (mapCell == shootCellPlayer)
                        {
                            gamePage.touchedCellsPlayer.Add(shootCellPlayer);
                            System.Console.WriteLine(boat.BoatType.Name + " touché");
                            gamePage.shots.Items.Insert(0, "IA : " + boat.BoatType.Name + " touché !");
                            shootCellPlayer.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                            // Boat is killed 
                            if (gamePage.checkForSankBoat(boat))
                            {
                                System.Console.WriteLine(boat.BoatType.Name + " coulé ");
                                gamePage.shots.Items.Insert(0, "IA : " + boat.BoatType.Name + " coulé !");
                            }
                            break;
                        }
                    }

                    if (boatFound)
                    {
                        break;
                    }
                   
                }
            } else
            {
                System.Console.WriteLine(" à l'eau !");
                gamePage.shots.Items.Insert(0, "IA : à l'eau !");
                shootCellPlayer.Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            game.Currentplayer = game.Player;
            System.Console.WriteLine("Player turn");
            gamePage.turn.Text = "A votre tour !";
        }

        /// <summary>
        /// resolve ia and players shots
        /// </summary>
        public void resolveShot()
        {
            Game game = Game.Instance;
            Grid grid = this.Parent as Grid;
            Grid parentGrid = grid.Parent as Grid;
            Grid playerGrid = parentGrid.FindName("playerGrid") as Grid;
            Grid iaGrid = parentGrid.FindName("iaGrid") as Grid;
            GamePage gamePage = parentGrid.Parent as GamePage;

            this.playerTurn(game, grid, iaGrid, gamePage);
            this.iaTurn(game, grid, playerGrid, gamePage);

            if (gamePage.touchedCellsIA.Count == gamePage.occupiedCellsIA.Count)
            {
                System.Console.WriteLine("Vous avez gagné !");
                iaGrid.IsEnabled = false;
                playerGrid.IsEnabled = false;
                gamePage.btn_replay.IsEnabled = true;
                gamePage.winner.Text = "Vous avez gagné !";

            }
            else if (gamePage.touchedCellsPlayer.Count == gamePage.occupiedCellsPlayer.Count)
            {
                System.Console.WriteLine("Vous avez perdu !");
                iaGrid.IsEnabled = false;
                playerGrid.IsEnabled = false;
                gamePage.btn_replay.IsEnabled = true;
                gamePage.winner.Text = "Vous avez gagné !";
            }
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
