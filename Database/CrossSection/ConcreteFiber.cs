using Database.MaterialModels.ConcreteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CrossSection
{
    public class ConcreteFiber
    {
        #region Constructor

        public ConcreteFiber(BaseConcreteMaterial materialModel, double width, double height, double distFromFiberCentroidToNeutralAxis)
        {
            _mat = materialModel;
            _width = width;
            _height = height;
            _dist = distFromFiberCentroidToNeutralAxis;
        }

        #endregion 

        #region Private Fields

        private BaseConcreteMaterial _mat;
        private double _width;
        private double _height;
        private double _dist;
        
        #endregion

        #region Public Properties

        public BaseConcreteMaterial Mat 
        { 
            get => _mat; 
            set => _mat = value; 
        }
        
        public double Width 
        { 
            get => _width; 
            set => _width = value; 
        }
        
        public double Height 
        { 
            get => _height; 
            set => _height = value; 
        }
        
        public double Dist 
        { 
            get => _dist; 
            set => _dist = value; 
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
