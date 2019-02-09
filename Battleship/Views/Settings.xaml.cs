using Battleship.Database;
using Battleship.Models;
using System;
using System.Collections.ObjectModel;
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
using System.ComponentModel;


namespace Battleship.Views
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>


    public partial class Settings : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        Game game;
        ObservableCollection<BoatType> boattype = new ObservableCollection<BoatType>();
        ObservableCollection<Boat> boat = new ObservableCollection<Boat>();
        #endregion

        #region Property changed implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        #endregion



        #region Attributs
        #endregion

        #region Properties
        public ObservableCollection<BoatType> BoatType { get; set; }
        public ObservableCollection<Boat> Boat { get; set; }


        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            InitializeGame();
            this.DataContext = this;
            //this.DataContext = boat;
        }


        #endregion

        #region StaticFunctions
        #endregion

        #region Functions

        public void InitializeGame()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                // System.Console.WriteLine("----je passe ici-----------");


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

                this.game = Game.Instance;
                this.game.Width = 15;
                this.game.Height = 15;
                this.game.Player1 = player1;
                this.game.Player2 = player2;
                db.GamesDbSet.Add(this.game);

                db.PlayersDbSet.Add(player1);
                db.PlayersDbSet.Add(player2);

                Boat boat1 = new Boat(destroyer);
                boat1.X = this.xBoatxt.Text;
                boat1.Y = this.yBoatxt.Text;
                boat1.Orientation = true;
                boat1.Player = player1;

                Boat boat2 = new Boat(crusader);
                boat2.X = "2";
                boat2.Y = "A";
                boat2.Orientation = true;
                boat2.Player = player1;

                Boat boat3 = new Boat(aircraftCarrier);
                boat3.X = "3";
                boat3.Y = "A";
                boat3.Orientation = true;
                boat3.Player = player1;

                Boat boat4 = new Boat(submarine);
                boat4.X = "4";
                boat4.Y = "A";
                boat4.Orientation = true;
                boat4.Player = player1;

                Boat boat5 = new Boat(destroyer);
                boat5.X = "5";
                boat5.Y = "A";
                boat5.Orientation = true;
                boat5.Player = player2;

                Boat boat6 = new Boat(crusader);
                boat6.X = "6";
                boat6.Y = "A";
                boat6.Orientation = true;
                boat6.Player = player2;

                Boat boat7 = new Boat(aircraftCarrier);
                boat7.X = "7";
                boat7.Y = "A";
                boat7.Orientation = true;
                boat7.Player = player2;

                Boat boat8 = new Boat(submarine);
                boat8.X = "8";
                boat8.Y = "A";
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
                //this.txtX.Text = this.game.ToString();
            }
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("aircraftCarrier");
            data.Add("submarine");
            data.Add("crusader");
            data.Add("destroyer");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
        }

        private void DbBtn_Click(object sender, RoutedEventArgs e)
        {
            string message =this.PlayerTxt.Text + " batiment " + this.typeBoatCb.Text + "X: " + this.xBoatxt.Text + " Y: " + this.yBoatxt.Text ;
            System.Console.WriteLine(message);

            using (var db = new ApplicationDbContext())
            {
            

                //db.SaveChanges();
            }
        }
    }

    #endregion

    #region StaticFunctions
    #endregion

    #region Functions
    #endregion

    #region Events
    #endregion


}
