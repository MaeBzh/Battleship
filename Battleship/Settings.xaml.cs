using Battleship.Database;
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

namespace Battleship
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        Game game;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            InitializeGame();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions

        public void InitializeGame()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BoatType destroyer = new BoatType("destroyer", 1, 2);
                BoatType crusader = new BoatType("crusader", 1, 3);
                BoatType aircraftCarrier = new BoatType("aircraft-carrier", 1, 5);
                BoatType submarine = new BoatType("submarine", 1, 5);
                db.BoatTypesDbSet.Add(destroyer);
                db.BoatTypesDbSet.Add(crusader);
                db.BoatTypesDbSet.Add(aircraftCarrier);
                db.BoatTypesDbSet.Add(submarine);

                Player player1 = new Player("Toto", false);
                Player player2 = new Player("IA", true);

                this.game = new Game(15, 15);
                this.game.Player1 = player1;
                this.game.Player2 = player2;
                db.GamesDbSet.Add(this.game);

                db.PlayersDbSet.Add(player1);
                db.PlayersDbSet.Add(player2);

                Boat boat1 = new Boat(destroyer);
                boat1.X = 1;
                boat1.Y = "A";
                boat1.Orientation = "vertical";
                boat1.Player = player1;

                Boat boat2 = new Boat(crusader);
                boat2.X = 2;
                boat2.Y = "A";
                boat2.Orientation = "vertical";
                boat2.Player = player1;

                Boat boat3 = new Boat(aircraftCarrier);
                boat3.X = 3;
                boat3.Y = "A";
                boat3.Orientation = "vertical";
                boat3.Player = player1;

                Boat boat4 = new Boat(submarine);
                boat4.X = 4;
                boat4.Y = "A";
                boat4.Orientation = "vertical";
                boat4.Player = player1;

                Boat boat5 = new Boat(destroyer);
                boat5.X = 5;
                boat5.Y = "A";
                boat5.Orientation = "vertical";
                boat5.Player = player2;

                Boat boat6 = new Boat(crusader);
                boat6.X = 6;
                boat6.Y = "A";
                boat6.Orientation = "vertical";
                boat6.Player = player2;

                Boat boat7 = new Boat(aircraftCarrier);
                boat7.X = 7;
                boat7.Y = "A";
                boat7.Orientation = "vertical";
                boat7.Player = player2;

                Boat boat8 = new Boat(submarine);
                boat8.X = 8;
                boat8.Y = "A";
                boat8.Orientation = "vertical";
                boat8.Player = player2;

                db.BoatsDbSet.Add(boat1);
                db.BoatsDbSet.Add(boat2);
                db.BoatsDbSet.Add(boat3);
                db.BoatsDbSet.Add(boat4);
                db.BoatsDbSet.Add(boat5);
                db.BoatsDbSet.Add(boat6);
                db.BoatsDbSet.Add(boat7);
                db.BoatsDbSet.Add(boat8);

                db.SaveChanges();
                this.txtX.Text = this.game.ToString();
            }
        }

        #endregion

        #region Events
        #endregion
    }
}
