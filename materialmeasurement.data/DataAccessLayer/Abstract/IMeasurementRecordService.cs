using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IMeasurementRecordService: IBaseService<MeasurementRecord>
    {
        IEnumerable<MeasurementRecord> GetMeasurementRecordByMonth(int month, int year);

        int GetLatestParcelCodeNo(long resultMaterialId);

        MeasurementRecord GetLatestRecord(long resultMaterialId);
    }
}
