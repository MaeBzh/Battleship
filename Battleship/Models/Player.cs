
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Battleship.Models
{
    public class Player
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int id;
        private String name;
        private Boolean isIa;
        private Boolean isWinner;
        private List<Boat> boats;
        private List<Shot> shots;
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column]
        public Boolean IsIA
        {
            get { return isIa; }
            set { isIa = value; }
        }

        [Column]
        public Boolean IsWinner
        {
            get { return isWinner; }
            set { isWinner = value; }
        }
      
        public List<Boat> Boats
        {
            get { return boats; }
            set { boats = value; }
        }

        public List<Shot> Shots
        {
            get { return shots; }
            set { shots = value; }
        }       
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Player()
        {
            this.boats = new List<Boat> ();
            this.shots = new List<Shot> ();
            this.isWinner = false;
        }

        public Player(string name, bool isIa)
        {
            this.name = name;
            this.isIa = isIa;
            this.boats = new List<Boat>();
            this.shots = new List<Shot>();
            this.isWinner = false;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public override string ToString()
        {
            String result = String.Format("id:{0} name:{1} isIA:{2} isWinner:{3}",
             Id,
             Name,
             IsIA,
             IsWinner);

            result += ", [boats: ";
            foreach (Boat boat in this.Boats)
            {
                result += boat.ToString() + ",";
            }
            result += "], ";

            result += ", [shots: ";
            foreach (Shot shot in this.Shots)
            {
                result += shot.ToString() + ",\n";
            }
            result += "], ";

            return result+"\n";
        }
        #endregion

        #region Events
        #endregion


    }
}
