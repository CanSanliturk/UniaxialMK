using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Rebar
{
    public class RebarLayer
    {
        #region Constructor
        
        public RebarLayer(Rebar Rebar, int RebarQuantity, double BottomDistance)
        {
            _Rebar = Rebar;
            _RebarQuantity = RebarQuantity;
            _BottomDistance = BottomDistance;
        }

        #endregion

        #region Private Fields

        private Rebar _Rebar;
        private int _RebarQuantity;
        private double _BottomDistance;

        #endregion

        #region Public Properties

        public Rebar Rebar 
        { 
            get => _Rebar; 
            set => _Rebar = value; 
        }

        public int RebarQuantity 
        { 
            get => _RebarQuantity; 
            set => _RebarQuantity = value; 
        }

        public double BottomDistance 
        { 
            get => _BottomDistance; 
            set => _BottomDistance = value; 
        }

        #endregion
    }
}
