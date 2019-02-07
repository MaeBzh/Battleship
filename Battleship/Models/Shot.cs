using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Shot
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int id;
        private int x;
        private int y;
        private Player player;
        private int playerId;
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column]
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        [Column]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        [Column]
        [ForeignKey("Player")]
        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Shot()
        {

        }

        public Shot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            return  String.Format("id:{0} x:{1} y:{2}\n",
             this.Id,
             this.X,
             this.Y
             );
        }
        #endregion

        #region Events
        #endregion


    }
}
