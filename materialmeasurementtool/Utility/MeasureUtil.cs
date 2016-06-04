using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurementTool.Utility
{
    public class MeasureUtil
    {
        public static double ConvertWeightUnit(double weight, string originalWeightUnit, string resultWeightUnit)
        {
            double result = weight;
            var originalUnit = string.IsNullOrEmpty(originalWeightUnit) ? "" : originalWeightUnit.Trim().ToLower();
            var resultUnit = string.IsNullOrEmpty(resultWeightUnit) ? "" : resultWeightUnit.Trim().ToLower();

            if (!string.IsNullOrEmpty(originalWeightUnit) && !string.IsNullOrEmpty(resultWeightUnit)){
                switch (originalUnit)
                {
                    case "g":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "gam":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "gram":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "kg":
                        if (!resultUnit.Equals("kg"))
                        {
                            result = weight * 1000;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public static bool IsAcceptedWeight(double expectedWeight, double realWeight)
        {
            if (expectedWeight < 0 || realWeight < 0)
            {
                return false;
            }

            var min = expectedWeight - expectedWeight * Properties.Settings.Default.WeightDeviation;
            var max = expectedWeight + expectedWeight * Properties.Settings.Default.WeightDeviation;

            if (min <= realWeight && realWeight <= max)
            {
                return true;
            }

            return false;
        }
    }
}
