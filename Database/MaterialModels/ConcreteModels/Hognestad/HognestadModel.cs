using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MaterialModels.ConcreteModels.Hognestad
{
    public class HognestadModel : BaseConcreteMaterial
    {
        #region Constructor

        /// <summary>
        /// Class that used to construct stress-strain relation for 
        /// </summary>
        /// <param name="fck">Characteristic compressive strength of concrete at 28th day in MPa</param>
        /// <param name="eps0">Strain at ultimate stress</param>
        public HognestadModel(double fck, double eps0)
        {
            _fck = fck;
            _eps0 = eps0;
            _Ec = 12680 + (460 * fck);
            _epsUlt = 0.0038;
            _stressStrainDict = GenerateStressStrainRelation();
        }
        
        #endregion

        #region Private Fields

        private double _fck;
        private double _eps0;
        private double _epsUlt;
        private double _Ec;
        private Dictionary<double, double> _stressStrainDict;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Characteristic compressive strength of concrete 
        /// </summary>
        public double Fck 
        { 
            get => _fck; 
            set => _fck = value; 
        }
        
        /// <summary>
        /// Strain at ultimate stress
        /// </summary>
        public double Eps0
        {
            get => _eps0;
            set => _eps0 = value; 
        }
        
        /// <summary>
        /// Ultimate strain capacity of concrete
        /// </summary>
        public double EpsUlt 
        { 
            get => _epsUlt; 
            set => _epsUlt = value; 
        }
        
        /// <summary>
        /// Modulus of elasticity of concrete calculated according to Hognestad model
        /// </summary>
        public double Ec 
        { 
            get => _Ec; 
            set => _Ec = value; 
        }

        /// <summary>
        /// Stress-strain relationship given in a dictionary. Note that Stress is in MPa
        /// (Key is strain and value is stress)
        /// </summary>
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

            while (eps <= _eps0)
            {
                str = CalculateStressCorrespondingToGivenStressForAscendingBranch(eps);
                stressStrain.Add(eps, str);
                eps += 0.0001;
            }

            while (eps <= _epsUlt)
            {
                str = CalculateStressCorrespondingToGivenStressForDescendingBranch(eps);
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

        private double CalculateStressCorrespondingToGivenStressForAscendingBranch(double eps)
        {
            double helper =  eps / _eps0;
            double inPar = (2 * helper) - (helper * helper);
            double str = _fck * inPar;

            return str;
        }

        private double CalculateStressCorrespondingToGivenStressForDescendingBranch(double eps)
        {
            double helperOne = eps - _eps0;
            double helperTwo = _epsUlt - _eps0;
            double helperThree = helperOne / helperTwo;
            double helperFour = 1 - (0.15 * helperThree);
            double str = _fck * helperFour;

            return str;
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
