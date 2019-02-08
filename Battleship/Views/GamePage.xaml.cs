using Battleship.Database;
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
        public List<MapCell> touchedCellsIA = new List<MapCell>();
        public List<MapCell> touchedCellsPlayer = new List<MapCell>();
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
                            /*if(grid.Name == "playerGrid")
                            {
                                mapCell.Button.IsEnabled = false;
                            }*/    
                            
                        }));
                    }
                }
            });
            

        }

        public Boolean setRandomPlace(Boat boat, Grid grid, List<MapCell> occupiedCells)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {              
                Boolean possiblePlace = true;
                Random random = new Random();
                boat.X = random.Next(0, mapWidth - boat.Width);
                boat.Y = random.Next(0, mapHeight - boat.Height);
                db.BoatsDbSet.Add(boat);
                db.SaveChanges();
                foreach (int[] cell in boat.getHitBox())
                {
                    MapCell mapCell = grid.Children.Cast<MapCell>()
                                .FirstOrDefault(fc => Grid.GetColumn(fc) == cell[0] && Grid.GetRow(fc) == cell[1]);
                    if (occupiedCells.Contains(mapCell))
                    {
                        possiblePlace = false;
                    }
                    else
                    {
                        possiblePlace = true;
                        occupiedCells.Add(mapCell);
                    }
                }
                return possiblePlace;
            }
        }

        public void randomBoatPlacement(List<Boat> boatList)
        {

            foreach (Boat boat in boatList)
            {
                if (boat.Player.IsIA)
                {
                    while (!this.setRandomPlace(boat, this.iaGrid, this.occupiedCellsIA))
                    {
                        this.setRandomPlace(boat, this.iaGrid, this.occupiedCellsIA);
                    }
                    foreach (MapCell occupiedCell in this.occupiedCellsIA)
                    {
                        if (occupiedCell != null)
                        {
                            occupiedCell.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 255));
                        }
                    }


                }
                else
                {
                    while (!this.setRandomPlace(boat, this.playerGrid, this.occupiedCellsPlayer))
                    {
                        this.setRandomPlace(boat, this.playerGrid, this.occupiedCellsPlayer);
                    }
                    foreach (MapCell occupiedCell in this.occupiedCellsPlayer)
                    {
                        if (occupiedCell != null)
                        {
                            occupiedCell.Button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 255));
                        }
                    }

                }
                this.btn_random.IsEnabled = false;
            }
        }

        public void startGame()
        {
            Game game = Game.Instance;
            Game.Instance.Currentplayer = Game.Instance.Player;
            this.turn.Text = "A votre tour";
        }

        public Boolean checkForSankBoat(Boat boat)
        {
            Boolean sank = false;
            int count = boat.getHitBox().Count;
            if (count > 0)
            {
                foreach (int[] cell in boat.getHitBox())
                {
                    MapCell mapCell = iaGrid.Children.Cast<MapCell>()
                                     .FirstOrDefault(fc => Grid.GetColumn(fc) == cell[0] && Grid.GetRow(fc) == cell[1]);
                    if (this.touchedCellsIA.Contains(mapCell))
                    {
                        count--;
                        if (count == 0)
                        {                            
                            sank = true;
                        }
                    }
                }
            }
            return sank;
        }


        #endregion

        #region Events
        private void Random_placement(object sender, RoutedEventArgs e)
        {
            this.occupiedCellsIA.Clear();
            this.occupiedCellsPlayer.Clear();
            this.randomBoatPlacement(this.boatsPlayerIa);
            this.randomBoatPlacement(this.boatsPlayer);
            startGame();
        }
        #endregion
      
    }
}
