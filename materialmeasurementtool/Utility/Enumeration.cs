using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurementTool.Utility
{
    public enum MaterialTableColumn
    {
        MaterialID = 0,
        MaterialCode = 1,
        OriginalConstraintWeight = 2,
        ConstraintWeight = 3,
        WeightUnit = 4,
        DoneQuantity = 5,
        Status = 6,
        RealDone = 7,
        ParcelCode = 8
    }

    public enum MaterialForEditTableColumn
    {
        CompositionID = 0,
        MaterialID = 1,
        MaterialCode = 2,
        ConstraintWeight = 3,
        WeightUnit = 4
    }
}
