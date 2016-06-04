using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface ICompositionService: IBaseService<Composition>
    {
        IEnumerable<Composition> GetCompositionsByResultMaterialId(long rsMaterialId);

        Composition GetCompositionByID(long compositionID);
    }
}
