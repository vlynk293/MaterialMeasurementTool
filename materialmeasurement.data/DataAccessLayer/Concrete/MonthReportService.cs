using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class MonthReportService:IMonthReportService
    {
       //MaterialMeasurementEntities db;

       public MonthReportService()
        {
            //this.db = db;
        }
        //we dont use this method :3
        public bool Add(MonthReport newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var monthReport = db.MonthReports.Where(i => i.MaterialId == newInstance.MaterialId
                  && i.ParcelCode == newInstance.ParcelCode && i.ReportDate == newInstance.ReportDate.Date);
                if (monthReport.Count() == 0)
                {
                    db.MonthReports.Add(newInstance);
                    SaveChanges(db);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool AddMonthReport(int month, int year, MonthReport newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var monthReport = db.MonthReports.Where(i => i.MaterialId == newInstance.MaterialId
                  && i.ParcelCode == newInstance.ParcelCode && i.ReportDate.Month == month 
                  && i.ReportDate.Year == year).FirstOrDefault();
                if (monthReport == null)
                {
                    db.MonthReports.Add(newInstance);
                    SaveChanges(db);
                }

                if (monthReport != null)
                {
                    monthReport.RemainQuantity = monthReport.RemainQuantity == 0 ? newInstance.RemainQuantity : monthReport.RemainQuantity;
                    monthReport.ImportQuantity = monthReport.ImportQuantity == 0 ? newInstance.ImportQuantity : monthReport.ImportQuantity;
                    monthReport.ExportQuantity = monthReport.ExportQuantity == 0 ? newInstance.ExportQuantity : monthReport.ExportQuantity;
                    db.Entry(monthReport).State = System.Data.Entity.EntityState.Modified;
                    SaveChanges(db);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool Edit(MonthReport newInstance)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long Id)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.MonthReports.FirstOrDefault(m => m.ID == Id);
                if (currentInstance == null)
                {
                    return false;
                }
                db.Entry(currentInstance).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void SaveChanges(MaterialMeasurementEntities db)
        {
            db.SaveChanges();
        }
        
        public MonthReport GetPreviousMonthReport(long materialId, string parcelCode, int month)
        {
            var db = new MaterialMeasurementEntities();

            var monthReport = db.MonthReports.Where(m => m.MaterialId == materialId 
                && m.ParcelCode == parcelCode && m.ReportDate.Month == month - 1).FirstOrDefault();
            return monthReport;
        }

        public IEnumerable<MonthReport> GetAllRemainPreviousMonthReport(int month, int year)
        {
            var db = new MaterialMeasurementEntities();

            var listMonthReport = db.MonthReports.Where(m => m.ReportDate.Month == month-1 
                                                          && m.ReportDate.Year == year
                                                          && (m.RemainQuantity + m.ImportQuantity - m.ExportQuantity) > 0);
            return listMonthReport;
        }

        public IEnumerable<MonthReport> GetMonthReportsByMonth(int month, int year)
        {
            var db = new MaterialMeasurementEntities();

            var listMonthReport = db.MonthReports.Where(m => m.ReportDate.Month == month && m.ReportDate.Year == year);
            return listMonthReport;
        }
    }
}
