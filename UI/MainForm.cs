using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Database.CrossSection;
using Database.MaterialModels.ConcreteModels.Hognestad;
using Database.MaterialModels.ConcreteModels.Saatcioglu;
using Database.Rebar;

namespace UI
{
    public partial class MainForm : Form
    {
        #region Constuctor
        public MainForm()
        {
            InitializeComponent();
            CreateDefaultSection();
            PrepareUI();
            Rec2Form();
            SubscribeEvents();
        }
        #endregion

        #region Private Fields

        private double _CrossSectionHeight;
        private double _CrossSectionWidth;
        private double _ClearCover;
        private double _ConcreteGrade;
        private double _SteelGrade;
        private int _LayerNumber;
        private bool _IsConfined;

        private RebarLayer _Layer1;
        private Rebar _Layer1Rebar;
        private int _Layer1RebarQuantity;
        private double _Layer1BottomDistance;

        private RebarLayer _Layer2;
        private Rebar _Layer2Rebar;
        private int _Layer2RebarQuantity;
        private double _Layer2BottomDistance;

        private RebarLayer _Layer3;
        private Rebar _Layer3Rebar;
        private int _Layer3RebarQuantity;
        private double _Layer3BottomDistance;

        private RebarLayer _Layer4;
        private Rebar _Layer4Rebar;
        private int _Layer4RebarQuantity;
        private double _Layer4BottomDistance;

        private RebarLayer _Layer5;
        private Rebar _Layer5Rebar;
        private int _Layer5RebarQuantity;
        private double _Layer5BottomDistance;

        private RebarLayer _Layer6;
        private Rebar _Layer6Rebar;
        private int _Layer6RebarQuantity;
        private double _Layer6BottomDistance;

        private RebarLayer _Layer7;
        private Rebar _Layer7Rebar;
        private int _Layer7RebarQuantity;
        private double _Layer7BottomDistance;

        private RebarLayer _Layer8;
        private Rebar _Layer8Rebar;
        private int _Layer8RebarQuantity;
        private double _Layer8BottomDistance;

        private RebarLayer _Layer9;
        private Rebar _Layer9Rebar;
        private int _Layer9RebarQuantity;
        private double _Layer9BottomDistance;

        private int _StirrupDiam;
        private double _fYwk;
        private double _StirrupSpacing;

        private double _AxialLoadRatio;

        private Dictionary<int, RebarLayer> _LayerDict = new Dictionary<int, RebarLayer>();
        private CrossSection _xSec;

        #endregion

        #region Private Methods

        private void PrepareUI()
        {
            _LayerNumber = 1;
            _IsConfined = false;
            txtAxilLoadCapacity.Enabled = false;
            txtMomentCapacity.Enabled = false;

            AdjustLayerVisibility();
            FillLayerDiametersComboBox();
            SetUpInitialPhaseOfComboBoxes();
        }

        private void SubscribeEvents()
        {
            txtXSecHeight.Leave += TxtXSecHeight_Leave;
            txtXSecWidth.Leave += TxtXSecWidth_Leave;
            txtClearCover.Leave += TxtClearCover_Leave;
            txtConcreteGrade.Leave += TxtConcreteGrade_Leave;
            txtSteelGrade.Leave += TxtSteelGrade_Leave;

            btnAddRebarLayer.Click += BtnAddRebarLayer_Click;
            btnDeleteRebarLayer.Click += BtnDeleteRebarLayer_Click;

            chkConfined.CheckedChanged += ChkConfined_CheckedChanged;

            cmbLayerDia1.SelectedIndexChanged += CmbLayerDia1_SelectedIndexChanged;
            cmbLayerDia2.SelectedIndexChanged += CmbLayerDia2_SelectedIndexChanged;
            cmbLayerDia3.SelectedIndexChanged += CmbLayerDia3_SelectedIndexChanged;
            cmbLayerDia4.SelectedIndexChanged += CmbLayerDia4_SelectedIndexChanged;
            cmbLayerDia5.SelectedIndexChanged += CmbLayerDia5_SelectedIndexChanged;
            cmbLayerDia6.SelectedIndexChanged += CmbLayerDia6_SelectedIndexChanged;
            cmbLayerDia7.SelectedIndexChanged += CmbLayerDia7_SelectedIndexChanged;
            cmbLayerDia8.SelectedIndexChanged += CmbLayerDia8_SelectedIndexChanged;
            cmbLayerDia9.SelectedIndexChanged += CmbLayerDia9_SelectedIndexChanged;
            cmbStirrupDia.SelectedIndexChanged += CmbStirrupDia_SelectedIndexChanged;

            txtLayerQty1.Leave += TxtLayerQty1_Leave;
            txtLayerQty2.Leave += TxtLayerQty2_Leave;
            txtLayerQty3.Leave += TxtLayerQty3_Leave;
            txtLayerQty4.Leave += TxtLayerQty4_Leave;
            txtLayerQty5.Leave += TxtLayerQty5_Leave;
            txtLayerQty6.Leave += TxtLayerQty6_Leave;
            txtLayerQty7.Leave += TxtLayerQty7_Leave;
            txtLayerQty8.Leave += TxtLayerQty8_Leave;
            txtLayerQty9.Leave += TxtLayerQty9_Leave;

            txtLayerBotDist1.Leave += TxtLayerBotDist1_Leave;
            txtLayerBotDist2.Leave += TxtLayerBotDist2_Leave;
            txtLayerBotDist3.Leave += TxtLayerBotDist3_Leave;
            txtLayerBotDist4.Leave += TxtLayerBotDist4_Leave;
            txtLayerBotDist5.Leave += TxtLayerBotDist5_Leave;
            txtLayerBotDist6.Leave += TxtLayerBotDist6_Leave;
            txtLayerBotDist7.Leave += TxtLayerBotDist7_Leave;
            txtLayerBotDist8.Leave += TxtLayerBotDist8_Leave;
            txtLayerBotDist9.Leave += TxtLayerBotDist9_Leave;

            txtStirrupSpacing.Leave += TxtStirrupSpacing_Leave;
            txtTransverseSteelGrade.Leave += TxtTransverseSteelGrade_Leave;

            txtAxialLoadRatio.Leave += TxtAxialLoadRatio_Leave;
        }

        private void UnsubscribeEvents()
        {
            txtXSecHeight.Leave -= TxtXSecHeight_Leave;
            txtXSecWidth.Leave -= TxtXSecWidth_Leave;
            txtClearCover.Leave -= TxtClearCover_Leave;
            txtConcreteGrade.Leave -= TxtConcreteGrade_Leave;
            txtSteelGrade.Leave -= TxtSteelGrade_Leave;

            btnAddRebarLayer.Click -= BtnAddRebarLayer_Click;
            btnDeleteRebarLayer.Click -= BtnDeleteRebarLayer_Click;

            chkConfined.CheckedChanged -= ChkConfined_CheckedChanged;

            cmbLayerDia1.SelectedIndexChanged -= CmbLayerDia1_SelectedIndexChanged;
            cmbLayerDia2.SelectedIndexChanged -= CmbLayerDia2_SelectedIndexChanged;
            cmbLayerDia3.SelectedIndexChanged -= CmbLayerDia3_SelectedIndexChanged;
            cmbLayerDia4.SelectedIndexChanged -= CmbLayerDia4_SelectedIndexChanged;
            cmbLayerDia5.SelectedIndexChanged -= CmbLayerDia5_SelectedIndexChanged;
            cmbLayerDia6.SelectedIndexChanged -= CmbLayerDia6_SelectedIndexChanged;
            cmbLayerDia7.SelectedIndexChanged -= CmbLayerDia7_SelectedIndexChanged;
            cmbLayerDia8.SelectedIndexChanged -= CmbLayerDia8_SelectedIndexChanged;
            cmbLayerDia9.SelectedIndexChanged -= CmbLayerDia9_SelectedIndexChanged;
            cmbStirrupDia.SelectedIndexChanged -= CmbStirrupDia_SelectedIndexChanged;

            txtLayerQty1.Leave -= TxtLayerQty1_Leave;
            txtLayerQty2.Leave -= TxtLayerQty2_Leave;
            txtLayerQty3.Leave -= TxtLayerQty3_Leave;
            txtLayerQty4.Leave -= TxtLayerQty4_Leave;
            txtLayerQty5.Leave -= TxtLayerQty5_Leave;
            txtLayerQty6.Leave -= TxtLayerQty6_Leave;
            txtLayerQty7.Leave -= TxtLayerQty7_Leave;
            txtLayerQty8.Leave -= TxtLayerQty8_Leave;
            txtLayerQty9.Leave -= TxtLayerQty9_Leave;

            txtLayerBotDist1.Leave -= TxtLayerBotDist1_Leave;
            txtLayerBotDist2.Leave -= TxtLayerBotDist2_Leave;
            txtLayerBotDist3.Leave -= TxtLayerBotDist3_Leave;
            txtLayerBotDist4.Leave -= TxtLayerBotDist4_Leave;
            txtLayerBotDist5.Leave -= TxtLayerBotDist5_Leave;
            txtLayerBotDist6.Leave -= TxtLayerBotDist6_Leave;
            txtLayerBotDist7.Leave -= TxtLayerBotDist7_Leave;
            txtLayerBotDist8.Leave -= TxtLayerBotDist8_Leave;
            txtLayerBotDist9.Leave -= TxtLayerBotDist9_Leave;
        
            txtStirrupSpacing.Leave -= TxtStirrupSpacing_Leave;
            txtTransverseSteelGrade.Leave -= TxtTransverseSteelGrade_Leave;
         
            txtAxialLoadRatio.Leave -= TxtAxialLoadRatio_Leave;
        }


        private void Form2Rec()
        {
            _CrossSectionHeight = Double.Parse(txtXSecHeight.Text);
            _CrossSectionWidth = Double.Parse(txtXSecWidth.Text);
            _ClearCover = Double.Parse(txtClearCover.Text);
            _ConcreteGrade = Double.Parse(txtConcreteGrade.Text);
            _SteelGrade = Double.Parse(txtSteelGrade.Text);

            _Layer1Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia1.SelectedIndex);
            _Layer1RebarQuantity = Int32.Parse(txtLayerQty1.Text);
            _Layer1BottomDistance = Double.Parse(txtLayerBotDist1.Text);

            _Layer2Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia2.SelectedIndex);
            _Layer2RebarQuantity = Int32.Parse(txtLayerQty2.Text);
            _Layer2BottomDistance = Double.Parse(txtLayerBotDist2.Text);

            _Layer3Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia3.SelectedIndex);
            _Layer3RebarQuantity = Int32.Parse(txtLayerQty3.Text);
            _Layer3BottomDistance = Double.Parse(txtLayerBotDist3.Text);

            _Layer4Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia4.SelectedIndex);
            _Layer4RebarQuantity = Int32.Parse(txtLayerQty4.Text);
            _Layer4BottomDistance = Double.Parse(txtLayerBotDist4.Text);

            _Layer5Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia5.SelectedIndex);
            _Layer5RebarQuantity = Int32.Parse(txtLayerQty5.Text);
            _Layer5BottomDistance = Double.Parse(txtLayerBotDist5.Text);

            _Layer6Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia6.SelectedIndex);
            _Layer6RebarQuantity = Int32.Parse(txtLayerQty6.Text);
            _Layer6BottomDistance = Double.Parse(txtLayerBotDist6.Text);

            _Layer7Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia7.SelectedIndex);
            _Layer7RebarQuantity = Int32.Parse(txtLayerQty7.Text);
            _Layer7BottomDistance = Double.Parse(txtLayerBotDist7.Text);

            _Layer8Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia8.SelectedIndex);
            _Layer8RebarQuantity = Int32.Parse(txtLayerQty8.Text);
            _Layer8BottomDistance = Double.Parse(txtLayerBotDist8.Text);

            _Layer9Rebar.RebarDiameter = AssignDiameterForFivenIndex(cmbLayerDia9.SelectedIndex);
            _Layer9RebarQuantity = Int32.Parse(txtLayerQty9.Text);
            _Layer9BottomDistance = Double.Parse(txtLayerBotDist9.Text);

            _StirrupDiam = AssignDiameterForFivenIndex(cmbStirrupDia.SelectedIndex);
            _StirrupSpacing = Double.Parse(txtStirrupSpacing.Text);
            _fYwk = Double.Parse(txtTransverseSteelGrade.Text);

            _AxialLoadRatio = Double.Parse(txtAxialLoadRatio.Text);
        }

        private void Rec2Form()
        {
            txtXSecHeight.Text = _CrossSectionHeight.ToString();
            txtXSecWidth.Text = _CrossSectionWidth.ToString();
            txtClearCover.Text = _ClearCover.ToString();
            txtConcreteGrade.Text = _ConcreteGrade.ToString();
            txtSteelGrade.Text = _SteelGrade.ToString();
            ConfinementSettings();

            cmbLayerDia1.SelectedIndex = AssignIndexForGivenDiameter(_Layer1Rebar.RebarDiameter);
            txtLayerQty1.Text = _Layer1RebarQuantity.ToString();
            txtLayerBotDist1.Text = _Layer1BottomDistance.ToString();

            cmbLayerDia2.SelectedIndex = AssignIndexForGivenDiameter(_Layer2Rebar.RebarDiameter);
            txtLayerQty2.Text = _Layer2RebarQuantity.ToString();
            txtLayerBotDist2.Text = _Layer2BottomDistance.ToString();

            cmbLayerDia3.SelectedIndex = AssignIndexForGivenDiameter(_Layer3Rebar.RebarDiameter);
            txtLayerQty3.Text = _Layer3RebarQuantity.ToString();
            txtLayerBotDist3.Text = _Layer3BottomDistance.ToString();

            cmbLayerDia4.SelectedIndex = AssignIndexForGivenDiameter(_Layer4Rebar.RebarDiameter);
            txtLayerQty4.Text = _Layer4RebarQuantity.ToString();
            txtLayerBotDist4.Text = _Layer4BottomDistance.ToString();

            cmbLayerDia5.SelectedIndex = AssignIndexForGivenDiameter(_Layer5Rebar.RebarDiameter);
            txtLayerQty5.Text = _Layer5RebarQuantity.ToString();
            txtLayerBotDist5.Text = _Layer5BottomDistance.ToString();

            cmbLayerDia6.SelectedIndex = AssignIndexForGivenDiameter(_Layer6Rebar.RebarDiameter);
            txtLayerQty6.Text = _Layer6RebarQuantity.ToString();
            txtLayerBotDist6.Text = _Layer6BottomDistance.ToString();

            cmbLayerDia7.SelectedIndex = AssignIndexForGivenDiameter(_Layer7Rebar.RebarDiameter);
            txtLayerQty7.Text = _Layer7RebarQuantity.ToString();
            txtLayerBotDist7.Text = _Layer7BottomDistance.ToString();

            cmbLayerDia8.SelectedIndex = AssignIndexForGivenDiameter(_Layer8Rebar.RebarDiameter);
            txtLayerQty8.Text = _Layer8RebarQuantity.ToString();
            txtLayerBotDist8.Text = _Layer8BottomDistance.ToString();

            cmbLayerDia9.SelectedIndex = AssignIndexForGivenDiameter(_Layer9Rebar.RebarDiameter);
            txtLayerQty9.Text = _Layer9RebarQuantity.ToString();
            txtLayerBotDist9.Text = _Layer9BottomDistance.ToString();

            cmbStirrupDia.SelectedIndex = AssignIndexForGivenDiameter(_StirrupDiam);
            txtStirrupSpacing.Text = _StirrupSpacing.ToString();
            txtTransverseSteelGrade.Text = _fYwk.ToString();

            txtAxialLoadRatio.Text = _AxialLoadRatio.ToString();

            AdjustLayerVisibility();
            AssembleLayerInformation();
            UpdateCrossSection();
            txtAxilLoadCapacity.Text = (_xSec.AxialLoadCapacity / 1000).ToString("#.00");
            txtMomentCapacity.Text = (_xSec.MomentCapacity).ToString("#.00");
            UpdateGraph();

        }

        private int AssignDiameterForFivenIndex(int index)
        {
            int dia = 8;

            if (index == 0)
            {
                dia = 8;
            }
            else if (index == 1)
            {
                dia = 10;
            }
            else if (index == 2)
            {
                dia = 12;
            }
            else if (index == 3)
            {
                dia = 14;
            }
            else if (index == 4)
            {
                dia = 16;
            }
            else if (index == 5)
            {
                dia = 18;
            }
            else if (index == 6)
            {
                dia = 20;
            }
            else if (index == 7)
            {
                dia = 22;
            }
            else if (index == 8)
            {
                dia = 24;
            }
            else if (index == 9)
            {
                dia = 26;
            }
            else if (index == 10)
            {
                dia = 28;
            }
            else if (index == 11)
            {
                dia = 30;
            }
            else if (index == 12)
            {
                dia = 32;
            }

            return dia;
        }


        private int AssignIndexForGivenDiameter(int dia)
        {
            int index = 0;

            if (dia == 8)
            {
                index = 0;
            }
            else if (dia == 10)
            {
                index = 1;
            }
            else if (dia == 12)
            {
                index = 2;
            }
            else if (dia == 14)
            {
                index = 3;
            }
            else if (dia == 16)
            {
                index = 4;
            }
            else if (dia == 18)
            {
                index = 5;
            }
            else if (dia == 20)
            {
                index = 6;
            }
            else if (dia == 22)
            {
                index = 7;
            }
            else if (dia == 24)
            {
                index = 8;
            }
            else if (dia == 26)
            {
                index = 9;
            }
            else if (dia == 28)
            {
                index = 10;
            }
            else if (dia == 30)
            {
                index = 1;
            }
            else if (dia == 32)
            {
                index = 12;
            }

            return index;
        }

        private void AssembleLayerInformation()
        {
            _LayerDict.Clear();

            // Layer 1
            _Layer1 = new RebarLayer(_Layer1Rebar, _Layer1RebarQuantity, _Layer1BottomDistance);

            // Layer 2
            _Layer2 = new RebarLayer(_Layer2Rebar, _Layer2RebarQuantity, _Layer2BottomDistance);

            // Layer 3
            _Layer3 = new RebarLayer(_Layer3Rebar, _Layer3RebarQuantity, _Layer3BottomDistance);

            // Layer 4
            _Layer4 = new RebarLayer(_Layer4Rebar, _Layer4RebarQuantity, _Layer4BottomDistance);

            // Layer 5
            _Layer5 = new RebarLayer(_Layer5Rebar, _Layer5RebarQuantity, _Layer5BottomDistance);

            // Layer 6
            _Layer6 = new RebarLayer(_Layer6Rebar, _Layer6RebarQuantity, _Layer6BottomDistance);

            // Layer 7
            _Layer7 = new RebarLayer(_Layer7Rebar, _Layer7RebarQuantity, _Layer7BottomDistance);

            // Layer 8
            _Layer8 = new RebarLayer(_Layer8Rebar, _Layer8RebarQuantity, _Layer8BottomDistance);

            // Layer 9
            _Layer9 = new RebarLayer(_Layer9Rebar, _Layer9RebarQuantity, _Layer9BottomDistance);

            _LayerDict.Add(1, _Layer1);
            _LayerDict.Add(2, _Layer2);
            _LayerDict.Add(3, _Layer3);
            _LayerDict.Add(4, _Layer4);
            _LayerDict.Add(5, _Layer5);
            _LayerDict.Add(6, _Layer6);
            _LayerDict.Add(7, _Layer7);
            _LayerDict.Add(8, _Layer8);
            _LayerDict.Add(9, _Layer9);
        }

        private void CreateDefaultSection()
        {
            _CrossSectionHeight = 500; // mm
            _CrossSectionWidth = 500; // mm
            _ClearCover = 30; // mm
            _ConcreteGrade = 30; // MPa
            _SteelGrade = 420; // MPa
            _fYwk = 420; // MPa
            _StirrupSpacing = 100; // mm
            _StirrupDiam = 10; // mm
            _AxialLoadRatio = 0;

            double counter = 0;

            _Layer1Rebar = new Rebar(14, _SteelGrade);
            _Layer1RebarQuantity = 2;
            _Layer1BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer2Rebar = new Rebar(14, _SteelGrade);
            _Layer2RebarQuantity = 2;
            _Layer2BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer3Rebar = new Rebar(14, _SteelGrade);
            _Layer3RebarQuantity = 2;
            _Layer3BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer4Rebar = new Rebar(14, _SteelGrade);
            _Layer4RebarQuantity = 2;
            _Layer4BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer5Rebar = new Rebar(14, _SteelGrade);
            _Layer5RebarQuantity = 2;
            _Layer5BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer6Rebar = new Rebar(14, _SteelGrade);
            _Layer6RebarQuantity = 2;
            _Layer6BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer7Rebar = new Rebar(14, _SteelGrade);
            _Layer7RebarQuantity = 2;
            _Layer7BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer8Rebar = new Rebar(14, _SteelGrade);
            _Layer8RebarQuantity = 2;
            _Layer8BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;

            counter += 30;

            _Layer9Rebar = new Rebar(14, _SteelGrade);
            _Layer9RebarQuantity = 2;
            _Layer9BottomDistance = _ClearCover - (_Layer1Rebar.RebarDiameter / 2) + counter;
        }

        private void AdjustLayerVisibility()
        {
            if (_LayerNumber == 0)
            {
                lblDiam.Visible = false;
                lblQty.Visible = false;
                lblDistFromBot.Visible = false;

                // Layer 1
                lblLayer1.Visible = false;
                cmbLayerDia1.Visible = false;
                txtLayerQty1.Visible = false;
                txtLayerBotDist1.Visible = false;

                // Layer 2
                lblLayer2.Visible = false;
                cmbLayerDia2.Visible = false;
                txtLayerQty2.Visible = false;
                txtLayerBotDist2.Visible = false;

                // Layer 3
                lblLayer3.Visible = false;
                cmbLayerDia3.Visible = false;
                txtLayerQty3.Visible = false;
                txtLayerBotDist3.Visible = false;

                // Layer 4
                lblLayer4.Visible = false;
                cmbLayerDia4.Visible = false;
                txtLayerQty4.Visible = false;
                txtLayerBotDist4.Visible = false;

                // Layer 5
                lblLayer5.Visible = false;
                cmbLayerDia5.Visible = false;
                txtLayerQty5.Visible = false;
                txtLayerBotDist5.Visible = false;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 1)
            {
                lblDiam.Visible = true;
                lblQty.Visible = true;
                lblDistFromBot.Visible = true;

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = false;
                cmbLayerDia2.Visible = false;
                txtLayerQty2.Visible = false;
                txtLayerBotDist2.Visible = false;

                // Layer 3
                lblLayer3.Visible = false;
                cmbLayerDia3.Visible = false;
                txtLayerQty3.Visible = false;
                txtLayerBotDist3.Visible = false;

                // Layer 4
                lblLayer4.Visible = false;
                cmbLayerDia4.Visible = false;
                txtLayerQty4.Visible = false;
                txtLayerBotDist4.Visible = false;

                // Layer 5
                lblLayer5.Visible = false;
                cmbLayerDia5.Visible = false;
                txtLayerQty5.Visible = false;
                txtLayerBotDist5.Visible = false;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 2)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = false;
                cmbLayerDia3.Visible = false;
                txtLayerQty3.Visible = false;
                txtLayerBotDist3.Visible = false;

                // Layer 4
                lblLayer4.Visible = false;
                cmbLayerDia4.Visible = false;
                txtLayerQty4.Visible = false;
                txtLayerBotDist4.Visible = false;

                // Layer 5
                lblLayer5.Visible = false;
                cmbLayerDia5.Visible = false;
                txtLayerQty5.Visible = false;
                txtLayerBotDist5.Visible = false;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 3)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = false;
                cmbLayerDia4.Visible = false;
                txtLayerQty4.Visible = false;
                txtLayerBotDist4.Visible = false;

                // Layer 5
                lblLayer5.Visible = false;
                cmbLayerDia5.Visible = false;
                txtLayerQty5.Visible = false;
                txtLayerBotDist5.Visible = false;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 4)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = false;
                cmbLayerDia5.Visible = false;
                txtLayerQty5.Visible = false;
                txtLayerBotDist5.Visible = false;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 5)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = true;
                cmbLayerDia5.Visible = true;
                txtLayerQty5.Visible = true;
                txtLayerBotDist5.Visible = true;

                // Layer 6
                lblLayer6.Visible = false;
                cmbLayerDia6.Visible = false;
                txtLayerQty6.Visible = false;
                txtLayerBotDist6.Visible = false;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 6)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = true;
                cmbLayerDia5.Visible = true;
                txtLayerQty5.Visible = true;
                txtLayerBotDist5.Visible = true;

                // Layer 6
                lblLayer6.Visible = true;
                cmbLayerDia6.Visible = true;
                txtLayerQty6.Visible = true;
                txtLayerBotDist6.Visible = true;

                // Layer 7
                lblLayer7.Visible = false;
                cmbLayerDia7.Visible = false;
                txtLayerQty7.Visible = false;
                txtLayerBotDist7.Visible = false;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 7)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = true;
                cmbLayerDia5.Visible = true;
                txtLayerQty5.Visible = true;
                txtLayerBotDist5.Visible = true;

                // Layer 6
                lblLayer6.Visible = true;
                cmbLayerDia6.Visible = true;
                txtLayerQty6.Visible = true;
                txtLayerBotDist6.Visible = true;

                // Layer 7
                lblLayer7.Visible = true;
                cmbLayerDia7.Visible = true;
                txtLayerQty7.Visible = true;
                txtLayerBotDist7.Visible = true;

                // Layer 8
                lblLayer8.Visible = false;
                cmbLayerDia8.Visible = false;
                txtLayerQty8.Visible = false;
                txtLayerBotDist8.Visible = false;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 8)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = true;
                cmbLayerDia5.Visible = true;
                txtLayerQty5.Visible = true;
                txtLayerBotDist5.Visible = true;

                // Layer 6
                lblLayer6.Visible = true;
                cmbLayerDia6.Visible = true;
                txtLayerQty6.Visible = true;
                txtLayerBotDist6.Visible = true;

                // Layer 7
                lblLayer7.Visible = true;
                cmbLayerDia7.Visible = true;
                txtLayerQty7.Visible = true;
                txtLayerBotDist7.Visible = true;

                // Layer 8
                lblLayer8.Visible = true;
                cmbLayerDia8.Visible = true;
                txtLayerQty8.Visible = true;
                txtLayerBotDist8.Visible = true;

                // Layer 9
                lblLayer9.Visible = false;
                cmbLayerDia9.Visible = false;
                txtLayerQty9.Visible = false;
                txtLayerBotDist9.Visible = false;
            }
            else if (_LayerNumber == 9)
            {

                // Layer 1
                lblLayer1.Visible = true;
                cmbLayerDia1.Visible = true;
                txtLayerQty1.Visible = true;
                txtLayerBotDist1.Visible = true;

                // Layer 2
                lblLayer2.Visible = true;
                cmbLayerDia2.Visible = true;
                txtLayerQty2.Visible = true;
                txtLayerBotDist2.Visible = true;

                // Layer 3
                lblLayer3.Visible = true;
                cmbLayerDia3.Visible = true;
                txtLayerQty3.Visible = true;
                txtLayerBotDist3.Visible = true;

                // Layer 4
                lblLayer4.Visible = true;
                cmbLayerDia4.Visible = true;
                txtLayerQty4.Visible = true;
                txtLayerBotDist4.Visible = true;

                // Layer 5
                lblLayer5.Visible = true;
                cmbLayerDia5.Visible = true;
                txtLayerQty5.Visible = true;
                txtLayerBotDist5.Visible = true;

                // Layer 6
                lblLayer6.Visible = true;
                cmbLayerDia6.Visible = true;
                txtLayerQty6.Visible = true;
                txtLayerBotDist6.Visible = true;

                // Layer 7
                lblLayer7.Visible = true;
                cmbLayerDia7.Visible = true;
                txtLayerQty7.Visible = true;
                txtLayerBotDist7.Visible = true;

                // Layer 8
                lblLayer8.Visible = true;
                cmbLayerDia8.Visible = true;
                txtLayerQty8.Visible = true;
                txtLayerBotDist8.Visible = true;

                // Layer 9
                lblLayer9.Visible = true;
                cmbLayerDia9.Visible = true;
                txtLayerQty9.Visible = true;
                txtLayerBotDist9.Visible = true;
            }
        }

        private void FillLayerDiametersComboBox()
        {
            cmbLayerDia1.Items.Add("Ø8");
            cmbLayerDia1.Items.Add("Ø10");
            cmbLayerDia1.Items.Add("Ø12");
            cmbLayerDia1.Items.Add("Ø14");
            cmbLayerDia1.Items.Add("Ø16");
            cmbLayerDia1.Items.Add("Ø18");
            cmbLayerDia1.Items.Add("Ø20");
            cmbLayerDia1.Items.Add("Ø22");
            cmbLayerDia1.Items.Add("Ø24");
            cmbLayerDia1.Items.Add("Ø26");
            cmbLayerDia1.Items.Add("Ø28");
            cmbLayerDia1.Items.Add("Ø30");
            cmbLayerDia1.Items.Add("Ø32");

            cmbLayerDia2.Items.Add("Ø8");
            cmbLayerDia2.Items.Add("Ø10");
            cmbLayerDia2.Items.Add("Ø12");
            cmbLayerDia2.Items.Add("Ø14");
            cmbLayerDia2.Items.Add("Ø16");
            cmbLayerDia2.Items.Add("Ø18");
            cmbLayerDia2.Items.Add("Ø20");
            cmbLayerDia2.Items.Add("Ø22");
            cmbLayerDia2.Items.Add("Ø24");
            cmbLayerDia2.Items.Add("Ø26");
            cmbLayerDia2.Items.Add("Ø28");
            cmbLayerDia2.Items.Add("Ø30");
            cmbLayerDia2.Items.Add("Ø32");

            cmbLayerDia3.Items.Add("Ø8");
            cmbLayerDia3.Items.Add("Ø10");
            cmbLayerDia3.Items.Add("Ø12");
            cmbLayerDia3.Items.Add("Ø14");
            cmbLayerDia3.Items.Add("Ø16");
            cmbLayerDia3.Items.Add("Ø18");
            cmbLayerDia3.Items.Add("Ø20");
            cmbLayerDia3.Items.Add("Ø22");
            cmbLayerDia3.Items.Add("Ø24");
            cmbLayerDia3.Items.Add("Ø26");
            cmbLayerDia3.Items.Add("Ø28");
            cmbLayerDia3.Items.Add("Ø30");
            cmbLayerDia3.Items.Add("Ø32");

            cmbLayerDia4.Items.Add("Ø8");
            cmbLayerDia4.Items.Add("Ø10");
            cmbLayerDia4.Items.Add("Ø12");
            cmbLayerDia4.Items.Add("Ø14");
            cmbLayerDia4.Items.Add("Ø16");
            cmbLayerDia4.Items.Add("Ø18");
            cmbLayerDia4.Items.Add("Ø20");
            cmbLayerDia4.Items.Add("Ø22");
            cmbLayerDia4.Items.Add("Ø24");
            cmbLayerDia4.Items.Add("Ø26");
            cmbLayerDia4.Items.Add("Ø28");
            cmbLayerDia4.Items.Add("Ø30");
            cmbLayerDia4.Items.Add("Ø32");

            cmbLayerDia5.Items.Add("Ø8");
            cmbLayerDia5.Items.Add("Ø10");
            cmbLayerDia5.Items.Add("Ø12");
            cmbLayerDia5.Items.Add("Ø14");
            cmbLayerDia5.Items.Add("Ø16");
            cmbLayerDia5.Items.Add("Ø18");
            cmbLayerDia5.Items.Add("Ø20");
            cmbLayerDia5.Items.Add("Ø22");
            cmbLayerDia5.Items.Add("Ø24");
            cmbLayerDia5.Items.Add("Ø26");
            cmbLayerDia5.Items.Add("Ø28");
            cmbLayerDia5.Items.Add("Ø30");
            cmbLayerDia5.Items.Add("Ø32");

            cmbLayerDia6.Items.Add("Ø8");
            cmbLayerDia6.Items.Add("Ø10");
            cmbLayerDia6.Items.Add("Ø12");
            cmbLayerDia6.Items.Add("Ø14");
            cmbLayerDia6.Items.Add("Ø16");
            cmbLayerDia6.Items.Add("Ø18");
            cmbLayerDia6.Items.Add("Ø20");
            cmbLayerDia6.Items.Add("Ø22");
            cmbLayerDia6.Items.Add("Ø24");
            cmbLayerDia6.Items.Add("Ø26");
            cmbLayerDia6.Items.Add("Ø28");
            cmbLayerDia6.Items.Add("Ø30");
            cmbLayerDia6.Items.Add("Ø32");

            cmbLayerDia7.Items.Add("Ø8");
            cmbLayerDia7.Items.Add("Ø10");
            cmbLayerDia7.Items.Add("Ø12");
            cmbLayerDia7.Items.Add("Ø14");
            cmbLayerDia7.Items.Add("Ø16");
            cmbLayerDia7.Items.Add("Ø18");
            cmbLayerDia7.Items.Add("Ø20");
            cmbLayerDia7.Items.Add("Ø22");
            cmbLayerDia7.Items.Add("Ø24");
            cmbLayerDia7.Items.Add("Ø26");
            cmbLayerDia7.Items.Add("Ø28");
            cmbLayerDia7.Items.Add("Ø30");
            cmbLayerDia7.Items.Add("Ø32");

            cmbLayerDia8.Items.Add("Ø8");
            cmbLayerDia8.Items.Add("Ø10");
            cmbLayerDia8.Items.Add("Ø12");
            cmbLayerDia8.Items.Add("Ø14");
            cmbLayerDia8.Items.Add("Ø16");
            cmbLayerDia8.Items.Add("Ø18");
            cmbLayerDia8.Items.Add("Ø20");
            cmbLayerDia8.Items.Add("Ø22");
            cmbLayerDia8.Items.Add("Ø24");
            cmbLayerDia8.Items.Add("Ø26");
            cmbLayerDia8.Items.Add("Ø28");
            cmbLayerDia8.Items.Add("Ø30");
            cmbLayerDia8.Items.Add("Ø32");

            cmbLayerDia9.Items.Add("Ø8");
            cmbLayerDia9.Items.Add("Ø10");
            cmbLayerDia9.Items.Add("Ø12");
            cmbLayerDia9.Items.Add("Ø14");
            cmbLayerDia9.Items.Add("Ø16");
            cmbLayerDia9.Items.Add("Ø18");
            cmbLayerDia9.Items.Add("Ø20");
            cmbLayerDia9.Items.Add("Ø22");
            cmbLayerDia9.Items.Add("Ø24");
            cmbLayerDia9.Items.Add("Ø26");
            cmbLayerDia9.Items.Add("Ø28");
            cmbLayerDia9.Items.Add("Ø30");
            cmbLayerDia9.Items.Add("Ø32");

            cmbStirrupDia.Items.Add("Ø8");
            cmbStirrupDia.Items.Add("Ø10");
            cmbStirrupDia.Items.Add("Ø12");
            cmbStirrupDia.Items.Add("Ø14");
        }

        private void SetUpInitialPhaseOfComboBoxes()
        {
            cmbLayerDia1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia7.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia8.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayerDia9.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStirrupDia.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfinementSettings()
        {
            if (_LayerNumber > 1)
            {
                chkConfined.Visible = true;
            }
            else
            {
                chkConfined.Visible = false;
                chkConfined.Checked = false;
            }

            if (chkConfined.Checked == true)
            {
                _IsConfined = true;
            }
            else
            {
                _IsConfined = false;
            }

            label5.Visible = _IsConfined;
            label6.Visible = _IsConfined;
            label9.Visible = _IsConfined;
            txtStirrupSpacing.Visible = _IsConfined;
            txtTransverseSteelGrade.Visible = _IsConfined;
            label4.Visible = _IsConfined;
            label12.Visible = _IsConfined;
            cmbStirrupDia.Visible = _IsConfined;

        }

        private void UpdateCrossSection()
        {
            _xSec = new CrossSection(_LayerDict, _CrossSectionHeight, _CrossSectionWidth, _LayerNumber, _ClearCover, _ConcreteGrade, _SteelGrade, _fYwk, _StirrupSpacing, _IsConfined, _StirrupDiam, _AxialLoadRatio, 5);
        }

        private void UpdateGraph()
        {
            graphMK.Series.Clear();
            graphMK.ChartAreas[0].AxisX.Title = "Curvature (1/km)";
            graphMK.ChartAreas[0].AxisY.Title = "Moment (kNm)";

            ChartArea area = graphMK.ChartAreas[0];

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = _xSec.MomentCurvature.Values.Max() * 1.1;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = _xSec.MomentCurvature.Keys.Max() * 1000000 * 1.1;

            Series mk = new Series();
            mk.ChartType = SeriesChartType.Line;
            mk.IsVisibleInLegend = false;

            Dictionary<double, double> mkVals = _xSec.MomentCurvature;

            foreach (var item in mkVals)
            {
                double curv = item.Key * 1000000;
                double mom = item.Value;
                mk.Points.AddXY(curv, mom);
            }

            graphMK.Series.Add(mk);
            graphMK.Series[0].BorderWidth = 5;
        }

        #endregion

        #region Events

        private void TxtXSecHeight_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtXSecHeight.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();

                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtAxialLoadRatio_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtAxialLoadRatio.Text, out val);

            if (isParsed)
            {
                if (val >= 0 && val <= 100)
                {
                    Form2Rec();

                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtTransverseSteelGrade_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtTransverseSteelGrade.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();

                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtStirrupSpacing_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtStirrupSpacing.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();

                }
            }

            Rec2Form();
            SubscribeEvents();
        }


        private void TxtXSecWidth_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtXSecWidth.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtClearCover_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtClearCover.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }


        private void TxtConcreteGrade_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtConcreteGrade.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtSteelGrade_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtSteelGrade.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void BtnDeleteRebarLayer_Click(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();

            if (_LayerNumber > 0)
            {
                _LayerNumber -= 1;
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void BtnAddRebarLayer_Click(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();

            if (_LayerNumber < 9)
            {
                _LayerNumber += 1;
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void ChkConfined_CheckedChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia6_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbLayerDia9_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void CmbStirrupDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            Form2Rec();
            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty1_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty1.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty2_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty2.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty3_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty3.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty4_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty4.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty5_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty5.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty6_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty6.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty7_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty7.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty8_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty8.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerQty9_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerQty9.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();

                }
            }

            Rec2Form();
            SubscribeEvents();
        }


        private void TxtLayerBotDist1_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist1.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist2_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist2.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist3_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist3.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist4_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist4.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist5_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist5.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist6_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist6.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist7_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist7.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist8_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist8.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        private void TxtLayerBotDist9_Leave(object sender, EventArgs e)
        {
            UnsubscribeEvents();

            double val = 0;
            bool isParsed = Double.TryParse(txtLayerBotDist9.Text, out val);

            if (isParsed)
            {
                if (val > 0)
                {
                    Form2Rec();
                }
            }

            Rec2Form();
            SubscribeEvents();
        }

        #endregion

    }
}
