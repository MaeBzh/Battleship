﻿using System;
using System.Collections.Generic;
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
        private int row;
        private String column;
        private int width;
        private int height;
        private String position;
             
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public String Column
        {
            get { return column; }
            set { column = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public String Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Boat()
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
