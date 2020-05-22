using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Rebar
{
    public class Rebar
    {
        #region Constructor

        /// <summary>
        /// Creates instance of rebar
        /// </summary>
        /// <param name="RebarDiameter">Diameter of rebar in mm </param>
        /// <param name="Fy">Yielding stress of rebar in MPa</param>
        public Rebar(int RebarDiameter, double Fy)
        {
            _RebarDiameter = RebarDiameter;
            _Fy = Fy;
        }

        #endregion

        #region Private Fields

        private int _RebarDiameter;
        private double _Fy;

        #endregion

        #region Public Properties

        public int RebarDiameter 
        { 
            get => _RebarDiameter; 
            set => _RebarDiameter = value; 
        }

        public double Fy 
        { 
            get => _Fy; 
            set => _Fy = value; 
        }

        #endregion
    }
}
