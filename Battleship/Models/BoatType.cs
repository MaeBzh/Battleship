using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class BoatType
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
        private int defaultWidth;
        private int defaultHeight;   
                    
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int DefaultWidth
        {
            get { return defaultWidth; }
            set { defaultWidth = value; }
        }

        public int DefaultHeight
        {
            get { return defaultHeight; }
            set { defaultHeight = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BoatType()
        {

        }

        public BoatType(int id, string name, int defaultWidth, int defaultHeight)
        {
            this.id = id;
            this.name = name;
            this.defaultWidth = defaultWidth;
            this.defaultHeight = defaultHeight;
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
