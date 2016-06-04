using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class CompositionService : ICompositionService
    {
        //MaterialMeasurementEntities db;
        public CompositionService()
        {
            //db = _db;
        }

        public bool Add(Composition newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                //var resultMaterial = db.Materials.FirstOrDefault(m => m.ID == newInstance.ResultMaterialID);
                //var componentMaterial = db.Materials.FirstOrDefault(m => m.ID == newInstance.ComponentMaterialID);
                //if (resultMaterial == null || componentMaterial == null)
                //{
                //    return false;
                //}

                //newInstance.Material = resultMaterial;
                //newInstance.Material1 = componentMaterial;
                var composition = db.Compositions.Where(c => c.ResultMaterialID == newInstance.ResultMaterialID && c.ComponentMaterialID == newInstance.ComponentMaterialID);
                if (composition.Count() == 0)
                {
                    db.Compositions.Add(newInstance);
                    SaveChanges(db);
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public bool Edit(Composition newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.Compositions.FirstOrDefault(m => m.ID == newInstance.ID);
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.ResultMaterialID = newInstance.ResultMaterialID;
                currentInstance.ComponentMaterialID = newInstance.ComponentMaterialID;
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
                var currentInstance = db.Compositions.FirstOrDefault(m => m.ID == Id);
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

        public IEnumerable<Composition> GetCompositionsByResultMaterialId(long rsMaterialId)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var compositions = db.Compositions.Where(c => c.ResultMaterialID == rsMaterialId);
                return compositions;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Composition GetCompositionByID(long compositionID)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var composition = db.Compositions.FirstOrDefault(c => c.ID == compositionID);
                return composition;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SaveChanges(MaterialMeasurementEntities db)
        {
            db.SaveChanges();
        }
    }
}
