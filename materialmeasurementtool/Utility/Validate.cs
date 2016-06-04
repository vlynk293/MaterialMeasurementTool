using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurementTool.Utility
{
    public class Validate
    {
        public static bool NumberOnly(char keyChar)
        {
            return char.IsDigit(keyChar) || char.IsControl(keyChar);
        }
    }
}
