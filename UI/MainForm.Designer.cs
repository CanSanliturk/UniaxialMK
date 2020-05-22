namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graphMK = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpMaterialDefinitons = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStirrupSpacing = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransverseSteelGrade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSteelGrade = new System.Windows.Forms.TextBox();
            this.txtConcreteGrade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpRebars = new System.Windows.Forms.GroupBox();
            this.cmbStirrupDia = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkConfined = new System.Windows.Forms.CheckBox();
            this.txtLayerQty8 = new System.Windows.Forms.TextBox();
            this.txtLayerQty9 = new System.Windows.Forms.TextBox();
            this.txtLayerQty7 = new System.Windows.Forms.TextBox();
            this.txtLayerQty5 = new System.Windows.Forms.TextBox();
            this.txtLayerQty6 = new System.Windows.Forms.TextBox();
            this.txtLayerQty4 = new System.Windows.Forms.TextBox();
            this.txtLayerQty2 = new System.Windows.Forms.TextBox();
            this.txtLayerQty3 = new System.Windows.Forms.TextBox();
            this.txtLayerQty1 = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtLayerBotDist8 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia8 = new System.Windows.Forms.ComboBox();
            this.lblLayer8 = new System.Windows.Forms.Label();
            this.txtLayerBotDist9 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia9 = new System.Windows.Forms.ComboBox();
            this.lblLayer9 = new System.Windows.Forms.Label();
            this.txtLayerBotDist7 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia7 = new System.Windows.Forms.ComboBox();
            this.lblLayer7 = new System.Windows.Forms.Label();
            this.txtLayerBotDist5 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia5 = new System.Windows.Forms.ComboBox();
            this.lblLayer5 = new System.Windows.Forms.Label();
            this.txtLayerBotDist6 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia6 = new System.Windows.Forms.ComboBox();
            this.lblLayer6 = new System.Windows.Forms.Label();
            this.txtLayerBotDist4 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia4 = new System.Windows.Forms.ComboBox();
            this.lblLayer4 = new System.Windows.Forms.Label();
            this.txtLayerBotDist2 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia2 = new System.Windows.Forms.ComboBox();
            this.lblLayer2 = new System.Windows.Forms.Label();
            this.txtLayerBotDist3 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia3 = new System.Windows.Forms.ComboBox();
            this.lblLayer3 = new System.Windows.Forms.Label();
            this.txtLayerBotDist1 = new System.Windows.Forms.TextBox();
            this.cmbLayerDia1 = new System.Windows.Forms.ComboBox();
            this.lblLayer1 = new System.Windows.Forms.Label();
            this.lblDistFromBot = new System.Windows.Forms.Label();
            this.lblDiam = new System.Windows.Forms.Label();
            this.btnDeleteRebarLayer = new System.Windows.Forms.Button();
            this.btnAddRebarLayer = new System.Windows.Forms.Button();
            this.grpXSecDim = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClearCover = new System.Windows.Forms.TextBox();
            this.txtXSecWidth = new System.Windows.Forms.TextBox();
            this.txtXSecHeight = new System.Windows.Forms.TextBox();
            this.lblClearCover = new System.Windows.Forms.Label();
            this.lblXSecWidth = new System.Windows.Forms.Label();
            this.lblXSecHeight = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMomentCapacity = new System.Windows.Forms.TextBox();
            this.txtAxialLoadRatio = new System.Windows.Forms.TextBox();
            this.txtAxilLoadCapacity = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphMK)).BeginInit();
            this.grpMaterialDefinitons.SuspendLayout();
            this.grpRebars.SuspendLayout();
            this.grpXSecDim.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphMK
            // 
            chartArea1.Name = "ChartArea1";
            this.graphMK.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graphMK.Legends.Add(legend1);
            this.graphMK.Location = new System.Drawing.Point(15, 19);
            this.graphMK.Name = "graphMK";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphMK.Series.Add(series1);
            this.graphMK.Size = new System.Drawing.Size(956, 720);
            this.graphMK.TabIndex = 9;
            this.graphMK.Text = "Moment Curvature";
            // 
            // grpMaterialDefinitons
            // 
            this.grpMaterialDefinitons.Controls.Add(this.label6);
            this.grpMaterialDefinitons.Controls.Add(this.txtStirrupSpacing);
            this.grpMaterialDefinitons.Controls.Add(this.label9);
            this.grpMaterialDefinitons.Controls.Add(this.label4);
            this.grpMaterialDefinitons.Controls.Add(this.txtTransverseSteelGrade);
            this.grpMaterialDefinitons.Controls.Add(this.label5);
            this.grpMaterialDefinitons.Controls.Add(this.label7);
            this.grpMaterialDefinitons.Controls.Add(this.label8);
            this.grpMaterialDefinitons.Controls.Add(this.txtSteelGrade);
            this.grpMaterialDefinitons.Controls.Add(this.txtConcreteGrade);
            this.grpMaterialDefinitons.Controls.Add(this.label10);
            this.grpMaterialDefinitons.Controls.Add(this.label11);
            this.grpMaterialDefinitons.Location = new System.Drawing.Point(12, 172);
            this.grpMaterialDefinitons.Name = "grpMaterialDefinitons";
            this.grpMaterialDefinitons.Size = new System.Drawing.Size(429, 155);
            this.grpMaterialDefinitons.TabIndex = 9;
            this.grpMaterialDefinitons.TabStop = false;
            this.grpMaterialDefinitons.Text = "Concrete and Reinforcment Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "mm";
            // 
            // txtStirrupSpacing
            // 
            this.txtStirrupSpacing.Location = new System.Drawing.Point(264, 125);
            this.txtStirrupSpacing.Name = "txtStirrupSpacing";
            this.txtStirrupSpacing.Size = new System.Drawing.Size(100, 20);
            this.txtStirrupSpacing.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Transverse Reinforcement Spacing :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "MPa";
            // 
            // txtTransverseSteelGrade
            // 
            this.txtTransverseSteelGrade.Location = new System.Drawing.Point(264, 92);
            this.txtTransverseSteelGrade.Name = "txtTransverseSteelGrade";
            this.txtTransverseSteelGrade.Size = new System.Drawing.Size(100, 20);
            this.txtTransverseSteelGrade.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Yielding Strength of Transverse Reinforcement :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "MPa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "MPa";
            // 
            // txtSteelGrade
            // 
            this.txtSteelGrade.Location = new System.Drawing.Point(264, 56);
            this.txtSteelGrade.Name = "txtSteelGrade";
            this.txtSteelGrade.Size = new System.Drawing.Size(100, 20);
            this.txtSteelGrade.TabIndex = 4;
            // 
            // txtConcreteGrade
            // 
            this.txtConcreteGrade.Location = new System.Drawing.Point(264, 24);
            this.txtConcreteGrade.Name = "txtConcreteGrade";
            this.txtConcreteGrade.Size = new System.Drawing.Size(100, 20);
            this.txtConcreteGrade.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Yielding Strength of Longitudinal Rebar :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(82, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Compressive Strength of Concrete :";
            // 
            // grpRebars
            // 
            this.grpRebars.Controls.Add(this.cmbStirrupDia);
            this.grpRebars.Controls.Add(this.label12);
            this.grpRebars.Controls.Add(this.chkConfined);
            this.grpRebars.Controls.Add(this.txtLayerQty8);
            this.grpRebars.Controls.Add(this.txtLayerQty9);
            this.grpRebars.Controls.Add(this.txtLayerQty7);
            this.grpRebars.Controls.Add(this.txtLayerQty5);
            this.grpRebars.Controls.Add(this.txtLayerQty6);
            this.grpRebars.Controls.Add(this.txtLayerQty4);
            this.grpRebars.Controls.Add(this.txtLayerQty2);
            this.grpRebars.Controls.Add(this.txtLayerQty3);
            this.grpRebars.Controls.Add(this.txtLayerQty1);
            this.grpRebars.Controls.Add(this.lblQty);
            this.grpRebars.Controls.Add(this.txtLayerBotDist8);
            this.grpRebars.Controls.Add(this.cmbLayerDia8);
            this.grpRebars.Controls.Add(this.lblLayer8);
            this.grpRebars.Controls.Add(this.txtLayerBotDist9);
            this.grpRebars.Controls.Add(this.cmbLayerDia9);
            this.grpRebars.Controls.Add(this.lblLayer9);
            this.grpRebars.Controls.Add(this.txtLayerBotDist7);
            this.grpRebars.Controls.Add(this.cmbLayerDia7);
            this.grpRebars.Controls.Add(this.lblLayer7);
            this.grpRebars.Controls.Add(this.txtLayerBotDist5);
            this.grpRebars.Controls.Add(this.cmbLayerDia5);
            this.grpRebars.Controls.Add(this.lblLayer5);
            this.grpRebars.Controls.Add(this.txtLayerBotDist6);
            this.grpRebars.Controls.Add(this.cmbLayerDia6);
            this.grpRebars.Controls.Add(this.lblLayer6);
            this.grpRebars.Controls.Add(this.txtLayerBotDist4);
            this.grpRebars.Controls.Add(this.cmbLayerDia4);
            this.grpRebars.Controls.Add(this.lblLayer4);
            this.grpRebars.Controls.Add(this.txtLayerBotDist2);
            this.grpRebars.Controls.Add(this.cmbLayerDia2);
            this.grpRebars.Controls.Add(this.lblLayer2);
            this.grpRebars.Controls.Add(this.txtLayerBotDist3);
            this.grpRebars.Controls.Add(this.cmbLayerDia3);
            this.grpRebars.Controls.Add(this.lblLayer3);
            this.grpRebars.Controls.Add(this.txtLayerBotDist1);
            this.grpRebars.Controls.Add(this.cmbLayerDia1);
            this.grpRebars.Controls.Add(this.lblLayer1);
            this.grpRebars.Controls.Add(this.lblDistFromBot);
            this.grpRebars.Controls.Add(this.lblDiam);
            this.grpRebars.Controls.Add(this.btnDeleteRebarLayer);
            this.grpRebars.Controls.Add(this.btnAddRebarLayer);
            this.grpRebars.Location = new System.Drawing.Point(12, 333);
            this.grpRebars.Name = "grpRebars";
            this.grpRebars.Size = new System.Drawing.Size(429, 568);
            this.grpRebars.TabIndex = 9;
            this.grpRebars.TabStop = false;
            this.grpRebars.Text = "Rebar Definitions";
            // 
            // cmbStirrupDia
            // 
            this.cmbStirrupDia.FormattingEnabled = true;
            this.cmbStirrupDia.Location = new System.Drawing.Point(94, 437);
            this.cmbStirrupDia.Name = "cmbStirrupDia";
            this.cmbStirrupDia.Size = new System.Drawing.Size(71, 21);
            this.cmbStirrupDia.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 445);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Stirrup";
            // 
            // chkConfined
            // 
            this.chkConfined.AutoSize = true;
            this.chkConfined.Location = new System.Drawing.Point(25, 510);
            this.chkConfined.Name = "chkConfined";
            this.chkConfined.Size = new System.Drawing.Size(186, 17);
            this.chkConfined.TabIndex = 55;
            this.chkConfined.Text = "Confinement around outer rebars?";
            this.chkConfined.UseVisualStyleBackColor = true;
            // 
            // txtLayerQty8
            // 
            this.txtLayerQty8.Location = new System.Drawing.Point(196, 356);
            this.txtLayerQty8.Name = "txtLayerQty8";
            this.txtLayerQty8.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty8.TabIndex = 54;
            // 
            // txtLayerQty9
            // 
            this.txtLayerQty9.Location = new System.Drawing.Point(196, 396);
            this.txtLayerQty9.Name = "txtLayerQty9";
            this.txtLayerQty9.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty9.TabIndex = 53;
            // 
            // txtLayerQty7
            // 
            this.txtLayerQty7.Location = new System.Drawing.Point(196, 312);
            this.txtLayerQty7.Name = "txtLayerQty7";
            this.txtLayerQty7.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty7.TabIndex = 52;
            // 
            // txtLayerQty5
            // 
            this.txtLayerQty5.Location = new System.Drawing.Point(196, 232);
            this.txtLayerQty5.Name = "txtLayerQty5";
            this.txtLayerQty5.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty5.TabIndex = 51;
            // 
            // txtLayerQty6
            // 
            this.txtLayerQty6.Location = new System.Drawing.Point(196, 272);
            this.txtLayerQty6.Name = "txtLayerQty6";
            this.txtLayerQty6.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty6.TabIndex = 50;
            // 
            // txtLayerQty4
            // 
            this.txtLayerQty4.Location = new System.Drawing.Point(196, 188);
            this.txtLayerQty4.Name = "txtLayerQty4";
            this.txtLayerQty4.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty4.TabIndex = 49;
            // 
            // txtLayerQty2
            // 
            this.txtLayerQty2.Location = new System.Drawing.Point(196, 104);
            this.txtLayerQty2.Name = "txtLayerQty2";
            this.txtLayerQty2.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty2.TabIndex = 48;
            // 
            // txtLayerQty3
            // 
            this.txtLayerQty3.Location = new System.Drawing.Point(196, 144);
            this.txtLayerQty3.Name = "txtLayerQty3";
            this.txtLayerQty3.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty3.TabIndex = 47;
            // 
            // txtLayerQty1
            // 
            this.txtLayerQty1.Location = new System.Drawing.Point(196, 60);
            this.txtLayerQty1.Name = "txtLayerQty1";
            this.txtLayerQty1.Size = new System.Drawing.Size(90, 20);
            this.txtLayerQty1.TabIndex = 45;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(207, 37);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(46, 13);
            this.lblQty.TabIndex = 46;
            this.lblQty.Text = "Quantity";
            // 
            // txtLayerBotDist8
            // 
            this.txtLayerBotDist8.Location = new System.Drawing.Point(320, 356);
            this.txtLayerBotDist8.Name = "txtLayerBotDist8";
            this.txtLayerBotDist8.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist8.TabIndex = 42;
            // 
            // cmbLayerDia8
            // 
            this.cmbLayerDia8.FormattingEnabled = true;
            this.cmbLayerDia8.Location = new System.Drawing.Point(94, 356);
            this.cmbLayerDia8.Name = "cmbLayerDia8";
            this.cmbLayerDia8.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia8.TabIndex = 43;
            // 
            // lblLayer8
            // 
            this.lblLayer8.AutoSize = true;
            this.lblLayer8.Location = new System.Drawing.Point(26, 364);
            this.lblLayer8.Name = "lblLayer8";
            this.lblLayer8.Size = new System.Drawing.Size(42, 13);
            this.lblLayer8.TabIndex = 44;
            this.lblLayer8.Text = "Layer 8";
            // 
            // txtLayerBotDist9
            // 
            this.txtLayerBotDist9.Location = new System.Drawing.Point(320, 396);
            this.txtLayerBotDist9.Name = "txtLayerBotDist9";
            this.txtLayerBotDist9.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist9.TabIndex = 39;
            // 
            // cmbLayerDia9
            // 
            this.cmbLayerDia9.FormattingEnabled = true;
            this.cmbLayerDia9.Location = new System.Drawing.Point(94, 396);
            this.cmbLayerDia9.Name = "cmbLayerDia9";
            this.cmbLayerDia9.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia9.TabIndex = 40;
            // 
            // lblLayer9
            // 
            this.lblLayer9.AutoSize = true;
            this.lblLayer9.Location = new System.Drawing.Point(26, 404);
            this.lblLayer9.Name = "lblLayer9";
            this.lblLayer9.Size = new System.Drawing.Size(42, 13);
            this.lblLayer9.TabIndex = 41;
            this.lblLayer9.Text = "Layer 9";
            // 
            // txtLayerBotDist7
            // 
            this.txtLayerBotDist7.Location = new System.Drawing.Point(320, 312);
            this.txtLayerBotDist7.Name = "txtLayerBotDist7";
            this.txtLayerBotDist7.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist7.TabIndex = 36;
            // 
            // cmbLayerDia7
            // 
            this.cmbLayerDia7.FormattingEnabled = true;
            this.cmbLayerDia7.Location = new System.Drawing.Point(94, 312);
            this.cmbLayerDia7.Name = "cmbLayerDia7";
            this.cmbLayerDia7.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia7.TabIndex = 37;
            // 
            // lblLayer7
            // 
            this.lblLayer7.AutoSize = true;
            this.lblLayer7.Location = new System.Drawing.Point(26, 320);
            this.lblLayer7.Name = "lblLayer7";
            this.lblLayer7.Size = new System.Drawing.Size(42, 13);
            this.lblLayer7.TabIndex = 38;
            this.lblLayer7.Text = "Layer 7";
            // 
            // txtLayerBotDist5
            // 
            this.txtLayerBotDist5.Location = new System.Drawing.Point(320, 232);
            this.txtLayerBotDist5.Name = "txtLayerBotDist5";
            this.txtLayerBotDist5.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist5.TabIndex = 33;
            // 
            // cmbLayerDia5
            // 
            this.cmbLayerDia5.FormattingEnabled = true;
            this.cmbLayerDia5.Location = new System.Drawing.Point(94, 232);
            this.cmbLayerDia5.Name = "cmbLayerDia5";
            this.cmbLayerDia5.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia5.TabIndex = 34;
            // 
            // lblLayer5
            // 
            this.lblLayer5.AutoSize = true;
            this.lblLayer5.Location = new System.Drawing.Point(26, 240);
            this.lblLayer5.Name = "lblLayer5";
            this.lblLayer5.Size = new System.Drawing.Size(42, 13);
            this.lblLayer5.TabIndex = 35;
            this.lblLayer5.Text = "Layer 5";
            // 
            // txtLayerBotDist6
            // 
            this.txtLayerBotDist6.Location = new System.Drawing.Point(320, 272);
            this.txtLayerBotDist6.Name = "txtLayerBotDist6";
            this.txtLayerBotDist6.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist6.TabIndex = 30;
            // 
            // cmbLayerDia6
            // 
            this.cmbLayerDia6.FormattingEnabled = true;
            this.cmbLayerDia6.Location = new System.Drawing.Point(94, 272);
            this.cmbLayerDia6.Name = "cmbLayerDia6";
            this.cmbLayerDia6.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia6.TabIndex = 31;
            // 
            // lblLayer6
            // 
            this.lblLayer6.AutoSize = true;
            this.lblLayer6.Location = new System.Drawing.Point(26, 280);
            this.lblLayer6.Name = "lblLayer6";
            this.lblLayer6.Size = new System.Drawing.Size(42, 13);
            this.lblLayer6.TabIndex = 32;
            this.lblLayer6.Text = "Layer 6";
            // 
            // txtLayerBotDist4
            // 
            this.txtLayerBotDist4.Location = new System.Drawing.Point(320, 188);
            this.txtLayerBotDist4.Name = "txtLayerBotDist4";
            this.txtLayerBotDist4.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist4.TabIndex = 27;
            // 
            // cmbLayerDia4
            // 
            this.cmbLayerDia4.FormattingEnabled = true;
            this.cmbLayerDia4.Location = new System.Drawing.Point(94, 188);
            this.cmbLayerDia4.Name = "cmbLayerDia4";
            this.cmbLayerDia4.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia4.TabIndex = 28;
            // 
            // lblLayer4
            // 
            this.lblLayer4.AutoSize = true;
            this.lblLayer4.Location = new System.Drawing.Point(26, 196);
            this.lblLayer4.Name = "lblLayer4";
            this.lblLayer4.Size = new System.Drawing.Size(42, 13);
            this.lblLayer4.TabIndex = 29;
            this.lblLayer4.Text = "Layer 4";
            // 
            // txtLayerBotDist2
            // 
            this.txtLayerBotDist2.Location = new System.Drawing.Point(320, 104);
            this.txtLayerBotDist2.Name = "txtLayerBotDist2";
            this.txtLayerBotDist2.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist2.TabIndex = 24;
            // 
            // cmbLayerDia2
            // 
            this.cmbLayerDia2.FormattingEnabled = true;
            this.cmbLayerDia2.Location = new System.Drawing.Point(94, 104);
            this.cmbLayerDia2.Name = "cmbLayerDia2";
            this.cmbLayerDia2.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia2.TabIndex = 25;
            // 
            // lblLayer2
            // 
            this.lblLayer2.AutoSize = true;
            this.lblLayer2.Location = new System.Drawing.Point(26, 112);
            this.lblLayer2.Name = "lblLayer2";
            this.lblLayer2.Size = new System.Drawing.Size(42, 13);
            this.lblLayer2.TabIndex = 26;
            this.lblLayer2.Text = "Layer 2";
            // 
            // txtLayerBotDist3
            // 
            this.txtLayerBotDist3.Location = new System.Drawing.Point(320, 144);
            this.txtLayerBotDist3.Name = "txtLayerBotDist3";
            this.txtLayerBotDist3.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist3.TabIndex = 21;
            // 
            // cmbLayerDia3
            // 
            this.cmbLayerDia3.FormattingEnabled = true;
            this.cmbLayerDia3.Location = new System.Drawing.Point(94, 144);
            this.cmbLayerDia3.Name = "cmbLayerDia3";
            this.cmbLayerDia3.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia3.TabIndex = 22;
            // 
            // lblLayer3
            // 
            this.lblLayer3.AutoSize = true;
            this.lblLayer3.Location = new System.Drawing.Point(26, 152);
            this.lblLayer3.Name = "lblLayer3";
            this.lblLayer3.Size = new System.Drawing.Size(42, 13);
            this.lblLayer3.TabIndex = 23;
            this.lblLayer3.Text = "Layer 3";
            // 
            // txtLayerBotDist1
            // 
            this.txtLayerBotDist1.Location = new System.Drawing.Point(320, 60);
            this.txtLayerBotDist1.Name = "txtLayerBotDist1";
            this.txtLayerBotDist1.Size = new System.Drawing.Size(90, 20);
            this.txtLayerBotDist1.TabIndex = 9;
            // 
            // cmbLayerDia1
            // 
            this.cmbLayerDia1.FormattingEnabled = true;
            this.cmbLayerDia1.Location = new System.Drawing.Point(94, 60);
            this.cmbLayerDia1.Name = "cmbLayerDia1";
            this.cmbLayerDia1.Size = new System.Drawing.Size(71, 21);
            this.cmbLayerDia1.TabIndex = 10;
            // 
            // lblLayer1
            // 
            this.lblLayer1.AutoSize = true;
            this.lblLayer1.Location = new System.Drawing.Point(26, 68);
            this.lblLayer1.Name = "lblLayer1";
            this.lblLayer1.Size = new System.Drawing.Size(42, 13);
            this.lblLayer1.TabIndex = 11;
            this.lblLayer1.Text = "Layer 1";
            // 
            // lblDistFromBot
            // 
            this.lblDistFromBot.AutoSize = true;
            this.lblDistFromBot.Location = new System.Drawing.Point(285, 37);
            this.lblDistFromBot.Name = "lblDistFromBot";
            this.lblDistFromBot.Size = new System.Drawing.Size(136, 13);
            this.lblDistFromBot.TabIndex = 9;
            this.lblDistFromBot.Text = "Distance From Bottom (mm)";
            // 
            // lblDiam
            // 
            this.lblDiam.AutoSize = true;
            this.lblDiam.Location = new System.Drawing.Point(91, 37);
            this.lblDiam.Name = "lblDiam";
            this.lblDiam.Size = new System.Drawing.Size(74, 13);
            this.lblDiam.TabIndex = 10;
            this.lblDiam.Text = "Diameter (mm)";
            // 
            // btnDeleteRebarLayer
            // 
            this.btnDeleteRebarLayer.Location = new System.Drawing.Point(285, 533);
            this.btnDeleteRebarLayer.Name = "btnDeleteRebarLayer";
            this.btnDeleteRebarLayer.Size = new System.Drawing.Size(138, 29);
            this.btnDeleteRebarLayer.TabIndex = 1;
            this.btnDeleteRebarLayer.Text = "Delete Rebar Layer";
            this.btnDeleteRebarLayer.UseVisualStyleBackColor = true;
            // 
            // btnAddRebarLayer
            // 
            this.btnAddRebarLayer.Location = new System.Drawing.Point(140, 533);
            this.btnAddRebarLayer.Name = "btnAddRebarLayer";
            this.btnAddRebarLayer.Size = new System.Drawing.Size(139, 29);
            this.btnAddRebarLayer.TabIndex = 0;
            this.btnAddRebarLayer.Text = "Add Rebar Layer";
            this.btnAddRebarLayer.UseVisualStyleBackColor = true;
            // 
            // grpXSecDim
            // 
            this.grpXSecDim.Controls.Add(this.label3);
            this.grpXSecDim.Controls.Add(this.label2);
            this.grpXSecDim.Controls.Add(this.label1);
            this.grpXSecDim.Controls.Add(this.txtClearCover);
            this.grpXSecDim.Controls.Add(this.txtXSecWidth);
            this.grpXSecDim.Controls.Add(this.txtXSecHeight);
            this.grpXSecDim.Controls.Add(this.lblClearCover);
            this.grpXSecDim.Controls.Add(this.lblXSecWidth);
            this.grpXSecDim.Controls.Add(this.lblXSecHeight);
            this.grpXSecDim.Location = new System.Drawing.Point(12, 12);
            this.grpXSecDim.Name = "grpXSecDim";
            this.grpXSecDim.Size = new System.Drawing.Size(429, 154);
            this.grpXSecDim.TabIndex = 3;
            this.grpXSecDim.TabStop = false;
            this.grpXSecDim.Text = "Cross-Section Dimensions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "mm";
            // 
            // txtClearCover
            // 
            this.txtClearCover.Location = new System.Drawing.Point(124, 108);
            this.txtClearCover.Name = "txtClearCover";
            this.txtClearCover.Size = new System.Drawing.Size(100, 20);
            this.txtClearCover.TabIndex = 5;
            // 
            // txtXSecWidth
            // 
            this.txtXSecWidth.Location = new System.Drawing.Point(124, 74);
            this.txtXSecWidth.Name = "txtXSecWidth";
            this.txtXSecWidth.Size = new System.Drawing.Size(100, 20);
            this.txtXSecWidth.TabIndex = 4;
            // 
            // txtXSecHeight
            // 
            this.txtXSecHeight.Location = new System.Drawing.Point(124, 36);
            this.txtXSecHeight.Name = "txtXSecHeight";
            this.txtXSecHeight.Size = new System.Drawing.Size(100, 20);
            this.txtXSecHeight.TabIndex = 3;
            // 
            // lblClearCover
            // 
            this.lblClearCover.AutoSize = true;
            this.lblClearCover.Location = new System.Drawing.Point(44, 111);
            this.lblClearCover.Name = "lblClearCover";
            this.lblClearCover.Size = new System.Drawing.Size(68, 13);
            this.lblClearCover.TabIndex = 2;
            this.lblClearCover.Text = "Clear Cover :";
            // 
            // lblXSecWidth
            // 
            this.lblXSecWidth.AutoSize = true;
            this.lblXSecWidth.Location = new System.Drawing.Point(6, 74);
            this.lblXSecWidth.Name = "lblXSecWidth";
            this.lblXSecWidth.Size = new System.Drawing.Size(109, 13);
            this.lblXSecWidth.TabIndex = 1;
            this.lblXSecWidth.Text = "Cross Section Width :";
            // 
            // lblXSecHeight
            // 
            this.lblXSecHeight.AutoSize = true;
            this.lblXSecHeight.Location = new System.Drawing.Point(6, 36);
            this.lblXSecHeight.Name = "lblXSecHeight";
            this.lblXSecHeight.Size = new System.Drawing.Size(112, 13);
            this.lblXSecHeight.TabIndex = 0;
            this.lblXSecHeight.Text = "Cross Section Height :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMomentCapacity);
            this.groupBox1.Controls.Add(this.txtAxialLoadRatio);
            this.groupBox1.Controls.Add(this.txtAxilLoadCapacity);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.graphMK);
            this.groupBox1.Location = new System.Drawing.Point(447, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 890);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // txtMomentCapacity
            // 
            this.txtMomentCapacity.Location = new System.Drawing.Point(289, 828);
            this.txtMomentCapacity.Name = "txtMomentCapacity";
            this.txtMomentCapacity.Size = new System.Drawing.Size(90, 20);
            this.txtMomentCapacity.TabIndex = 52;
            // 
            // txtAxialLoadRatio
            // 
            this.txtAxialLoadRatio.Location = new System.Drawing.Point(289, 793);
            this.txtAxialLoadRatio.Name = "txtAxialLoadRatio";
            this.txtAxialLoadRatio.Size = new System.Drawing.Size(90, 20);
            this.txtAxialLoadRatio.TabIndex = 51;
            // 
            // txtAxilLoadCapacity
            // 
            this.txtAxilLoadCapacity.Location = new System.Drawing.Point(289, 763);
            this.txtAxilLoadCapacity.Name = "txtAxilLoadCapacity";
            this.txtAxilLoadCapacity.Size = new System.Drawing.Size(90, 20);
            this.txtAxilLoadCapacity.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 800);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(262, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Ratio of Applied Axial Load to Axial Load Capacity  (%)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 835);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Moment Capacity (kNm)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(148, 770);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Axial Load Capacity (kN)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1438, 913);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpRebars);
            this.Controls.Add(this.grpMaterialDefinitons);
            this.Controls.Add(this.grpXSecDim);
            this.MaximumSize = new System.Drawing.Size(1454, 952);
            this.MinimumSize = new System.Drawing.Size(1454, 952);
            this.Name = "MainForm";
            this.Text = "Moment Curvature Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.graphMK)).EndInit();
            this.grpMaterialDefinitons.ResumeLayout(false);
            this.grpMaterialDefinitons.PerformLayout();
            this.grpRebars.ResumeLayout(false);
            this.grpRebars.PerformLayout();
            this.grpXSecDim.ResumeLayout(false);
            this.grpXSecDim.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpXSecDim;
        private System.Windows.Forms.TextBox txtClearCover;
        private System.Windows.Forms.TextBox txtXSecWidth;
        private System.Windows.Forms.TextBox txtXSecHeight;
        private System.Windows.Forms.Label lblClearCover;
        private System.Windows.Forms.Label lblXSecWidth;
        private System.Windows.Forms.Label lblXSecHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpRebars;
        private System.Windows.Forms.TextBox txtLayerBotDist8;
        private System.Windows.Forms.ComboBox cmbLayerDia8;
        private System.Windows.Forms.Label lblLayer8;
        private System.Windows.Forms.TextBox txtLayerBotDist9;
        private System.Windows.Forms.ComboBox cmbLayerDia9;
        private System.Windows.Forms.Label lblLayer9;
        private System.Windows.Forms.ComboBox cmbLayerDia7;
        private System.Windows.Forms.Label lblLayer7;
        private System.Windows.Forms.TextBox txtLayerBotDist5;
        private System.Windows.Forms.ComboBox cmbLayerDia5;
        private System.Windows.Forms.Label lblLayer5;
        private System.Windows.Forms.TextBox txtLayerBotDist6;
        private System.Windows.Forms.ComboBox cmbLayerDia6;
        private System.Windows.Forms.Label lblLayer6;
        private System.Windows.Forms.TextBox txtLayerBotDist4;
        private System.Windows.Forms.ComboBox cmbLayerDia4;
        private System.Windows.Forms.Label lblLayer4;
        private System.Windows.Forms.TextBox txtLayerBotDist2;
        private System.Windows.Forms.ComboBox cmbLayerDia2;
        private System.Windows.Forms.Label lblLayer2;
        private System.Windows.Forms.TextBox txtLayerBotDist3;
        private System.Windows.Forms.ComboBox cmbLayerDia3;
        private System.Windows.Forms.Label lblLayer3;
        private System.Windows.Forms.TextBox txtLayerBotDist1;
        private System.Windows.Forms.ComboBox cmbLayerDia1;
        private System.Windows.Forms.Label lblLayer1;
        private System.Windows.Forms.Label lblDistFromBot;
        private System.Windows.Forms.Label lblDiam;
        private System.Windows.Forms.Button btnDeleteRebarLayer;
        private System.Windows.Forms.Button btnAddRebarLayer;
        private System.Windows.Forms.TextBox txtLayerQty8;
        private System.Windows.Forms.TextBox txtLayerQty9;
        private System.Windows.Forms.TextBox txtLayerQty7;
        private System.Windows.Forms.TextBox txtLayerQty5;
        private System.Windows.Forms.TextBox txtLayerQty6;
        private System.Windows.Forms.TextBox txtLayerQty4;
        private System.Windows.Forms.TextBox txtLayerQty2;
        private System.Windows.Forms.TextBox txtLayerQty3;
        private System.Windows.Forms.TextBox txtLayerQty1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtLayerBotDist7;
        private System.Windows.Forms.GroupBox grpMaterialDefinitons;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSteelGrade;
        private System.Windows.Forms.TextBox txtConcreteGrade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkConfined;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphMK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransverseSteelGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStirrupSpacing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStirrupDia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMomentCapacity;
        private System.Windows.Forms.TextBox txtAxialLoadRatio;
        private System.Windows.Forms.TextBox txtAxilLoadCapacity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}

