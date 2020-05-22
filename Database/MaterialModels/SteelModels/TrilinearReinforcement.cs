using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MaterialModels.SteelModels
{
    public class TrilinearReinforcement
    {
        #region Constructor

        /// <summary>
        /// Constitutes trilinear material model for given parameters
        /// </summary>
        /// <param name="EpsY">Yielding strain</param>
        /// <param name="StrY">Yielding stress in MPa</param>
        /// <param name="EpsH">Strain where hardening begins</param>
        /// <param name="StrH">Stress in MPa where hardening begins</param>
        /// <param name="EpsU">Ultimate strain</param>
        /// <param name="Stru">Ultimate stress in MPa</param>
        public TrilinearReinforcement(double EpsY, double StrY, double EpsH, double StrH, double EpsU, double StrU)
        {
            _epsY = EpsY;
            _strY = StrY;
            _epsH = EpsH;
            _strH = StrH;
            _epsU = EpsU;
            _strU = StrU;
            //_stressStrain = GenerateStressStrainRelation();
        }

        #endregion

        #region Private Fields

        private double _epsY;
        private double _strY;
        private double _epsH;
        private double _strH;
        private double _epsU;
        private double _strU;
        private Dictionary<double, double> _stressStrain;

        #endregion

        #region Public Properties

        public double EpsY
        {
            get => _epsY;
            set => _epsY = value;
        }

        public double StrY
        {
            get => _strY;
            set => _strY = value;
        }

        public double EpsH
        {
            get => _epsH;
            set => _epsH = value;
        }

        public double StrH
        {
            get => _strH;
            set => _strH = value;
        }

        public double EpsU
        {
            get => _epsU;
            set => _epsU = value;
        }

        public double StrU
        {
            get => _strU;
            set => _strU = value;
        }

        public Dictionary<double, double> StressStrain
        {
            get => _stressStrain;
            set => _stressStrain = value;
        }

        #endregion

        #region Private Methods

        private Dictionary<double, double> GenerateStressStrainRelation()
        {
            Dictionary<double, double> strEps = new Dictionary<double, double>();

            double eps = 0;
            double str;
            double eEl = _strY / _epsY;
            double eH = (_strH - _strY) / (_epsH - _epsY);
            double eU = (_strU - _strH) / (_epsU - _epsH);

            while (eps <= _epsY)
            {
                str = eEl * eps;
                strEps.Add(eps, str);
                eps += 0.0001;
            }

            while (eps <= _epsH)
            {
                str = _strY + ((eps - _epsY) * (eH));
                strEps.Add(eps, str);
                eps += 0.0001;
            }

            while (eps <= _epsU)
            {
                str = _strH + ((eps - _epsH) * (eU));
                strEps.Add(eps, str);
                eps += 0.0001;
            }

            return strEps;
        }

        #endregion

        #region Public Methods


        public double GetStressForGivenStrain(double eps)
        {
            double str = 0;
            if (_stressStrain != null)
            {
                if (_stressStrain.ContainsKey(eps))
                {
                    str = _stressStrain.First(x => x.Key == eps).Value;
                }
            }
            else
            {
                //for (int i = 0; i < _stressStrain.Count - 1; i++) // To prevent run time errors since there is i + 1 
                //{
                //double epsDict = _stressStrain.ElementAt(i).Key;
                //if (epsDict < eps)
                //{
                //double epsOne = epsDict;
                //double strOne = _stressStrain.ElementAt(i).Value;
                //double epsTwo = _stressStrain.ElementAt(i + 1).Key; ;
                //double strTwo = _stressStrain.ElementAt(i + 1).Value;

                //str = strOne + ((eps - epsOne) / (epsTwo - epsOne)) * (strTwo - strOne);

                //break;
                //}
                //else
                //{
                //continue;
                //}
                //}
                double eEl = _strY / _epsY;
                double eH = (_strH - _strY) / (_epsH - _epsY);
                double eU = (_strU - _strH) / (_epsU - _epsH);
                if (eps <= _epsY)
                {
                    str = eEl * eps;
                }
                else if (eps <= _epsH)
                {
                    str = _strY + ((eps - _epsY) * (eH));
                }
                else if (eps <= _epsU)
                {
                    str = _strH + ((eps - _epsH) * (eU));
                }
                else if (true)
                {
                    str = 0;
                }
            }

            return str;
        }


        #endregion
    }
}
