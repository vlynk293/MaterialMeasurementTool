using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class ImportednventoryService : IImportedInventoryService
    {
        //MaterialMeasurementEntities db;

        public ImportednventoryService()
        {
            //this.db = db;
        }
        public bool Add(ImportedInventory newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var importedInventory = db.ImportedInventories.Where(i => i.MaterialID == newInstance.MaterialID
                    && i.ParcelCode == newInstance.ParcelCode);
                if (importedInventory.Count() == 0)
                {
                    db.ImportedInventories.Add(newInstance);
                    SaveChanges(db);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(ImportedInventory newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.ImportedInventories.FirstOrDefault(m => m.ID == newInstance.ID);
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.MaterialID = newInstance.MaterialID;
                currentInstance.ParcelCode = newInstance.ParcelCode;
                currentInstance.ImportDate = newInstance.ImportDate;
                currentInstance.Quantity = newInstance.Quantity;
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
                var currentInstance = db.ImportedInventories.FirstOrDefault(m => m.ID == Id);
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

        public IEnumerable<ImportedInventory> GetImportedInventories()
        {
            var db = new MaterialMeasurementEntities();

            var importedInventories = db.ImportedInventories;
            return importedInventories;
        }

        public IEnumerable<ImportedInventory> GetNotEmptyInventoriesByMaterialID(long materialID)
        {
            var db = new MaterialMeasurementEntities();

            var importedInventories = db.ImportedInventories.Where(i => i.MaterialID == materialID && i.Quantity > 0).OrderBy(i => i.ID);
            return importedInventories;
        }
        
        public IEnumerable<ImportedInventory> GetImportedInventoriesByMonthAndMaterialIDAndParcelCode(int month, int year, long materialId, string parcelCode)
        {
            var db = new MaterialMeasurementEntities();

            var importedInventories = db.ImportedInventories.Where(i => i.ImportDate.Month == month
                                                                     && i.ImportDate.Year == year
                                                                     && i.MaterialID == materialId
                                                                     && i.ParcelCode.ToLower().Equals(parcelCode.ToLower()));
            return importedInventories;
        }
    }
}
