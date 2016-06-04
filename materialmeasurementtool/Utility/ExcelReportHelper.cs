using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using System.Data;
using MaterialMeasurement.Data;


namespace MaterialMeasurementTool.Utility
{
    public class ExcelReportHelper
    {
        private Excel.Application excelApp;
        private string ExcelFilePath;
        private string[] sheetName;
        private string creatingTime;
        public ExcelReportHelper(string ExcelFilePath, string[] sheetName, string creatingTime)
        {
            try
            {
                excelApp = new Excel.Application();
                this.ExcelFilePath = ExcelFilePath;
                this.sheetName = sheetName;
                this.creatingTime = creatingTime;

                InitializeInventoryFile();
            }
            catch (Exception)
            {
                if (excelApp != null)
                {
                    Close(excelApp);
                }
            }
        }

        private void Close(Excel.Application excelApp)
        {
            excelApp.ActiveWorkbook.Close();
            excelApp.Quit();
            excelApp.Dispose();
        }

        private void InitializeInventoryFile()
        {
            try
            {
                excelApp.Workbooks.Add();
                int sheetCount = sheetName.Count() - excelApp.Worksheets.Count;
                for (int i = 0; i < sheetCount; i++)
                {
                    excelApp.Worksheets.Add();
                }
                for (int i = 0; i < sheetName.Count(); i++)
                {
                    Excel.Worksheet ws = (Excel.Worksheet)excelApp.Worksheets[i + 1];
                    ws.Name = sheetName[i];
                }
            }
            catch (Exception)
            {
                Close(excelApp);
            }
        }

        private void AddInventoryFileHeader(Excel._Worksheet workSheet)
        {

            workSheet.Cells[4, 1].Value = "BÁO CÁO NHẬP XUẤT TỒN";
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[4, 13]).Merge();

            workSheet.Cells[5, 1].Value = "Kho: Phối liệu";
            workSheet.Range(workSheet.Cells[5, 1], workSheet.Cells[5, 13]).Merge();
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[5, 1]).Font.Size = 15;

            workSheet.Cells[6, 1].Value = "Kỳ: Tháng " + this.creatingTime;
            workSheet.Cells[6, 1].Font.Size = 10;
            workSheet.Range(workSheet.Cells[6, 1], workSheet.Cells[6, 13]).Merge();

            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[8, 13]).Font.Bold = true;
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[8, 13]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[8, 13]).VerticalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]).Font.Size = 8;
            workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]).Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            BorderAround(workSheet.Range(workSheet.Cells[7, 1], workSheet.Cells[8, 13]), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black));
            workSheet.Range(workSheet.Cells[7, 5], workSheet.Cells[5, 12]).Font.Size = 8;
        }
        private void BorderAround(Excel.Range range, int colour)
        {
            range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
        }
        public void AddInventorySheetContent(string sheetHeader, string workSheetName, DataTable Tbl)
        {
            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.Worksheets[workSheetName];

            AddInventoryFileHeader(workSheet);

            // column headings
            for (int i = 0; i < 4; i++)
            {
                workSheet.Cells[7, (i + 1)].Value = Tbl.Columns[i].Caption;
                workSheet.Cells[7, (i + 1)].Font.Bold = true;
                workSheet.Cells[7, (i + 1)].Font.Size = 8;
                workSheet.Cells[7, (i + 1)].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Cells[7, (i + 1)].VerticalAlignment = XlHAlign.xlHAlignCenter;
                workSheet.Range(workSheet.Cells[7, i + 1], workSheet.Cells[8, i + 1]).Merge();
            }

            workSheet.Cells[7, 13].Value = Tbl.Columns["ParcelCode"].Caption;
            workSheet.Cells[7, 13].Font.Bold = true;
            workSheet.Cells[7, 13].Font.Size = 8;
            workSheet.Cells[7, 13].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Cells[7, 13].VerticalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[7, 13], workSheet.Cells[8, 13]).Merge();

            for (int i = 4; i < 12; i += 2)
            {
                workSheet.Cells[7, (i + 1)].Value = Tbl.Columns[i].Caption;

                workSheet.Range(workSheet.Cells[7, i + 1], workSheet.Cells[7, i + 2]).Merge();

                workSheet.Cells[8, (i + 1)].Value = "Số lượng";

                workSheet.Cells[8, (i + 2)].Value = "Thành tiền";
            }

            //Excel.Range range = workSheet.Range(workSheet.Cells[4, (i + 1)], workSheet.Cells[4, (i + 1)]);
            //BorderAround(range, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black));

            var sumRemain = 0.0;
            var sumImport = 0.0;
            var sumExport = 0.0;
            // rows
            for (int i = 0; i < Tbl.Rows.Count; i++)
            {
                // workSheet.Cells[(i + 9), 0].Value = i + 1;
                for (int j = 0; j < Tbl.Columns.Count; j++)
                {
                    workSheet.Cells[(i + 9), (j + 1)].Value = Tbl.Rows[i][j];
                    if (j == 3 || j == 5 || j == 7 || j == 9)
                    {
                        workSheet.Cells[(i + 9), (j + 2)].NumberFormat = "#,###.0";
                    }
                    else if (j == 4 || j == 6 || j == 8 || j == 10)
                    {
                        workSheet.Cells[(i + 9), (j + 2)].NumberFormat = "#,###.0";
                    }
                }
                sumRemain += double.Parse(Tbl.Rows[i][4].ToString().Trim());
                sumImport += double.Parse(Tbl.Rows[i][6].ToString().Trim());
                sumExport += double.Parse(Tbl.Rows[i][8].ToString().Trim());
            }

            var sumRow = Tbl.Rows.Count + 10;
            workSheet.Cells[sumRow, 1].Value = "TỔNG CỘNG";
            workSheet.Cells[sumRow, 1].Font.Bold = true;
            workSheet.Cells[sumRow, 1].Font.Size = 8;
            workSheet.Cells[sumRow, 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Cells[sumRow, 1].VerticalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[sumRow, 1], workSheet.Cells[sumRow, 4]).Merge();
            workSheet.Range(workSheet.Cells[sumRow, 1], workSheet.Cells[sumRow, 13]).Font.Bold = true;

            workSheet.Cells[sumRow, 5].Value = sumRemain;
            workSheet.Cells[sumRow, 7].Value = sumImport;
            workSheet.Cells[sumRow, 9].Value = sumExport;
            workSheet.Cells[sumRow, 11].Value = sumRemain + sumImport - sumExport;

            BorderAround(workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black));
            workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]).Font.Size = 8;
            workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]).Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlHairline;
            workSheet.Range(workSheet.Cells[9, 1], workSheet.Cells[sumRow, 13]).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            BorderAround(workSheet.Range(workSheet.Cells[sumRow, 1], workSheet.Cells[sumRow, 13]), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black));

            //format numbers


            //auto fit columns
            workSheet.Columns.AutoFit();

        }

        public void AddExportSheetContent(string sheetName, List<MeasurementDetailRecord> listRecordDetails)
        {
            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.Worksheets[sheetName];

            //Title
            workSheet.Cells[4, 1].Value = "BÁO CÁO XUẤT NGUYÊN VẬT LIỆU";
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[4, 13]).Merge();

            workSheet.Cells[5, 1].Value = "Kỳ: Tháng " + this.creatingTime;
            workSheet.Cells[5, 1].Font.Size = 10;
            workSheet.Range(workSheet.Cells[5, 1], workSheet.Cells[5, 13]).Merge();

            workSheet.Cells[7, 3].Value = "Nghiệp vụ(TransType)";
            workSheet.Cells[7, 3].Font.Size = 10;
            workSheet.Cells[7, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

            workSheet.Cells[7, 4].Value = "PXK";
            workSheet.Cells[7, 4].Font.Size = 10;

            workSheet.Cells[8, 3].Value = "Loại nghiệp vụ(TransTypeID)";
            workSheet.Cells[8, 3].Font.Size = 10;
            workSheet.Cells[8, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

            workSheet.Cells[8, 4].Value = "2";
            workSheet.Cells[8, 4].Font.Size = 10;

            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[8, 13]).Font.Bold = true;
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[5, 13]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[4, 1], workSheet.Cells[5, 13]).VerticalAlignment = XlHAlign.xlHAlignCenter;

            #region header
            workSheet.Cells[10, 2].Value = "Loại phiếu";
            workSheet.Cells[11, 2].Value = "VoucherTypeID";
            workSheet.Cells[12, 2].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 3].Value = "Số phiếu";
            workSheet.Cells[11, 3].Value = "VoucherNo";
            workSheet.Cells[12, 3].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 4].Value = "Ngày phiếu";
            workSheet.Cells[11, 4].Value = "VoucherDate";
            workSheet.Cells[12, 4].Value = "Kiểu ngày";

            workSheet.Cells[10, 5].Value = "Diễn giải";
            workSheet.Cells[11, 5].Value = "VoucherDesc ";
            workSheet.Cells[12, 5].Value = "Kiểu chuỗi: Max 250";

            workSheet.Cells[10, 6].Value = "Số seri";
            workSheet.Cells[11, 6].Value = "SerialNo ";
            workSheet.Cells[12, 6].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 7].Value = "Số hóa đơn";
            workSheet.Cells[11, 7].Value = "RefNo ";
            workSheet.Cells[12, 7].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 8].Value = "Loại tiền";
            workSheet.Cells[11, 8].Value = "CurrencyID";
            workSheet.Cells[12, 8].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 9].Value = "Tỷ giá";
            workSheet.Cells[11, 9].Value = "ExchangeRate";
            workSheet.Cells[12, 9].Value = "Kiểu số";

            workSheet.Cells[10, 10].Value = "Loại đối tượng";
            workSheet.Cells[11, 10].Value = "ObjectTypeID";
            workSheet.Cells[12, 10].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 11].Value = "Đối tượng";
            workSheet.Cells[11, 11].Value = "ObjectID";
            workSheet.Cells[12, 11].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 12].Value = "Người lập";
            workSheet.Cells[11, 12].Value = "EmployeeID";
            workSheet.Cells[12, 12].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 13].Value = "Kho hàng";
            workSheet.Cells[11, 13].Value = "RWareHouseID";
            workSheet.Cells[12, 13].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 14].Value = "Kho xuất(VCNB)";
            workSheet.Cells[11, 14].Value = "DWareHouseID";
            workSheet.Cells[12, 14].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 15].Value = "Mã hàng";
            workSheet.Cells[11, 15].Value = "InventoryID";
            workSheet.Cells[12, 15].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 16].Value = "ĐVT";
            workSheet.Cells[11, 16].Value = "UnitID";
            workSheet.Cells[12, 16].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 17].Value = "TK Nợ";
            workSheet.Cells[11, 17].Value = "DebitAccountID";
            workSheet.Cells[12, 17].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 18].Value = "TK Có";
            workSheet.Cells[11, 18].Value = "CreditAccountID";
            workSheet.Cells[12, 18].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 19].Value = "Số lượng";
            workSheet.Cells[11, 19].Value = "OQuantity";
            workSheet.Cells[12, 19].Value = "Kiểu số";

            workSheet.Cells[10, 20].Value = "Số lượng quy đổi";
            workSheet.Cells[11, 20].Value = "CQuantity";
            workSheet.Cells[12, 20].Value = "Kiểu số";

            workSheet.Cells[10, 21].Value = "Đơn giá";
            workSheet.Cells[11, 21].Value = "UnitPrice";
            workSheet.Cells[12, 21].Value = "Kiểu số";

            workSheet.Cells[10, 22].Value = "Thành tiền";
            workSheet.Cells[11, 22].Value = "OAmount";
            workSheet.Cells[12, 22].Value = "Kiểu số";

            workSheet.Cells[10, 23].Value = "Thành tiền quy đổi";
            workSheet.Cells[11, 23].Value = "CAmount";
            workSheet.Cells[12, 23].Value = "Kiểu số";

            workSheet.Cells[10, 24].Value = "Diễn giải chi tiết";
            workSheet.Cells[11, 24].Value = "DetailDescription";
            workSheet.Cells[12, 24].Value = "Kiểu chuỗi: Max 250";

            workSheet.Cells[10, 25].Value = "Lô";
            workSheet.Cells[11, 25].Value = "LocationNo";
            workSheet.Cells[12, 25].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 26].Value = "Ngày hết hạn";
            workSheet.Cells[11, 26].Value = "LimitDate";
            workSheet.Cells[12, 26].Value = "Kiểu ngày";

            workSheet.Cells[10, 27].Value = "Ngày sản xuất";
            workSheet.Cells[11, 27].Value = "ProDate";
            workSheet.Cells[12, 27].Value = "Kiểu ngày";

            workSheet.Cells[10, 28].Value = "Tập chí";
            workSheet.Cells[11, 28].Value = "PeriodID";
            workSheet.Cells[12, 28].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 29].Value = "Mã sản phẩm";
            workSheet.Cells[11, 29].Value = "ProductID";
            workSheet.Cells[12, 29].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 30].Value = "Lệnh sản xuất";
            workSheet.Cells[11, 30].Value = "ProOrderNo";
            workSheet.Cells[12, 30].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 31].Value = "Khoản mục 1";
            workSheet.Cells[11, 31].Value = "Ana01ID";
            workSheet.Cells[12, 31].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 32].Value = "Khoản mục 2";
            workSheet.Cells[11, 32].Value = "Ana02ID";
            workSheet.Cells[12, 32].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 33].Value = "Khoản mục 3";
            workSheet.Cells[11, 33].Value = "Ana03ID";
            workSheet.Cells[12, 33].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 34].Value = "Khoản mục 4";
            workSheet.Cells[11, 34].Value = "Ana04ID";
            workSheet.Cells[12, 34].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 35].Value = "Khoản mục 5";
            workSheet.Cells[11, 35].Value = "Ana05ID";
            workSheet.Cells[12, 35].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 36].Value = "Khoản mục 6";
            workSheet.Cells[11, 36].Value = "Ana06ID";
            workSheet.Cells[12, 36].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 37].Value = "Khoản mục 7";
            workSheet.Cells[11, 37].Value = "Ana07ID";
            workSheet.Cells[12, 37].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 38].Value = "Khoản mục 8";
            workSheet.Cells[11, 38].Value = "Ana08ID";
            workSheet.Cells[12, 38].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 39].Value = "Khoản mục 9";
            workSheet.Cells[11, 39].Value = "Ana09ID";
            workSheet.Cells[12, 39].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 40].Value = "Khoản mục 10";
            workSheet.Cells[11, 40].Value = "Ana10ID";
            workSheet.Cells[12, 40].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 41].Value = "Quy cách 1";
            workSheet.Cells[11, 41].Value = "Spec01ID";
            workSheet.Cells[12, 41].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 42].Value = "Quy cách 2";
            workSheet.Cells[11, 42].Value = "Spec02ID";
            workSheet.Cells[12, 42].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 43].Value = "Quy cách 3";
            workSheet.Cells[11, 43].Value = "Spec03ID";
            workSheet.Cells[12, 43].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 44].Value = "Quy cách 4";
            workSheet.Cells[11, 44].Value = "Spec04ID";
            workSheet.Cells[12, 44].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 45].Value = "Quy cách 5";
            workSheet.Cells[11, 45].Value = "Spec05ID";
            workSheet.Cells[12, 45].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 46].Value = "Quy cách 6";
            workSheet.Cells[11, 46].Value = "Spec06ID";
            workSheet.Cells[12, 46].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 47].Value = "Quy cách 7";
            workSheet.Cells[11, 47].Value = "Spec07ID";
            workSheet.Cells[12, 47].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 48].Value = "Quy cách 8";
            workSheet.Cells[11, 48].Value = "Spec08ID";
            workSheet.Cells[12, 48].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 49].Value = "Quy cách 9";
            workSheet.Cells[11, 49].Value = "Spec09ID";
            workSheet.Cells[12, 49].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 50].Value = "Quy cách 10";
            workSheet.Cells[11, 50].Value = "Spec10ID";
            workSheet.Cells[12, 50].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 51].Value = "Thông tin phụ chuỗi 1";
            workSheet.Cells[11, 51].Value = "VRef1";
            workSheet.Cells[12, 51].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 52].Value = "Thông tin phụ chuỗi 2";
            workSheet.Cells[11, 52].Value = "VRef2";
            workSheet.Cells[12, 52].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 53].Value = "Thông tin phụ chuỗi 3";
            workSheet.Cells[11, 53].Value = "VRef3";
            workSheet.Cells[12, 53].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 54].Value = "Thông tin phụ chuỗi 4";
            workSheet.Cells[11, 54].Value = "VRef4";
            workSheet.Cells[12, 54].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 55].Value = "Thông tin phụ chuỗi 5";
            workSheet.Cells[11, 55].Value = "VRef5";
            workSheet.Cells[12, 55].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 56].Value = "Thông tin phụ số 1";
            workSheet.Cells[11, 56].Value = "NRef1";
            workSheet.Cells[12, 56].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 57].Value = "Thông tin phụ số 2";
            workSheet.Cells[11, 57].Value = "NRef2";
            workSheet.Cells[12, 57].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 58].Value = "Thông tin phụ số 3";
            workSheet.Cells[11, 58].Value = "NRef3";
            workSheet.Cells[12, 58].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 59].Value = "Thông tin phụ số 4";
            workSheet.Cells[11, 59].Value = "NRef4";
            workSheet.Cells[12, 59].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 60].Value = "Thông tin phụ số 5";
            workSheet.Cells[11, 60].Value = "NRef5";
            workSheet.Cells[12, 60].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 61].Value = "Thông tin phụ ngày 1";
            workSheet.Cells[11, 61].Value = "DRef1";
            workSheet.Cells[12, 61].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 62].Value = "Thông tin phụ ngày 2";
            workSheet.Cells[11, 62].Value = "DRef2";
            workSheet.Cells[12, 62].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 63].Value = "Thông tin phụ ngày 3";
            workSheet.Cells[11, 63].Value = "DRef3";
            workSheet.Cells[12, 63].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 64].Value = "Thông tin phụ ngày 4";
            workSheet.Cells[11, 64].Value = "DRef4";
            workSheet.Cells[12, 64].Value = "Kiểu chuỗi: Max 20";

            workSheet.Cells[10, 65].Value = "Thông tin phụ ngày 5";
            workSheet.Cells[11, 65].Value = "DRef5";
            workSheet.Cells[12, 65].Value = "Kiểu chuỗi: Max 20";

            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[11, 65]).Font.Bold = true;
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[11, 65]).Font.Size = 10;
            workSheet.Range(workSheet.Cells[12, 2], workSheet.Cells[12, 65]).Font.Italic = true;
            workSheet.Range(workSheet.Cells[12, 2], workSheet.Cells[12, 65]).Font.Size = 8;

            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightCyan);
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[12, 65]).VerticalAlignment = XlHAlign.xlHAlignCenter;
            #endregion

            for (int i = 0; i < listRecordDetails.Count; i++)
            {
                var row = i + 13;
                //VoucherTypeID
                workSheet.Cells[row, 2].Value = "PXK";

                //VoucherNo
                var day = listRecordDetails[i].MeasurementRecord.RecordDate.Day.ToString().PadLeft(3, '0');
                var month = listRecordDetails[i].MeasurementRecord.RecordDate.Month.ToString().PadLeft(2, '0');
                var year = listRecordDetails[i].MeasurementRecord.RecordDate.Year.ToString().Substring(2, 2);
                workSheet.Cells[row, 3].Value = day + "/XKT/" + month + "/" + year;

                //VourcherDesc
                workSheet.Cells[row, 5].Value = listRecordDetails[i].MeasurementRecord.Material.TypeID == (int)MaterialTypeEnum.Keo ? "Xuất cán Keo" : "Xuất cán Pat";

                //RWareHouse
                workSheet.Cells[row, 13].Value = "PL";

                //InventoryID
                workSheet.Cells[row, 15].Value = listRecordDetails[i].Material.Code;

                //Unit
                workSheet.Cells[row, 16].Value = listRecordDetails[i].WeightUnit;

                //CQuantity
                workSheet.Cells[row, 20].Value = listRecordDetails[i].Weight;

                //LocationNO
                workSheet.Cells[row, 25].Value = listRecordDetails[i].ParcelCode;

                //ProductID
                workSheet.Cells[row, 29].Value = listRecordDetails[i].MeasurementRecord.Material.Code;
            }

            var row2 = 13 + listRecordDetails.Count;
            workSheet.Range(workSheet.Cells[10, 2], workSheet.Cells[row2, 65]).BorderAround(XlLineStyle.xlDouble, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
            workSheet.Range(workSheet.Cells[13, 2], workSheet.Cells[row2, 65]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[13, 2], workSheet.Cells[row2, 65]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[13, 2], workSheet.Cells[row2, 65]).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[13, 2], workSheet.Cells[row2, 65]).Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlHairline;

            //auto fit columns
            workSheet.Columns.AutoFit();

        }

        public void AddProductionResultSheetContent(string sheetName, List<MeasurementRecord> listRecords)
        {
            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.Worksheets[sheetName];

            var exportTime = this.creatingTime.Split('/');
            //Title
            workSheet.Cells[2, 1].Value = "DivisionID";
            workSheet.Cells[2, 2].Value = "DIGINET";
            workSheet.Cells[3, 1].Value = "TranMonth";
            workSheet.Cells[3, 2].Value = exportTime[0];
            workSheet.Cells[4, 1].Value = "TranYear";
            workSheet.Cells[4, 2].Value = exportTime[1];
            workSheet.Range(workSheet.Cells[2,1], workSheet.Cells[4,1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);

            workSheet.Cells[2, 7].Value = "PRODUCTION RESULT";
            workSheet.Range(workSheet.Cells[2, 7], workSheet.Cells[2, 8]).Merge();
            workSheet.Cells[3, 7].Value = "KẾT QUẢ SẢN XUẤT";
            workSheet.Range(workSheet.Cells[3, 7], workSheet.Cells[3, 8]).Merge();
            workSheet.Range(workSheet.Cells[2, 7], workSheet.Cells[3, 8]).Font.Bold = true;
            workSheet.Range(workSheet.Cells[2, 7], workSheet.Cells[3, 8]).Font.Size = 14;
            
            #region header
            workSheet.Cells[5, 8].Value = "MASTER";
            workSheet.Range(workSheet.Cells[5, 8], workSheet.Cells[5, 10]).Merge();
            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[5, 14]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            
            workSheet.Cells[5, 23].Value = "DETAIL";
            workSheet.Range(workSheet.Cells[5, 23], workSheet.Cells[5, 25]).Merge();
            workSheet.Range(workSheet.Cells[5, 15], workSheet.Cells[5, 30]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightCyan);
            
            workSheet.Cells[5, 34].Value = "SUB INFORMATION";
            workSheet.Range(workSheet.Cells[5, 34], workSheet.Cells[5, 36]).Merge();
            workSheet.Range(workSheet.Cells[5, 31], workSheet.Cells[5, 40]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
            
            workSheet.Cells[5, 45].Value = "ANALYSIS CODE";
            workSheet.Range(workSheet.Cells[5, 45], workSheet.Cells[5, 47]).Merge();
            workSheet.Range(workSheet.Cells[5, 41], workSheet.Cells[5, 50]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
            
            workSheet.Cells[5, 57].Value = "RECEIPT/DELIVERY INDEX";
            workSheet.Range(workSheet.Cells[5, 57], workSheet.Cells[5, 59]).Merge();
            workSheet.Range(workSheet.Cells[5, 51], workSheet.Cells[5, 61]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightPink);
            
            workSheet.Cells[5, 65].Value = "SPECIFICATION";
            workSheet.Range(workSheet.Cells[5, 65], workSheet.Cells[5, 67]).Merge();
            workSheet.Range(workSheet.Cells[5, 62], workSheet.Cells[5, 71]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);


            int col = 3;
            workSheet.Cells[7, col].Value = "Loại phiếu";
            workSheet.Cells[6, col++].Value = "Voucher Type";

            workSheet.Cells[7, col].Value = "Loại nghiệp vụ";
            workSheet.Cells[6, col++].Value = "TransType";

            workSheet.Cells[7, col].Value = "Số phiếu";
            workSheet.Cells[6, col++].Value = "Voucher No";

            workSheet.Cells[7, col].Value = "Ngày phiếu";
            workSheet.Cells[6, col++].Value = "Voucher Date";

            workSheet.Cells[7, col].Value = "Diễn giải phiếu";
            workSheet.Cells[6, col++].Value = "Voucher Description";

            workSheet.Cells[7, col].Value = "Người lập";
            workSheet.Cells[6, col++].Value = "Employee ID";

            workSheet.Cells[7, col].Value = "Loại đối tượng";
            workSheet.Cells[6, col++].Value = "Object Type ID";

            workSheet.Cells[7, col].Value = "Mã đối tượng";
            workSheet.Cells[6, col++].Value = "Object ID";

            workSheet.Cells[7, col].Value = "Nhân viên KCS";
            workSheet.Cells[6, col++].Value = "KCSEmployeeID";

            workSheet.Cells[7, col].Value = "Ngày KCS";
            workSheet.Cells[6, col++].Value = "FindDate";

            workSheet.Cells[7, col].Value = "Kỳ sản xuất";
            workSheet.Cells[6, col++].Value = "Prod Period";

            workSheet.Cells[7, col].Value = "Loại KQSX";
            workSheet.Cells[6, col++].Value = "Result Type ID";

            workSheet.Cells[7, col].Value = "Mã hàng";
            workSheet.Cells[6, col++].Value = "Inventory ID";

            workSheet.Cells[7, col].Value = "ĐVT";
            workSheet.Cells[6, col++].Value = "Unit ID";

            workSheet.Cells[7, col].Value = "Số lượng";
            workSheet.Cells[6, col++].Value = "Original Quantity";

            workSheet.Cells[7, col].Value = "Số lượng quy đổi";
            workSheet.Cells[6, col++].Value = "Converted Quantity";

            workSheet.Cells[7, col].Value = "Đơn giá";
            workSheet.Cells[6, col++].Value = "Unit Price";

            workSheet.Cells[7, col].Value = "Thành tiền";
            workSheet.Cells[6, col++].Value = "Amount";

            workSheet.Cells[7, col].Value = "Ghi chú";
            workSheet.Cells[6, col++].Value = "Note";

            workSheet.Cells[7, col].Value = "Số lô";
            workSheet.Cells[6, col++].Value = "Location No";

            workSheet.Cells[7, col].Value = "Ngày sản xuất";
            workSheet.Cells[6, col++].Value = "Production date";

            workSheet.Cells[7, col].Value = "Ngày hết hạn";
            workSheet.Cells[6, col++].Value = "Limit date";

            workSheet.Cells[7, col].Value = "Mã chất lượng";
            workSheet.Cells[6, col++].Value = "QualityID";

            workSheet.Cells[7, col].Value = "Kế hoạch sản xuất";
            workSheet.Cells[6, col++].Value = "MPSVoucherNo";

            workSheet.Cells[7, col].Value = "Lệnh sản xuất";
            workSheet.Cells[6, col++].Value = "ProOrderNo";

            workSheet.Cells[7, col].Value = "% hoàn thành";
            workSheet.Cells[6, col++].Value = "Finished Percent";

            workSheet.Cells[7, col].Value = "Mã sản phẩm";
            workSheet.Cells[6, col++].Value = "Product Code";

            workSheet.Cells[7, col].Value = "Yếu tố chi phí";
            workSheet.Cells[6, col++].Value = "Material Type";

            workSheet.Cells[7, col].Value = "Số thứ 1";
            workSheet.Cells[6, col++].Value = "Num 1";

            workSheet.Cells[7, col].Value = "Số thứ 2";
            workSheet.Cells[6, col++].Value = "Num 2";

            workSheet.Cells[7, col].Value = "Số thứ 3";
            workSheet.Cells[6, col++].Value = "Num 3";

            workSheet.Cells[7, col].Value = "Số thứ 4";
            workSheet.Cells[6, col++].Value = "Num 4";

            workSheet.Cells[7, col].Value = "Số thứ 5";
            workSheet.Cells[6, col++].Value = "Num 5";

            workSheet.Cells[7, col].Value = "Chuỗi 1";
            workSheet.Cells[6, col++].Value = "String 1";

            workSheet.Cells[7, col].Value = "Chuỗi 2";
            workSheet.Cells[6, col++].Value = "String 2";

            workSheet.Cells[7, col].Value = "Chuỗi 3";
            workSheet.Cells[6, col++].Value = "String 3";

            workSheet.Cells[7, col].Value = "Chuỗi 4";
            workSheet.Cells[6, col++].Value = "String 4";

            workSheet.Cells[7, col].Value = "Chuỗi 5";
            workSheet.Cells[6, col++].Value = "String 5";

            workSheet.Cells[7, col].Value = "Khoản mục 1";
            workSheet.Cells[6, col++].Value = "K-Code 01";

            workSheet.Cells[7, col].Value = "Khoản mục 2";
            workSheet.Cells[6, col++].Value = "K-Code 02";

            workSheet.Cells[7, col].Value = "Khoản mục 3";
            workSheet.Cells[6, col++].Value = "K-Code 03";

            workSheet.Cells[7, col].Value = "Khoản mục 4";
            workSheet.Cells[6, col++].Value = "K-Code 04";

            workSheet.Cells[7, col].Value = "Khoản mục 5";
            workSheet.Cells[6, col++].Value = "K-Code 05";

            workSheet.Cells[7, col].Value = "Khoản mục 6";
            workSheet.Cells[6, col++].Value = "K-Code 06";

            workSheet.Cells[7, col].Value = "Khoản mục 7";
            workSheet.Cells[6, col++].Value = "K-Code 07";

            workSheet.Cells[7, col].Value = "Khoản mục 8";
            workSheet.Cells[6, col++].Value = "K-Code 08";

            workSheet.Cells[7, col].Value = "Khoản mục 9";
            workSheet.Cells[6, col++].Value = "K-Code 09";

            workSheet.Cells[7, col].Value = "Khoản mục 10";
            workSheet.Cells[6, col++].Value = "K-Code 10";

            workSheet.Cells[7, col].Value = "Công thức";
            workSheet.Cells[6, col++].Value = "Formula";

            workSheet.Cells[7, col].Value = "Chỉ số 01";
            workSheet.Cells[6, col++].Value = "Num01";

            workSheet.Cells[7, col].Value = "Chỉ số 02";
            workSheet.Cells[6, col++].Value = "Num02";

            workSheet.Cells[7, col].Value = "Chỉ số 03";
            workSheet.Cells[6, col++].Value = "Num03";

            workSheet.Cells[7, col].Value = "Chỉ số 04";
            workSheet.Cells[6, col++].Value = "Num04";

            workSheet.Cells[7, col].Value = "Chỉ số 05";
            workSheet.Cells[6, col++].Value = "Num05";

            workSheet.Cells[7, col].Value = "Chỉ số 06";
            workSheet.Cells[6, col++].Value = "Num06";

            workSheet.Cells[7, col].Value = "Chỉ số 07";
            workSheet.Cells[6, col++].Value = "Num07";

            workSheet.Cells[7, col].Value = "Chỉ số 08";
            workSheet.Cells[6, col++].Value = "Num08";

            workSheet.Cells[7, col].Value = "Chỉ số 09";
            workSheet.Cells[6, col++].Value = "Num09";

            workSheet.Cells[7, col].Value = "Chỉ số 10";
            workSheet.Cells[6, col++].Value = "Num10";

            workSheet.Cells[7, col].Value = "Quy cách 1";
            workSheet.Cells[6, col++].Value = "Spec 01";

            workSheet.Cells[7, col].Value = "Quy cách 2";
            workSheet.Cells[6, col++].Value = "Spec 02";

            workSheet.Cells[7, col].Value = "Quy cách 3";
            workSheet.Cells[6, col++].Value = "Spec 03";

            workSheet.Cells[7, col].Value = "Quy cách 4";
            workSheet.Cells[6, col++].Value = "Spec 04";

            workSheet.Cells[7, col].Value = "Quy cách 5";
            workSheet.Cells[6, col++].Value = "Spec 05";

            workSheet.Cells[7, col].Value = "Quy cách 6";
            workSheet.Cells[6, col++].Value = "Spec 06";

            workSheet.Cells[7, col].Value = "Quy cách 7";
            workSheet.Cells[6, col++].Value = "Spec 07";

            workSheet.Cells[7, col].Value = "Quy cách 8";
            workSheet.Cells[6, col++].Value = "Spec 08";

            workSheet.Cells[7, col].Value = "Quy cách 9";
            workSheet.Cells[6, col++].Value = "Spec 09";

            workSheet.Cells[7, col].Value = "Quy cách 10";
            workSheet.Cells[6, col++].Value = "Spec 10";


            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[7, 71]).Font.Bold = true;
            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[7, 71]).Font.Size = 10;

            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[7, 71]).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[5, 71]).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
            workSheet.Range(workSheet.Cells[6, 3], workSheet.Cells[7, 71]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[6, 3], workSheet.Cells[7, 71]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            #endregion

            for (int i = 0; i < listRecords.Count; i++)
            {
                var row = i + 8;
                //VoucherType
                workSheet.Cells[row, 3].Value = "KQT";

                //TransType
                workSheet.Cells[row, 4].Value = "KQSX";

                //VoucherNo
                var day = listRecords[i].RecordDate.Day.ToString().PadLeft(3, '0');
                var month = listRecords[i].RecordDate.Month.ToString().PadLeft(2, '0');
                var year = listRecords[i].RecordDate.Year.ToString().Substring(2, 2);
                workSheet.Cells[row, 5].Value = day + "/KQT/" + month + "/" + year;

                //Voucher Description
                string desc = (listRecords[i].Material.TypeID == (int)MaterialTypeEnum.Pat ? "Nhập Pat " : "Nhập Keo ") + listRecords[i].Material.Code + " Rev " + listRecords[i].Material.Revision;
                if (!listRecords[i].Description.Equals("Cân thực"))
                {
                    desc = desc + " (Thí nghiệm)";
                }
                workSheet.Cells[row, 7].Value = desc;

                ////Prod Period
                //workSheet.Cells[row, 13].Value = "KY" + this.creatingTime.ToString().PadLeft(7, '0');

                //Inventory ID
                workSheet.Cells[row, 15].Value = listRecords[i].Material.Code;

                //Unit
                workSheet.Cells[row, 16].Value = listRecords[i].WeightUnit;

                //Original Quantity
                workSheet.Cells[row, 17].Value = Math.Round(listRecords[i].Weight, 1);

                //Converted Quantity
                workSheet.Cells[row, 18].Value = Math.Round(listRecords[i].Weight, 1);

                //Note
                workSheet.Cells[row, 21].Value = listRecords[i].Material.TypeID == (int)MaterialTypeEnum.Pat ? "NK PAT" : "NK KEO";

                //Location No
                workSheet.Cells[row, 22].Value = listRecords[i].ParcelCode;

                //Production date
                workSheet.Cells[row, 23].Value = listRecords[i].RecordDate.ToShortDateString();
            }

            var row2 = 8 + listRecords.Count;
            workSheet.Range(workSheet.Cells[5, 3], workSheet.Cells[row2, 30]).BorderAround(XlLineStyle.xlDouble, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
            workSheet.Range(workSheet.Cells[8, 3], workSheet.Cells[row2, 30]).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[8, 3], workSheet.Cells[row2, 30]).Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            workSheet.Range(workSheet.Cells[8, 3], workSheet.Cells[row2, 30]).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            workSheet.Range(workSheet.Cells[8, 3], workSheet.Cells[row2, 30]).Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlHairline;

            //auto fit columns
            workSheet.Columns.AutoFit();

        }

        public bool ExportReportToExcel()
        {
            if (ExcelFilePath != null && ExcelFilePath.Trim().Length > 0)
            {
                try
                {
                    excelApp.ActiveWorkbook.SaveAs(ExcelFilePath, XlFileFormat.xlExcel8);
                    Close(excelApp);

                    return true; //success
                }
                catch (Exception ex)
                {
                    Close(excelApp);
                    return false;
                }
            }
            return false;
        }


    }

    public class InventoryFileContent
    {
        public int STT { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double RemainQuantity { get; set; }
        public double RemainTotal { get; set; }
        public double ImportQuantity { get; set; }
        public double ImportTotal { get; set; }
        public double ExportQuantity { get; set; }
        public double ExportTotal { get; set; }
        public double LastQuantity { get; set; }
        public double LastTotal { get; set; }
        public string ParcelCode { get; set; }
    }

    public class ExportFileContent
    {
        public string VoucherTypeID { get; set; }
        public string VoucherNo { get; set; }

    }
}
