﻿using Battleship.Database;
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

                Player player1 = new Player("Toto", false);
                Player player2 = new Player("IA", true);

                Game game = Game.Instance;
                System.Console.WriteLine("game before" + Game.Instance.ToString());
                game.Width = 15;
                game.Height = 15;
                game.Player1 = player1;
                game.Player2 = player2;
                db.GamesDbSet.Add(game);
                System.Console.WriteLine("game after" + Game.Instance.ToString());


                db.PlayersDbSet.Add(player1);
                db.PlayersDbSet.Add(player2);

                Boat boat1 = new Boat(destroyer);
                boat1.X = 6;
                boat1.Y = 1;
                boat1.Width = 2;                
                boat1.Height = 3;                
                boat1.Orientation = true;
                boat1.Player = player1;

                Boat boat2 = new Boat(crusader);
                boat2.X = 2;
                boat2.Y = 1;
                boat2.Width = 1;
                boat2.Height = 2;
                boat2.Orientation = true;
                boat2.Player = player1;

                Boat boat3 = new Boat(aircraftCarrier);
                boat3.X = 3;
                boat3.Y = 1;
                boat3.Width = 1;
                boat3.Height = 2;
                boat3.Orientation = true;
                boat3.Player = player1;

                Boat boat4 = new Boat(submarine);
                boat4.X = 4;
                boat4.Y = 1;
                boat4.Width = 1;
                boat4.Height = 2;
                boat4.Orientation = true;
                boat4.Player = player1;

                Boat boat5 = new Boat(destroyer);
                boat5.X = 5;
                boat5.Y = 1;
                boat5.Width = 1;
                boat5.Height = 2;
                boat5.Orientation = true;
                boat5.Player = player2;

                Boat boat6 = new Boat(crusader);
                boat6.X = 6;
                boat6.Y = 1;
                boat6.Width = 1;
                boat6.Height = 2;
                boat6.Orientation = true;
                boat6.Player = player2;

                Boat boat7 = new Boat(aircraftCarrier);
                boat7.X = 7;
                boat7.Y = 1;
                boat7.Width = 1;
                boat7.Height = 2;
                boat7.Orientation = true;
                boat7.Player = player2;

                Boat boat8 = new Boat(submarine);
                boat8.X = 8;
                boat8.Y = 1;
                boat8.Width = 1;
                boat8.Height = 2;
                boat8.Orientation = true;
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
