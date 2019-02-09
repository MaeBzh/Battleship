using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Battleship.Models
{
    public class Boat
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        List<int[]> cells = new List<int[]>();
        #endregion

        #region Attributs
        private int id;
        private int x;
        private int y;
        private int width;
        private int height;
        private Boolean orientation;
        private int boatTypeId;
        private BoatType boatType;
        private int playerId;
        private Player player;
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
        public Boolean Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        [Column]
        [ForeignKey("BoatType")]
        public int BoatTypeId
        {
            get { return boatTypeId; }
            set { boatTypeId = value; }
        }

        public BoatType BoatType
        {
            get { return boatType; }
            set { boatType = value; }
        }

        [Column]
        [ForeignKey("Player")]
        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>

        public Boat(BoatType boatType)
        {
            this.boatType = boatType;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions 
        /// <summary>
        /// Get the hitbox of a boat according the position of its first cell.
        /// </summary>
        /// <returns></returns>
        public List<int[]> getHitBox()
        {

            int[] firstCell = new int[2];
            firstCell[0] = this.X - 1;
            firstCell[1] = this.Y - 1;
            int nbCells = this.Width * this.Height;          

            if (this.Orientation)
            {
                for (int j = firstCell[0]; j < (this.Width + firstCell[0]); j++)
                {
                    for (int k = firstCell[1]; k < (this.Height + firstCell[1]); k++)
                    {
                        int[] cell = new int[2];
                        cell[0] = this.X + j - firstCell[0];
                        cell[1] = this.Y + k - firstCell[1];
                        if (!this.cells.Any(c => c[0] == cell[0] && c[1] == cell[1]))
                        {
                            this.cells.Add(cell);
                        }
                    }
                }
            }
            else
            {
                for (int j = firstCell[0]; j < (this.Height + firstCell[0]); j++)
                {
                    for (int k = firstCell[1]; k < (this.Width + firstCell[1]); k++)
                    {
                        int[] cell = new int[2];
                        cell[0] = this.X + k - firstCell[0];

                        cell[1] = this.Y + j - firstCell[1];
                        if (!this.cells.Contains(cell))
                            if (!this.cells.Any(c => c[0] == cell[0] && c[1] == cell[1]))
                            {
                                this.cells.Add(cell);
                            }
                    }
                }
            }
            return this.cells;
        }


        public override string ToString()
        {
            return String.Format("id:{0} x:{1} y:{2} width:{3} height:{4} orientation:{5} boat type:{6}\n",
             this.Id,
             this.X,
             this.Y,
             this.Width,
             this.Height,
             this.Orientation,
             this.BoatType.ToString()
             );
        }

        #endregion

        #region Events
        #endregion


    }
}
