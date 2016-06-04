using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IMaterialService: IBaseService<Material>
    {
        IEnumerable<Material> GetMaterials();

        Material GetMaterialById(long materialId);

        bool IsExisted(string materialCode);

        IEnumerable<Material> GetMaterialsByCode(string materialCode);

        Material GetMaterialByCodeAndRev(string materialCode, int rev);

        int GetLatestRevision(string materialCode);
    }
}
