using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    class Cell
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
        private String y;
        #endregion




        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public String Y
        {
            get { return y; }
            set { y = value; }
        }


        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cell()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion


    }
}
