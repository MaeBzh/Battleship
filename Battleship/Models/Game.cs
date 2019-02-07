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
        private Player player1;
        private Player player2;
        private int? player1Id;
        private int? player2Id;        
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
        [ForeignKey("Player1")]
        public int? Player1Id
        {
            get { return player1Id; }
            set { player1Id = value; }
        }

        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        [Column]
        [ForeignKey("Player2")]
        public int? Player2Id
        {
            get { return player2Id; }
            set { player2Id = value; }
        }

        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
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
                this.Player1.ToString(),
                this.Player2.ToString());
           
        }
        #endregion

        #region Events
        #endregion


    }
}
