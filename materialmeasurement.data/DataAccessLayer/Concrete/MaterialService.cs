using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialMeasurementTool.Utility;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class MaterialService : IMaterialService
    {
        //MaterialMeasurementEntities db;
        public MaterialService()
        {
            //db = _db;
        }
        public bool Add(Material newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var material = db.Materials.FirstOrDefault(m => m.Code.Equals(newInstance.Code)
                    && (m.Revision == newInstance.Revision || m.TypeID == (int)MaterialTypeEnum.Raw));
                if (material == null)
                {
                    db.Materials.Add(newInstance);
                    SaveChanges(db);
                }
                else if ("".Equals(material.Name.Trim()))
                {
                    newInstance.ID = material.ID;
                    Edit(newInstance);
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(Material newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.Materials.FirstOrDefault(m => m.ID == newInstance.ID);
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.Name = newInstance.Name;
                currentInstance.PatId = newInstance.PatId;
                currentInstance.Revision = newInstance.Revision;
                currentInstance.Code = newInstance.Code;
                currentInstance.IsDeleted = newInstance.IsDeleted;
                currentInstance.TypeID = newInstance.TypeID;

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
                var currentInstance = db.Materials.FirstOrDefault(m => m.ID == Id);
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

        public IEnumerable<Material> GetMaterials()
        {
            var db = new MaterialMeasurementEntities();

            var materialList = db.Materials.Where(m => !m.IsDeleted);
            return materialList;
        }

        public Material GetMaterialById(long materialId)
        {
            var db = new MaterialMeasurementEntities();

            var material = db.Materials.FirstOrDefault(m => m.ID == materialId);
            return material;
        }

        //existed => true
        public bool IsExisted(string materialCode)
        {
            var db = new MaterialMeasurementEntities();

            var materials = GetMaterialsByCode(materialCode);
            if (materials.Count() > 0)
            {
                return !"".Equals(materials.ElementAt(0).Name.Trim());
            }
            return false;
        }

        public IEnumerable<Material> GetMaterialsByCode(string materialCode)
        {
            var db = new MaterialMeasurementEntities();

            var materialList = db.Materials.Where(m => m.Code.ToLower().Equals(materialCode.ToLower())).OrderBy(m => m.Revision);
            return materialList;
        }

        public Material GetMaterialByCodeAndRev(string materialCode, int rev)
        {
            var db = new MaterialMeasurementEntities();

            var material = db.Materials.Where(m => m.Code.ToLower().Equals(materialCode.ToLower()) && m.Revision == rev).FirstOrDefault();
            return material;
        }

        public int GetLatestRevision(string materialCode)
        {
            var db = new MaterialMeasurementEntities();

            var materials = db.Materials.Where(m => m.Code.Equals(materialCode)).OrderByDescending(m => m.Revision).FirstOrDefault();
            if (materials == null)
            {
                return 0;
            }
            return materials.Revision;
        }

        public void SaveChanges(MaterialMeasurementEntities db)
        {
            db.SaveChanges();
        }

    }
}
