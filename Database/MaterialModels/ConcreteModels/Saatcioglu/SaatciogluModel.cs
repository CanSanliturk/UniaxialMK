using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MaterialModels.ConcreteModels.Saatcioglu
{
    /// <summary>
    /// Class that has a method to calculate stress-strain relationship according
    /// to Ravzi-Saatcioglu Model for given parameters
    /// </summary>
    public class SaatciogluModel : BaseConcreteMaterial
    {
        #region Constructor

        public SaatciogluModel(double fck, double fywk, double width, double height, double bkx, double bky, double s, double A0x, double A0y)
        {
            _fck = fck;
            _fywk = fywk;
            _width = width;
            _height = height;
            _bkx = bkx;
            _bky = bky;
            _s = s =
            _a0x = A0x;
            _a0y = A0y;
            _sigmaTwo = CalculateSigmaTwo();
            _k1 = CalculateK1();
            _lambda = CalculateLambda();
            _epsCoc = CalculateEpsCoc();
            _fcc = CalculateFcc();
            _rho = CalculateRho();
            _epsC85 = CalculateEpsC85();
            _stressStrainDict = GenerateStressStrainRelation();
        }

        #endregion

        #region Private Fields

        private double _fck;
        private double _fywk;
        private double _width;
        private double _height;
        private double _bkx;
        private double _bky;
        private double _s;
        private double _a0x;
        private double _a0y;
        private double _sigmaTwo;
        private double _k1;
        private double _lambda;
        private double _epsCoc;
        private double _rho;
        private double _epsC85;
        private double _fcc;
        private Dictionary<double, double> _stressStrainDict;
        #endregion

        #region Public Properties

        public double Fck 
        { 
            get => _fck; 
            set => _fck = value; 
        }
        
        public double Fywk 
        { 
            get => _fywk; 
            set => _fywk = value; 
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
        
        public double Bkx 
        { 
            get => _bkx; 
            set => _bkx = value; 
        }

        public double Bky 
        { 
            get => _bky; 
            set => _bky = value; 
        }
        
        public double S 
        { 
            get => _s; 
            set => _s = value; 
        }
        
        public double A0x 
        { 
            get => _a0x; 
            set => _a0x = value; 
        }
        
        public double A0y 
        { 
            get => _a0y; 
            set => _a0y = value; 
        }
        
        public Dictionary<double, double> StressStrainDict 
        { 
            get => _stressStrainDict; 
            set => _stressStrainDict = value; 
        }

        #endregion

        #region Private Methods

        private Dictionary<double, double> GenerateStressStrainRelation()
        {
            Dictionary<double, double> stressStrain = new Dictionary<double, double>();
            double eps = 0;
            double str;

            while (eps < 0.002)
            {
                str = CalculateStressStrainRelationForAscendingBranch(eps);
                stressStrain.Add(eps, str);
                eps += 0.0001;
            }
            
            while (eps < _epsC85)
            {
                str = CalculateStressStrainRelationForDescendingBranch(eps);
                stressStrain.Add(eps, str);
                eps += 0.0001;
            }
            while (eps < 0.025 - 0.0001)
            {
                str = 0;
                stressStrain.Add(eps, str);
                eps += 0.0001;
            }
            return stressStrain;
        }

        private double CalculateStressStrainRelationForAscendingBranch(double eps)
        {
            double helper = eps / _epsCoc;
            double powerTerm = (1 / (2 + _lambda));
            double inPar = (2 * helper) - (helper * helper);
            double strHelper = Math.Pow(inPar, powerTerm);
            double strCalc = _fcc * strHelper;
            double str = Math.Min(strCalc, _fcc);
            return str;
        }

        private double CalculateStressStrainRelationForDescendingBranch(double eps)
        {
            double k3 = 0.85;
            double str = _fcc + ((((1 - k3) * _fcc) / (_epsCoc - _epsC85)) * (eps - _epsCoc));
            return str;
        }

        private double CalculateRho()
        {
            double rho = (_a0x + _a0y) / (_s * (_bkx + _bky));
            return rho;
        }

        private double CalculateEpsC85()
        {
            double epsU38 = 0.0038;
            double eps = (260 * _rho * _epsCoc) + epsU38;
            return eps;
        }

        private double CalculateFcc()
        {
            double fcc = (0.85 * _fck) + (_k1 * _sigmaTwo);
            return fcc;
        }

        private double CalculateK1()
        {
            double k1 = 6.7 / Math.Pow(_sigmaTwo, 0.17);
            return k1;
        }

        private double CalculateEpsCoc()
        {
            double epsCoc = 0.002 * (1 + (5 * _lambda));
            return epsCoc;
        }

        private double CalculateSigmaTwo()
        {
            double sigmaTwoEX = CalculateSigmaTwoEX();
            double sigmaTwoEY = CalculateSigmaTwoEY();
            double sigmaTwoE = ((sigmaTwoEX * _bkx) + (sigmaTwoEY * _bky)) / (_bkx + _bky);
            return sigmaTwoE;
        }

        private double CalculateLambda()
        {
            double sigmaTwo = CalculateSigmaTwo();
            double k1 = CalculateK1();
            double lambda = (k1 * sigmaTwo) / (0.85 * _fck);
            return lambda;
        }

        private double CalculateSigmaTwoEX()
        {
            double sigmaTwoX = CalculateSigmaTwoX();
            double sigmaTwoEX = 0.26 * sigmaTwoX * Math.Sqrt((_bkx / _bkx) * (_bkx / _s) * (1 / sigmaTwoX));
            return sigmaTwoEX;
        }

        private double CalculateSigmaTwoEY()
        {
            double sigmaTwoY = CalculateSigmaTwoY();
            double sigmaTwoEY = 0.26 * sigmaTwoY * Math.Sqrt((_bky / _bky) * (_bky / _s) * (1 / sigmaTwoY));
            return sigmaTwoEY;
        }


        private double CalculateSigmaTwoX()
        {
            double sigmaTwoX = (_a0x * _fywk) / (_s * _bkx);
            return sigmaTwoX;
        }

        private double CalculateSigmaTwoY()
        {
            double sigmaTwoY = (_a0y * _fywk) / (_s * _bky);
            return sigmaTwoY;
        }
 
        #endregion

        #region Public Methods

        public double GetStressForGivenStrain(double eps)
        {
            double str = 0;
            if (_stressStrainDict.ContainsKey(eps))
            {
                str = _stressStrainDict.First(x => x.Key == eps).Value;    
            }
            else
            {
                for (int i = 0; i < _stressStrainDict.Count - 1; i++) // To prevent run time errors since there is i + 1 
                {
                    double epsDict = _stressStrainDict.ElementAt(i).Key;
                    if (epsDict < eps)
                    {
                        double epsOne = epsDict;
                        double strOne = _stressStrainDict.ElementAt(i).Value;
                        double epsTwo = _stressStrainDict.ElementAt(i + 1).Key; ;
                        double strTwo = _stressStrainDict.ElementAt(i + 1).Value;

                        str = strOne + ((eps - epsOne) / (epsTwo - epsOne)) * (strTwo - strOne);

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }



            return str;
        }

        #endregion

    }
}
