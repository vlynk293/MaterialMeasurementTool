using FastMember;
using MaterialMeasurement.Data;
using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using MaterialMeasurement.Data.DataAccessLayer.Concrete;
using MaterialMeasurementTool.Utility;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialMeasurementTool
{
    public partial class MainForm : MetroForm
    {
        //public static MaterialMeasurementEntities db = new MaterialMeasurementEntities();
        private readonly IMaterialService _materialService = new MaterialService();
        private readonly IImportedInventoryService _importedInventoryService = new ImportednventoryService();
        private readonly ICompositionService _compositionService = new CompositionService();
        private readonly IMeasurementRecordService _measurementRecordService = new MeasurementRecordService();
        private readonly IMonthReportService _monthReportService = new MonthReportService();
        private readonly IMeasurementDetailRecordService _measurementDetailRecordService = new MeasurementDetailRecordService();
        private readonly IUserService _userService = new UserService();

        //cbx datasource
        private BindingList<ComboBoxItem> listCbxCompositionItems, listCbxRevItems, listCbxStageItems, listCbxMaterialItems, listCbxRoles;
        //valid weight unit 
        private List<string> ValidWeightUnit;
        //Authorized tab for Admin
        private List<TabPage> AdminTab;

        //temp list for edit composition
        private List<string> lackMaterialCode;
        private Dictionary<string, Dictionary<string, double>> materialParcelList;
        private Material patForEdit, keoForEdit;
        private List<Composition> patComForEdit, keoComForEdit;
        private bool IsModified;

        private List<ComboBoxItem> listErrorFile = null;
        //current logged in user
        private User currentUser;

        //flag initialize
        private bool finishInitializing;

        private SerialPort mySerialPort = new SerialPort();

        public MainForm()
        {
            currentUser = null;
            ValidWeightUnit = new List<string>() { "g", "gam", "gram", "kg" };
            listCbxRoles = new BindingList<ComboBoxItem>();
            finishInitializing = false;

            InitializeComponent();

            InitiateTabControl();
            this.panelTabControl.Visible = false;

            this.txtMeasureQuantity.Text = "1"; //xong =))
            this.loadingBar.Visible = false;

            //Data binding
            InitCompositionList();
            InitMaterialList();
            listCbxRoles.Add(new ComboBoxItem(((int)RoleEnum.Admin).ToString(), "Admin"));
            listCbxRoles.Add(new ComboBoxItem(((int)RoleEnum.User).ToString(), "User"));
            this.cbxNewAccRole.DataSource = listCbxRoles;
            listCbxRoles.ResetBindings();

            //Initiate
            InitiateMeasurementTab();
            InitiateSettingTab();
            InitiateManagementTab();
            InitiateReportTab();

            //Tab: Management
            ////enable 'add new'
            this.btnSaveMaterialEdit.Text = "Thêm";
            this.cbxMaterialForEdit.Enabled = true;

            finishInitializing = true;
        }

        #region Initiate

        private void InitiateTabControl()
        {
            AdminTab = new List<TabPage> { this.tabManagement, this.tabSetting };

            this.panelTabControl.SelectedTab = this.tabMeasure;

            foreach (TabPage item in AdminTab)
            {
                this.panelTabControl.TabPages.Remove(item);
            }
        }

        private void InitiateMeasurementTab()
        {
            //cbx
            this.cbxComposition.SelectedItem = null;
            this.cbxRev.SelectedItem = null;
            this.cbxStage.SelectedItem = null;
            this.cbxMeasureUnit.SelectedIndex = 0;
            this.cbxMeasureType.SelectedIndex = 0;

            //gridview
            if (this.grvMaterialTable.Rows != null)
            {
                this.grvMaterialTable.Rows.Clear();
            }

            //textfield
            this.txtCurrentMaterial.Clear();
            this.txtConstraintWeight.Clear();
            this.txtWeightUnit.Clear();
            this.txtMaterialStatus.Clear();
            this.txtParcelCodePrefix.Text = "M";
            this.txtMeasureQuantity.Text = "1";
        }

        private void InitiateSettingTab()
        {
            //account
            this.txtUsername.Clear();
            this.txtCurrentPassword.Clear();
            this.txtNewPassword.Clear();
            this.txtConfirmingPassword.Clear();

            if (currentUser != null)
            {
                this.txtUsername.Text = currentUser.Username;
            }

            //scale
            this.txtWeightDeviation.Text = Math.Round(Properties.Settings.Default.WeightDeviation, 1).ToString();
            this.txtWeightCapacity.Text = Math.Round(Properties.Settings.Default.WeightCapacity, 1).ToString();

            //add new account
            this.txtNewAccUserName.Clear();
            this.txtNewAccPassword.Clear();
            this.txtNewAccConfirmPassword.Clear();

            //acc table
            this.grvAccount.Rows.Clear();
            var allAccount = _userService.GetAll().OrderBy(a => a.Role).ThenBy(a => a.Username);
            if (allAccount != null)
            {
                var listAcc = allAccount.ToList();
                foreach (var item in listAcc)
                {
                    this.grvAccount.Rows.Add(item.Username, item.Role == (int)RoleEnum.Admin ? "******" : item.Password, Enum.GetName(typeof(RoleEnum), item.Role));
                }
            }
        }

        private void InitiateManagementTab()
        {
            //cbx
            this.cbxCompositionForEdit.SelectedItem = null;
            this.cbxActiveRevForEdit.SelectedItem = null;

            //grv
            if (this.grvMaterialForEdit.Rows != null)
            {
                this.grvMaterialForEdit.Rows.Clear();
            }

            //txt
            this.txtConstraintWeightForEdit.Clear();
            this.txtWeightUnitForEdit.Clear();


            this.cbxMaterialForEdit.SelectedItem = null;
            this.cbxMaterialForEdit.Text = "";

            IsModified = false;
        }

        private void InitiateReportTab()
        {
            var today = DateTime.Today;

            this.cbxMonthExport.Text = today.Month.ToString();
            this.cbxMonthInventory.Text = today.Month.ToString();
            this.cbxMonthProductionResult.Text = today.Month.ToString();


            this.cbxYearExport.Items.Clear();
            this.cbxYearInventory.Items.Clear();
            this.cbxYearProductionResult.Items.Clear();
            for (int i = 2015; i <= DateTime.Today.Year; i++)
            {
                this.cbxYearExport.Items.Add(i);
                this.cbxYearInventory.Items.Add(i);
                this.cbxYearProductionResult.Items.Add(i);
            }

            this.cbxYearExport.Text = today.Year.ToString();
            this.cbxYearInventory.Text = today.Year.ToString();
            this.cbxYearProductionResult.Text = today.Year.ToString();
        }

        private void InitCompositionList()
        {
            //get all materials that contain a 'Pat' as it component
            var listComposition = _materialService.GetMaterials().Where(m => m.PatId.HasValue).Select(m => m.Code).Distinct().ToList();
            listCbxCompositionItems = new BindingList<ComboBoxItem>();
            foreach (var item in listComposition)
            {
                listCbxCompositionItems.Add(new ComboBoxItem(item, item));
            }

            this.cbxComposition.DataSource = listCbxCompositionItems;
            this.cbxCompositionForEdit.DataSource = listCbxCompositionItems;
            listCbxCompositionItems.ResetBindings();
        }

        private void InitMaterialList()
        {
            //get all raw materials
            var listMaterial = _materialService.GetMaterials().Where(m => m.TypeID == (int)MaterialTypeEnum.Raw).Select(m => m.Code).Distinct().ToList();
            listCbxMaterialItems = new BindingList<ComboBoxItem>();
            foreach (var item in listMaterial)
            {
                listCbxMaterialItems.Add(new ComboBoxItem(item, item));
            }

            this.cbxMaterialForEdit.DataSource = listCbxMaterialItems;
            listCbxMaterialItems.ResetBindings();
        }

        private void ClearMeasurementResultField()
        {
            this.txtMeasurementDigit.Text = "0.00";
            this.txtCurrentMaterial.Clear();
            this.txtConstraintWeight.Clear();
            this.txtWeightUnit.Clear();
            this.txtMaterialStatus.Clear();

            this.grvMaterialTable.ClearSelection();
        }

        private void InitiateSerialPort()
        {
            try
            {
                mySerialPort.PortName = SerialPort.GetPortNames().First();
                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                mySerialPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kết nối với cân điện tử và khởi động lại chương trình.", "Không tìm thấy thiết bị", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Support methods

        private void Login()
        {
            LoginForm loginForm = new LoginForm();
            var rs = loginForm.ShowDialog();

            if (rs == DialogResult.Cancel)
            {
                this.Close();
                return;
            }

            currentUser = loginForm.SignedInUser;
            this.panelTabControl.Visible = true;

            if (currentUser.Role == (int)RoleEnum.Admin)
            {
                foreach (TabPage item in this.AdminTab)
                {
                    if (!this.panelTabControl.TabPages.Contains(item))
                    {
                        this.panelTabControl.TabPages.Add(item);
                    }
                }
            }
        }

        private bool IsInMeasureProcess()
        {
            bool isInProcess = false;

            if (this.grvMaterialTable.Rows != null && this.grvMaterialTable.Rows.Count > 0)
            {
                for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                {
                    var row = this.grvMaterialTable.Rows[i];

                    if (Resource.Message_vi.ConfirmMaterialSuccess.Equals(row.Cells[(int)MaterialTableColumn.Status].Value))
                    {
                        isInProcess = true;
                        break;
                    }
                }
            }

            return isInProcess;
        }

        private void ReCalculateConstraintWeight()
        {
            if (!"Cây".Equals((string)this.cbxMeasureUnit.SelectedItem))
            {
                if (this.grvMaterialTable.Rows != null && this.grvMaterialTable.Rows.Count > 0)
                {
                    //calculate standard total weight
                    double totalWeight = 0;
                    for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                    {
                        var row = this.grvMaterialTable.Rows[i];
                        totalWeight += MeasureUtil.ConvertWeightUnit((double)row.Cells[(int)MaterialTableColumn.OriginalConstraintWeight].Value, (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value, "g");
                    }

                    //divide by ratio
                    var expectWeight = MeasureUtil.ConvertWeightUnit(double.Parse(this.txtMeasureQuantity.Text), "kg", "g");
                    double ratio = expectWeight / totalWeight;
                    for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                    {
                        var row = this.grvMaterialTable.Rows[i];
                        var currentWeight = (double)row.Cells[(int)MaterialTableColumn.OriginalConstraintWeight].Value;
                        row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value = Math.Round(currentWeight * ratio, 1);
                    }

                    //clear selection
                    this.grvMaterialTable.ClearSelection();
                }
            }
        }

        private void CheckLackMaterialAndIncreaseParcelCode(long selectedMaterialId)
        {
            var latestRecord = _measurementRecordService.GetLatestRecord(selectedMaterialId);
            bool increaseParcelCode = false;

            #region Check lack material

            lackMaterialCode = new List<string>();
            materialParcelList = new Dictionary<string, Dictionary<string, double>>();

            if (this.grvMaterialTable.Rows != null && this.grvMaterialTable.Rows.Count > 0)
            {
                for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                {
                    var row = this.grvMaterialTable.Rows[i];
                    var latestDetailRecord = _measurementDetailRecordService.GetLatestDetailRecord((long)row.Cells[(int)MaterialTableColumn.MaterialID].Value, latestRecord == null ? -1 : latestRecord.ID);
                    var currentMaterialCode = (string)row.Cells[(int)MaterialTableColumn.MaterialCode].Value;

                    var inventory = _importedInventoryService.GetNotEmptyInventoriesByMaterialID((long)row.Cells[(int)MaterialTableColumn.MaterialID].Value).ToList();
                    var currentQuantity = inventory.Sum(inv => MeasureUtil.ConvertWeightUnit(inv.Quantity, inv.WeightUnit, "g"));
                    var neededQuantity = MeasureUtil.ConvertWeightUnit((double)row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value, (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value, "g");
                    if ("Cây".Equals(this.cbxMeasureUnit.Text))
                    {
                        int multiplyQuantity = int.Parse(this.txtMeasureQuantity.Text);
                        neededQuantity = neededQuantity * multiplyQuantity;
                    }

                    if (currentQuantity < neededQuantity)
                    {
                        lackMaterialCode.Add(currentMaterialCode);
                    }
                    else
                    {
                        var usingInventory = inventory;
                        for (int j = 0; j < usingInventory.Count; j++)
                        {
                            var inventoryQuantity = MeasureUtil.ConvertWeightUnit(usingInventory[j].Quantity, usingInventory[j].WeightUnit, "g");

                            if (inventoryQuantity < neededQuantity)
                            {
                                if (materialParcelList.ContainsKey(currentMaterialCode))
                                {
                                    materialParcelList[currentMaterialCode].Add(usingInventory[j].ParcelCode, MeasureUtil.ConvertWeightUnit(inventoryQuantity, "g", (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value));
                                    increaseParcelCode = true;
                                }
                                else
                                {
                                    materialParcelList.Add(currentMaterialCode, new Dictionary<string, double>() { { usingInventory[j].ParcelCode, MeasureUtil.ConvertWeightUnit(inventoryQuantity, "g", (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value) } });
                                    if (latestDetailRecord != null && !usingInventory[j].ParcelCode.Equals(latestDetailRecord.ParcelCode))
                                    {
                                        increaseParcelCode = true;
                                    }
                                }

                                neededQuantity -= inventoryQuantity;
                            }
                            else
                            {
                                if (materialParcelList.ContainsKey(currentMaterialCode))
                                {
                                    materialParcelList[currentMaterialCode].Add(usingInventory[j].ParcelCode, MeasureUtil.ConvertWeightUnit(neededQuantity, "g", (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value));
                                    increaseParcelCode = true;
                                }
                                else
                                {
                                    materialParcelList.Add(currentMaterialCode, new Dictionary<string, double>() { { usingInventory[j].ParcelCode, MeasureUtil.ConvertWeightUnit(neededQuantity, "g", (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value) } });
                                    if (latestDetailRecord != null && !usingInventory[j].ParcelCode.Equals(latestDetailRecord.ParcelCode))
                                    {
                                        increaseParcelCode = true;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            int latestParcelCode = 0;
            if (latestRecord != null)
            {
                int.TryParse(latestRecord.ParcelCode.Substring(1), out latestParcelCode);
            }

            if (increaseParcelCode)
            {
                latestParcelCode += 1;
            }
            this.txtParcelCode.Text = latestParcelCode.ToString();
        }

        #endregion

        #region Events

        #region Tab: Measurement
        private void btnCancelItem_Click(object sender, EventArgs e)
        {
            if (this.grvMaterialTable.SelectedRows != null && this.grvMaterialTable.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có muốn hủy kết quả cân?", "Hủy kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var row = this.grvMaterialTable.SelectedRows[0];
                    row.Cells[(int)MaterialTableColumn.Status].Value = Resource.Message_vi.ConfirmMaterialFail;
                    row.Cells[(int)MaterialTableColumn.RealDone].Value = (double)0;
                    row.Cells[(int)MaterialTableColumn.DoneQuantity].Value = (double)0;

                    ClearMeasurementResultField();
                }
            }
        }

        private void btnCancelComposition_Click(object sender, EventArgs e)
        {
            if (this.cbxComposition.SelectedItem != null)
            {
                var result = MessageBox.Show("Bạn có muốn hủy kết quả cân?", "Hủy kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    InitiateMeasurementTab();
                    btnCancelItem_Click(sender, e);
                }
            }
        }

        private void btnConfirmMaterial_Click(object sender, EventArgs e)
        {
            if (this.grvMaterialTable.SelectedRows != null && this.grvMaterialTable.SelectedRows.Count > 0)
            {
                var row = this.grvMaterialTable.SelectedRows[0];
                if (Resource.Message_vi.ConfirmMaterialSuccess.Equals(row.Cells[(int)MaterialTableColumn.Status].Value))
                {
                    return;
                }

                if (!string.IsNullOrEmpty(this.txtMaterialStatus.Text) && this.txtMaterialStatus.Text.Equals(Resource.Message_vi.ConfirmMaterialSuccess))
                {
                    double doneQuantity = 0;
                    double totalQuantity = 0;

                    #region Check total quantity
                    try
                    {
                        totalQuantity = double.Parse(this.txtMeasureQuantity.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Số lượng cân không phù hợp", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    #endregion

                    #region Update done quantity
                    var measureType = (string)this.cbxMeasureUnit.SelectedItem;
                    var doneMaterial = false;
                    var realWeightDone = double.Parse(this.txtMeasurementDigit.Text);
                    switch (measureType)
                    {
                        case "Cây":
                            doneQuantity = (double)row.Cells[(int)MaterialTableColumn.DoneQuantity].Value;
                            doneQuantity = doneQuantity + 1;
                            if (doneQuantity == totalQuantity)
                            {
                                doneMaterial = true;
                            }
                            row.Cells[(int)MaterialTableColumn.RealDone].Value = (double)row.Cells[(int)MaterialTableColumn.RealDone].Value + realWeightDone;
                            break;
                        case "Kg":
                            doneQuantity = realWeightDone;
                            doneMaterial = true;
                            row.Cells[(int)MaterialTableColumn.RealDone].Value = doneQuantity;
                            break;
                        default:
                            break;
                    }

                    row.Cells[(int)MaterialTableColumn.DoneQuantity].Value = doneQuantity;

                    #endregion

                    if (doneMaterial)
                    {
                        row.Cells[(int)MaterialTableColumn.Status].Value = Resource.Message_vi.ConfirmMaterialSuccess;

                        var currentIndexRow = this.grvMaterialTable.Rows.IndexOf(row);
                        ClearMeasurementResultField();
                        if (currentIndexRow < this.grvMaterialTable.Rows.Count - 1)
                        {
                            this.grvMaterialTable.Rows[currentIndexRow + 1].Selected = true;
                        }
                    }

                    this.txtMeasurementDigit.Text = "0.0";
                    this.txtMaterialStatus.Clear();
                    return;
                }
            }

            MessageBox.Show("Kết quả cân không hợp lệ.", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnFinishMeasurement_Click(object sender, EventArgs e)
        {
            if (this.grvMaterialTable.Rows != null && this.grvMaterialTable.Rows.Count > 0)
            {
                double totalWeight = 0;

                //check if all material is measured properly
                bool canFinish = true;
                for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                {
                    var row = this.grvMaterialTable.Rows[i];
                    totalWeight += MeasureUtil.ConvertWeightUnit((double)row.Cells[(int)MaterialTableColumn.RealDone].Value, (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value, "kg");

                    if (!row.Cells[(int)MaterialTableColumn.Status].Value.Equals(Resource.Message_vi.ConfirmMaterialSuccess))
                    {
                        MessageBox.Show("Các chất thành phần chưa được cân thành công. Không thể hoàn tất đơn.", "Hoàn tất đơn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        canFinish = false;
                        break;
                    }
                }

                //add to database
                if (canFinish)
                {
                    #region Save measurement records

                    #region Measurement Record

                    var today = DateTime.Now;
                    var newRecord = new MeasurementRecord()
                    {
                        RecordDate = today,
                        ResultMaterialID = long.Parse((string)this.cbxStage.SelectedValue),
                        Weight = totalWeight,
                        WeightUnit = "kg",
                        ParcelCode = this.txtParcelCodePrefix.Text + this.txtParcelCode.Text,
                        Description = this.cbxMeasureType.Text
                    };
                    bool completeRecord = _measurementRecordService.Add(newRecord);
                    #endregion

                    #region Measurement Detail Record

                    var listDetailId = new List<long>();
                    if (completeRecord)
                    {
                        for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                        {
                            var row = this.grvMaterialTable.Rows[i];
                            var currentMaterialCode = (string)row.Cells[(int)MaterialTableColumn.MaterialCode].Value;

                            if (materialParcelList != null && materialParcelList.ContainsKey(currentMaterialCode))
                            {
                                foreach (var item in materialParcelList[currentMaterialCode])
                                {
                                    var detailRecord = new MeasurementDetailRecord()
                                    {
                                        MeasurementRecordID = newRecord.ID,
                                        RawMaterialID = (long)row.Cells[(int)MaterialTableColumn.MaterialID].Value,
                                        Weight = item.Value,
                                        WeightUnit = (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value,
                                        ParcelCode = item.Key
                                    };

                                    completeRecord = _measurementDetailRecordService.Add(detailRecord);
                                    if (completeRecord)
                                    {
                                        listDetailId.Add(detailRecord.ID);

                                        //update inventory
                                        var usedInventory = _importedInventoryService.GetImportedInventories().FirstOrDefault(inv => inv.MaterialID == detailRecord.RawMaterialID && inv.ParcelCode.Equals(detailRecord.ParcelCode));
                                        if (usedInventory == null)
                                        {
                                            completeRecord = false;
                                            break;
                                        }
                                        usedInventory.Quantity = usedInventory.Quantity - MeasureUtil.ConvertWeightUnit(detailRecord.Weight, detailRecord.WeightUnit, usedInventory.WeightUnit);
                                        completeRecord = _importedInventoryService.Edit(usedInventory);

                                    }
                                    if (!completeRecord)
                                    {
                                        break;
                                    }
                                }
                                if (!completeRecord)
                                {
                                    break;
                                }
                            }

                        }
                    }
                    #endregion

                    #region Add Composition to Inventory

                    if (completeRecord)
                    {
                        var inventory = _importedInventoryService.GetImportedInventoriesByMonthAndMaterialIDAndParcelCode(today.Month, today.Year, newRecord.ResultMaterialID, newRecord.ParcelCode);
                        if (inventory == null)
                        {
                            var import = new ImportedInventory()
                            {
                                ImportDate = today,
                                MaterialID = newRecord.ResultMaterialID,
                                OriginalQuantity = newRecord.Weight,
                                ParcelCode = newRecord.ParcelCode,
                                Quantity = newRecord.Weight,
                                WeightUnit = newRecord.WeightUnit
                            };
                            completeRecord = _importedInventoryService.Add(import);
                        }
                        else
                        {
                            var currentInventory = inventory.FirstOrDefault();
                            if (currentInventory == null)
                            {
                                var import = new ImportedInventory()
                                {
                                    ImportDate = today,
                                    MaterialID = newRecord.ResultMaterialID,
                                    OriginalQuantity = newRecord.Weight,
                                    ParcelCode = newRecord.ParcelCode,
                                    Quantity = newRecord.Weight,
                                    WeightUnit = newRecord.WeightUnit
                                };
                                completeRecord = _importedInventoryService.Add(import);
                            }
                            else
                            {
                                currentInventory.OriginalQuantity = currentInventory.OriginalQuantity.Value + newRecord.Weight;
                                currentInventory.Quantity = currentInventory.Quantity + newRecord.Weight;

                                completeRecord = _importedInventoryService.Edit(currentInventory);
                            }
                        }
                    }
                    #endregion

                    #endregion

                    //rollback if fail to save records
                    if (!completeRecord)
                    {
                        _measurementRecordService.Delete(newRecord.ID);
                        foreach (var item in listDetailId)
                        {
                            _measurementDetailRecordService.Delete(item);
                        }

                        MessageBox.Show("Lưu thất bại. Vui lòng thử lại sau.", "Hoàn tất đơn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                        {
                            this.grvMaterialTable.Rows[i].Cells[(int)MaterialTableColumn.Status].Value = Resource.Message_vi.ConfirmMaterialFail;

                            this.grvMaterialTable.Rows[i].Cells[(int)MaterialTableColumn.RealDone].Value = (double)0;
                            this.grvMaterialTable.Rows[i].Cells[(int)MaterialTableColumn.DoneQuantity].Value = (double)0;
                        }

                        ClearMeasurementResultField();
                        MessageBox.Show("Đã lưu kết quả cân.", "Hoàn tất đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.cbxStage.SelectedItem = null;
                        this.grvMaterialTable.Rows.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Hiện tại không có đơn nào được cân.", "Hoàn tất đơn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbxComposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (finishInitializing && this.cbxComposition.SelectedItem != null)
            {
                //get the result material from cbxComposition
                var selectedMaterialCode = (string)this.cbxComposition.SelectedValue;
                var selectedMaterial = _materialService.GetMaterialsByCode(selectedMaterialCode).Where(m => m.IsActive).ToList();

                if (selectedMaterial != null)
                {
                    //bind data to cbxRev
                    listCbxRevItems = new BindingList<ComboBoxItem>();
                    foreach (var item in selectedMaterial)
                    {
                        listCbxRevItems.Add(new ComboBoxItem(item.ID.ToString(), item.Revision.ToString()));
                    }

                    finishInitializing = false;
                    if (listCbxRevItems.Count > 0)
                    {
                        this.cbxRev.DataSource = listCbxRevItems;
                        listCbxRevItems.ResetBindings();

                        finishInitializing = true;
                        this.cbxRev.SelectedItem = null;
                        this.cbxRev.SelectedIndex = listCbxRevItems.Count - 1;
                    }
                }
            }
            else
            {
                listCbxRevItems = new BindingList<ComboBoxItem>();
                listCbxStageItems = new BindingList<ComboBoxItem>();

                this.cbxRev.DataSource = listCbxRevItems;
                this.cbxStage.DataSource = listCbxStageItems;

                listCbxRevItems.ResetBindings();
                listCbxStageItems.ResetBindings();
            }
        }

        private void cbxRev_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the result material from cbxRev
            if (finishInitializing && this.cbxRev.SelectedItem != null)
            {
                var selectedMaterialId = long.Parse((string)this.cbxRev.SelectedValue);
                var selectedMaterial = _materialService.GetMaterialById(selectedMaterialId);

                if (selectedMaterial != null)
                {
                    listCbxStageItems = new BindingList<ComboBoxItem>();
                    listCbxStageItems.Add(new ComboBoxItem(selectedMaterial.PatId.ToString(), "Cán luyện kín"));
                    listCbxStageItems.Add(new ComboBoxItem(selectedMaterial.ID.ToString(), "Cán luyện hở"));

                    this.cbxStage.DataSource = listCbxStageItems;
                    listCbxStageItems.ResetBindings();
                }
            }
        }

        private void cbxStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isMeasuring = IsInMeasureProcess();
            DialogResult confirm = DialogResult.Yes;
            if (isMeasuring)
            {
                confirm = MessageBox.Show("Đơn hiện tại đang trong quá trình cân. Bạn có muốn hủy và chuyển sang đơn mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (!isMeasuring || confirm == DialogResult.Yes)
            {
                if (this.cbxStage.SelectedItem != null)
                {
                    var selectedMaterialId = long.Parse((string)this.cbxStage.SelectedValue);
                    //var latestParcelCode = _measurementRecordService.GetLatestParcelCodeNo(selectedMaterialId);

                    var composition = _compositionService.GetCompositionsByResultMaterialId(selectedMaterialId);

                    this.grvMaterialTable.Rows.Clear();
                    finishInitializing = false;
                    if (composition != null)
                    {
                        var listComposition = composition.ToList();
                        //bind data to grid view
                        foreach (var item in listComposition)
                        {
                            this.grvMaterialTable.Rows.Add(item.Material1.ID, item.Material1.Code, item.Weight, item.Weight, item.WeightUnit, (double)0, Resource.Message_vi.ConfirmMaterialFail, (double)0);
                        }
                    }
                    this.grvMaterialTable.ClearSelection();
                    finishInitializing = true;

                    ReCalculateConstraintWeight();

                    CheckLackMaterialAndIncreaseParcelCode(selectedMaterialId);

                }
            }
        }

        private void cbxMeasureUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsInMeasureProcess())
            {
                if (!"Cây".Equals((string)this.cbxMeasureUnit.SelectedItem))
                {
                    ReCalculateConstraintWeight();
                }
                else
                {
                    if (this.grvMaterialTable.Rows != null && this.grvMaterialTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.grvMaterialTable.Rows.Count; i++)
                        {
                            var row = this.grvMaterialTable.Rows[i];
                            row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value = row.Cells[(int)MaterialTableColumn.OriginalConstraintWeight].Value;
                        }
                        this.grvMaterialTable.ClearSelection();
                    }
                }

                if (this.cbxStage.SelectedItem != null)
                {
                    CheckLackMaterialAndIncreaseParcelCode(long.Parse((string)this.cbxStage.SelectedValue));
                }

            }
        }

        private void grvMaterialTable_SelectionChanged(object sender, EventArgs e)
        {
            if (finishInitializing && this.grvMaterialTable.SelectedRows != null && this.grvMaterialTable.SelectedRows.Count > 0)
            {
                var row = this.grvMaterialTable.SelectedRows[0];
                var currentMaterialCode = (string)row.Cells[(int)MaterialTableColumn.MaterialCode].Value;

                #region Validate

                //check lack material
                if (lackMaterialCode != null && lackMaterialCode.Count > 0)
                {
                    var allLacks = string.Join("; ", lackMaterialCode.ToArray());
                    MessageBox.Show("Trong kho không có đủ hóa chất: " + allLacks, "Phối liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ClearMeasurementResultField();
                    this.txtCurrentMaterial.Clear();
                    this.txtConstraintWeight.Clear();
                    this.txtWeightUnit.Clear();
                    return;
                }

                //check material-parcel
                if (materialParcelList.ContainsKey(currentMaterialCode))
                {
                    if (materialParcelList[currentMaterialCode].Count > 1)
                    {
                        var allParcel = "";
                        foreach (var item in materialParcelList[currentMaterialCode])
                        {
                            allParcel = allParcel + item.Key + "; ";
                        }
                        MessageBox.Show("Sử dụng hóa chất từ các lô: " + allParcel, "Phối liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // check scale capacity
                var neededQuantity = MeasureUtil.ConvertWeightUnit((double)row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value, (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value, "g");
                if (neededQuantity > Properties.Settings.Default.WeightCapacity * 1000)
                {
                    this.txtMeasurementDigit.ReadOnly = false;
                }
                else
                {
                    this.txtMeasurementDigit.ReadOnly = true;
                }
                #endregion

                this.txtCurrentMaterial.Text = (string)row.Cells[(int)MaterialTableColumn.MaterialCode].Value;
                this.txtConstraintWeight.Text = ((double)row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value).ToString();
                this.txtWeightUnit.Text = (string)row.Cells[(int)MaterialTableColumn.WeightUnit].Value;
                this.txtMaterialStatus.Text = (string)row.Cells[(int)MaterialTableColumn.Status].Value;
                if (Resource.Message_vi.ConfirmMaterialSuccess.Equals(this.txtMaterialStatus.Text))
                {
                    this.txtMeasurementDigit.Text = ((double)row.Cells[(int)MaterialTableColumn.ConstraintWeight].Value).ToString();
                }
                else
                {
                    this.txtMeasurementDigit.Text = "0.0";
                }
            }
        }

        private void grvMaterialTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnConfirmMaterial.PerformClick();
            }
        }

        private void txtMaterialStatus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMaterialStatus.Text))
            {
                if (this.txtMaterialStatus.Text.Equals(Resource.Message_vi.ConfirmMaterialFail))
                {
                    this.txtMaterialStatus.ForeColor = Color.Red;
                }
                else
                {
                    this.txtMaterialStatus.ForeColor = Color.Green;
                }
            }
        }

        private void txtMeasurementDigit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMeasurementDigit.Text))
            {
                if (!string.IsNullOrEmpty(this.txtConstraintWeight.Text))
                {
                    double resultWeight, constraintWeight;
                    try
                    {
                        resultWeight = double.Parse((string)this.txtMeasurementDigit.Text);
                        constraintWeight = double.Parse((string)this.txtConstraintWeight.Text);
                    }
                    catch (Exception)
                    {
                        resultWeight = -1;
                        constraintWeight = -1;
                    }
                    if (MeasureUtil.IsAcceptedWeight(constraintWeight, resultWeight))
                    {
                        this.txtMaterialStatus.Text = Resource.Message_vi.ConfirmMaterialSuccess;
                        return;
                    }
                }
            }
            this.txtMaterialStatus.Text = Resource.Message_vi.ConfirmMaterialFail;
        }

        private void txtMeasureQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsInMeasureProcess())
            {
                e.Handled = true;
                MessageBox.Show("Đang trong quá trình cân, không thể thay đổi số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.grvMaterialTable.ClearSelection();
            if (e.KeyChar == '.')
            {
                if (string.IsNullOrEmpty(this.txtMeasureQuantity.Text) || this.txtMeasureQuantity.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = !(Utility.Validate.NumberOnly(e.KeyChar) || e.KeyChar == '.');
        }

        private void txtMeasureQuantity_Validating(object sender, CancelEventArgs e)
        {
            bool valid = true;
            double temp = 0;
            if (string.IsNullOrEmpty(this.txtMeasureQuantity.Text))
            {
                valid = true;
            }
            else
            {
                valid = double.TryParse(this.txtMeasureQuantity.Text, out temp);
            }

            if (!valid || temp == 0)
            {
                errorProvider.SetError(this.lblMeasureQuantity, "Vui lòng nhập số");
                this.txtMeasureQuantity.Focus();
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtMeasureQuantity_Leave(object sender, EventArgs e)
        {
            double tempQuantity = 0;
            var valid = double.TryParse(this.txtMeasureQuantity.Text, out tempQuantity);

            if (valid && !IsInMeasureProcess())
            {
                ReCalculateConstraintWeight();

                if (this.cbxStage.SelectedItem != null)
                {
                    CheckLackMaterialAndIncreaseParcelCode(long.Parse((string)this.cbxStage.SelectedValue));
                }
            }
        }

        private void txtMeasurementDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnConfirmMaterial.PerformClick();
            }
        }

        #endregion

        #region Tab: Management

        #region Import excel file
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog importDialog = new OpenFileDialog();

            importDialog.InitialDirectory = "c:\\";
            importDialog.Filter = "Excel Workbook(*.xls, *.xlsx)|*.xls;*.xlsx";
            importDialog.FilterIndex = 1;
            importDialog.Multiselect = true;
            importDialog.RestoreDirectory = true;


            if (importDialog.ShowDialog() == DialogResult.OK)
            {
                bool isValid = false;
                listErrorFile = new List<ComboBoxItem>();
                foreach (var file in importDialog.FileNames)
                {
                    string filePath = file;
                    string extension = Path.GetExtension(filePath);
                    lblFilename.Text = filePath;

                    try
                    {
                        isValid = ReadMaterialExcelFile(filePath, extension);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra có thể do định dạng file excel chưa đúng, vui lòng thử lại. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.WriteLine(ex.Message);
                    }
                }
                listBoxErrorFiles.DataSource = listErrorFile;
                if (isValid)
                {
                    MessageBox.Show("Thêm file thành công.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra có thể do định dạng file excel chưa đúng, vui lòng thử lại. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finishInitializing = false;
                InitCompositionList();
                this.cbxComposition.SelectedItem = null;
                if (this.grvMaterialTable.Rows != null)
                {
                    this.grvMaterialTable.Rows.Clear();
                }

                InitMaterialList();
                finishInitializing = true;
            }
        }

        private bool ReadMaterialExcelFile(string path, string extension)
        {
            //connection string
            string excelConnectionString = string.Empty;
            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

            if (extension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (extension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }


            //Create Connection to Excel work book and add oledb namespace
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            try
            {
                excelConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng đóng file" + path + " trước khi import.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
                return false;
            }

            System.Data.DataTable dt = new System.Data.DataTable();

            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;

            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);



            for (int k = 1; k < t; k++)
            {
                DataSet ds = new DataSet();
                string query = string.Format("Select * from [{0}]", excelSheets[k]);


                //get revision
                int rev = 0;
                try
                {
                    rev = int.Parse(excelSheets[k][5] + "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Vui lòng kiểm tra lại file: " + path + " revision: " + rev + ". Gợi ý: tên sheet có dạng 'Rev x'", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listErrorFile.Add(new ComboBoxItem
                    {
                        Id = "",
                        Name = path 
                    });
                    return false;
                }

                //adapt datasource
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                {
                    dataAdapter.Fill(ds);
                }

                //define keo and pat
                var pat = new Material
                {
                    TypeID = (int)MaterialTypeEnum.Pat,
                    Revision = rev,
                    IsDeleted = false,
                    IsActive = true
                };

                var keo = new Material
                {
                    TypeID = (int)MaterialTypeEnum.Keo,
                    Revision = rev,
                    PatId = pat.ID,
                    IsDeleted = false,
                    IsActive = true
                };

                //table in 1 rev
                var table = 0;
                int i = 0;
                var isIn_ms = false;
                var isIn_ten = false;
                var isIn_canluyenkin = false;
                var isIn_maso = false;
                var isIn_subtotal = false;

                List<long> listMaterialId = new List<long>();
                List<long> listCompositionId = new List<long>();

                foreach (var row in ds.Tables[0].Rows)
                {
                    if (i < ds.Tables[0].Rows.Count)
                    {
                        if ("ms".Equals(ds.Tables[0].Rows[i][2].ToString().Trim().ToLower()))
                        {
                            keo.Code = ds.Tables[0].Rows[i][3].ToString();
                            isIn_ms = true;
                        }

                        if ("tên".Equals(ds.Tables[0].Rows[i][2].ToString().Trim().ToLower()))
                        {
                            keo.Name = ds.Tables[0].Rows[i][3].ToString();
                            isIn_ten = true;
                        }


                        if ("cán luyện kín".Equals(ds.Tables[0].Rows[i][0].ToString().Trim().ToLower()))
                        {
                            isIn_canluyenkin = true;
                            pat.Code = ds.Tables[0].Rows[i][2].ToString();
                            pat.Name = ds.Tables[0].Rows[i][2].ToString();

                            //check if pat and keo is existed
                            //thinking.............................
                            var isPatExisted = _materialService.IsExisted(pat.Code);
                            var isKeoExisted = _materialService.IsExisted(keo.Code);



                            //add pat and keo
                            if (!_materialService.Add(pat))
                            {
                                pat.ID = _materialService.GetMaterialByCodeAndRev(pat.Code, rev).ID;
                            }
                            else
                            {
                                listMaterialId.Add(pat.ID);
                            }
                            keo.PatId = pat.ID;
                            if (!_materialService.Add(keo))
                            {
                                keo.ID = _materialService.GetMaterialByCodeAndRev(keo.Code, rev).ID;
                            }
                            else
                            {
                                listMaterialId.Add(keo.ID);
                            }
                        }

                        if ("mã số".Equals(ds.Tables[0].Rows[i][0].ToString().Trim().ToLower()))
                        {
                            isIn_maso = true;
                            //increase i to move current possion to data row, table to idenity which is pat, keo
                            table++;
                            i++;

                            Console.WriteLine("---------------rev-------" + rev + "table: " + table);
                            while (!"subtotal".Equals(ds.Tables[0].Rows[i][1].ToString().Trim().ToLower()))
                            {
                                isIn_subtotal = true;
                                var code = ds.Tables[0].Rows[i][0].ToString();
                                var name = ds.Tables[0].Rows[i][1].ToString();
                                var weigh = ds.Tables[0].Rows[i][5].ToString();
                                var unit = ds.Tables[0].Rows[i][6].ToString();
                                var isRawExisted = _materialService.IsExisted(code);

                                if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
                                {
                                    foreach (var item2 in listCompositionId)
                                    {
                                        _compositionService.Delete(item2);
                                    }
                                    for (int m = listMaterialId.Count - 1; m >= 0; m--)
                                    {
                                        _materialService.Delete(listMaterialId[m]);
                                    }
                                    listErrorFile.Add(new ComboBoxItem
                                    {
                                        Id = "",
                                        Name = path 
                                    });
                                    MessageBox.Show("Vui lòng kiểm tra lại file: " + path + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }

                                var raw = new Material
                                {
                                    Code = code,
                                    Name = name,
                                    TypeID = (int)MaterialTypeEnum.Raw,
                                    Revision = rev,
                                    IsDeleted = false,
                                    IsActive = true
                                };
                                if (!isRawExisted)
                                {
                                    _materialService.Add(raw);
                                    listMaterialId.Add(raw.ID);
                                }
                                else
                                {
                                    raw.ID = _materialService.GetMaterialsByCode(code).FirstOrDefault().ID;
                                }


                                if (table == 1)
                                {
                                    var composition1 = new Composition
                                    {
                                        ResultMaterialID = pat.ID,
                                        ComponentMaterialID = raw.ID,
                                        Weight = double.Parse(weigh),
                                        WeightUnit = unit
                                    };
                                    _compositionService.Add(composition1);
                                    listCompositionId.Add(composition1.ID);
                                }

                                if (table == 2)
                                {
                                    if (code.Equals(pat.Code))
                                    {
                                        var composition2 = new Composition
                                        {
                                            ResultMaterialID = keo.ID,
                                            ComponentMaterialID = pat.ID,
                                            Weight = double.Parse(weigh),
                                            WeightUnit = unit
                                        };
                                        _compositionService.Add(composition2);
                                        listCompositionId.Add(composition2.ID);
                                    }
                                    else
                                    {
                                        var composition2 = new Composition
                                        {
                                            ResultMaterialID = keo.ID,
                                            ComponentMaterialID = raw.ID,
                                            Weight = double.Parse(weigh),
                                            WeightUnit = unit
                                        };
                                        _compositionService.Add(composition2);
                                        listCompositionId.Add(composition2.ID);
                                    }
                                }

                                Console.WriteLine("====>" + code + " " + name + " " + weigh + " " + unit);
                                i++;
                            }
                        }
                    }
                    i++;
                } // end foreach in rows

                if (!(isIn_ms && isIn_subtotal && isIn_canluyenkin && isIn_ten && isIn_maso))
                {

                    foreach (var item2 in listCompositionId)
                    {
                        _compositionService.Delete(item2);
                    }
                    foreach (var item in listMaterialId)
                    {
                        _materialService.Delete(item);
                    }
                    listErrorFile.Add(new ComboBoxItem
                    {
                        Id = "",
                        Name = path 
                    });
                    MessageBox.Show("Vui lòng kiểm tra lại file: " + path + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listMaterialId = new List<long>();
                    listCompositionId = new List<long>();
                }
            } //end for in sheets


            excelConnection1.Close();
            return true;
        }
        #endregion

        private void btnSaveMaterialEdit_Click(object sender, EventArgs e)
        {
            var listComp = (this.cbxStageForEdit.SelectedIndex == 0) ? patComForEdit : keoComForEdit;

            //validate weight
            double newConstrainWeight = 0;
            var validWeight = double.TryParse(this.txtConstraintWeightForEdit.Text, out newConstrainWeight);
            if (!validWeight || newConstrainWeight == 0)
            {
                MessageBox.Show("Trọng lượng không phù hợp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //validate weight unit
            if (string.IsNullOrEmpty(this.txtWeightUnitForEdit.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!ValidWeightUnit.Contains(this.txtWeightUnitForEdit.Text.Trim().ToLower()))
            {
                MessageBox.Show("Đơn vị tính không phù hợp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //excute
            if (this.btnSaveMaterialEdit.Text.Equals("Lưu"))
            {
                #region 'Update' mode

                if (this.grvMaterialForEdit.SelectedRows != null && this.grvMaterialForEdit.SelectedRows.Count > 0)
                {
                    var row = this.grvMaterialForEdit.SelectedRows[0];
                    var newWeight = Math.Round(newConstrainWeight, 2);
                    var newWeightUnit = this.txtWeightUnitForEdit.Text.Trim();

                    var comp = listComp.FirstOrDefault(c => c.ComponentMaterialID == (long)row.Cells[(int)MaterialForEditTableColumn.MaterialID].Value);
                    if (comp.Weight != newWeight || comp.WeightUnit != newWeightUnit)
                    {
                        IsModified = true;

                        comp.Weight = newWeight;
                        comp.WeightUnit = newWeightUnit;

                        row.Cells[(int)MaterialForEditTableColumn.ConstraintWeight].Value = newWeight;
                        row.Cells[(int)MaterialForEditTableColumn.WeightUnit].Value = newWeightUnit;
                    }

                    this.cbxMaterialForEdit.SelectedItem = null;
                    this.txtConstraintWeightForEdit.Clear();
                    this.txtWeightUnitForEdit.Clear();

                    //swith from 'update' to 'add'
                    this.btnSaveMaterialEdit.Text = "Thêm";
                    this.cbxMaterialForEdit.Enabled = true;
                }


                #endregion
            }
            else
            {
                #region 'Add' mode

                if (this.cbxStageForEdit.SelectedItem != null)
                {
                    //validate material
                    if (this.cbxMaterialForEdit.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn hóa chất thành phần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    var material = _materialService.GetMaterialsByCode((string)this.cbxMaterialForEdit.SelectedValue).FirstOrDefault();
                    if (material == null)
                    {
                        MessageBox.Show("Hóa chất không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (listComp.FirstOrDefault(c => c.ComponentMaterialID == material.ID) != null)
                    {
                        MessageBox.Show(material.Code + " đã có trong đơn, không thể thêm 2 hóa chất trùng nhau.", "Thêm hóa chất", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //add
                    this.grvMaterialForEdit.Rows.Add((long)0, material.ID, material.Code, Math.Round(newConstrainWeight, 2), "g");
                    var comp = new Composition()
                    {
                        ComponentMaterialID = material.ID,
                        Material1 = material,
                        ResultMaterialID = long.Parse((string)this.cbxStageForEdit.SelectedValue),
                        Weight = Math.Round(newConstrainWeight, 2),
                        WeightUnit = this.txtWeightUnitForEdit.Text
                    };
                    listComp.Add(comp);
                    IsModified = true;
                }

                #endregion
            }

        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (this.grvMaterialForEdit.SelectedRows != null && this.grvMaterialForEdit.SelectedRows.Count > 0)
            {
                var listComp = (this.cbxStageForEdit.SelectedIndex == 0) ? patComForEdit : keoComForEdit;

                if (listComp != null)
                {
                    // cannot remove pat
                    var material = _materialService.GetMaterialsByCode((string)this.grvMaterialForEdit.SelectedRows[0].Cells[(int)MaterialForEditTableColumn.MaterialCode].Value).FirstOrDefault();
                    if (material == null)
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (material.TypeID != (int)MaterialTypeEnum.Raw)
                    {
                        MessageBox.Show("Không thể xóa PAT.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //execute
                    var result = MessageBox.Show("Bạn có muốn xóa hóa chất này ra khỏi đơn?", "Xóa thành phần", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var currentSelectedIndex = this.grvMaterialForEdit.Rows.IndexOf(this.grvMaterialForEdit.SelectedRows[0]);
                        this.grvMaterialForEdit.Rows[currentSelectedIndex].Visible = false;
                        this.grvMaterialForEdit.ClearSelection();

                        var comp = listComp.FirstOrDefault(c => c.ComponentMaterialID == material.ID);
                        if (comp != null)
                        {
                            listComp.Remove(comp);
                        }

                        // clear textbox
                        this.cbxMaterialForEdit.SelectedItem = null;
                        this.txtConstraintWeightForEdit.Clear();
                        this.txtWeightUnitForEdit.Clear();

                        //swith from 'update' to 'add'
                        this.btnSaveMaterialEdit.Text = "Thêm";
                        this.cbxMaterialForEdit.Enabled = true;

                        IsModified = true;
                    }
                }
            }
        }

        private void btnCancelMaterialEdit_Click(object sender, EventArgs e)
        {
            if (this.grvMaterialForEdit.SelectedRows != null && this.grvMaterialForEdit.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có muốn hủy thay đổi?", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.cbxMaterialForEdit.SelectedItem = null;
                    this.cbxMaterialForEdit.Text = "";
                    this.txtConstraintWeightForEdit.Clear();
                    this.txtWeightUnitForEdit.Clear();

                    //switch from 'update' to 'add'
                    this.cbxMaterialForEdit.Enabled = true;
                    this.btnSaveMaterialEdit.Text = "Thêm";
                }
            }
        }

        private void btnCancelCompositionEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn hủy thay đổi?", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.cbxCompositionForEdit.SelectedItem = null;
                this.grvMaterialForEdit.Rows.Clear();

                this.cbxMaterialForEdit.SelectedItem = null;
                this.txtConstraintWeightForEdit.Clear();
                this.txtWeightUnitForEdit.Clear();

                //switch from 'update' to 'add'
                this.cbxMaterialForEdit.Enabled = true;
                this.btnSaveMaterialEdit.Text = "Thêm";

                IsModified = false;
            }
        }

        private void btnSaveCompositionEdit_Click(object sender, EventArgs e)
        {
            bool success = false;

            if (this.cbxStageForEdit.SelectedItem != null)
            {
                if (this.grvMaterialForEdit.Rows != null && this.grvMaterialForEdit.Rows.Count > 0)
                {
                    if (IsModified)
                    {

                        #region Add pat

                        if (patForEdit == null || !_materialService.Add(patForEdit))
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        #endregion

                        #region Add keo

                        keoForEdit.PatId = patForEdit.ID;
                        if (keoForEdit == null || !_materialService.Add(keoForEdit))
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        #endregion

                        #region Add Pat composition

                        if (patComForEdit == null)
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        foreach (var item in patComForEdit)
                        {
                            var comp = new Composition()
                            {
                                ComponentMaterialID = item.ComponentMaterialID,
                                ResultMaterialID = patForEdit.ID,
                                Weight = item.Weight,
                                WeightUnit = item.WeightUnit
                            };
                            if (!_compositionService.Add(comp))
                            {
                                MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        #endregion

                        #region Add Keo composition

                        if (keoComForEdit == null)
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        foreach (var item in keoComForEdit)
                        {
                            var comp = new Composition()
                            {
                                ComponentMaterialID = item.ComponentMaterialID,
                                ResultMaterialID = keoForEdit.ID,
                                Weight = item.Weight,
                                WeightUnit = item.WeightUnit
                            };

                            if (item.Material1.Code.Equals(patForEdit.Code))
                            {
                                comp.ComponentMaterialID = patForEdit.ID;
                            }

                            if (!_compositionService.Add(comp))
                            {
                                MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        #endregion

                        success = true;
                    }

                    if (this.cbxActiveRevForEdit.SelectedItem != null)
                    {
                        var activeMaterials = _materialService.GetMaterialsByCode((string)this.cbxCompositionForEdit.SelectedValue).Where(m => m.IsActive).ToList();
                        var newActiveMaterial = _materialService.GetMaterialById(long.Parse((string)this.cbxActiveRevForEdit.SelectedValue));

                        foreach (var item in activeMaterials)
                        {
                            item.IsActive = false;
                            _materialService.Edit(item);
                        }
                        newActiveMaterial.IsActive = true;
                        if (!_materialService.Edit(newActiveMaterial))
                        {
                            MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        success = true;
                    }

                }
            }

            if (success)
            {
                //reset value
                patForEdit = null;
                keoForEdit = null;
                patComForEdit = null;
                keoForEdit = null;

                //success
                MessageBox.Show("Đã lưu thành công.", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitCompositionList();
            }
        }

        private void cbxCompositionForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxCompositionForEdit.SelectedItem != null)
            {
                //get the result material from cbxComposition
                var selectedMaterialCode = (string)this.cbxCompositionForEdit.SelectedValue;
                var selectedMaterial = _materialService.GetMaterialsByCode(selectedMaterialCode).ToList();

                if (selectedMaterial != null)
                {
                    //bind data to cbxRev
                    listCbxRevItems = new BindingList<ComboBoxItem>();
                    var listRevForEdit = new BindingList<ComboBoxItem>();
                    int selectedIndex = 0;
                    foreach (var item in selectedMaterial)
                    {
                        listCbxRevItems.Add(new ComboBoxItem(item.ID.ToString(), item.Revision.ToString()));
                        listRevForEdit.Add(new ComboBoxItem(item.ID.ToString(), item.Revision.ToString()));
                        if (item.IsActive)
                        {
                            selectedIndex = listRevForEdit.Count - 1;
                        }
                    }

                    if (listCbxRevItems.Count > 0)
                    {
                        this.cbxRevisionForEdit.DataSource = listCbxRevItems;
                        listCbxRevItems.ResetBindings();
                        this.cbxRevisionForEdit.SelectedIndex = listCbxRevItems.Count - 1;

                        this.cbxActiveRevForEdit.DataSource = listRevForEdit;
                        listRevForEdit.ResetBindings();
                        this.cbxActiveRevForEdit.SelectedIndex = selectedIndex;
                    }
                }
            }
            else
            {
                listCbxRevItems = new BindingList<ComboBoxItem>();
                listCbxStageItems = new BindingList<ComboBoxItem>();

                this.cbxRevisionForEdit.DataSource = listCbxRevItems;
                this.cbxStageForEdit.DataSource = listCbxStageItems;

                listCbxRevItems.ResetBindings();
                listCbxStageItems.ResetBindings();

                this.cbxActiveRevForEdit.DataSource = new BindingList<ComboBoxItem>();
            }
        }

        private void cbxRevisionForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the result material from cbxRevisionForEdit
            if (this.cbxRevisionForEdit.SelectedItem != null)
            {
                var selectedMaterialId = long.Parse((string)this.cbxRevisionForEdit.SelectedValue);
                var selectedMaterial = _materialService.GetMaterialById(selectedMaterialId);

                if (selectedMaterial != null)
                {
                    #region Temp Obj for Edit

                    var pat = _materialService.GetMaterialById(selectedMaterial.PatId.GetValueOrDefault());
                    var rev = _materialService.GetLatestRevision(selectedMaterial.Code) + 1;
                    keoForEdit = new Material()
                    {
                        Code = selectedMaterial.Code,
                        Name = selectedMaterial.Name,
                        TypeID = (int)MaterialTypeEnum.Keo,
                        IsDeleted = false,
                        Revision = rev,
                        IsActive = false
                    };
                    patForEdit = new Material()
                    {
                        Code = pat.Code,
                        Name = pat.Name,
                        TypeID = (int)MaterialTypeEnum.Pat,
                        IsDeleted = false,
                        Revision = rev,
                        IsActive = true
                    };
                    patComForEdit = _compositionService.GetCompositionsByResultMaterialId(pat.ID).ToList();
                    keoComForEdit = _compositionService.GetCompositionsByResultMaterialId(selectedMaterialId).ToList();
                    #endregion

                    listCbxStageItems = new BindingList<ComboBoxItem>();
                    listCbxStageItems.Add(new ComboBoxItem(selectedMaterial.PatId.ToString(), "Cán luyện kín"));
                    listCbxStageItems.Add(new ComboBoxItem(selectedMaterial.ID.ToString(), "Cán luyện hở"));

                    this.cbxStageForEdit.DataSource = listCbxStageItems;
                    listCbxStageItems.ResetBindings();

                    this.cbxStageForEdit.SelectedIndex = 0;
                }
            }
        }

        private void cbxStageForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxStageForEdit.SelectedItem != null)
            {
                var listComp = (this.cbxStageForEdit.SelectedIndex == 0) ? patComForEdit : keoComForEdit;

                //bind data to grid view
                this.grvMaterialForEdit.Rows.Clear();
                if (listComp != null)
                {
                    foreach (var item in listComp)
                    {
                        this.grvMaterialForEdit.Rows.Add(item.ID, item.Material1.ID, item.Material1.Code, item.Weight, item.WeightUnit);
                    }

                    this.txtConstraintWeightForEdit.Clear();
                    this.txtWeightUnitForEdit.Clear();
                    this.cbxMaterialForEdit.SelectedItem = null;
                    this.cbxMaterialForEdit.Text = "";
                    this.cbxMaterialForEdit.Enabled = true;

                    this.grvMaterialForEdit.ClearSelection();
                    IsModified = false;
                }

            }
        }

        private void grvMaterialForEdit_SelectionChanged(object sender, EventArgs e)
        {
            if (this.grvMaterialForEdit.SelectedRows != null && this.grvMaterialForEdit.SelectedRows.Count > 0)
            {
                // display info
                var row = this.grvMaterialForEdit.SelectedRows[0];
                this.cbxMaterialForEdit.Text = (string)row.Cells[(int)MaterialForEditTableColumn.MaterialCode].Value;
                this.txtConstraintWeightForEdit.Text = ((double)row.Cells[(int)MaterialForEditTableColumn.ConstraintWeight].Value).ToString();
                this.txtWeightUnitForEdit.Text = (string)row.Cells[(int)MaterialForEditTableColumn.WeightUnit].Value;

                //switch from 'add' to 'update'
                this.cbxMaterialForEdit.Enabled = false;
                this.btnSaveMaterialEdit.Text = "Lưu";
            }
        }

        private void txtConstraintWeightForEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (string.IsNullOrEmpty(this.txtConstraintWeightForEdit.Text) || this.txtConstraintWeightForEdit.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = !(Utility.Validate.NumberOnly(e.KeyChar) || e.KeyChar == '.');
        }

        private void txtConstraintWeightForEdit_Validating(object sender, CancelEventArgs e)
        {
            bool valid = true;
            double temp = 0;
            if (string.IsNullOrEmpty(this.txtConstraintWeightForEdit.Text))
            {
                valid = true;
            }
            else
            {
                valid = double.TryParse(this.txtConstraintWeightForEdit.Text, out temp);
            }

            if (!valid || temp == 0)
            {
                errorProvider.SetError(this.lblConstraintWeightForEdit, "Vui lòng nhập số");
                this.txtConstraintWeightForEdit.Focus();
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtParcelCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Utility.Validate.NumberOnly(e.KeyChar));
        }

        private void txtParcelCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtParcelCode.Text))
            {
                this.txtParcelCode.Text = "0";
                return;
            }

            try
            {
                int code = int.Parse(this.txtParcelCode.Text);
            }
            catch (Exception)
            {
                this.txtParcelCode.Text = "0";
                return;
            }
        }

        #region Inventory
        private void btnImportInventory_Click(object sender, EventArgs e)
        {
            OpenFileDialog importDialog = new OpenFileDialog();

            importDialog.InitialDirectory = "c:\\";
            importDialog.Filter = "Excel Workbook(*.xls, *.xlsx)|*.xls;*.xlsx";
            importDialog.FilterIndex = 1;
            importDialog.RestoreDirectory = true;

            if (importDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = importDialog.FileName;
                string extension = Path.GetExtension(filePath);
                this.lblImportInventoryExcelPath.Text = filePath;

                try
                {
                    var result = ReadInventoryExcelFile(filePath, extension);
                    if (result)
                    {
                        MessageBox.Show("Thêm file thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra. Xin kiểm tra định dạng file excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Vui lòng nhập file excel đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ReadInventoryExcelFile(string path, string extension)
        {
            #region connection part
            //connection string
            string excelConnectionString = string.Empty;
            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

            if (extension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (extension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }


            //Create Connection to Excel work book and add oledb namespace
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            try
            {
                excelConnection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng đóng file exel trước khi import.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            #endregion

            #region read file

            System.Data.DataTable dt = new System.Data.DataTable();

            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;

            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);



            //get data in sheet #1
            DataSet ds = new DataSet();
            string query = string.Format("Select * from [{0}]", excelSheets[0]);


            //adapt datasource
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(ds);
            }
            int i = 0;
            int j = 0;
            bool isCorrectFormat = false;
            foreach (var row in ds.Tables[0].Rows)
            {
                if (i < ds.Tables[0].Rows.Count)
                {
                    for (int k = 0; k < ds.Tables[0].Rows[i].ItemArray.Count(); k++)
                    {
                        if ("VoucherTypeID".Equals(ds.Tables[0].Rows[i][k].ToString().Trim()))
                        {
                            j = k;
                            break;
                        }
                    }

                    if ("VoucherTypeID".Equals(ds.Tables[0].Rows[i][j].ToString().Trim()))
                    {
                        i += 2;
                        isCorrectFormat = true;
                        while (!"".Equals(ds.Tables[0].Rows[i][j].ToString().Trim().ToLower()))
                        {
                            var vDate = ds.Tables[0].Rows[i][j + 2].ToString().Trim();
                            var inventoryId = ds.Tables[0].Rows[i][j + 13].ToString().Trim();
                            var unit = ds.Tables[0].Rows[i][j + 14].ToString().Trim();
                            var cQuantity = ds.Tables[0].Rows[i][j + 18].ToString().Trim();
                            var locationNo = ds.Tables[0].Rows[i][j + 23].ToString().Trim();

                            double quantity = 0;
                            DateTime voucherDate = new DateTime();
                            try
                            {
                                quantity = double.Parse(cQuantity.Trim());
                                voucherDate = DateTime.Parse(vDate);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                MessageBox.Show("Một trong các phần tử của file excel không đúng định dạng.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                            var material = _materialService.GetMaterialsByCode(inventoryId);
                            long id = -1;
                            if (material.Count() > 0)
                            {
                                id = material.ElementAt(0).ID;
                            }
                            else
                            {
                                var newMaterial = new Material
                                {
                                    Code = inventoryId,
                                    TypeID = (int)MaterialTypeEnum.Raw,
                                    Revision = 1,
                                    IsDeleted = false,
                                    IsActive = true
                                };
                                _materialService.Add(newMaterial);
                                id = newMaterial.ID;
                            }
                            _importedInventoryService.Add(new ImportedInventory
                            {
                                MaterialID = id,
                                Quantity = quantity,
                                ImportDate = voucherDate,
                                WeightUnit = unit,
                                ParcelCode = locationNo,
                                OriginalQuantity = quantity
                            });


                            Console.WriteLine("=>> " + voucherDate + " " + inventoryId + " " + unit + " " + cQuantity + " " + locationNo);
                            i++;
                        }
                    }
                }
                i++;
            }
            if (!isCorrectFormat)
            {
                MessageBox.Show("File excel không đúng định dạng.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            excelConnection1.Close();
            return true;
            #endregion
        }

        //import current inventory
        private void btnImportInventory2_Click(object sender, EventArgs e)
        {
            OpenFileDialog importDialog = new OpenFileDialog();

            importDialog.InitialDirectory = "c:\\";
            importDialog.Filter = "Excel Workbook(*.xls, *.xlsx)|*.xls;*.xlsx";
            importDialog.FilterIndex = 1;
            importDialog.RestoreDirectory = true;

            if (importDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = importDialog.FileName;
                string extension = Path.GetExtension(filePath);
                this.lblRemainInventoryExcelPath.Text = filePath;

                try
                {
                    var result = ReadCurrentInventoryExcelFile(filePath, extension);
                    if (result)
                    {
                        MessageBox.Show("Thêm file thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra. Xin kiểm tra định dạng file excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Vui lòng nhập file excel đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        private bool ReadCurrentInventoryExcelFile(string path, string extension)
        {
            #region connection part
            //connection string
            string excelConnectionString = string.Empty;
            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

            if (extension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (extension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }


            //Create Connection to Excel work book and add oledb namespace
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            try
            {
                excelConnection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng đóng file exel trước khi import.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            #endregion

            #region read file

            System.Data.DataTable dt = new System.Data.DataTable();

            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;

            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);



            //get data in sheet #1
            DataSet ds = new DataSet();
            string query = string.Format("Select * from [{0}]", excelSheets[0]);


            //adapt datasource
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(ds);
            }
            int i = 0;
            bool isCorrectFormat = false;
            foreach (var row in ds.Tables[0].Rows)
            {
                if (i < ds.Tables[0].Rows.Count)
                {
                    if ("stt".Equals(ds.Tables[0].Rows[i][0].ToString().Trim().ToLower()))
                    {
                        isCorrectFormat = true;
                        var importDate = ds.Tables[0].Rows[i - 1][8].ToString().Trim();
                        i += 2;
                        while (!"".Equals(ds.Tables[0].Rows[i][1].ToString().Trim()))
                        {
                            var inventoryId = ds.Tables[0].Rows[i][1].ToString().Trim();
                            var name = ds.Tables[0].Rows[i][2].ToString().Trim();
                            var unit = ds.Tables[0].Rows[i][3].ToString().Trim();
                            var cQuantity = ds.Tables[0].Rows[i][5].ToString().Trim();
                            var parcelCode = ds.Tables[0].Rows[i][8].ToString().Trim();

                            double quantity = 0;
                            DateTime voucherDate = new DateTime();
                            try
                            {
                                quantity = double.Parse(cQuantity.Trim());
                                voucherDate = DateTime.ParseExact(importDate, "dd/MM/yyyy", null);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                MessageBox.Show("Một trong các phần tử của file excel không đúng định dạng.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                            var material = _materialService.GetMaterialsByCode(inventoryId);
                            long id = -1;
                            if (material.Count() > 0)
                            {
                                id = material.ElementAt(0).ID;
                            }
                            else
                            {
                                var newMaterial = new Material
                                {
                                    Code = inventoryId,
                                    Name = name,
                                    TypeID = (int)MaterialTypeEnum.Raw,
                                    Revision = 1, //default, revision of raw is not important!
                                    IsDeleted = false,
                                    IsActive = true
                                };
                                _materialService.Add(newMaterial);
                                id = newMaterial.ID;
                            }
                            _importedInventoryService.Add(new ImportedInventory
                            {
                                MaterialID = id,
                                Quantity = quantity,
                                ImportDate = voucherDate,
                                WeightUnit = unit,
                                ParcelCode = parcelCode,
                                OriginalQuantity = quantity
                            });


                            Console.WriteLine("=>> " + voucherDate + " " + inventoryId + " " + unit + " " + cQuantity + " " + parcelCode);
                            i++;
                        }


                    }
                }
                i++;
            }
            if (!isCorrectFormat)
            {
                MessageBox.Show("File excel không đúng định dạng.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            excelConnection1.Close();
            return true;
            #endregion
        }

        #endregion

        #endregion

        #region Tab: Setting

        private void btnSaveScaleSetting_Click(object sender, EventArgs e)
        {
            double deviation = 0;
            double scaleCapacity = 0;

            //validate
            try
            {
                deviation = double.Parse(this.txtWeightDeviation.Text);
                scaleCapacity = double.Parse(this.txtWeightCapacity.Text);
            }
            catch (Exception)
            {
                this.txtWeightDeviation.Text = Math.Round(Properties.Settings.Default.WeightDeviation, 1).ToString();
                this.txtWeightCapacity.Text = Math.Round(Properties.Settings.Default.WeightCapacity, 1).ToString();
                MessageBox.Show("Số không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //save
            try
            {
                Properties.Settings.Default.WeightDeviation = deviation;
                Properties.Settings.Default.WeightCapacity = scaleCapacity;
                Properties.Settings.Default.Save();
                MessageBox.Show("Đã lưu thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancelScaleSetting_Click(object sender, EventArgs e)
        {
            this.txtWeightDeviation.Text = Math.Round(Properties.Settings.Default.WeightDeviation, 1).ToString();
            this.txtWeightCapacity.Text = Math.Round(Properties.Settings.Default.WeightCapacity, 1).ToString();
        }

        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            this.txtCurrentPassword.Clear();
            this.txtNewPassword.Clear();
            this.txtConfirmingPassword.Clear();
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            if (this.txtCurrentPassword.Text.Equals(this.currentUser.Password))
            {
                if (this.txtNewPassword.Text.Equals(this.txtConfirmingPassword.Text))
                {
                    var newAccountInfo = new User()
                    {
                        Username = this.currentUser.Username,
                        Password = this.txtNewPassword.Text
                    };
                    if (_userService.Edit(newAccountInfo))
                    {
                        this.txtCurrentPassword.Clear();
                        this.txtNewPassword.Clear();
                        this.txtConfirmingPassword.Clear();
                        MessageBox.Show("Đổi mật khẩu thành công.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không đúng.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            #region Validate

            if (string.IsNullOrEmpty(this.txtNewAccUserName.Text) || string.IsNullOrEmpty(this.txtNewAccPassword.Text) || string.IsNullOrEmpty(this.txtNewAccConfirmPassword.Text))
            {
                MessageBox.Show("Thông tin tài khoản không được để trống.", "Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.txtNewAccUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên tài khoản không được để trống.", "Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!this.txtNewAccPassword.Text.Equals(this.txtNewAccConfirmPassword.Text))
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng.", "Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion

            var newAccount = new User
            {
                Username = this.txtNewAccUserName.Text,
                Password = this.txtNewAccPassword.Text,
                Role = int.Parse((string)this.cbxNewAccRole.SelectedValue)
            };

            if (!_userService.Add(newAccount))
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Thêm tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.grvAccount.Rows.Add(newAccount.Username, newAccount.Role == (int)RoleEnum.Admin ? "******" : newAccount.Password, Enum.GetName(typeof(RoleEnum), newAccount.Role));
            MessageBox.Show("Thêm tài khoản thành công.", "Thêm tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelAddingAccount_Click(object sender, EventArgs e)
        {
            this.txtNewAccUserName.Clear();
            this.txtNewAccPassword.Clear();
            this.txtNewAccConfirmPassword.Clear();
        }

        #endregion

        #region Tab: Report

        #region Month report

        private void btnExportReportFile_Click(object sender, EventArgs e)
        {
            BackgroundWorker bwMonthReport = new BackgroundWorker();

            bwMonthReport.DoWork += bwMonthReport_DoWork;
            bwMonthReport.RunWorkerCompleted += bwMonthReport_RunWorkerCompleted;

            this.btnExportMonthReport.Enabled = false;
            this.loadingBar.Show();
            bwMonthReport.RunWorkerAsync();
        }

        void bwMonthReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnExportMonthReport.Enabled = true;
            this.loadingBar.Hide();
        }

        void bwMonthReport_DoWork(object sender, DoWorkEventArgs e)
        {
            string txtMonth = string.Empty;
            this.cbxMonthInventory.Invoke(new MethodInvoker(delegate
            {
                txtMonth = this.cbxMonthInventory.Text;
            }));
            string txtYear = string.Empty;
            this.cbxMonthInventory.Invoke(new MethodInvoker(delegate
            {
                txtYear = this.cbxYearInventory.Text;
            }));

            var currentTime = DateTime.Now;
            var month = int.Parse(txtMonth);
            var year = int.Parse(txtYear);

            if (month >= currentTime.Month - 1)
            {
                ExecuteMonthReport(month, year);
            }
            ExportReportFile(month, year);
        }

        private void ExportReportFile(int month, int year)
        {
            List<InventoryFileContent> listMonthReport = new List<InventoryFileContent>();

            var listReport = _monthReportService.GetMonthReportsByMonth(month, year);
            int i = 1;
            foreach (var item in listReport)
            {
                listMonthReport.Add(new InventoryFileContent
                {
                    STT = i++,
                    Code = item.MaterialCode,
                    Name = item.MaterialName,
                    Unit = item.WeightUnit,
                    RemainQuantity = item.RemainQuantity,
                    RemainTotal = 0,
                    ImportQuantity = item.ImportQuantity,
                    ImportTotal = 0,
                    ExportQuantity = item.ExportQuantity,
                    ExportTotal = 0,
                    LastQuantity = item.RemainQuantity + item.ImportQuantity - item.ExportQuantity,
                    LastTotal = 0,
                    ParcelCode = item.ParcelCode
                });
            }


            System.Data.DataTable TblInventoryItem = new System.Data.DataTable();
            using (var reader = ObjectReader.Create(listMonthReport, "STT", "Code", "Name", "Unit", "RemainQuantity", "RemainTotal",
                "ImportQuantity", "ImportTotal", "ExportQuantity", "ExportTotal", "LastQuantity", "LastTotal", "ParcelCode"))
            {
                TblInventoryItem.Load(reader);
            }

            TblInventoryItem.Columns["STT"].Caption = "STT";
            TblInventoryItem.Columns["Code"].Caption = "Mã hàng";
            TblInventoryItem.Columns["Name"].Caption = "Tên hàng";
            TblInventoryItem.Columns["Unit"].Caption = "ĐVT";
            TblInventoryItem.Columns["RemainQuantity"].Caption = "Tồn đầu kỳ";
            TblInventoryItem.Columns["RemainTotal"].Caption = "";
            TblInventoryItem.Columns["ImportQuantity"].Caption = "Nhập trong kỳ";
            TblInventoryItem.Columns["ImportTotal"].Caption = "";
            TblInventoryItem.Columns["ExportQuantity"].Caption = "Xuất trong kỳ";
            TblInventoryItem.Columns["ExportTotal"].Caption = "";
            TblInventoryItem.Columns["LastQuantity"].Caption = "Tồn cuối kỳ";
            TblInventoryItem.Columns["LastTotal"].Caption = "";
            TblInventoryItem.Columns["ParcelCode"].Caption = "Mã lô";

            string fileName = "inventory" + DateTime.Now.ToBinary().ToString();
            string ExcelFilePath = "C:\\";
            string[] sheetName = { "BÁO CÁO NHẬP XUẤT TỒN" };

            bool exit = false;
            this.Invoke((MethodInvoker)delegate
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel files (*.xls)|*.xls";
                    dialog.FilterIndex = 1;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelFilePath = dialog.FileName;
                    }
                    else
                    {
                        exit = true;
                    }
                }
            });
            if (exit)
            {
                return;
            }

            try
            {
                ExcelReportHelper inventoryReport = new ExcelReportHelper(ExcelFilePath, sheetName, month + "/" + year);

                inventoryReport.AddInventorySheetContent("", sheetName[0], TblInventoryItem);

                if (inventoryReport.ExportReportToExcel())
                {
                    MessageBox.Show("Xuất file thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
            }
        }

        private void ExecuteMonthReport(int month, int year)
        {
            //clear current data
            var currentMonthReport = _monthReportService.GetMonthReportsByMonth(month, year).ToList();
            if (currentMonthReport != null)
            {
                foreach (var item in currentMonthReport)
                {
                    if (!_monthReportService.Delete(item.ID))
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //get remain
            var previousMonthReport = _monthReportService.GetAllRemainPreviousMonthReport(month, year).ToList();
            if (previousMonthReport != null)
            {
                foreach (var item in previousMonthReport)
                {
                    var newReport = new MonthReport()
                    {
                        Material = item.Material,
                        MaterialId = item.MaterialId,
                        MaterialCode = item.MaterialCode,
                        MaterialName = item.MaterialName + (item.Material.TypeID == (int)MaterialTypeEnum.Raw ? "" : " rev. " + item.Material.Revision),
                        ParcelCode = item.ParcelCode,
                        RemainQuantity = MeasureUtil.ConvertWeightUnit(item.RemainQuantity + item.ImportQuantity - item.ExportQuantity, item.WeightUnit, "kg"),
                        ImportQuantity = 0,
                        ExportQuantity = 0,
                        WeightUnit = "kg",
                        ReportDate = new DateTime(year, month, 1)
                    };
                    if (!_monthReportService.AddMonthReport(month, year, newReport))
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //get import
            var importedInventory = _importedInventoryService.GetImportedInventories().Where(inv => inv.ImportDate.Month == month && inv.ImportDate.Year == year).ToList();
            if (importedInventory != null)
            {
                foreach (var item in importedInventory)
                {
                    var newReport = new MonthReport()
                    {
                        Material = item.Material,
                        MaterialId = item.MaterialID,
                        MaterialCode = item.Material.Code,
                        MaterialName = item.Material.Name + (item.Material.TypeID == (int)MaterialTypeEnum.Raw ? "" : " rev. " + item.Material.Revision),
                        ParcelCode = item.ParcelCode,
                        RemainQuantity = 0,
                        ImportQuantity = MeasureUtil.ConvertWeightUnit(item.OriginalQuantity.GetValueOrDefault(), item.WeightUnit, "kg"),
                        ExportQuantity = 0,
                        WeightUnit = "kg",
                        ReportDate = new DateTime(year, month, 1)
                    };
                    if (!_monthReportService.AddMonthReport(month, year, newReport))
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //get export
            var exportedRecord = _measurementDetailRecordService.GetMeasurementDetailRecordByMonth(month, year)
                                                                .GroupBy(r => new { r.RawMaterialID, r.ParcelCode })
                                                                .ToList();
            if (exportedRecord != null)
            {
                foreach (var item in exportedRecord)
                {
                    var newReport = new MonthReport()
                    {
                        Material = item.First().Material,
                        MaterialId = item.First().RawMaterialID,
                        MaterialCode = item.First().Material.Code,
                        MaterialName = item.First().Material.Name + (item.First().Material.TypeID == (int)MaterialTypeEnum.Raw ? "" : " rev. " + item.First().Material.Revision),
                        ParcelCode = item.Key.ParcelCode ?? "",
                        RemainQuantity = 0,
                        ImportQuantity = 0,
                        ExportQuantity = item.Sum(record => MeasureUtil.ConvertWeightUnit(record.Weight, record.WeightUnit, "kg")),
                        WeightUnit = "kg",
                        ReportDate = new DateTime(year, month, 1)
                    };
                    if (!_monthReportService.AddMonthReport(month, year, newReport))
                    {
                        MessageBox.Show("Đã xảy ra lỗi, vui lòng thử lại sau.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //var importedInventories = _importedInventoryService.GetImportedInventories().ToList();
            //var detailRecords = _measurementDetailRecordService.GetDetailRecordsByMonth(month);

            //foreach (var item in importedInventories)
            //{
            //    double rmQuantity = 0;
            //    double impQuantity = 0;
            //    double expQuantity = 0;

            //    var remain = _monthReportService.GetPreviousMonthReport(item.MaterialID, item.ParcelCode, month);
            //    if (remain != null)
            //    {
            //        rmQuantity = MeasureUtil.ConvertWeightUnit(remain.RemainQuantity, remain.WeightUnit, "kg")
            //            + MeasureUtil.ConvertWeightUnit(remain.ImportQuantity, remain.WeightUnit, "kg")
            //            + MeasureUtil.ConvertWeightUnit(remain.ExportQuantity, remain.WeightUnit, "kg");
            //    }

            //    if (item.ImportDate.Month == month)
            //    {
            //        impQuantity = MeasureUtil.ConvertWeightUnit(item.OriginalQuantity.GetValueOrDefault(), item.WeightUnit, "kg");
            //    }

            //    if (detailRecords != null)
            //    {
            //        foreach (var record in detailRecords)
            //        {
            //            if (record.RawMaterialID == item.MaterialID && record.ParcelCode == item.ParcelCode)
            //            {
            //                expQuantity = MeasureUtil.ConvertWeightUnit(record.Weight, record.Unit, "kg");
            //            }
            //        }
            //    }


            //    _monthReportService.AddMonthReport(month, year, new MonthReport
            //    {
            //        MaterialId = item.MaterialID,
            //        MaterialName = item.Material.Name,
            //        ParcelCode = item.ParcelCode,
            //        WeightUnit = "kg",
            //        MaterialCode = item.Material.Code,
            //        RemainQuantity = rmQuantity,
            //        ImportQuantity = impQuantity,
            //        ExportQuantity = expQuantity,
            //        ReportDate = DateTime.Now
            //    });
            //}
        }

        #endregion

        #region Export material report

        private void btnExportMaterialReport_Click(object sender, EventArgs e)
        {
            BackgroundWorker bwExportMaterialReport = new BackgroundWorker();

            bwExportMaterialReport.DoWork += bwExportMaterialReport_DoWork;
            bwExportMaterialReport.RunWorkerCompleted += bwExportMaterialReport_RunWorkerCompleted;

            this.btnExportMaterialReport.Enabled = false;
            this.loadingBar.Show();
            bwExportMaterialReport.RunWorkerAsync();
        }

        void bwExportMaterialReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnExportMaterialReport.Enabled = true;
            this.loadingBar.Hide();
        }

        void bwExportMaterialReport_DoWork(object sender, DoWorkEventArgs e)
        {
            string txtMonth = string.Empty;
            this.cbxMonthInventory.Invoke(new MethodInvoker(delegate
            {
                txtMonth = this.cbxMonthExport.Text;
            }));
            string txtYear = string.Empty;
            this.cbxMonthInventory.Invoke(new MethodInvoker(delegate
            {
                txtYear = this.cbxYearExport.Text;
            }));

            var currentTime = DateTime.Now;
            var month = int.Parse(txtMonth);
            var year = int.Parse(txtYear);
            var listMonthDetailRecord = _measurementDetailRecordService.GetMeasurementDetailRecordByMonth(month, year);

            string fileName = "inventory" + DateTime.Now.ToBinary().ToString();
            string ExcelFilePath = "C:\\" + fileName;
            string[] sheetName = { "BÁO CÁO XUẤT NGUYÊN VẬT LIỆU" };

            bool exit = false;
            this.Invoke((MethodInvoker)delegate
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel files (*.xls)|*.xls";
                    dialog.FilterIndex = 1;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelFilePath = dialog.FileName;
                    }
                    else
                    {
                        exit = true;
                    }
                }
            });
            if (exit)
            {
                return;
            }

            try
            {
                ExcelReportHelper exportReport = new ExcelReportHelper(ExcelFilePath, sheetName, month + "/" + year);

                exportReport.AddExportSheetContent(sheetName[0], listMonthDetailRecord);

                if (exportReport.ExportReportToExcel())
                {
                    MessageBox.Show("Xuất file thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Export production result report

        private void btnExportProductionResultReport_Click(object sender, EventArgs e)
        {
            BackgroundWorker bwExportProductionResultReport = new BackgroundWorker();

            bwExportProductionResultReport.DoWork += bwExportProductionResultReport_DoWork;
            bwExportProductionResultReport.RunWorkerCompleted += bwExportProductionResultReport_RunWorkerCompleted;

            this.btnExportProductionResultReport.Enabled = false;
            this.loadingBar.Show();
            bwExportProductionResultReport.RunWorkerAsync();
        }

        void bwExportProductionResultReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnExportProductionResultReport.Enabled = true;
            this.loadingBar.Hide();
        }

        void bwExportProductionResultReport_DoWork(object sender, DoWorkEventArgs e)
        {
            string txtMonth = string.Empty;
            this.cbxMonthProductionResult.Invoke(new MethodInvoker(delegate
            {
                txtMonth = this.cbxMonthProductionResult.Text;
            }));
            string txtYear = string.Empty;
            this.cbxYearProductionResult.Invoke(new MethodInvoker(delegate
            {
                txtYear = this.cbxYearProductionResult.Text;
            }));

            var currentTime = DateTime.Now;
            var month = int.Parse(txtMonth);
            var year = int.Parse(txtYear);
            var listMonthRecord = _measurementRecordService.GetMeasurementRecordByMonth(month, year)
                                                           .OrderBy(r => r.RecordDate)
                                                           .GroupBy(r => new
                                                           {
                                                               Date = r.RecordDate.Date,
                                                               MaterialID = r.ResultMaterialID,
                                                               ParcelCode = r.ParcelCode,
                                                               Description = r.Description
                                                           })
                                                           .ToList();
            var listRecord = new List<MeasurementRecord>();
            foreach (var item in listMonthRecord)
            {
                var record = new MeasurementRecord()
                {
                    Material = item.First().Material,
                    ResultMaterialID = item.First().ResultMaterialID,
                    RecordDate = item.Key.Date,
                    ParcelCode = item.Key.ParcelCode,
                    Weight = item.Sum(r => r.Weight),
                    WeightUnit = item.First().WeightUnit,
                    Description = item.Key.Description
                };
                listRecord.Add(record);
            }

            string fileName = "KQSX" + DateTime.Now.ToBinary().ToString();
            string ExcelFilePath = "C:\\" + fileName;
            string[] sheetName = { "BÁO CÁO KẾT QUẢ SẢN XUẤT" };

            bool exit = false;
            this.Invoke((MethodInvoker)delegate
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel files (*.xls)|*.xls";
                    dialog.FilterIndex = 1;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelFilePath = dialog.FileName;
                    }
                    else
                    {
                        exit = true;
                    }
                }
            });
            if (exit)
            {
                return;
            }

            try
            {
                ExcelReportHelper exportReport = new ExcelReportHelper(ExcelFilePath, sheetName, month + "/" + year);

                exportReport.AddProductionResultSheetContent(sheetName[0], listRecord);

                if (exportReport.ExportReportToExcel())
                {
                    MessageBox.Show("Xuất file thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #endregion

        private void panelTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void panelTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.panelTabControl.SelectedTab.Name.Equals(this.tabMeasure.Name))
            {

            }
            else if (this.panelTabControl.SelectedTab.Name.Equals(this.tabManagement.Name))
            {
                InitiateManagementTab();
            }
            else if (this.panelTabControl.SelectedTab.Name.Equals(this.tabReport.Name))
            {
                InitiateReportTab();
            }
            else if (this.panelTabControl.SelectedTab.Name.Equals(this.tabSetting.Name))
            {
                InitiateSettingTab();
            }
        }

        private void linkSignOut_Click(object sender, EventArgs e)
        {
            bool canSignOut = true;

            //confirm
            if (IsInMeasureProcess())
            {
                var rs = MessageBox.Show("Bạn có muốn hủy kết quả cân hiện tại và thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    canSignOut = false;
                }
            }

            if (canSignOut)
            {
                this.currentUser = null;

                #region Reset Form
                finishInitializing = false;
                InitiateTabControl();
                this.panelTabControl.Visible = false;

                this.txtMeasureQuantity.Text = "1"; //xong =))

                //Data binding
                InitCompositionList();
                InitMaterialList();

                //Initiate
                InitiateMeasurementTab();
                InitiateSettingTab();
                InitiateManagementTab();

                //Tab: Management
                ////enable 'add new'
                this.btnSaveMaterialEdit.Text = "Thêm";
                this.cbxMaterialForEdit.Enabled = true;

                finishInitializing = true;
                #endregion

                //Show login form
                Login();
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsInMeasureProcess())
            {
                var rs = MessageBox.Show("Bạn có muốn hủy kết quả cân hiện tại và thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Login();

            InitiateSerialPort();
        }

        #endregion

        #region Commuticate with scale
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            lock (mySerialPort)
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();

                var data = indata.Split(':')[1].Trim();

                string weight = "";
                string unit = "";
                double rsWeight = 0;
                for (int i = data.Length - 1; i >= 0; i--)
                {
                    if (data[i] == ' ')
                    {
                        unit = data.Substring(i + 1).Trim();
                        weight = data.Substring(0, i).Trim();

                        if (double.TryParse(weight, out rsWeight))
                        {
                            rsWeight = MeasureUtil.ConvertWeightUnit(rsWeight / 1000, unit, this.txtWeightUnit.Text);
                        }

                        break;
                    }
                }

                SetText(rsWeight.ToString());
            }
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtMeasurementDigit.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtMeasurementDigit.Text = text;
            }
        }
        #endregion

        private void cbxActiveRevForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



    }
}
