using Database.MaterialModels.ConcreteModels.Hognestad;
using Database.MaterialModels.ConcreteModels.Saatcioglu;
using Database.MaterialModels.SteelModels;
using Database.Rebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.CrossSection
{
    public class CrossSection
    {
        #region Constructor

        /// <summary>
        /// Creates cross-section for given parameters
        /// </summary>
        /// <param name="layerDict">Dictionary of rebars (all nine)</param>
        /// <param name="height">Height of cross-section</param>
        /// <param name="width">Width of cross-section</param>
        /// <param name="layerNumber">Number of longitudinal reinforcement layers in corss-section</param>
        /// <param name="clearCover">Clear cover in mm</param>
        /// <param name="fck">Characteristic compressive strength of concrete</param>
        /// <param name="fyk">Characteristic yielding strength of longitudinal reinforcement</param>
        /// <param name="fywk">Characteristic yielding strength of confinement reinforcement</param>
        /// <param name="isConfined">Is it confined?</param>
        /// <param name="confinementDiameter">Diameter of confinement reinforcement?</param>
        /// <param name="axialLoadRatio">Ratio of axial load to axial load capacity?</param>
        public CrossSection(Dictionary<int, RebarLayer> layerDict, double height, double width, int layerNumber, double clearCover,
                            double fck, double fyk, double fywk, double spacing, bool isConfined, double confinementDiameter, double axialLoadRatio, double fiberThickness)
        {
            _layerDict = layerDict;
            _height = height;
            _width = width;
            _layerNumber = layerNumber;
            _clearCover = clearCover;
            _fck = fck;
            _fyk = fyk;
            _fywk = fywk;
            _spacing = spacing;
            _isConfined = isConfined;
            _confinementDiameter = confinementDiameter;
            double a0x = 2 * (Math.PI * _confinementDiameter * _confinementDiameter / 4);
            double a0y = 2 * (Math.PI * _confinementDiameter * _confinementDiameter / 4);
            _confinedMatModel = new SaatciogluModel(_fck, _fywk, (_width - 2 * _clearCover), fiberThickness, (_width - 2 * _clearCover), fiberThickness, spacing, a0x, a0y);
            _axialLoadRatio = axialLoadRatio;
            _unconfinedMatModel = new HognestadModel(_fck, 0.002);
            _axialLoadCapacity = CalculateAxialLoadCapacity();
            _axialLoad = CalculateAxialLoad();
            _rebars = GetUsedRebars();
            _confinedFibers = GetConfinedFibers();
            _unconfinedFibers = GetUnconfinedFibers();
            _momentCurvature = CalculateMomentCurvature();
            _momentCapacity = CalculateMomentCapacity();
        }

        #endregion

        #region Private Fields

        private Dictionary<int, RebarLayer> _layerDict;
        private double _height;
        private double _width;
        private int _layerNumber;
        private double _clearCover;
        private double _fck;
        private double _fyk;
        private double _fywk;
        private bool _isConfined;
        private double _confinementDiameter;
        private double _axialLoadRatio;
        private double _axialLoadCapacity;
        private double _momentCapacity;
        private double _spacing;
        private double _axialLoad;
        private SaatciogluModel _confinedMatModel;
        private HognestadModel _unconfinedMatModel;
        private List<RebarLayer> _rebars;
        private List<ConcreteFiber> _confinedFibers;
        private List<ConcreteFiber> _unconfinedFibers;
        private Dictionary<double, double> _momentCurvature;
        #endregion

        #region Public Properties

        public Dictionary<int, RebarLayer> LayerDict
        {
            get => _layerDict;
            set => _layerDict = value;
        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }

        public double Width
        {
            get => _width;
            set => _width = value;
        }

        public int LayerNumber
        {
            get => _layerNumber;
            set => _layerNumber = value;
        }

        public double Fck
        {
            get => _fck;
            set => _fck = value;
        }

        public double Fyk
        {
            get => _fyk;
            set => _fyk = value;
        }

        public double Fywk
        {
            get => _fywk;
            set => _fywk = value;
        }

        public bool IsConfined
        {
            get => _isConfined;
            set => _isConfined = value;
        }

        public double ConfinementDiameter
        {
            get => _confinementDiameter;
            set => _confinementDiameter = value;
        }

        public double AxialLoadRatio
        {
            get => _axialLoadRatio;
            set => _axialLoadRatio = value;
        }

        /// <summary>
        /// First index is curvature in 1/mm and second index is moment in Nmm
        /// </summary>
        public Dictionary<double, double> MomentCurvature
        {
            get => _momentCurvature;
            set => _momentCurvature = value;
        }
        public double AxialLoadCapacity
        {
            get => _axialLoadCapacity;
            set => _axialLoadCapacity = value;
        }

        public double MomentCapacity
        {
            get => _momentCapacity;
            set => _momentCapacity = value;
        }

        #endregion

        #region Private Methods

        private Dictionary<double, double> CalculateMomentCurvature()
        {
            Dictionary<double, double> momCurv = new Dictionary<double, double>();
            double epsUlt = 0.0025;

            momCurv.Add(0, 0);
            double eps = 0.0001;

            double curvature = 0;

            while (eps < epsUlt)
            {
                double neutralAxisDistToBot = CalculateNeutralAxis(eps);
                List<double> mK = GetMomentAndCurvature(neutralAxisDistToBot, eps);
                try
                {
                    if (mK[0] > curvature)
                    {
                        curvature = mK[0];
                        double moment = mK[1];

                        if (double.IsInfinity(moment) || double.IsNaN(moment))
                        {
                            moment = 0;
                        }
                        if (double.IsInfinity(curvature) || double.IsNaN(curvature))
                        {
                            curvature = 0;
                        }

                        if (!momCurv.ContainsKey(curvature))
                        {
                            momCurv.Add(curvature, moment / 1000000);
                        }
                    }
                }
                catch (Exception e)
                {
                    return momCurv;
                }
                eps += 0.0001;
            }

            return momCurv;
        }

        private double CalculateNeutralAxis(double epsTop)
        {
            //double neutralAxis = -Height / 10;
            double neutralAxis = _height / 2;
            double tol = 100000; // in Newtons;
            double error = 10000000;

            List<List<RebarLayer>> rebars = GetCompressionRebars(neutralAxis);
            List<RebarLayer> compRebars = rebars[0];
            List<RebarLayer> tensRebars = rebars[1];
            List<ConcreteFiber> confFibers = _confinedFibers;
            List<ConcreteFiber> unconfFibers = _unconfinedFibers;

            while (tol < error)
            {                
                Dictionary<RebarLayer, double> compRebarWithStrain = new Dictionary<RebarLayer, double>();
                Dictionary<RebarLayer, double> tensRebarWithStrain = new Dictionary<RebarLayer, double>();
                Dictionary<ConcreteFiber, double> confFiberWithStrainInCompression = new Dictionary<ConcreteFiber, double>();
                Dictionary<ConcreteFiber, double> unconfFiberWithStrainInCompression = new Dictionary<ConcreteFiber, double>();

                neutralAxis += 1; // mm

                // Assign strain values to concrete fibers and steel layers
                if (compRebars != null && compRebars.Count > 0)
                {
                    foreach (RebarLayer compRebar in compRebars)
                    {
                        double c = _height - neutralAxis;
                        double dist = compRebar.BottomDistance - neutralAxis;
                        double eps = (dist / c) * epsTop;
                        compRebarWithStrain.Add(compRebar, eps);
                    }
                }

                if (tensRebars != null && tensRebars.Count > 0)
                {
                    foreach (RebarLayer tensRebar in tensRebars)
                    {
                        double c = _height - neutralAxis;
                        double dist = neutralAxis - tensRebar.BottomDistance;
                        double eps = (dist / c) * epsTop;
                        tensRebarWithStrain.Add(tensRebar, eps);
                    }
                }

                if (confFibers != null && confFibers.Count > 0)
                {
                    foreach (ConcreteFiber fiber in confFibers)
                    {
                        if (fiber.Dist > neutralAxis)
                        {
                            double c = _height - neutralAxis;
                            double dist = fiber.Dist - neutralAxis;
                            double eps = (dist / c) * epsTop;
                            confFiberWithStrainInCompression.Add(fiber, eps);
                        }
                    }
                }

                if (unconfFibers != null && unconfFibers.Count > 0)
                {
                    foreach (ConcreteFiber fiber in unconfFibers)
                    {
                        if (fiber.Dist > neutralAxis)
                        {
                            double c = _height - neutralAxis;
                            double dist = fiber.Dist - neutralAxis;
                            double eps = (dist / c) * epsTop;
                            unconfFiberWithStrainInCompression.Add(fiber, eps);
                        }
                    }
                }

                // Now, strain values at each fibers are known for given top fiber strain. 
                // Equilibrium check can be done. If equilibrium is not satisfied, 
                // neutral axis will be updated and new check will be done until error 
                // stays in tolerance limit.

                // Calculate compressive forces

                double compForce = 0;

                if (confFiberWithStrainInCompression != null)
                {
                    for (int i = 0; i < confFiberWithStrainInCompression.Count; i++)
                    {
                        double eps = confFiberWithStrainInCompression.ElementAt(i).Value;
                        ConcreteFiber fiber = confFiberWithStrainInCompression.ElementAt(i).Key;
                        SaatciogluModel matModel = fiber.Mat as SaatciogluModel;
                        Dictionary<double, double> strainStress = matModel.StressStrainDict;
                        double stress = matModel.GetStressForGivenStrain(eps);
                        double width = fiber.Width;
                        double height = fiber.Height;
                        double force = width * height * stress;
                        compForce += force;
                    }
                }

                if (unconfFiberWithStrainInCompression != null)
                {
                    for (int i = 0; i < unconfFiberWithStrainInCompression.Count; i++)
                    {
                        double eps = unconfFiberWithStrainInCompression.ElementAt(i).Value;
                        ConcreteFiber fiber = unconfFiberWithStrainInCompression.ElementAt(i).Key;
                        HognestadModel matModel = fiber.Mat as HognestadModel;
                        Dictionary<double, double> strainStress = matModel.StressStrainDict;
                        double stress = matModel.GetStressForGivenStrain(eps);
                        double width = fiber.Width;
                        double height = fiber.Height;
                        double force = width * height * stress;
                        compForce += force;
                    }
                }

                if (compRebarWithStrain != null && compRebarWithStrain.Count > 0)
                {
                    for (int i = 0; i < compRebarWithStrain.Count; i++)
                    {
                        double eps = compRebarWithStrain.ElementAt(i).Value;
                        RebarLayer layer = compRebarWithStrain.ElementAt(i).Key;
                        
                        TrilinearReinforcement mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, 550);
                        if (_fyk != 420)
                        {
                            mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, _fyk * 1.3);
                        }

                        Dictionary<double, double> strainStress = mat.StressStrain;
                        double stress = mat.GetStressForGivenStrain(eps);
                        double qty = layer.RebarQuantity;
                        double area = Math.PI * (layer.Rebar.RebarDiameter) * (layer.Rebar.RebarDiameter) / 4;
                        double force = area * qty * stress;
                        compForce += force;
                    }
                }

                // Calculate tensile forces

                double tensForce = 0;

                if (tensRebarWithStrain != null && tensRebarWithStrain.Count > 0)
                {
                    for (int i = 0; i < tensRebarWithStrain.Count; i++)
                    {
                        double eps = tensRebarWithStrain.ElementAt(i).Value;
                        RebarLayer layer = tensRebarWithStrain.ElementAt(i).Key;
                        TrilinearReinforcement mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, 550);
                        if (_fyk != 420)
                        {
                            mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, _fyk * 1.3);
                        }
                        Dictionary<double, double> strainStress = mat.StressStrain;
                        double stress = mat.GetStressForGivenStrain(eps);
                        double qty = layer.RebarQuantity;
                        double area = Math.PI * (layer.Rebar.RebarDiameter) * (layer.Rebar.RebarDiameter) / 4;
                        double force = area * qty * stress;
                        tensForce += force;
                    }
                }

                // Update error     // TODO : Can. Compressive force sürekli artarken tensile force sürekli sıfırda kalıyor
                if ((tensForce != 0 && compForce != 0) || (_axialLoad != 0 && compForce != 0))
                {
                    error = Math.Abs(_axialLoad + tensForce - compForce);
                }
                //else if (compForce != 0)
                //{
                //    error = Math.Abs(_axialLoad + tensForce - compForce);

                //}
                else
                {
                    error = 0;
                }
            }
            return neutralAxis;
        }

        private List<double> GetMomentAndCurvature(double neutralAxisDistFromBot, double epsTop)
        {
            List<double> momentCurv = new List<double>();

            // Calculate Curvature
            double c = _height - neutralAxisDistFromBot;
            double curv = epsTop / c;
            momentCurv.Add(curv);

            // Calculate moment capacity
            List<List<RebarLayer>> rebars = GetCompressionRebars(neutralAxisDistFromBot);
            List<RebarLayer> compRebars = rebars[0];
            List<RebarLayer> tensRebars = rebars[1];
            List<ConcreteFiber> confFibers = _confinedFibers;
            List<ConcreteFiber> unconfFibers = _unconfinedFibers;

            Dictionary<RebarLayer, double> compRebarWithStrain = new Dictionary<RebarLayer, double>();
            Dictionary<RebarLayer, double> tensRebarWithStrain = new Dictionary<RebarLayer, double>();
            Dictionary<ConcreteFiber, double> confFiberWithStrainInCompression = new Dictionary<ConcreteFiber, double>();
            Dictionary<ConcreteFiber, double> unconfFiberWithStrainInCompression = new Dictionary<ConcreteFiber, double>();

            // Assign strain values to concrete fibers and steel layers
            if (compRebars != null && compRebars.Count > 0)
            {
                foreach (RebarLayer compRebar in compRebars)
                {
                    double dist = compRebar.BottomDistance - neutralAxisDistFromBot;
                    double eps = (dist / c) * epsTop;
                    compRebarWithStrain.Add(compRebar, eps);
                }
            }

            if (tensRebars != null && tensRebars.Count > 0)
            {
                foreach (RebarLayer tensRebar in tensRebars)
                {
                    double dist = neutralAxisDistFromBot - tensRebar.BottomDistance;
                    double eps = (dist / c) * epsTop;
                    tensRebarWithStrain.Add(tensRebar, eps);
                }
            }

            if (confFibers != null && confFibers.Count > 0)
            {
                foreach (ConcreteFiber fiber in confFibers)
                {
                    if (fiber.Dist > neutralAxisDistFromBot)
                    {
                        double dist = fiber.Dist - neutralAxisDistFromBot;
                        double eps = (dist / c) * epsTop;
                        confFiberWithStrainInCompression.Add(fiber, eps);
                    }
                }
            }

            if (unconfFibers != null && unconfFibers.Count > 0)
            {
                foreach (ConcreteFiber fiber in unconfFibers)
                {
                    if (fiber.Dist > neutralAxisDistFromBot)
                    {
                        double dist = fiber.Dist - neutralAxisDistFromBot;
                        double eps = (dist / c) * epsTop;
                        unconfFiberWithStrainInCompression.Add(fiber, eps);
                    }
                }
            }

            // Calculate compressive forces

            double momCap = 0;

            if (confFiberWithStrainInCompression != null)
            {
                for (int i = 0; i < confFiberWithStrainInCompression.Count; i++)
                {
                    double eps = confFiberWithStrainInCompression.ElementAt(i).Value;
                    ConcreteFiber fiber = confFiberWithStrainInCompression.ElementAt(i).Key;
                    SaatciogluModel matModel = fiber.Mat as SaatciogluModel;
                    Dictionary<double, double> strainStress = matModel.StressStrainDict;
                    double stress = matModel.GetStressForGivenStrain(eps);
                    double width = fiber.Width;
                    double height = fiber.Height;
                    double force = width * height * stress;
                    double momentArm = fiber.Dist - neutralAxisDistFromBot;
                    momCap += force * momentArm;
                }
            }

            if (unconfFiberWithStrainInCompression != null)
            {
                for (int i = 0; i < unconfFiberWithStrainInCompression.Count; i++)
                {
                    double eps = unconfFiberWithStrainInCompression.ElementAt(i).Value;
                    ConcreteFiber fiber = unconfFiberWithStrainInCompression.ElementAt(i).Key;
                    HognestadModel matModel = fiber.Mat as HognestadModel;
                    Dictionary<double, double> strainStress = matModel.StressStrainDict;
                    double stress = matModel.GetStressForGivenStrain(eps);
                    double width = fiber.Width;
                    double height = fiber.Height;
                    double force = width * height * stress;
                    double momentArm = fiber.Dist - neutralAxisDistFromBot;
                    momCap += force * momentArm;
                }
            }

            if (compRebarWithStrain != null && compRebarWithStrain.Count > 0)
            {
                for (int i = 0; i < compRebarWithStrain.Count; i++)
                {
                    double eps = compRebarWithStrain.ElementAt(i).Value;
                    RebarLayer layer = compRebarWithStrain.ElementAt(i).Key;
                    TrilinearReinforcement mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, 550);
                    if (_fyk != 420)
                    {
                        mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, _fyk * 1.3);
                    }
                    Dictionary<double, double> strainStress = mat.StressStrain;
                    double stress = mat.GetStressForGivenStrain(eps);
                    double qty = layer.RebarQuantity;
                    double area = Math.PI * (layer.Rebar.RebarDiameter) * (layer.Rebar.RebarDiameter) / 4;
                    double force = area * qty * stress;
                    double momentArm = layer.BottomDistance - neutralAxisDistFromBot;
                    momCap += force * momentArm;
                }
            }

            // Calculate tensile forces

            if (tensRebarWithStrain != null && tensRebarWithStrain.Count > 0)
            {
                for (int i = 0; i < tensRebarWithStrain.Count; i++)
                {
                    double eps = tensRebarWithStrain.ElementAt(i).Value;
                    RebarLayer layer = tensRebarWithStrain.ElementAt(i).Key;
                    TrilinearReinforcement mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, 550);
                    if (_fyk != 420)
                    {
                        mat = new TrilinearReinforcement(0.0021, _fyk, 0.005, 420, 0.05, _fyk * 1.3);
                    }
                    Dictionary<double, double> strainStress = mat.StressStrain;
                    double stress = mat.GetStressForGivenStrain(eps);
                    double qty = layer.RebarQuantity;
                    double area = Math.PI * (layer.Rebar.RebarDiameter) * (layer.Rebar.RebarDiameter) / 4;
                    double force = area * qty * stress;
                    double momentArm = neutralAxisDistFromBot - layer.BottomDistance;
                    momCap += force * momentArm;
                }
            }

            momentCurv.Add(momCap);

            return momentCurv;
        }


        private List<RebarLayer> GetUsedRebars()
        {
            List<RebarLayer> rebars = new List<RebarLayer>();

            for (int i = 0; i < _layerNumber; i++)
            {
                rebars.Add(_layerDict.ElementAt(i).Value);
            }

            return rebars;
        }

        private List<List<RebarLayer>> GetCompressionRebars(double dist)
        {
            List<List<RebarLayer>> rebars = new List<List<RebarLayer>>();
            List<RebarLayer> compRebars = new List<RebarLayer>();
            List<RebarLayer> tensRebars = new List<RebarLayer>();

            for (int i = 0; i < _rebars.Count; i++)
            {
                RebarLayer rebar = _rebars[i];
                if (rebar != null)
                {
                    if (rebar.BottomDistance <= dist)
                    {
                        tensRebars.Add(rebar);
                    }
                    else
                    {
                        compRebars.Add(rebar);
                    }
                }
            }

            rebars.Add(compRebars);
            rebars.Add(tensRebars);

            return rebars;
        }

        /// <summary>
        /// From bottom to top
        /// </summary>
        /// <returns></returns>
        private List<ConcreteFiber> GetConfinedFibers()
        {
            List<ConcreteFiber> fiberList = new List<ConcreteFiber>();
            if (_isConfined)
            {
                double fiberThickness = 5; // 5 mm fibers
                double dist = _clearCover + fiberThickness / 2;

                while (dist <= (_height - _clearCover - (fiberThickness / 2)))
                {
                    ConcreteFiber fiber = new ConcreteFiber(_confinedMatModel, (_width - 2 * _clearCover), fiberThickness, dist);
                    fiberList.Add(fiber);

                    dist += fiberThickness;
                }
            }
            return fiberList;
        }

        /// <summary>
        /// From bottom to top
        /// </summary>
        /// <returns></returns>
        private List<ConcreteFiber> GetUnconfinedFibers()
        {
            List<ConcreteFiber> fiberList = new List<ConcreteFiber>();
            double fiberThickness = 5; // 5 mm fibers
            double dist = fiberThickness / 2;

            while (dist <= _clearCover - (fiberThickness / 2))
            {
                ConcreteFiber fiber = new ConcreteFiber(_unconfinedMatModel, _width, fiberThickness, dist);
                fiberList.Add(fiber);
                dist += fiberThickness;
            }
            while (dist <= _height - _clearCover - (fiberThickness / 2))
            {
                ConcreteFiber fiber = new ConcreteFiber(_unconfinedMatModel, 2 * _clearCover, fiberThickness, dist);
                if (!_isConfined)
                {
                    fiber = new ConcreteFiber(_unconfinedMatModel, _width, fiberThickness, dist);
                }
                fiberList.Add(fiber);
                dist += fiberThickness;
            }
            while (dist <= _height - (fiberThickness / 2))
            {
                ConcreteFiber fiber = new ConcreteFiber(_unconfinedMatModel, _width, fiberThickness, dist);
                fiberList.Add(fiber);
                dist += fiberThickness;
            }

            return fiberList;
        }

        #endregion
        
        private double CalculateAxialLoadCapacity()
        {
            double bkx = 0;
            double bky = 0;
            double insForce = 0;
            if (_confinedMatModel != null && _isConfined)
            {
                bkx = _confinedMatModel.Bkx;
                bky = _confinedMatModel.Bky;

                double ins = _confinedMatModel.StressStrainDict.Values.Max();
                insForce = ins * bkx * bky;
            }

            double outsideArea = (_height * _width) - (bkx * bky);
            double outsideStr = _unconfinedMatModel.StressStrainDict.Values.Max();
            double outsideForce = outsideArea * outsideStr;

            double axialCapacity = insForce + outsideForce;

            return axialCapacity;
        }

        private double CalculateAxialLoad()
        {
            return _axialLoadRatio * _axialLoadCapacity / 100;
        }

        private double CalculateMomentCapacity()
        {
            double momCap = MomentCurvature.Values.Max();
            return momCap;
        }

    }
}
