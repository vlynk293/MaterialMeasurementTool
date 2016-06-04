using MaterialMeasurement.Data.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IMeasurementDetailRecordService: IBaseService<MeasurementDetailRecord>
    {
        List<MeasurementDetailRecord> GetMeasurementDetailRecordByMonth(int month, int year);

        MeasurementDetailRecord GetLatestDetailRecord(long componentID, long recordID);
    }
}
