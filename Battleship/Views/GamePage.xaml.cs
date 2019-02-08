using Battleship.Models;
using Battleship.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Battleship.Views
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public int mapWidth = Game.Instance.Width;
        public int mapHeight = Game.Instance.Height;
        public List<Boat> boatsPlayerIa = Game.Instance.PlayerIa.Boats;
        public List<Boat> boatsPlayer = Game.Instance.Player.Boats;
        public List<MapCell> occupiedCellsIA = new List<MapCell>();
        public List<MapCell> occupiedCellsPlayer = new List<MapCell>();
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>      
        public GamePage()
        {
            InitializeComponent();
            this.setMap(this.iaGrid);
            this.setMap(this.playerGrid);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions         

        public void setMap(Grid grid)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            for (int i = 0; i < this.mapHeight; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                grid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < this.mapWidth; i++)
            {
                RowDefinition row = new RowDefinition();
                grid.RowDefinitions.Add(row);
            }

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.mapHeight; i++)
                {
                    for (int j = 0; j < this.mapWidth; j++)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            MapCell mapCell = new MapCell();
                            mapCell.X = i;
                            mapCell.Y = j;

                            Grid.SetColumn(mapCell, i);
                            Grid.SetRow(mapCell, j);

                            grid.Children.Add(mapCell);
                        
                        }));
                    }
                }
            });
        }

        public MapCell setRandomFirstCell(Boat boat)
        {
            MapCell result;
            if (boat.Orientation)
            {
                Random random = new Random();
                boat.X = random.Next(0, mapWidth + 1 - boat.Width);
                boat.Y = random.Next(0, mapHeight + 1 - boat.Height);
                result = playerGrid.Children.Cast<MapCell>().FirstOrDefault(fc => Grid.GetColumn(fc) == boat.X && Grid.GetRow(fc) == boat.Y);
            }
            else
            {
                Random random = new Random();
                boat.X = random.Next(0, mapWidth + 1 - boat.Height);
                boat.Y = random.Next(0, mapHeight + 1 - boat.Width);
                result = playerGrid.Children.Cast<MapCell>().FirstOrDefault(fc => Grid.GetColumn(fc) == boat.X && Grid.GetRow(fc) == boat.Y);
            }
            return result;
        }

        public void randomBoatPlacement(List<Boat> boatList)
        {
           
            foreach (Boat boat in boatList)
            {              
                if(boat.Player.IsIA) {
                    MapCell firstCell = this.setRandomFirstCell(boat);
                    while (this.occupiedCellsIA.Contains(firstCell))
                    {
                        firstCell = this.setRandomFirstCell(boat);
                    }
                    this.occupiedCellsIA.Add(firstCell);
                    foreach (int[] coordinates in boat.getHitBox())
                    {
                        MapCell cell = iaGrid.Children.Cast<MapCell>()
                            .FirstOrDefault(fc => Grid.GetColumn(fc) == coordinates[0] && Grid.GetRow(fc) == coordinates[1]);
                        cell.Button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        this.occupiedCellsIA.Add(cell);
                    }
                } else { 
                    MapCell firstCell = this.setRandomFirstCell(boat);
                    while (this.occupiedCellsPlayer.Contains(firstCell))
                    {
                        firstCell = this.setRandomFirstCell(boat);
                    }
                        this.occupiedCellsPlayer.Add(firstCell);
                    foreach (int[] coordinates in boat.getHitBox())
                    {
                        MapCell cell = playerGrid.Children.Cast<MapCell>()
                            .FirstOrDefault(fc => Grid.GetColumn(fc) == coordinates[0] && Grid.GetRow(fc) == coordinates[1]);
                        cell.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 255));
                        this.occupiedCellsPlayer.Add(cell);
                    }
                }
                this.btn_random.IsEnabled = false;
            }
        }

        public void startGame()
        {
            Game game = Game.Instance;
            Game.Instance.Currentplayer = Game.Instance.Player;
        }

        #endregion

        #region Events
        private void Random_placement(object sender, RoutedEventArgs e)
        {
            this.randomBoatPlacement(this.boatsPlayerIa);
            this.randomBoatPlacement(this.boatsPlayer);
        }
        #endregion

        private void Btn_play_Click(object sender, RoutedEventArgs e)
        {            
            startGame();
        }
    }
}
