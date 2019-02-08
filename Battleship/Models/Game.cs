using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{   
    public class Game
    {

        #region StaticVariables
        #endregion
        static readonly Game _instance = new Game();

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int id;
        private int width;
        private int height;        
        private Player playerIa;
        private Player player;
        private int? playerIaId;
        private int? playerId;
        private Player currentPlayer;      
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        [Column]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        [Column]
        [ForeignKey("PlayerIa")]
        public int? PlayerIaId
        {
            get { return playerIaId; }
            set { playerIaId = value; }
        }

        public Player PlayerIa
        {
            get { return playerIa; }
            set { playerIa = value; }
        }

        [Column]
        [ForeignKey("Player")]
        public int? PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Player Currentplayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }


        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        private Game()
        {
            this.width = 10;
            this.height = 10;
            this.playerIa = new Player("IA 1", true);
            this.player = new Player("IA 2", true);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public static Game Instance
        {
            get { return _instance; }
        }

        public override string ToString()
        {
            return String.Format("id:{0} width:{1} height:{2} player 1:{3} player 2:{4}\n",
                this.Id,
                this.Width,
                this.Height,
                this.PlayerIa.ToString(),
                this.Player.ToString());
           
        }
        #endregion

        #region Events
        #endregion


    }
}
