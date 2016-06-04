using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IImportedInventoryService : IBaseService<ImportedInventory>
    {
        IEnumerable<ImportedInventory> GetImportedInventories();

        IEnumerable<ImportedInventory> GetNotEmptyInventoriesByMaterialID(long materialID);
        
        IEnumerable<ImportedInventory> GetImportedInventoriesByMonthAndMaterialIDAndParcelCode(int month, int year, long materialId, string parcelCode);
    }
}
