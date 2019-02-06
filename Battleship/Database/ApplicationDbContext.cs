using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Database
{
    public class ApplicationDbContext : DbContext
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private DbSet<Boat> boats;
        private DbSet<BoatType> boatTypes;
        private DbSet<Game> games;
        private DbSet<Player> players;
        private DbSet<Shot> shots;

        #endregion

        #region Properties
        public DbSet<Boat> BoatsDbSet
        {
            get { return boats; }
            set { boats = value; }
        }
        public DbSet<BoatType> BoatTypesDbSet
        {
            get { return boatTypes; }
            set { boatTypes = value; }
        }
        public DbSet<Game> GamesDbSet
        {
            get { return games; }
            set { games = value; }
        }       
        public DbSet<Player> PlayersDbSet
        {
            get { return players; }
            set { players = value; }
        }
        public DbSet<Shot> ShotsDbSet
        {
            get { return shots; }
            set { shots = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApplicationDbContext() : base("battleshipDB")
        {
            DevResetDatabase();                
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void DevResetDatabase()
        {
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.Create();
            }
        }
        #endregion

        #region Events
        #endregion


    }
}
