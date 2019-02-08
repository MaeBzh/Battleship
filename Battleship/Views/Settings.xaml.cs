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

namespace Battleship.Views
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
        public Game game;
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
            setConfiguration();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions

        public void setConfiguration()
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

                Player playerIa = new Player("IA", true);
                Player player = new Player("Toto", false);

                Game game = Game.Instance;
                System.Console.WriteLine("game before" + Game.Instance.ToString());
                game.Width = 15;
                game.Height = 15;
                game.PlayerIa = playerIa;
                game.Player = player;
                db.GamesDbSet.Add(game);
                System.Console.WriteLine("game after" + Game.Instance.ToString());


                db.PlayersDbSet.Add(playerIa);
                db.PlayersDbSet.Add(player);

                Boat boat1 = new Boat(destroyer);
                boat1.Width = 2;                
                boat1.Height = 3;                
                boat1.Orientation = true;
                boat1.Player = playerIa;

                Boat boat2 = new Boat(crusader);
                boat2.Width = 1;
                boat2.Height = 4;
                boat2.Orientation = false;
                boat2.Player = playerIa;

                Boat boat3 = new Boat(aircraftCarrier);
                boat3.Width = 2;
                boat3.Height = 2;
                boat3.Orientation = true;
                boat3.Player = playerIa;

                Boat boat4 = new Boat(submarine);
                boat4.Width = 1;
                boat4.Height = 2;
                boat4.Orientation = false;
                boat4.Player = playerIa;

                Boat boat5 = new Boat(destroyer);
                boat5.Width = 2;
                boat5.Height = 3;
                boat5.Orientation = true;
                boat5.Player = player;

                Boat boat6 = new Boat(crusader);
                boat6.Width = 1;
                boat6.Height = 4;
                boat6.Orientation = false;
                boat6.Player = player;

                Boat boat7 = new Boat(aircraftCarrier);
                boat7.Width = 2;
                boat7.Height = 2;
                boat7.Orientation = true;
                boat7.Player = player;

                Boat boat8 = new Boat(submarine);
                boat8.Width = 1;
                boat8.Height = 2;
                boat8.Orientation = false;
                boat8.Player = player;

                db.BoatsDbSet.Add(boat1);
                db.BoatsDbSet.Add(boat2);
                db.BoatsDbSet.Add(boat3);
                db.BoatsDbSet.Add(boat4);
                db.BoatsDbSet.Add(boat5);
                db.BoatsDbSet.Add(boat6);
                db.BoatsDbSet.Add(boat7);
                db.BoatsDbSet.Add(boat8);

                db.SaveChanges();
                this.txtX.Text = game.ToString();
            }
        }

        #endregion

        #region Events
        public void btnEvent()
        {
            //send  to gameWindow with
        }
        #endregion
    }
}
