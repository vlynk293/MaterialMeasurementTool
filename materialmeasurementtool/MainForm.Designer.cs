namespace MaterialMeasurementTool
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabMeasure = new MetroFramework.Controls.MetroTabPage();
            this.txtParcelCode = new System.Windows.Forms.TextBox();
            this.cbxMeasureType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.cbxMeasureUnit = new MetroFramework.Controls.MetroComboBox();
            this.txtMeasureQuantity = new System.Windows.Forms.TextBox();
            this.lblMeasureQuantity = new MetroFramework.Controls.MetroLabel();
            this.txtParcelCodePrefix = new System.Windows.Forms.TextBox();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWeightUnit = new System.Windows.Forms.TextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtConstraintWeight = new System.Windows.Forms.TextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.btnConfirmMaterial = new System.Windows.Forms.Button();
            this.btnCancelItem = new System.Windows.Forms.Button();
            this.txtCurrentMaterial = new System.Windows.Forms.TextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtMaterialStatus = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtMeasurementDigit = new System.Windows.Forms.TextBox();
            this.cbxRev = new MetroFramework.Controls.MetroComboBox();
            this.comboBoxItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbxStage = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnCancelComposition = new System.Windows.Forms.Button();
            this.btnFinishMeasurement = new System.Windows.Forms.Button();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.grvMaterialTable = new MetroFramework.Controls.MetroGrid();
            this.MaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalConstraintWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeightUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxComposition = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabReport = new MetroFramework.Controls.MetroTabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnExportProductionResultReport = new MetroFramework.Controls.MetroButton();
            this.cbxYearProductionResult = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.cbxMonthProductionResult = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnExportMaterialReport = new MetroFramework.Controls.MetroButton();
            this.cbxYearExport = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel27 = new MetroFramework.Controls.MetroLabel();
            this.cbxMonthExport = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel28 = new MetroFramework.Controls.MetroLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnExportMonthReport = new MetroFramework.Controls.MetroButton();
            this.cbxYearInventory = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.cbxMonthInventory = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tabManagement = new MetroFramework.Controls.MetroTabPage();
            this.cbxActiveRevForEdit = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblImportInventoryExcelPath = new MetroFramework.Controls.MetroLabel();
            this.lblRemainInventoryExcelPath = new MetroFramework.Controls.MetroLabel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxErrorFiles = new System.Windows.Forms.ListBox();
            this.lblFilename = new MetroFramework.Controls.MetroLabel();
            this.btnImportComposition = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxStageForEdit = new MetroFramework.Controls.MetroComboBox();
            this.cbxCompositionForEdit = new System.Windows.Forms.ComboBox();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.cbxRevisionForEdit = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.btnCancelCompositionEdit = new System.Windows.Forms.Button();
            this.btnSaveCompositionEdit = new System.Windows.Forms.Button();
            this.grvMaterialForEdit = new MetroFramework.Controls.MetroGrid();
            this.colCompositionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelMaterialEdit = new System.Windows.Forms.Button();
            this.cbxMaterialForEdit = new System.Windows.Forms.ComboBox();
            this.txtWeightUnitForEdit = new System.Windows.Forms.TextBox();
            this.btnRemoveMaterial = new System.Windows.Forms.Button();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.txtConstraintWeightForEdit = new System.Windows.Forms.TextBox();
            this.lblConstraintWeightForEdit = new MetroFramework.Controls.MetroLabel();
            this.btnSaveMaterialEdit = new System.Windows.Forms.Button();
            this.tabSetting = new MetroFramework.Controls.MetroTabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.grvAccount = new MetroFramework.Controls.MetroGrid();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxNewAccRole = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel30 = new MetroFramework.Controls.MetroLabel();
            this.btnCancelAddingAccount = new MetroFramework.Controls.MetroButton();
            this.txtNewAccPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnAddAccount = new MetroFramework.Controls.MetroButton();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel29 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel31 = new MetroFramework.Controls.MetroLabel();
            this.txtNewAccConfirmPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtNewAccUserName = new MetroFramework.Controls.MetroTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.metroLabel32 = new MetroFramework.Controls.MetroLabel();
            this.btnCancelScaleSetting = new MetroFramework.Controls.MetroButton();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.txtWeightCapacity = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.btnSaveScaleSetting = new MetroFramework.Controls.MetroButton();
            this.txtWeightDeviation = new MetroFramework.Controls.MetroTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCancelAccount = new MetroFramework.Controls.MetroButton();
            this.txtCurrentPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnSaveAccount = new MetroFramework.Controls.MetroButton();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.txtConfirmingPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtNewPassword = new MetroFramework.Controls.MetroTextBox();
            this.loadingBar = new MetroFramework.Controls.MetroProgressBar();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkSignOut = new MetroFramework.Controls.MetroLink();
            this.metroLabel33 = new MetroFramework.Controls.MetroLabel();
            this.panelTabControl.SuspendLayout();
            this.tabMeasure.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterialTable)).BeginInit();
            this.tabReport.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabManagement.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterialForEdit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccount)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTabControl
            // 
            this.panelTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.panelTabControl.Controls.Add(this.tabMeasure);
            this.panelTabControl.Controls.Add(this.tabReport);
            this.panelTabControl.Controls.Add(this.tabManagement);
            this.panelTabControl.Controls.Add(this.tabSetting);
            this.panelTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabControl.Location = new System.Drawing.Point(20, 60);
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.SelectedIndex = 2;
            this.panelTabControl.Size = new System.Drawing.Size(960, 470);
            this.panelTabControl.TabIndex = 0;
            this.panelTabControl.UseSelectable = true;
            this.panelTabControl.SelectedIndexChanged += new System.EventHandler(this.panelTabControl_SelectedIndexChanged);
            this.panelTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.panelTabControl_Selecting);
            // 
            // tabMeasure
            // 
            this.tabMeasure.Controls.Add(this.txtParcelCode);
            this.tabMeasure.Controls.Add(this.cbxMeasureType);
            this.tabMeasure.Controls.Add(this.metroLabel18);
            this.tabMeasure.Controls.Add(this.cbxMeasureUnit);
            this.tabMeasure.Controls.Add(this.txtMeasureQuantity);
            this.tabMeasure.Controls.Add(this.lblMeasureQuantity);
            this.tabMeasure.Controls.Add(this.txtParcelCodePrefix);
            this.tabMeasure.Controls.Add(this.metroLabel16);
            this.tabMeasure.Controls.Add(this.groupBox1);
            this.tabMeasure.Controls.Add(this.cbxRev);
            this.tabMeasure.Controls.Add(this.metroLabel3);
            this.tabMeasure.Controls.Add(this.cbxStage);
            this.tabMeasure.Controls.Add(this.metroLabel6);
            this.tabMeasure.Controls.Add(this.btnCancelComposition);
            this.tabMeasure.Controls.Add(this.btnFinishMeasurement);
            this.tabMeasure.Controls.Add(this.metroLabel2);
            this.tabMeasure.Controls.Add(this.grvMaterialTable);
            this.tabMeasure.Controls.Add(this.cbxComposition);
            this.tabMeasure.Controls.Add(this.metroLabel1);
            this.tabMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMeasure.HorizontalScrollbarBarColor = true;
            this.tabMeasure.HorizontalScrollbarHighlightOnWheel = false;
            this.tabMeasure.HorizontalScrollbarSize = 10;
            this.tabMeasure.Location = new System.Drawing.Point(4, 41);
            this.tabMeasure.Name = "tabMeasure";
            this.tabMeasure.Padding = new System.Windows.Forms.Padding(20, 10, 20, 30);
            this.tabMeasure.Size = new System.Drawing.Size(952, 425);
            this.tabMeasure.TabIndex = 0;
            this.tabMeasure.Text = "Phối liệu";
            this.tabMeasure.VerticalScrollbarBarColor = true;
            this.tabMeasure.VerticalScrollbarHighlightOnWheel = false;
            this.tabMeasure.VerticalScrollbarSize = 10;
            // 
            // txtParcelCode
            // 
            this.txtParcelCode.BackColor = System.Drawing.Color.White;
            this.txtParcelCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParcelCode.Location = new System.Drawing.Point(502, 38);
            this.txtParcelCode.Name = "txtParcelCode";
            this.txtParcelCode.Size = new System.Drawing.Size(52, 29);
            this.txtParcelCode.TabIndex = 31;
            this.txtParcelCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParcelCode_KeyPress);
            this.txtParcelCode.Leave += new System.EventHandler(this.txtParcelCode_Leave);
            // 
            // cbxMeasureType
            // 
            this.cbxMeasureType.FormattingEnabled = true;
            this.cbxMeasureType.ItemHeight = 23;
            this.cbxMeasureType.Items.AddRange(new object[] {
            "Cân thực",
            "Cân thí nghiệm"});
            this.cbxMeasureType.Location = new System.Drawing.Point(784, 38);
            this.cbxMeasureType.Name = "cbxMeasureType";
            this.cbxMeasureType.Size = new System.Drawing.Size(145, 29);
            this.cbxMeasureType.TabIndex = 30;
            this.cbxMeasureType.UseSelectable = true;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.Location = new System.Drawing.Point(784, 10);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(44, 25);
            this.metroLabel18.TabIndex = 29;
            this.metroLabel18.Text = "Loại";
            // 
            // cbxMeasureUnit
            // 
            this.cbxMeasureUnit.FormattingEnabled = true;
            this.cbxMeasureUnit.ItemHeight = 23;
            this.cbxMeasureUnit.Items.AddRange(new object[] {
            "Cây",
            "Kg"});
            this.cbxMeasureUnit.Location = new System.Drawing.Point(699, 38);
            this.cbxMeasureUnit.Name = "cbxMeasureUnit";
            this.cbxMeasureUnit.Size = new System.Drawing.Size(79, 29);
            this.cbxMeasureUnit.TabIndex = 28;
            this.cbxMeasureUnit.UseSelectable = true;
            this.cbxMeasureUnit.SelectedIndexChanged += new System.EventHandler(this.cbxMeasureUnit_SelectedIndexChanged);
            // 
            // txtMeasureQuantity
            // 
            this.txtMeasureQuantity.BackColor = System.Drawing.Color.White;
            this.txtMeasureQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeasureQuantity.Location = new System.Drawing.Point(608, 38);
            this.txtMeasureQuantity.Name = "txtMeasureQuantity";
            this.txtMeasureQuantity.Size = new System.Drawing.Size(85, 29);
            this.txtMeasureQuantity.TabIndex = 27;
            this.txtMeasureQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeasureQuantity_KeyPress);
            this.txtMeasureQuantity.Leave += new System.EventHandler(this.txtMeasureQuantity_Leave);
            this.txtMeasureQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtMeasureQuantity_Validating);
            // 
            // lblMeasureQuantity
            // 
            this.lblMeasureQuantity.AutoSize = true;
            this.lblMeasureQuantity.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMeasureQuantity.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMeasureQuantity.Location = new System.Drawing.Point(608, 10);
            this.lblMeasureQuantity.Name = "lblMeasureQuantity";
            this.lblMeasureQuantity.Size = new System.Drawing.Size(85, 25);
            this.lblMeasureQuantity.TabIndex = 26;
            this.lblMeasureQuantity.Text = "Số lượng";
            // 
            // txtParcelCodePrefix
            // 
            this.txtParcelCodePrefix.BackColor = System.Drawing.Color.White;
            this.txtParcelCodePrefix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParcelCodePrefix.Location = new System.Drawing.Point(469, 38);
            this.txtParcelCodePrefix.Name = "txtParcelCodePrefix";
            this.txtParcelCodePrefix.ReadOnly = true;
            this.txtParcelCodePrefix.Size = new System.Drawing.Size(27, 29);
            this.txtParcelCodePrefix.TabIndex = 25;
            this.txtParcelCodePrefix.Text = "M";
            this.txtParcelCodePrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Location = new System.Drawing.Point(469, 10);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(57, 25);
            this.metroLabel16.TabIndex = 24;
            this.metroLabel16.Text = "Mã lô";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtWeightUnit);
            this.groupBox1.Controls.Add(this.metroLabel9);
            this.groupBox1.Controls.Add(this.txtConstraintWeight);
            this.groupBox1.Controls.Add(this.metroLabel8);
            this.groupBox1.Controls.Add(this.btnConfirmMaterial);
            this.groupBox1.Controls.Add(this.btnCancelItem);
            this.groupBox1.Controls.Add(this.txtCurrentMaterial);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.txtMaterialStatus);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.txtMeasurementDigit);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(608, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.groupBox1.Size = new System.Drawing.Size(321, 314);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cân phối liệu";
            // 
            // txtWeightUnit
            // 
            this.txtWeightUnit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightUnit.Location = new System.Drawing.Point(223, 224);
            this.txtWeightUnit.Name = "txtWeightUnit";
            this.txtWeightUnit.ReadOnly = true;
            this.txtWeightUnit.Size = new System.Drawing.Size(75, 33);
            this.txtWeightUnit.TabIndex = 22;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(223, 202);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(49, 19);
            this.metroLabel9.TabIndex = 21;
            this.metroLabel9.Text = "Đơn vị";
            // 
            // txtConstraintWeight
            // 
            this.txtConstraintWeight.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstraintWeight.Location = new System.Drawing.Point(23, 224);
            this.txtConstraintWeight.Name = "txtConstraintWeight";
            this.txtConstraintWeight.ReadOnly = true;
            this.txtConstraintWeight.Size = new System.Drawing.Size(194, 33);
            this.txtConstraintWeight.TabIndex = 20;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(23, 202);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(143, 19);
            this.metroLabel8.TabIndex = 19;
            this.metroLabel8.Text = "Trọng lượng mẻ luyện";
            // 
            // btnConfirmMaterial
            // 
            this.btnConfirmMaterial.BackColor = System.Drawing.Color.LightBlue;
            this.btnConfirmMaterial.FlatAppearance.BorderSize = 0;
            this.btnConfirmMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmMaterial.Location = new System.Drawing.Point(190, 273);
            this.btnConfirmMaterial.Name = "btnConfirmMaterial";
            this.btnConfirmMaterial.Size = new System.Drawing.Size(108, 28);
            this.btnConfirmMaterial.TabIndex = 11;
            this.btnConfirmMaterial.Text = "Xác nhận";
            this.btnConfirmMaterial.UseVisualStyleBackColor = false;
            this.btnConfirmMaterial.Click += new System.EventHandler(this.btnConfirmMaterial_Click);
            // 
            // btnCancelItem
            // 
            this.btnCancelItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelItem.FlatAppearance.BorderSize = 0;
            this.btnCancelItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelItem.Location = new System.Drawing.Point(77, 273);
            this.btnCancelItem.Name = "btnCancelItem";
            this.btnCancelItem.Size = new System.Drawing.Size(107, 28);
            this.btnCancelItem.TabIndex = 12;
            this.btnCancelItem.Text = "Hủy kết quả";
            this.btnCancelItem.UseVisualStyleBackColor = false;
            this.btnCancelItem.Click += new System.EventHandler(this.btnCancelItem_Click);
            // 
            // txtCurrentMaterial
            // 
            this.txtCurrentMaterial.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentMaterial.Location = new System.Drawing.Point(23, 166);
            this.txtCurrentMaterial.Name = "txtCurrentMaterial";
            this.txtCurrentMaterial.ReadOnly = true;
            this.txtCurrentMaterial.Size = new System.Drawing.Size(275, 33);
            this.txtCurrentMaterial.TabIndex = 18;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(23, 144);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(131, 19);
            this.metroLabel7.TabIndex = 17;
            this.metroLabel7.Text = "Nguyên liệu hiện tại";
            // 
            // txtMaterialStatus
            // 
            this.txtMaterialStatus.BackColor = System.Drawing.Color.White;
            this.txtMaterialStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialStatus.ForeColor = System.Drawing.Color.Red;
            this.txtMaterialStatus.Location = new System.Drawing.Point(23, 125);
            this.txtMaterialStatus.Name = "txtMaterialStatus";
            this.txtMaterialStatus.ReadOnly = true;
            this.txtMaterialStatus.Size = new System.Drawing.Size(275, 16);
            this.txtMaterialStatus.TabIndex = 16;
            this.txtMaterialStatus.Text = "chưa thành công";
            this.txtMaterialStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaterialStatus.TextChanged += new System.EventHandler(this.txtMaterialStatus_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(23, 36);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(130, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Trọng lượng thực tế";
            // 
            // txtMeasurementDigit
            // 
            this.txtMeasurementDigit.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeasurementDigit.Location = new System.Drawing.Point(23, 58);
            this.txtMeasurementDigit.Name = "txtMeasurementDigit";
            this.txtMeasurementDigit.Size = new System.Drawing.Size(275, 61);
            this.txtMeasurementDigit.TabIndex = 10;
            this.txtMeasurementDigit.Text = "0.00";
            this.txtMeasurementDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMeasurementDigit.WordWrap = false;
            this.txtMeasurementDigit.TextChanged += new System.EventHandler(this.txtMeasurementDigit_TextChanged);
            this.txtMeasurementDigit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeasurementDigit_KeyPress);
            // 
            // cbxRev
            // 
            this.cbxRev.DataSource = this.comboBoxItemBindingSource;
            this.cbxRev.DisplayMember = "Name";
            this.cbxRev.FormattingEnabled = true;
            this.cbxRev.ItemHeight = 23;
            this.cbxRev.Location = new System.Drawing.Point(187, 38);
            this.cbxRev.Name = "cbxRev";
            this.cbxRev.Size = new System.Drawing.Size(109, 29);
            this.cbxRev.TabIndex = 5;
            this.cbxRev.UseSelectable = true;
            this.cbxRev.ValueMember = "Id";
            this.cbxRev.SelectedIndexChanged += new System.EventHandler(this.cbxRev_SelectedIndexChanged);
            // 
            // comboBoxItemBindingSource
            // 
            this.comboBoxItemBindingSource.DataSource = typeof(MaterialMeasurementTool.Utility.ComboBoxItem);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(187, 10);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(109, 25);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Lần thay đổi";
            // 
            // cbxStage
            // 
            this.cbxStage.DataSource = this.comboBoxItemBindingSource;
            this.cbxStage.DisplayMember = "Name";
            this.cbxStage.FormattingEnabled = true;
            this.cbxStage.ItemHeight = 23;
            this.cbxStage.Location = new System.Drawing.Point(302, 38);
            this.cbxStage.Name = "cbxStage";
            this.cbxStage.Size = new System.Drawing.Size(161, 29);
            this.cbxStage.TabIndex = 6;
            this.cbxStage.UseSelectable = true;
            this.cbxStage.ValueMember = "Id";
            this.cbxStage.SelectedIndexChanged += new System.EventHandler(this.cbxStage_SelectedIndexChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(302, 10);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(87, 25);
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Giai đoạn";
            // 
            // btnCancelComposition
            // 
            this.btnCancelComposition.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelComposition.FlatAppearance.BorderSize = 0;
            this.btnCancelComposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelComposition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelComposition.Location = new System.Drawing.Point(325, 351);
            this.btnCancelComposition.Name = "btnCancelComposition";
            this.btnCancelComposition.Size = new System.Drawing.Size(90, 41);
            this.btnCancelComposition.TabIndex = 9;
            this.btnCancelComposition.Text = "Hủy";
            this.btnCancelComposition.UseVisualStyleBackColor = false;
            this.btnCancelComposition.Click += new System.EventHandler(this.btnCancelComposition_Click);
            // 
            // btnFinishMeasurement
            // 
            this.btnFinishMeasurement.BackColor = System.Drawing.Color.LightBlue;
            this.btnFinishMeasurement.FlatAppearance.BorderSize = 0;
            this.btnFinishMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishMeasurement.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishMeasurement.Location = new System.Drawing.Point(421, 351);
            this.btnFinishMeasurement.Name = "btnFinishMeasurement";
            this.btnFinishMeasurement.Size = new System.Drawing.Size(133, 41);
            this.btnFinishMeasurement.TabIndex = 8;
            this.btnFinishMeasurement.Text = "Hoàn tất đơn";
            this.btnFinishMeasurement.UseVisualStyleBackColor = false;
            this.btnFinishMeasurement.Click += new System.EventHandler(this.btnFinishMeasurement_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 78);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(105, 25);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Thành phần";
            // 
            // grvMaterialTable
            // 
            this.grvMaterialTable.AllowUserToAddRows = false;
            this.grvMaterialTable.AllowUserToDeleteRows = false;
            this.grvMaterialTable.AllowUserToResizeColumns = false;
            this.grvMaterialTable.AllowUserToResizeRows = false;
            this.grvMaterialTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grvMaterialTable.BackgroundColor = System.Drawing.Color.White;
            this.grvMaterialTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grvMaterialTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grvMaterialTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvMaterialTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grvMaterialTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvMaterialTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialID,
            this.colMaterialCode,
            this.colOriginalConstraintWeight,
            this.colWeight,
            this.colWeightUnit,
            this.colDone,
            this.colStatus,
            this.colRealDone,
            this.colParcelCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvMaterialTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.grvMaterialTable.EnableHeadersVisualStyles = false;
            this.grvMaterialTable.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMaterialTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grvMaterialTable.Location = new System.Drawing.Point(23, 106);
            this.grvMaterialTable.MultiSelect = false;
            this.grvMaterialTable.Name = "grvMaterialTable";
            this.grvMaterialTable.ReadOnly = true;
            this.grvMaterialTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvMaterialTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvMaterialTable.RowHeadersWidth = 20;
            this.grvMaterialTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grvMaterialTable.RowTemplate.Height = 50;
            this.grvMaterialTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvMaterialTable.Size = new System.Drawing.Size(531, 239);
            this.grvMaterialTable.TabIndex = 7;
            this.grvMaterialTable.UseCustomBackColor = true;
            this.grvMaterialTable.SelectionChanged += new System.EventHandler(this.grvMaterialTable_SelectionChanged);
            this.grvMaterialTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grvMaterialTable_KeyPress);
            // 
            // MaterialID
            // 
            this.MaterialID.HeaderText = "ID";
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.ReadOnly = true;
            this.MaterialID.Visible = false;
            // 
            // colMaterialCode
            // 
            this.colMaterialCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaterialCode.HeaderText = "Mã hóa chất";
            this.colMaterialCode.Name = "colMaterialCode";
            this.colMaterialCode.ReadOnly = true;
            // 
            // colOriginalConstraintWeight
            // 
            this.colOriginalConstraintWeight.HeaderText = "OriginalConstraintWeight";
            this.colOriginalConstraintWeight.Name = "colOriginalConstraintWeight";
            this.colOriginalConstraintWeight.ReadOnly = true;
            this.colOriginalConstraintWeight.Visible = false;
            // 
            // colWeight
            // 
            this.colWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colWeight.HeaderText = "Trọng lượng";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 113;
            // 
            // colWeightUnit
            // 
            this.colWeightUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colWeightUnit.HeaderText = "Đơn vị";
            this.colWeightUnit.Name = "colWeightUnit";
            this.colWeightUnit.ReadOnly = true;
            this.colWeightUnit.Width = 78;
            // 
            // colDone
            // 
            this.colDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colDone.HeaderText = "Đã cân";
            this.colDone.Name = "colDone";
            this.colDone.ReadOnly = true;
            this.colDone.Width = 81;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.Width = 99;
            // 
            // colRealDone
            // 
            this.colRealDone.HeaderText = "RealDone";
            this.colRealDone.Name = "colRealDone";
            this.colRealDone.ReadOnly = true;
            this.colRealDone.Visible = false;
            // 
            // colParcelCode
            // 
            this.colParcelCode.HeaderText = "ParcelCode";
            this.colParcelCode.Name = "colParcelCode";
            this.colParcelCode.ReadOnly = true;
            this.colParcelCode.Visible = false;
            // 
            // cbxComposition
            // 
            this.cbxComposition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxComposition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxComposition.DataSource = this.comboBoxItemBindingSource;
            this.cbxComposition.DisplayMember = "Name";
            this.cbxComposition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxComposition.FormattingEnabled = true;
            this.cbxComposition.Location = new System.Drawing.Point(23, 38);
            this.cbxComposition.Name = "cbxComposition";
            this.cbxComposition.Size = new System.Drawing.Size(158, 29);
            this.cbxComposition.TabIndex = 4;
            this.cbxComposition.ValueMember = "Id";
            this.cbxComposition.SelectedIndexChanged += new System.EventHandler(this.cbxComposition_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 25);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Mã đơn";
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.groupBox9);
            this.tabReport.Controls.Add(this.groupBox10);
            this.tabReport.Controls.Add(this.groupBox6);
            this.tabReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReport.HorizontalScrollbarBarColor = true;
            this.tabReport.HorizontalScrollbarHighlightOnWheel = false;
            this.tabReport.HorizontalScrollbarSize = 10;
            this.tabReport.Location = new System.Drawing.Point(4, 41);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(20);
            this.tabReport.Size = new System.Drawing.Size(952, 425);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Báo cáo";
            this.tabReport.VerticalScrollbarBarColor = true;
            this.tabReport.VerticalScrollbarHighlightOnWheel = false;
            this.tabReport.VerticalScrollbarSize = 10;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.btnExportProductionResultReport);
            this.groupBox9.Controls.Add(this.cbxYearProductionResult);
            this.groupBox9.Controls.Add(this.metroLabel23);
            this.groupBox9.Controls.Add(this.cbxMonthProductionResult);
            this.groupBox9.Controls.Add(this.metroLabel26);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(330, 23);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox9.Size = new System.Drawing.Size(290, 141);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Kết quả sản xuất";
            // 
            // btnExportProductionResultReport
            // 
            this.btnExportProductionResultReport.BackColor = System.Drawing.Color.LightBlue;
            this.btnExportProductionResultReport.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnExportProductionResultReport.Location = new System.Drawing.Point(13, 89);
            this.btnExportProductionResultReport.Name = "btnExportProductionResultReport";
            this.btnExportProductionResultReport.Size = new System.Drawing.Size(264, 39);
            this.btnExportProductionResultReport.TabIndex = 4;
            this.btnExportProductionResultReport.Text = "Xuất báo cáo";
            this.btnExportProductionResultReport.UseCustomBackColor = true;
            this.btnExportProductionResultReport.UseSelectable = true;
            this.btnExportProductionResultReport.Click += new System.EventHandler(this.btnExportProductionResultReport_Click);
            // 
            // cbxYearProductionResult
            // 
            this.cbxYearProductionResult.FormattingEnabled = true;
            this.cbxYearProductionResult.ItemHeight = 23;
            this.cbxYearProductionResult.Location = new System.Drawing.Point(181, 36);
            this.cbxYearProductionResult.Name = "cbxYearProductionResult";
            this.cbxYearProductionResult.Size = new System.Drawing.Size(96, 29);
            this.cbxYearProductionResult.TabIndex = 3;
            this.cbxYearProductionResult.UseSelectable = true;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(137, 36);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(38, 19);
            this.metroLabel23.TabIndex = 2;
            this.metroLabel23.Text = "Năm";
            // 
            // cbxMonthProductionResult
            // 
            this.cbxMonthProductionResult.FormattingEnabled = true;
            this.cbxMonthProductionResult.ItemHeight = 23;
            this.cbxMonthProductionResult.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxMonthProductionResult.Location = new System.Drawing.Point(64, 36);
            this.cbxMonthProductionResult.Name = "cbxMonthProductionResult";
            this.cbxMonthProductionResult.Size = new System.Drawing.Size(67, 29);
            this.cbxMonthProductionResult.TabIndex = 1;
            this.cbxMonthProductionResult.UseSelectable = true;
            // 
            // metroLabel26
            // 
            this.metroLabel26.AutoSize = true;
            this.metroLabel26.Location = new System.Drawing.Point(13, 36);
            this.metroLabel26.Name = "metroLabel26";
            this.metroLabel26.Size = new System.Drawing.Size(45, 19);
            this.metroLabel26.TabIndex = 0;
            this.metroLabel26.Text = "Tháng";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.btnExportMaterialReport);
            this.groupBox10.Controls.Add(this.cbxYearExport);
            this.groupBox10.Controls.Add(this.metroLabel27);
            this.groupBox10.Controls.Add(this.cbxMonthExport);
            this.groupBox10.Controls.Add(this.metroLabel28);
            this.groupBox10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(23, 23);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox10.Size = new System.Drawing.Size(290, 141);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Xuất nguyên vật liệu";
            // 
            // btnExportMaterialReport
            // 
            this.btnExportMaterialReport.BackColor = System.Drawing.Color.LightBlue;
            this.btnExportMaterialReport.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnExportMaterialReport.Location = new System.Drawing.Point(13, 89);
            this.btnExportMaterialReport.Name = "btnExportMaterialReport";
            this.btnExportMaterialReport.Size = new System.Drawing.Size(264, 39);
            this.btnExportMaterialReport.TabIndex = 4;
            this.btnExportMaterialReport.Text = "Xuất báo cáo";
            this.btnExportMaterialReport.UseCustomBackColor = true;
            this.btnExportMaterialReport.UseSelectable = true;
            this.btnExportMaterialReport.Click += new System.EventHandler(this.btnExportMaterialReport_Click);
            // 
            // cbxYearExport
            // 
            this.cbxYearExport.FormattingEnabled = true;
            this.cbxYearExport.ItemHeight = 23;
            this.cbxYearExport.Location = new System.Drawing.Point(181, 36);
            this.cbxYearExport.Name = "cbxYearExport";
            this.cbxYearExport.Size = new System.Drawing.Size(96, 29);
            this.cbxYearExport.TabIndex = 3;
            this.cbxYearExport.UseSelectable = true;
            // 
            // metroLabel27
            // 
            this.metroLabel27.AutoSize = true;
            this.metroLabel27.Location = new System.Drawing.Point(137, 36);
            this.metroLabel27.Name = "metroLabel27";
            this.metroLabel27.Size = new System.Drawing.Size(38, 19);
            this.metroLabel27.TabIndex = 2;
            this.metroLabel27.Text = "Năm";
            // 
            // cbxMonthExport
            // 
            this.cbxMonthExport.FormattingEnabled = true;
            this.cbxMonthExport.ItemHeight = 23;
            this.cbxMonthExport.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxMonthExport.Location = new System.Drawing.Point(64, 36);
            this.cbxMonthExport.Name = "cbxMonthExport";
            this.cbxMonthExport.Size = new System.Drawing.Size(67, 29);
            this.cbxMonthExport.TabIndex = 1;
            this.cbxMonthExport.UseSelectable = true;
            // 
            // metroLabel28
            // 
            this.metroLabel28.AutoSize = true;
            this.metroLabel28.Location = new System.Drawing.Point(13, 36);
            this.metroLabel28.Name = "metroLabel28";
            this.metroLabel28.Size = new System.Drawing.Size(45, 19);
            this.metroLabel28.TabIndex = 0;
            this.metroLabel28.Text = "Tháng";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.btnExportMonthReport);
            this.groupBox6.Controls.Add(this.cbxYearInventory);
            this.groupBox6.Controls.Add(this.metroLabel19);
            this.groupBox6.Controls.Add(this.cbxMonthInventory);
            this.groupBox6.Controls.Add(this.metroLabel4);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(639, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox6.Size = new System.Drawing.Size(290, 141);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Xuất nhập tồn";
            // 
            // btnExportMonthReport
            // 
            this.btnExportMonthReport.BackColor = System.Drawing.Color.LightBlue;
            this.btnExportMonthReport.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnExportMonthReport.Location = new System.Drawing.Point(13, 89);
            this.btnExportMonthReport.Name = "btnExportMonthReport";
            this.btnExportMonthReport.Size = new System.Drawing.Size(264, 39);
            this.btnExportMonthReport.TabIndex = 4;
            this.btnExportMonthReport.Text = "Xuất báo cáo";
            this.btnExportMonthReport.UseCustomBackColor = true;
            this.btnExportMonthReport.UseSelectable = true;
            this.btnExportMonthReport.Click += new System.EventHandler(this.btnExportReportFile_Click);
            // 
            // cbxYearInventory
            // 
            this.cbxYearInventory.FormattingEnabled = true;
            this.cbxYearInventory.ItemHeight = 23;
            this.cbxYearInventory.Location = new System.Drawing.Point(181, 36);
            this.cbxYearInventory.Name = "cbxYearInventory";
            this.cbxYearInventory.Size = new System.Drawing.Size(96, 29);
            this.cbxYearInventory.TabIndex = 3;
            this.cbxYearInventory.UseSelectable = true;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(137, 36);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(38, 19);
            this.metroLabel19.TabIndex = 2;
            this.metroLabel19.Text = "Năm";
            // 
            // cbxMonthInventory
            // 
            this.cbxMonthInventory.FormattingEnabled = true;
            this.cbxMonthInventory.ItemHeight = 23;
            this.cbxMonthInventory.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxMonthInventory.Location = new System.Drawing.Point(64, 36);
            this.cbxMonthInventory.Name = "cbxMonthInventory";
            this.cbxMonthInventory.Size = new System.Drawing.Size(67, 29);
            this.cbxMonthInventory.TabIndex = 1;
            this.cbxMonthInventory.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(13, 36);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(45, 19);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Tháng";
            // 
            // tabManagement
            // 
            this.tabManagement.Controls.Add(this.cbxActiveRevForEdit);
            this.tabManagement.Controls.Add(this.metroLabel10);
            this.tabManagement.Controls.Add(this.groupBox5);
            this.tabManagement.Controls.Add(this.groupBox4);
            this.tabManagement.Controls.Add(this.groupBox3);
            this.tabManagement.Controls.Add(this.btnCancelCompositionEdit);
            this.tabManagement.Controls.Add(this.btnSaveCompositionEdit);
            this.tabManagement.Controls.Add(this.grvMaterialForEdit);
            this.tabManagement.Controls.Add(this.groupBox2);
            this.tabManagement.HorizontalScrollbarBarColor = true;
            this.tabManagement.HorizontalScrollbarHighlightOnWheel = false;
            this.tabManagement.HorizontalScrollbarSize = 10;
            this.tabManagement.Location = new System.Drawing.Point(4, 41);
            this.tabManagement.Name = "tabManagement";
            this.tabManagement.Padding = new System.Windows.Forms.Padding(20, 10, 20, 30);
            this.tabManagement.Size = new System.Drawing.Size(952, 425);
            this.tabManagement.TabIndex = 2;
            this.tabManagement.Text = "Quản lý";
            this.tabManagement.VerticalScrollbarBarColor = true;
            this.tabManagement.VerticalScrollbarHighlightOnWheel = false;
            this.tabManagement.VerticalScrollbarSize = 10;
            // 
            // cbxActiveRevForEdit
            // 
            this.cbxActiveRevForEdit.DataSource = this.comboBoxItemBindingSource;
            this.cbxActiveRevForEdit.DisplayMember = "Name";
            this.cbxActiveRevForEdit.FormattingEnabled = true;
            this.cbxActiveRevForEdit.ItemHeight = 23;
            this.cbxActiveRevForEdit.Location = new System.Drawing.Point(129, 381);
            this.cbxActiveRevForEdit.Name = "cbxActiveRevForEdit";
            this.cbxActiveRevForEdit.Size = new System.Drawing.Size(70, 29);
            this.cbxActiveRevForEdit.TabIndex = 51;
            this.cbxActiveRevForEdit.UseSelectable = true;
            this.cbxActiveRevForEdit.ValueMember = "Id";
            this.cbxActiveRevForEdit.SelectedIndexChanged += new System.EventHandler(this.cbxActiveRevForEdit_SelectedIndexChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(23, 381);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(100, 19);
            this.metroLabel10.TabIndex = 51;
            this.metroLabel10.Text = "Đơn hiện hành";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.lblImportInventoryExcelPath);
            this.groupBox5.Controls.Add(this.lblRemainInventoryExcelPath);
            this.groupBox5.Controls.Add(this.metroButton3);
            this.groupBox5.Controls.Add(this.metroButton2);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(560, 185);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(369, 190);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kho phối liệu";
            // 
            // lblImportInventoryExcelPath
            // 
            this.lblImportInventoryExcelPath.AutoSize = true;
            this.lblImportInventoryExcelPath.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblImportInventoryExcelPath.Location = new System.Drawing.Point(137, 107);
            this.lblImportInventoryExcelPath.Name = "lblImportInventoryExcelPath";
            this.lblImportInventoryExcelPath.Size = new System.Drawing.Size(179, 19);
            this.lblImportInventoryExcelPath.TabIndex = 28;
            this.lblImportInventoryExcelPath.Text = " Chưa có file nào được chọn";
            this.lblImportInventoryExcelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemainInventoryExcelPath
            // 
            this.lblRemainInventoryExcelPath.AutoSize = true;
            this.lblRemainInventoryExcelPath.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblRemainInventoryExcelPath.Location = new System.Drawing.Point(137, 44);
            this.lblRemainInventoryExcelPath.Name = "lblRemainInventoryExcelPath";
            this.lblRemainInventoryExcelPath.Size = new System.Drawing.Size(179, 19);
            this.lblRemainInventoryExcelPath.TabIndex = 26;
            this.lblRemainInventoryExcelPath.Text = " Chưa có file nào được chọn";
            this.lblRemainInventoryExcelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroButton3.Location = new System.Drawing.Point(13, 98);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(118, 34);
            this.metroButton3.TabIndex = 27;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "Nhập kho Phối liệu";
            this.metroButton3.UseMnemonic = false;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.btnImportInventory_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroButton2.Location = new System.Drawing.Point(13, 36);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(118, 34);
            this.metroButton2.TabIndex = 26;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "Khởi tạo tồn kho";
            this.metroButton2.UseMnemonic = false;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.btnImportInventory2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.metroLabel33);
            this.groupBox4.Controls.Add(this.listBoxErrorFiles);
            this.groupBox4.Controls.Add(this.lblFilename);
            this.groupBox4.Controls.Add(this.btnImportComposition);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(560, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(369, 166);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thêm đơn mới";
            // 
            // listBoxErrorFiles
            // 
            this.listBoxErrorFiles.DataSource = this.comboBoxItemBindingSource;
            this.listBoxErrorFiles.DisplayMember = "Name";
            this.listBoxErrorFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxErrorFiles.FormattingEnabled = true;
            this.listBoxErrorFiles.Location = new System.Drawing.Point(13, 103);
            this.listBoxErrorFiles.Name = "listBoxErrorFiles";
            this.listBoxErrorFiles.Size = new System.Drawing.Size(343, 43);
            this.listBoxErrorFiles.TabIndex = 26;
            this.listBoxErrorFiles.ValueMember = "Id";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblFilename.Location = new System.Drawing.Point(137, 44);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(175, 19);
            this.lblFilename.TabIndex = 25;
            this.lblFilename.Text = "Chưa có file nào được chọn";
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImportComposition
            // 
            this.btnImportComposition.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImportComposition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImportComposition.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnImportComposition.Location = new System.Drawing.Point(13, 36);
            this.btnImportComposition.Name = "btnImportComposition";
            this.btnImportComposition.Size = new System.Drawing.Size(118, 34);
            this.btnImportComposition.TabIndex = 24;
            this.btnImportComposition.TabStop = false;
            this.btnImportComposition.Text = "Nhập file excel";
            this.btnImportComposition.UseMnemonic = false;
            this.btnImportComposition.UseSelectable = true;
            this.btnImportComposition.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.cbxStageForEdit);
            this.groupBox3.Controls.Add(this.cbxCompositionForEdit);
            this.groupBox3.Controls.Add(this.metroLabel24);
            this.groupBox3.Controls.Add(this.cbxRevisionForEdit);
            this.groupBox3.Controls.Add(this.metroLabel25);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(23, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(207, 126);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mã đơn";
            // 
            // cbxStageForEdit
            // 
            this.cbxStageForEdit.DataSource = this.comboBoxItemBindingSource;
            this.cbxStageForEdit.DisplayMember = "Name";
            this.cbxStageForEdit.FormattingEnabled = true;
            this.cbxStageForEdit.ItemHeight = 23;
            this.cbxStageForEdit.Location = new System.Drawing.Point(89, 89);
            this.cbxStageForEdit.Name = "cbxStageForEdit";
            this.cbxStageForEdit.Size = new System.Drawing.Size(107, 29);
            this.cbxStageForEdit.TabIndex = 45;
            this.cbxStageForEdit.UseSelectable = true;
            this.cbxStageForEdit.ValueMember = "Id";
            this.cbxStageForEdit.SelectedIndexChanged += new System.EventHandler(this.cbxStageForEdit_SelectedIndexChanged);
            // 
            // cbxCompositionForEdit
            // 
            this.cbxCompositionForEdit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCompositionForEdit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCompositionForEdit.DataSource = this.comboBoxItemBindingSource;
            this.cbxCompositionForEdit.DisplayMember = "Name";
            this.cbxCompositionForEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCompositionForEdit.FormattingEnabled = true;
            this.cbxCompositionForEdit.Location = new System.Drawing.Point(13, 35);
            this.cbxCompositionForEdit.Name = "cbxCompositionForEdit";
            this.cbxCompositionForEdit.Size = new System.Drawing.Size(183, 29);
            this.cbxCompositionForEdit.TabIndex = 43;
            this.cbxCompositionForEdit.ValueMember = "Id";
            this.cbxCompositionForEdit.SelectedIndexChanged += new System.EventHandler(this.cbxCompositionForEdit_SelectedIndexChanged);
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel24.Location = new System.Drawing.Point(13, 67);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(72, 19);
            this.metroLabel24.TabIndex = 50;
            this.metroLabel24.Text = "Lần Th.đổi";
            // 
            // cbxRevisionForEdit
            // 
            this.cbxRevisionForEdit.DataSource = this.comboBoxItemBindingSource;
            this.cbxRevisionForEdit.DisplayMember = "Name";
            this.cbxRevisionForEdit.FormattingEnabled = true;
            this.cbxRevisionForEdit.ItemHeight = 23;
            this.cbxRevisionForEdit.Location = new System.Drawing.Point(13, 89);
            this.cbxRevisionForEdit.Name = "cbxRevisionForEdit";
            this.cbxRevisionForEdit.Size = new System.Drawing.Size(70, 29);
            this.cbxRevisionForEdit.TabIndex = 44;
            this.cbxRevisionForEdit.UseSelectable = true;
            this.cbxRevisionForEdit.ValueMember = "Id";
            this.cbxRevisionForEdit.SelectedIndexChanged += new System.EventHandler(this.cbxRevisionForEdit_SelectedIndexChanged);
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel25.Location = new System.Drawing.Point(89, 67);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(67, 19);
            this.metroLabel25.TabIndex = 49;
            this.metroLabel25.Text = "Giai đoạn";
            // 
            // btnCancelCompositionEdit
            // 
            this.btnCancelCompositionEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelCompositionEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelCompositionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelCompositionEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCompositionEdit.Location = new System.Drawing.Point(296, 381);
            this.btnCancelCompositionEdit.Name = "btnCancelCompositionEdit";
            this.btnCancelCompositionEdit.Size = new System.Drawing.Size(90, 41);
            this.btnCancelCompositionEdit.TabIndex = 48;
            this.btnCancelCompositionEdit.Text = "Hủy";
            this.btnCancelCompositionEdit.UseVisualStyleBackColor = false;
            this.btnCancelCompositionEdit.Click += new System.EventHandler(this.btnCancelCompositionEdit_Click);
            // 
            // btnSaveCompositionEdit
            // 
            this.btnSaveCompositionEdit.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveCompositionEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveCompositionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCompositionEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCompositionEdit.Location = new System.Drawing.Point(392, 381);
            this.btnSaveCompositionEdit.Name = "btnSaveCompositionEdit";
            this.btnSaveCompositionEdit.Size = new System.Drawing.Size(133, 41);
            this.btnSaveCompositionEdit.TabIndex = 47;
            this.btnSaveCompositionEdit.Text = "Lưu thay đổi";
            this.btnSaveCompositionEdit.UseVisualStyleBackColor = false;
            this.btnSaveCompositionEdit.Click += new System.EventHandler(this.btnSaveCompositionEdit_Click);
            // 
            // grvMaterialForEdit
            // 
            this.grvMaterialForEdit.AllowUserToAddRows = false;
            this.grvMaterialForEdit.AllowUserToDeleteRows = false;
            this.grvMaterialForEdit.AllowUserToResizeColumns = false;
            this.grvMaterialForEdit.AllowUserToResizeRows = false;
            this.grvMaterialForEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grvMaterialForEdit.BackgroundColor = System.Drawing.Color.White;
            this.grvMaterialForEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grvMaterialForEdit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grvMaterialForEdit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvMaterialForEdit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvMaterialForEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvMaterialForEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCompositionID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvMaterialForEdit.DefaultCellStyle = dataGridViewCellStyle5;
            this.grvMaterialForEdit.EnableHeadersVisualStyles = false;
            this.grvMaterialForEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMaterialForEdit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grvMaterialForEdit.Location = new System.Drawing.Point(23, 145);
            this.grvMaterialForEdit.MultiSelect = false;
            this.grvMaterialForEdit.Name = "grvMaterialForEdit";
            this.grvMaterialForEdit.ReadOnly = true;
            this.grvMaterialForEdit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvMaterialForEdit.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grvMaterialForEdit.RowHeadersWidth = 20;
            this.grvMaterialForEdit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grvMaterialForEdit.RowTemplate.Height = 50;
            this.grvMaterialForEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvMaterialForEdit.Size = new System.Drawing.Size(502, 230);
            this.grvMaterialForEdit.TabIndex = 46;
            this.grvMaterialForEdit.UseCustomBackColor = true;
            this.grvMaterialForEdit.SelectionChanged += new System.EventHandler(this.grvMaterialForEdit_SelectionChanged);
            // 
            // colCompositionID
            // 
            this.colCompositionID.HeaderText = "CompositionID";
            this.colCompositionID.Name = "colCompositionID";
            this.colCompositionID.ReadOnly = true;
            this.colCompositionID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "MaterialID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã hóa chất";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "Trọng lượng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 113;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn vị";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnCancelMaterialEdit);
            this.groupBox2.Controls.Add(this.cbxMaterialForEdit);
            this.groupBox2.Controls.Add(this.txtWeightUnitForEdit);
            this.groupBox2.Controls.Add(this.btnRemoveMaterial);
            this.groupBox2.Controls.Add(this.metroLabel20);
            this.groupBox2.Controls.Add(this.txtConstraintWeightForEdit);
            this.groupBox2.Controls.Add(this.lblConstraintWeightForEdit);
            this.groupBox2.Controls.Add(this.btnSaveMaterialEdit);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(236, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(289, 126);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mã thành phần";
            // 
            // btnCancelMaterialEdit
            // 
            this.btnCancelMaterialEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelMaterialEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelMaterialEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelMaterialEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelMaterialEdit.Location = new System.Drawing.Point(223, 35);
            this.btnCancelMaterialEdit.Name = "btnCancelMaterialEdit";
            this.btnCancelMaterialEdit.Size = new System.Drawing.Size(53, 28);
            this.btnCancelMaterialEdit.TabIndex = 52;
            this.btnCancelMaterialEdit.Text = "Hủy";
            this.btnCancelMaterialEdit.UseVisualStyleBackColor = false;
            this.btnCancelMaterialEdit.Click += new System.EventHandler(this.btnCancelMaterialEdit_Click);
            // 
            // cbxMaterialForEdit
            // 
            this.cbxMaterialForEdit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxMaterialForEdit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMaterialForEdit.DataSource = this.comboBoxItemBindingSource;
            this.cbxMaterialForEdit.DisplayMember = "Name";
            this.cbxMaterialForEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaterialForEdit.FormattingEnabled = true;
            this.cbxMaterialForEdit.Location = new System.Drawing.Point(13, 35);
            this.cbxMaterialForEdit.Name = "cbxMaterialForEdit";
            this.cbxMaterialForEdit.Size = new System.Drawing.Size(145, 29);
            this.cbxMaterialForEdit.TabIndex = 51;
            this.cbxMaterialForEdit.ValueMember = "Id";
            // 
            // txtWeightUnitForEdit
            // 
            this.txtWeightUnitForEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightUnitForEdit.Location = new System.Drawing.Point(103, 89);
            this.txtWeightUnitForEdit.Name = "txtWeightUnitForEdit";
            this.txtWeightUnitForEdit.Size = new System.Drawing.Size(55, 29);
            this.txtWeightUnitForEdit.TabIndex = 22;
            // 
            // btnRemoveMaterial
            // 
            this.btnRemoveMaterial.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveMaterial.FlatAppearance.BorderSize = 0;
            this.btnRemoveMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMaterial.Location = new System.Drawing.Point(164, 89);
            this.btnRemoveMaterial.Name = "btnRemoveMaterial";
            this.btnRemoveMaterial.Size = new System.Drawing.Size(112, 29);
            this.btnRemoveMaterial.TabIndex = 12;
            this.btnRemoveMaterial.Text = "Xóa thành phần";
            this.btnRemoveMaterial.UseVisualStyleBackColor = false;
            this.btnRemoveMaterial.Click += new System.EventHandler(this.btnRemoveMaterial_Click);
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel20.Location = new System.Drawing.Point(103, 67);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(49, 19);
            this.metroLabel20.TabIndex = 21;
            this.metroLabel20.Text = "Đơn vị";
            // 
            // txtConstraintWeightForEdit
            // 
            this.txtConstraintWeightForEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstraintWeightForEdit.Location = new System.Drawing.Point(13, 89);
            this.txtConstraintWeightForEdit.Name = "txtConstraintWeightForEdit";
            this.txtConstraintWeightForEdit.Size = new System.Drawing.Size(84, 29);
            this.txtConstraintWeightForEdit.TabIndex = 20;
            this.txtConstraintWeightForEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConstraintWeightForEdit_KeyPress);
            this.txtConstraintWeightForEdit.Validating += new System.ComponentModel.CancelEventHandler(this.txtConstraintWeightForEdit_Validating);
            // 
            // lblConstraintWeightForEdit
            // 
            this.lblConstraintWeightForEdit.AutoSize = true;
            this.lblConstraintWeightForEdit.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblConstraintWeightForEdit.Location = new System.Drawing.Point(13, 67);
            this.lblConstraintWeightForEdit.Name = "lblConstraintWeightForEdit";
            this.lblConstraintWeightForEdit.Size = new System.Drawing.Size(83, 19);
            this.lblConstraintWeightForEdit.TabIndex = 19;
            this.lblConstraintWeightForEdit.Text = "Trong lượng";
            // 
            // btnSaveMaterialEdit
            // 
            this.btnSaveMaterialEdit.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveMaterialEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveMaterialEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMaterialEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMaterialEdit.Location = new System.Drawing.Point(164, 35);
            this.btnSaveMaterialEdit.Name = "btnSaveMaterialEdit";
            this.btnSaveMaterialEdit.Size = new System.Drawing.Size(53, 29);
            this.btnSaveMaterialEdit.TabIndex = 11;
            this.btnSaveMaterialEdit.Text = "Lưu";
            this.btnSaveMaterialEdit.UseVisualStyleBackColor = false;
            this.btnSaveMaterialEdit.Click += new System.EventHandler(this.btnSaveMaterialEdit_Click);
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.groupBox11);
            this.tabSetting.Controls.Add(this.groupBox8);
            this.tabSetting.Controls.Add(this.groupBox7);
            this.tabSetting.HorizontalScrollbarBarColor = true;
            this.tabSetting.HorizontalScrollbarHighlightOnWheel = false;
            this.tabSetting.HorizontalScrollbarSize = 10;
            this.tabSetting.Location = new System.Drawing.Point(4, 41);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(20);
            this.tabSetting.Size = new System.Drawing.Size(952, 425);
            this.tabSetting.TabIndex = 3;
            this.tabSetting.Text = "Tùy chỉnh";
            this.tabSetting.VerticalScrollbarBarColor = true;
            this.tabSetting.VerticalScrollbarHighlightOnWheel = false;
            this.tabSetting.VerticalScrollbarSize = 10;
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.grvAccount);
            this.groupBox11.Controls.Add(this.cbxNewAccRole);
            this.groupBox11.Controls.Add(this.metroLabel30);
            this.groupBox11.Controls.Add(this.btnCancelAddingAccount);
            this.groupBox11.Controls.Add(this.txtNewAccPassword);
            this.groupBox11.Controls.Add(this.btnAddAccount);
            this.groupBox11.Controls.Add(this.metroLabel17);
            this.groupBox11.Controls.Add(this.metroLabel29);
            this.groupBox11.Controls.Add(this.metroLabel31);
            this.groupBox11.Controls.Add(this.txtNewAccConfirmPassword);
            this.groupBox11.Controls.Add(this.txtNewAccUserName);
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(341, 23);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox11.Size = new System.Drawing.Size(588, 379);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Tạo tài khoản mới";
            // 
            // grvAccount
            // 
            this.grvAccount.AllowUserToAddRows = false;
            this.grvAccount.AllowUserToDeleteRows = false;
            this.grvAccount.AllowUserToResizeRows = false;
            this.grvAccount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grvAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grvAccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grvAccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grvAccount.ColumnHeadersHeight = 29;
            this.grvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserName,
            this.colPassword,
            this.colRole});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvAccount.DefaultCellStyle = dataGridViewCellStyle9;
            this.grvAccount.EnableHeadersVisualStyles = false;
            this.grvAccount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAccount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grvAccount.Location = new System.Drawing.Point(24, 113);
            this.grvAccount.MultiSelect = false;
            this.grvAccount.Name = "grvAccount";
            this.grvAccount.ReadOnly = true;
            this.grvAccount.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grvAccount.RowHeadersWidth = 20;
            this.grvAccount.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvAccount.Size = new System.Drawing.Size(551, 253);
            this.grvAccount.TabIndex = 17;
            // 
            // colUserName
            // 
            this.colUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUserName.HeaderText = "Tên tài khoản";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPassword.HeaderText = "Mật khẩu";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            this.colPassword.Width = 79;
            // 
            // colRole
            // 
            this.colRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colRole.DefaultCellStyle = dataGridViewCellStyle8;
            this.colRole.HeaderText = "Loại tài khoản";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Width = 103;
            // 
            // cbxNewAccRole
            // 
            this.cbxNewAccRole.DataSource = this.comboBoxItemBindingSource;
            this.cbxNewAccRole.DisplayMember = "Name";
            this.cbxNewAccRole.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbxNewAccRole.FormattingEnabled = true;
            this.cbxNewAccRole.ItemHeight = 19;
            this.cbxNewAccRole.Location = new System.Drawing.Point(115, 68);
            this.cbxNewAccRole.Name = "cbxNewAccRole";
            this.cbxNewAccRole.Size = new System.Drawing.Size(132, 25);
            this.cbxNewAccRole.TabIndex = 16;
            this.cbxNewAccRole.UseSelectable = true;
            this.cbxNewAccRole.ValueMember = "Id";
            // 
            // metroLabel30
            // 
            this.metroLabel30.AutoSize = true;
            this.metroLabel30.Location = new System.Drawing.Point(19, 72);
            this.metroLabel30.Name = "metroLabel30";
            this.metroLabel30.Size = new System.Drawing.Size(90, 19);
            this.metroLabel30.TabIndex = 15;
            this.metroLabel30.Text = "Loại tài khoản";
            // 
            // btnCancelAddingAccount
            // 
            this.btnCancelAddingAccount.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelAddingAccount.Location = new System.Drawing.Point(506, 39);
            this.btnCancelAddingAccount.Name = "btnCancelAddingAccount";
            this.btnCancelAddingAccount.Size = new System.Drawing.Size(69, 23);
            this.btnCancelAddingAccount.TabIndex = 14;
            this.btnCancelAddingAccount.Text = "Hủy";
            this.btnCancelAddingAccount.UseCustomBackColor = true;
            this.btnCancelAddingAccount.UseSelectable = true;
            this.btnCancelAddingAccount.Click += new System.EventHandler(this.btnCancelAddingAccount_Click);
            // 
            // txtNewAccPassword
            // 
            this.txtNewAccPassword.BackColor = System.Drawing.Color.White;
            this.txtNewAccPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNewAccPassword.Lines = new string[0];
            this.txtNewAccPassword.Location = new System.Drawing.Point(379, 39);
            this.txtNewAccPassword.MaxLength = 32767;
            this.txtNewAccPassword.Name = "txtNewAccPassword";
            this.txtNewAccPassword.PasswordChar = '•';
            this.txtNewAccPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewAccPassword.SelectedText = "";
            this.txtNewAccPassword.Size = new System.Drawing.Size(121, 23);
            this.txtNewAccPassword.TabIndex = 7;
            this.txtNewAccPassword.UseCustomBackColor = true;
            this.txtNewAccPassword.UseSelectable = true;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackColor = System.Drawing.Color.LightBlue;
            this.btnAddAccount.Location = new System.Drawing.Point(506, 68);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(69, 23);
            this.btnAddAccount.TabIndex = 13;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseCustomBackColor = true;
            this.btnAddAccount.UseSelectable = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(24, 43);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(85, 19);
            this.metroLabel17.TabIndex = 2;
            this.metroLabel17.Text = "Tên tài khoản";
            // 
            // metroLabel29
            // 
            this.metroLabel29.AutoSize = true;
            this.metroLabel29.Location = new System.Drawing.Point(310, 43);
            this.metroLabel29.Name = "metroLabel29";
            this.metroLabel29.Size = new System.Drawing.Size(63, 19);
            this.metroLabel29.TabIndex = 3;
            this.metroLabel29.Text = "Mật khẩu";
            // 
            // metroLabel31
            // 
            this.metroLabel31.AutoSize = true;
            this.metroLabel31.Location = new System.Drawing.Point(253, 72);
            this.metroLabel31.Name = "metroLabel31";
            this.metroLabel31.Size = new System.Drawing.Size(120, 19);
            this.metroLabel31.TabIndex = 5;
            this.metroLabel31.Text = "Xác nhận mật khẩu";
            // 
            // txtNewAccConfirmPassword
            // 
            this.txtNewAccConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtNewAccConfirmPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNewAccConfirmPassword.Lines = new string[0];
            this.txtNewAccConfirmPassword.Location = new System.Drawing.Point(379, 68);
            this.txtNewAccConfirmPassword.MaxLength = 32767;
            this.txtNewAccConfirmPassword.Name = "txtNewAccConfirmPassword";
            this.txtNewAccConfirmPassword.PasswordChar = '•';
            this.txtNewAccConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewAccConfirmPassword.SelectedText = "";
            this.txtNewAccConfirmPassword.Size = new System.Drawing.Size(121, 23);
            this.txtNewAccConfirmPassword.TabIndex = 9;
            this.txtNewAccConfirmPassword.UseCustomBackColor = true;
            this.txtNewAccConfirmPassword.UseSelectable = true;
            // 
            // txtNewAccUserName
            // 
            this.txtNewAccUserName.BackColor = System.Drawing.Color.White;
            this.txtNewAccUserName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNewAccUserName.Lines = new string[0];
            this.txtNewAccUserName.Location = new System.Drawing.Point(115, 39);
            this.txtNewAccUserName.MaxLength = 32767;
            this.txtNewAccUserName.Name = "txtNewAccUserName";
            this.txtNewAccUserName.PasswordChar = '\0';
            this.txtNewAccUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewAccUserName.SelectedText = "";
            this.txtNewAccUserName.Size = new System.Drawing.Size(132, 23);
            this.txtNewAccUserName.TabIndex = 6;
            this.txtNewAccUserName.UseCustomBackColor = true;
            this.txtNewAccUserName.UseSelectable = true;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.metroLabel32);
            this.groupBox8.Controls.Add(this.btnCancelScaleSetting);
            this.groupBox8.Controls.Add(this.metroLabel22);
            this.groupBox8.Controls.Add(this.txtWeightCapacity);
            this.groupBox8.Controls.Add(this.metroLabel15);
            this.groupBox8.Controls.Add(this.metroLabel21);
            this.groupBox8.Controls.Add(this.btnSaveScaleSetting);
            this.groupBox8.Controls.Add(this.txtWeightDeviation);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(23, 23);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox8.Size = new System.Drawing.Size(299, 120);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Cân phối liệu";
            // 
            // metroLabel32
            // 
            this.metroLabel32.AutoSize = true;
            this.metroLabel32.Location = new System.Drawing.Point(176, 43);
            this.metroLabel32.Name = "metroLabel32";
            this.metroLabel32.Size = new System.Drawing.Size(20, 19);
            this.metroLabel32.TabIndex = 13;
            this.metroLabel32.Text = "%";
            // 
            // btnCancelScaleSetting
            // 
            this.btnCancelScaleSetting.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelScaleSetting.Location = new System.Drawing.Point(207, 39);
            this.btnCancelScaleSetting.Name = "btnCancelScaleSetting";
            this.btnCancelScaleSetting.Size = new System.Drawing.Size(79, 23);
            this.btnCancelScaleSetting.TabIndex = 12;
            this.btnCancelScaleSetting.Text = "Hủy";
            this.btnCancelScaleSetting.UseCustomBackColor = true;
            this.btnCancelScaleSetting.UseSelectable = true;
            this.btnCancelScaleSetting.Click += new System.EventHandler(this.btnCancelScaleSetting_Click);
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(176, 72);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(23, 19);
            this.metroLabel22.TabIndex = 11;
            this.metroLabel22.Text = "kg";
            // 
            // txtWeightCapacity
            // 
            this.txtWeightCapacity.BackColor = System.Drawing.Color.White;
            this.txtWeightCapacity.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtWeightCapacity.Lines = new string[0];
            this.txtWeightCapacity.Location = new System.Drawing.Point(121, 72);
            this.txtWeightCapacity.MaxLength = 32767;
            this.txtWeightCapacity.Name = "txtWeightCapacity";
            this.txtWeightCapacity.PasswordChar = '\0';
            this.txtWeightCapacity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWeightCapacity.SelectedText = "";
            this.txtWeightCapacity.Size = new System.Drawing.Size(49, 23);
            this.txtWeightCapacity.TabIndex = 7;
            this.txtWeightCapacity.UseCustomBackColor = true;
            this.txtWeightCapacity.UseSelectable = true;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(13, 43);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(102, 19);
            this.metroLabel15.TabIndex = 2;
            this.metroLabel15.Text = "Sai số cho phép";
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(34, 72);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(81, 19);
            this.metroLabel21.TabIndex = 3;
            this.metroLabel21.Text = "Giới hạn cân";
            // 
            // btnSaveScaleSetting
            // 
            this.btnSaveScaleSetting.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveScaleSetting.Location = new System.Drawing.Point(207, 72);
            this.btnSaveScaleSetting.Name = "btnSaveScaleSetting";
            this.btnSaveScaleSetting.Size = new System.Drawing.Size(79, 23);
            this.btnSaveScaleSetting.TabIndex = 10;
            this.btnSaveScaleSetting.Text = "Lưu";
            this.btnSaveScaleSetting.UseCustomBackColor = true;
            this.btnSaveScaleSetting.UseSelectable = true;
            this.btnSaveScaleSetting.Click += new System.EventHandler(this.btnSaveScaleSetting_Click);
            // 
            // txtWeightDeviation
            // 
            this.txtWeightDeviation.BackColor = System.Drawing.Color.White;
            this.txtWeightDeviation.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtWeightDeviation.Lines = new string[0];
            this.txtWeightDeviation.Location = new System.Drawing.Point(121, 39);
            this.txtWeightDeviation.MaxLength = 32767;
            this.txtWeightDeviation.Name = "txtWeightDeviation";
            this.txtWeightDeviation.PasswordChar = '\0';
            this.txtWeightDeviation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWeightDeviation.SelectedText = "";
            this.txtWeightDeviation.Size = new System.Drawing.Size(49, 23);
            this.txtWeightDeviation.TabIndex = 6;
            this.txtWeightDeviation.UseCustomBackColor = true;
            this.txtWeightDeviation.UseSelectable = true;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.btnCancelAccount);
            this.groupBox7.Controls.Add(this.txtCurrentPassword);
            this.groupBox7.Controls.Add(this.btnSaveAccount);
            this.groupBox7.Controls.Add(this.metroLabel11);
            this.groupBox7.Controls.Add(this.metroLabel12);
            this.groupBox7.Controls.Add(this.metroLabel13);
            this.groupBox7.Controls.Add(this.metroLabel14);
            this.groupBox7.Controls.Add(this.txtConfirmingPassword);
            this.groupBox7.Controls.Add(this.txtUsername);
            this.groupBox7.Controls.Add(this.txtNewPassword);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(23, 153);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox7.Size = new System.Drawing.Size(299, 249);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tài khoản của tôi";
            // 
            // btnCancelAccount
            // 
            this.btnCancelAccount.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelAccount.Location = new System.Drawing.Point(139, 201);
            this.btnCancelAccount.Name = "btnCancelAccount";
            this.btnCancelAccount.Size = new System.Drawing.Size(66, 35);
            this.btnCancelAccount.TabIndex = 14;
            this.btnCancelAccount.Text = "Hủy";
            this.btnCancelAccount.UseCustomBackColor = true;
            this.btnCancelAccount.UseSelectable = true;
            this.btnCancelAccount.Click += new System.EventHandler(this.btnCancelAccount_Click);
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BackColor = System.Drawing.Color.White;
            this.txtCurrentPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCurrentPassword.Lines = new string[0];
            this.txtCurrentPassword.Location = new System.Drawing.Point(139, 78);
            this.txtCurrentPassword.MaxLength = 32767;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '•';
            this.txtCurrentPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(147, 23);
            this.txtCurrentPassword.TabIndex = 7;
            this.txtCurrentPassword.UseCustomBackColor = true;
            this.txtCurrentPassword.UseSelectable = true;
            // 
            // btnSaveAccount
            // 
            this.btnSaveAccount.BackColor = System.Drawing.Color.LightBlue;
            this.btnSaveAccount.Location = new System.Drawing.Point(220, 201);
            this.btnSaveAccount.Name = "btnSaveAccount";
            this.btnSaveAccount.Size = new System.Drawing.Size(66, 35);
            this.btnSaveAccount.TabIndex = 13;
            this.btnSaveAccount.Text = "Lưu";
            this.btnSaveAccount.UseCustomBackColor = true;
            this.btnSaveAccount.UseSelectable = true;
            this.btnSaveAccount.Click += new System.EventHandler(this.btnSaveAccount_Click);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(48, 43);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(85, 19);
            this.metroLabel11.TabIndex = 2;
            this.metroLabel11.Text = "Tên tài khoản";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(24, 82);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(109, 19);
            this.metroLabel12.TabIndex = 3;
            this.metroLabel12.Text = "Mật khẩu hiện tại";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(43, 121);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(90, 19);
            this.metroLabel13.TabIndex = 4;
            this.metroLabel13.Text = "Mật khẩu mới";
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(13, 159);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(120, 19);
            this.metroLabel14.TabIndex = 5;
            this.metroLabel14.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmingPassword
            // 
            this.txtConfirmingPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmingPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtConfirmingPassword.Lines = new string[0];
            this.txtConfirmingPassword.Location = new System.Drawing.Point(139, 155);
            this.txtConfirmingPassword.MaxLength = 32767;
            this.txtConfirmingPassword.Name = "txtConfirmingPassword";
            this.txtConfirmingPassword.PasswordChar = '•';
            this.txtConfirmingPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfirmingPassword.SelectedText = "";
            this.txtConfirmingPassword.Size = new System.Drawing.Size(147, 23);
            this.txtConfirmingPassword.TabIndex = 9;
            this.txtConfirmingPassword.UseCustomBackColor = true;
            this.txtConfirmingPassword.UseSelectable = true;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(139, 39);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ReadOnly = true;
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(147, 23);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.UseCustomBackColor = true;
            this.txtUsername.UseSelectable = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNewPassword.Lines = new string[0];
            this.txtNewPassword.Location = new System.Drawing.Point(139, 117);
            this.txtNewPassword.MaxLength = 32767;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(147, 23);
            this.txtNewPassword.TabIndex = 8;
            this.txtNewPassword.UseCustomBackColor = true;
            this.txtNewPassword.UseSelectable = true;
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(47, 532);
            this.loadingBar.MarqueeAnimationSpeed = 200;
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingBar.Size = new System.Drawing.Size(893, 10);
            this.loadingBar.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // linkSignOut
            // 
            this.linkSignOut.Location = new System.Drawing.Point(901, 31);
            this.linkSignOut.Name = "linkSignOut";
            this.linkSignOut.Size = new System.Drawing.Size(75, 23);
            this.linkSignOut.TabIndex = 1;
            this.linkSignOut.Text = "Đăng xuất";
            this.linkSignOut.UseSelectable = true;
            this.linkSignOut.Click += new System.EventHandler(this.linkSignOut_Click);
            // 
            // metroLabel33
            // 
            this.metroLabel33.AutoSize = true;
            this.metroLabel33.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel33.Location = new System.Drawing.Point(0, 81);
            this.metroLabel33.Name = "metroLabel33";
            this.metroLabel33.Size = new System.Drawing.Size(88, 19);
            this.metroLabel33.TabIndex = 27;
            this.metroLabel33.Text = "Các file bị lỗi:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.linkSignOut);
            this.Controls.Add(this.panelTabControl);
            this.Controls.Add(this.loadingBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Quản lý cân phối liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelTabControl.ResumeLayout(false);
            this.tabMeasure.ResumeLayout(false);
            this.tabMeasure.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterialTable)).EndInit();
            this.tabReport.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabManagement.ResumeLayout(false);
            this.tabManagement.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterialForEdit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccount)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl panelTabControl;
        private MetroFramework.Controls.MetroTabPage tabMeasure;
        private MetroFramework.Controls.MetroTabPage tabReport;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox cbxComposition;
        private MetroFramework.Controls.MetroTabPage tabManagement;
        private MetroFramework.Controls.MetroGrid grvMaterialTable;
        private System.Windows.Forms.Button btnCancelComposition;
        private System.Windows.Forms.Button btnFinishMeasurement;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWeightUnit;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.TextBox txtConstraintWeight;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.Button btnConfirmMaterial;
        private System.Windows.Forms.Button btnCancelItem;
        private System.Windows.Forms.TextBox txtCurrentMaterial;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.TextBox txtMaterialStatus;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.TextBox txtMeasurementDigit;
        private MetroFramework.Controls.MetroComboBox cbxRev;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbxStage;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.BindingSource comboBoxItemBindingSource;
        private MetroFramework.Controls.MetroTabPage tabSetting;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox txtConfirmingPassword;
        private MetroFramework.Controls.MetroTextBox txtNewPassword;
        private MetroFramework.Controls.MetroTextBox txtCurrentPassword;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private System.Windows.Forms.TextBox txtParcelCodePrefix;
        private MetroFramework.Controls.MetroComboBox cbxMeasureType;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroComboBox cbxMeasureUnit;
        private System.Windows.Forms.TextBox txtMeasureQuantity;
        private MetroFramework.Controls.MetroLabel lblMeasureQuantity;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MetroFramework.Controls.MetroComboBox cbxStageForEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxCompositionForEdit;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private MetroFramework.Controls.MetroComboBox cbxRevisionForEdit;
        private System.Windows.Forms.Button btnCancelCompositionEdit;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private System.Windows.Forms.Button btnSaveCompositionEdit;
        private MetroFramework.Controls.MetroGrid grvMaterialForEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private System.Windows.Forms.TextBox txtConstraintWeightForEdit;
        private MetroFramework.Controls.MetroLabel lblConstraintWeightForEdit;
        private System.Windows.Forms.Button btnSaveMaterialEdit;
        private System.Windows.Forms.Button btnRemoveMaterial;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroLabel lblFilename;
        private MetroFramework.Controls.MetroButton btnImportComposition;
        private System.Windows.Forms.Button btnCancelMaterialEdit;
        private System.Windows.Forms.TextBox txtWeightUnitForEdit;
        private System.Windows.Forms.ComboBox cbxMaterialForEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompositionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox8;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroTextBox txtWeightCapacity;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroButton btnSaveScaleSetting;
        private MetroFramework.Controls.MetroTextBox txtWeightDeviation;
        private System.Windows.Forms.GroupBox groupBox7;
        private MetroFramework.Controls.MetroButton btnCancelScaleSetting;
        private MetroFramework.Controls.MetroButton btnCancelAccount;
        private MetroFramework.Controls.MetroButton btnSaveAccount;
        private MetroFramework.Controls.MetroLabel lblRemainInventoryExcelPath;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel lblImportInventoryExcelPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalConstraintWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeightUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcelCode;
        private System.Windows.Forms.GroupBox groupBox6;
        private MetroFramework.Controls.MetroButton btnExportMonthReport;
        private MetroFramework.Controls.MetroComboBox cbxYearInventory;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroComboBox cbxMonthInventory;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.GroupBox groupBox9;
        private MetroFramework.Controls.MetroButton btnExportProductionResultReport;
        private MetroFramework.Controls.MetroComboBox cbxYearProductionResult;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroComboBox cbxMonthProductionResult;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private System.Windows.Forms.GroupBox groupBox10;
        private MetroFramework.Controls.MetroButton btnExportMaterialReport;
        private MetroFramework.Controls.MetroComboBox cbxYearExport;
        private MetroFramework.Controls.MetroLabel metroLabel27;
        private MetroFramework.Controls.MetroComboBox cbxMonthExport;
        private MetroFramework.Controls.MetroLabel metroLabel28;
        private MetroFramework.Controls.MetroLink linkSignOut;
        private System.Windows.Forms.TextBox txtParcelCode;
        private MetroFramework.Controls.MetroProgressBar loadingBar;
        private MetroFramework.Controls.MetroComboBox cbxActiveRevForEdit;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.GroupBox groupBox11;
        private MetroFramework.Controls.MetroComboBox cbxNewAccRole;
        private MetroFramework.Controls.MetroLabel metroLabel30;
        private MetroFramework.Controls.MetroButton btnCancelAddingAccount;
        private MetroFramework.Controls.MetroTextBox txtNewAccPassword;
        private MetroFramework.Controls.MetroButton btnAddAccount;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel29;
        private MetroFramework.Controls.MetroLabel metroLabel31;
        private MetroFramework.Controls.MetroTextBox txtNewAccConfirmPassword;
        private MetroFramework.Controls.MetroTextBox txtNewAccUserName;
        private MetroFramework.Controls.MetroGrid grvAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private MetroFramework.Controls.MetroLabel metroLabel32;
        private System.Windows.Forms.ListBox listBoxErrorFiles;
        private MetroFramework.Controls.MetroLabel metroLabel33;
    }
}

