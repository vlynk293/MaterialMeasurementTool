using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IBaseService<E>
    {
        bool Add(E newInstance);
        bool Edit(E newInstance);
        bool Delete(long Id);
        void SaveChanges(MaterialMeasurementEntities db);
    }
}
