using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IMonthReportService:IBaseService<MonthReport>
    {
        MonthReport GetPreviousMonthReport(long materialId, string parcelCode, int month);

        IEnumerable<MonthReport> GetAllRemainPreviousMonthReport(int month, int year);

        IEnumerable<MonthReport> GetMonthReportsByMonth(int month, int year);

        bool AddMonthReport(int month, int year, MonthReport newInstance);
    }
}
