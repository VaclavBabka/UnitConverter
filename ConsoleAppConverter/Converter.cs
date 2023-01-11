namespace UnitConverter
{
    internal class Converter
    {
        internal string Convert(string inputValue, string inputRequiredUnit)
        {
            string output = string.Empty;
            if (inputValue.Contains(' ')) 
            {
                string inputNumber = inputValue[..inputValue.IndexOf(' ')];
                string inputUnit = inputValue[(inputValue.IndexOf(' ') + 1)..];
                string inputBaseUnit = string.Empty;
                int inputPrefixBase = 0;
                string outputBaseUnit = string.Empty;
                int outputPrefixBase = 0;
                UnitTypes inputUnitType = UnitTypes.None;
                UnitTypes outputUnitType = UnitTypes.None;
                UnitList unitList = new();
                if (unitList.Exists(x => x.Prefix + x.Unit == inputUnit))
                {
                    UnitItem ui = unitList.Find(x => x.Prefix + x.Unit == inputUnit)!;
                    inputBaseUnit = ui.BaseUnitSymbol;
                    inputPrefixBase = ui.PrefixBase;
                    inputUnitType = ui.UnitType;
                }
                if (unitList.Exists(x => x.Prefix + x.Unit == inputRequiredUnit))
                {
                    UnitItem ui = unitList.Find(x => x.Prefix + x.Unit == inputRequiredUnit)!;
                    outputBaseUnit = ui.BaseUnitSymbol;
                    outputPrefixBase = ui.PrefixBase;
                    outputUnitType = ui.UnitType;
                }
                if (inputUnitType != outputUnitType || inputUnitType == UnitTypes.None || outputUnitType == UnitTypes.None)
                {
                    output = "Error - unit types different or invalid";
                }
                else
                {
                    if (double.TryParse(inputNumber, out double result))
                    {
                        output = ConvertParsed(result, inputBaseUnit, inputPrefixBase, outputBaseUnit, outputPrefixBase, inputRequiredUnit, inputUnitType);
                    }
                    else
                    {
                        output = "Error - numeric value not recognized";
                    }
                }
            }
            else
            {
                output = "Error - unrecognized input";
            }
            return output;
        }
        protected string ConvertParsed(double inputNumber, string inputBaseUnit, int inputPrefixBase, string outputBaseUnit, int outputPrefixBase, string inputRequiredUnit, UnitTypes unitType)
        {
            double result = 0;

            if (unitType == UnitTypes.Length)
            {
                result = inputNumber;
                if (inputBaseUnit == "m" && outputBaseUnit == "f") 
                {
                    result *= 3.2808399; // 1 meter = 3.2808399 feet
                }
                if (inputBaseUnit == "m" && outputBaseUnit == "i")
                {
                    result *= 39.3700787; // 1 m = 39.3700787 inches
                }
                if (inputBaseUnit == "f" && outputBaseUnit == "m")
                {
                    result *= 0.3048; // 1 foot = 0.3048 m
                }
                if (inputBaseUnit == "f" && outputBaseUnit == "i")
                {
                    result *= 12; // 1 foot = 12 inches
                }
                if (inputBaseUnit == "i" && outputBaseUnit == "m")
                {
                    result *= 0.0254; // 1 inch = 0.0254 m
                }
                if (inputBaseUnit == "i" && outputBaseUnit == "f")
                {
                    result /= 12; // 1 inch = 1/12 feet
                }
                result *= Math.Pow(10, inputPrefixBase - outputPrefixBase);
            }
            if (unitType == UnitTypes.Data)
            {
                result = inputNumber;
                if (inputBaseUnit == "b" && outputBaseUnit == "B")
                {
                    result /= 8; // 1 bit = 1/8 Byte
                }
                if (inputBaseUnit == "B" && outputBaseUnit == "b")
                {
                    result *= 8; // 1 Byte = 8 bit
                }
                result *= Math.Pow(10, inputPrefixBase - outputPrefixBase);
            }
            if (unitType == UnitTypes.Temperature)
            {
                result = inputNumber;
                if (inputBaseUnit == "C" && outputBaseUnit == "F")
                {
                    result = result * 9 / 5 + 32;
                }
                if (inputBaseUnit == "F" && outputBaseUnit == "C")
                {
                    result = (result - 32) * 5 / 9;
                }
                result *= Math.Pow(10, inputPrefixBase - outputPrefixBase);
            }
            return string.Format("{0:F2} {1}", result, inputRequiredUnit);
        }
    }
}
