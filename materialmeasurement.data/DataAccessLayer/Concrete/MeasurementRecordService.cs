using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class MeasurementRecordService : IMeasurementRecordService
    {
        //MaterialMeasurementEntities db;
        public MeasurementRecordService()
        {
            //db = _db;
        }

        public bool Add(MeasurementRecord newInstance)
        {
            var db = new MaterialMeasurementEntities();
 
            try
            {
                db.MeasurementRecords.Add(newInstance);
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(MeasurementRecord newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.MeasurementRecords.FirstOrDefault(m => m.ID == newInstance.ID);
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.RecordDate = newInstance.RecordDate;
                currentInstance.ResultMaterialID = newInstance.ResultMaterialID;
                currentInstance.Weight = newInstance.Weight;
                currentInstance.WeightUnit = newInstance.WeightUnit;
                currentInstance.Description = newInstance.Description;
                currentInstance.ParcelCode = newInstance.ParcelCode;

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
                var currentInstance = db.MeasurementRecords.FirstOrDefault(m => m.ID == Id);
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

        public int GetLatestParcelCodeNo(long resultMaterialId)
        {
            var db = new MaterialMeasurementEntities();

            var record = db.MeasurementRecords.Where(r => r.ResultMaterialID == resultMaterialId).OrderByDescending(r => r.ID).FirstOrDefault();
            if (record == null)
            {
                return 0;
            }
            var parcelCodeNo = record.ParcelCode.Substring(1);
            try
            {
                int result = int.Parse(parcelCodeNo);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public MeasurementRecord GetLatestRecord(long resultMaterialId)
        {
            var db = new MaterialMeasurementEntities();

            var record = db.MeasurementRecords.Where(r => r.ResultMaterialID == resultMaterialId).OrderByDescending(r => r.ID).FirstOrDefault();
            return record;
        }

        public IEnumerable<MeasurementRecord> GetMeasurementRecordByMonth(int month, int year)
        {
            var db = new MaterialMeasurementEntities();

            var listRecords = db.MeasurementRecords.Where(r => r.RecordDate.Month == month && r.RecordDate.Year == year);
            return listRecords;
        }

        public void SaveChanges(MaterialMeasurementEntities db)
        {
            db.SaveChanges();
        }
    }
}
