using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class MeasurementDetailRecordService : IMeasurementDetailRecordService
    {
        //MaterialMeasurementEntities db;
        public MeasurementDetailRecordService()
        {
            //db = _db;
        }
        public bool Add(MeasurementDetailRecord newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                db.MeasurementDetailRecords.Add(newInstance);
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(MeasurementDetailRecord newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.MeasurementDetailRecords.FirstOrDefault(m => m.ID == newInstance.ID);
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.MeasurementRecordID = newInstance.MeasurementRecordID;
                currentInstance.RawMaterialID = newInstance.RawMaterialID;
                currentInstance.Weight = newInstance.Weight;
                currentInstance.WeightUnit = newInstance.WeightUnit;

                db.Entry(currentInstance).State = System.Data.Entity.EntityState.Modified;
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(long Id)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.MeasurementDetailRecords.FirstOrDefault(m => m.ID == Id);
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

        //public List<DetailRecord> GetDetailRecordsByMonth(int month)
        //{
        //    var listRecords = db.MeasurementDetailRecords.Where(r => r.MeasurementRecord.RecordDate.Month == month)
        //        .GroupBy(r => new
        //        {
        //            r.RawMaterialID,
        //            r.ParcelCode,
        //            r.WeightUnit
        //        })
        //        .Select(g => new DetailRecord()
        //        {
        //            RawMaterialID = g.Key.RawMaterialID,
        //            ParcelCode = g.Key.ParcelCode,
        //            Unit = g.Key.WeightUnit,
        //            Weight = g.Sum(s => s.Weight),
        //        });
        //    return listRecords.ToList();
        //}

        public MeasurementDetailRecord GetLatestDetailRecord(long componentID, long recordID)
        {
            var db = new MaterialMeasurementEntities();

            var record = db.MeasurementDetailRecords.Where(r => r.MeasurementRecordID == recordID && r.RawMaterialID == componentID).OrderByDescending(r => r.ID).FirstOrDefault();
            return record;
        }

        public List<MeasurementDetailRecord> GetMeasurementDetailRecordByMonth(int month, int year)
        {
            var db = new MaterialMeasurementEntities();

            var listRecords = db.MeasurementDetailRecords.Where(r => r.MeasurementRecord.RecordDate.Month == month
                && r.MeasurementRecord.RecordDate.Year == year)
                .OrderBy(r => r.MeasurementRecord.RecordDate)
                .GroupBy(r => new
                {
                    Date = r.MeasurementRecord.RecordDate.Day,
                    ComponentMaterialID = r.RawMaterialID,
                    ParcelCode = r.ParcelCode,
                    WeightUnit = r.WeightUnit,
                    ResultMaterial = r.MeasurementRecord.Material
                }).ToList();

            var listDetailRecords = new List<MeasurementDetailRecord>();
            foreach (var item in listRecords)
            {
                listDetailRecords.Add(new MeasurementDetailRecord
                {
                    RawMaterialID = item.Key.ComponentMaterialID,
                    ParcelCode = item.Key.ParcelCode,
                    WeightUnit = item.Key.WeightUnit,
                    MeasurementRecordID = item.First().MeasurementRecordID,
                    Weight = item.Sum(r => r.Weight),
                    Material = item.First().Material,
                    MeasurementRecord = item.First().MeasurementRecord
                });
            }
            return listDetailRecords;
        }
    }
    public class DetailRecord
    {
        public long RawMaterialID { get; set; }
        public string Unit { get; set; }
        public double Weight { get; set; }
        public string ParcelCode { get; set; }
    }

    public class ExportDetailRecord
    {
        public long MeasurementRecordID { get; set; }
        public long RawMaterialID { get; set; }
        public double Weight { get; set; }
        public string WeightUnit { get; set; }
        public string ParcelCode { get; set; }
        public virtual Material Material { get; set; }
        public virtual MeasurementRecord MeasurementRecord { get; set; }
    }
}
