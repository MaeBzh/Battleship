﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class Boat
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int id;
        private String x;
        private String y;
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
        public String X
        {
            get { return x; }
            set { x = value; }
        }
        [Column]
        public String Y
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
        public void setHitBox(Boat boat)
        {
            List<String[]> cells = new List<String[]>();

            String[] firstCell = new String[2];
            firstCell[0] = boat.X;
            firstCell[1] = boat.Y;
            cells.Add(firstCell);
            int nbCells = boat.Width * boat.Height;

            for(int i = 0; i<nbCells; i++)
            {
                if(boat.Orientation)
                {

                }
            }

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
