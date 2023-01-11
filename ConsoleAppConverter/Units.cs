namespace UnitConverter
{
    internal class Prefix
    {
        internal string PrefixName { get; set; }
        internal string PrefixSymbol { get; set; }
        internal int PrefixBase { get; set; }
    }
    internal class PrefixList : List<Prefix>
    {
        internal PrefixList()
        {
            // source: https://en.wikipedia.org/wiki/Metric_prefix#List_of_SI_prefixes
            Add(new Prefix { PrefixName = "quetta", PrefixSymbol = "Q", PrefixBase = 30 });
            Add(new Prefix { PrefixName = "ronna", PrefixSymbol = "R", PrefixBase = 27 });
            Add(new Prefix { PrefixName = "yotta", PrefixSymbol = "Y", PrefixBase = 24 });
            Add(new Prefix { PrefixName = "zetta", PrefixSymbol = "Z", PrefixBase = 21 });
            Add(new Prefix { PrefixName = "exa", PrefixSymbol = "E", PrefixBase = 18 });
            Add(new Prefix { PrefixName = "peta", PrefixSymbol = "P", PrefixBase = 15 });
            Add(new Prefix { PrefixName = "tera", PrefixSymbol = "T", PrefixBase = 12 });
            Add(new Prefix { PrefixName = "giga", PrefixSymbol = "G", PrefixBase = 9 });
            Add(new Prefix { PrefixName = "mega", PrefixSymbol = "M", PrefixBase = 6 });
            Add(new Prefix { PrefixName = "kilo", PrefixSymbol = "k", PrefixBase = 3 });
            Add(new Prefix { PrefixName = "hecto", PrefixSymbol = "h", PrefixBase = 2 });
            Add(new Prefix { PrefixName = "deca", PrefixSymbol = "da", PrefixBase = 1 });
            Add(new Prefix { PrefixName = "deci", PrefixSymbol = "d", PrefixBase = -1 });
            Add(new Prefix { PrefixName = "centi", PrefixSymbol = "c", PrefixBase = -2 });
            Add(new Prefix { PrefixName = "milli", PrefixSymbol = "m", PrefixBase = -3 });
            Add(new Prefix { PrefixName = "micro", PrefixSymbol = "μ", PrefixBase = -6 });
            Add(new Prefix { PrefixName = "nano", PrefixSymbol = "n", PrefixBase = -9 });
            Add(new Prefix { PrefixName = "pico", PrefixSymbol = "p", PrefixBase = -12 });
            Add(new Prefix { PrefixName = "femto", PrefixSymbol = "f", PrefixBase = -15 });
            Add(new Prefix { PrefixName = "atto", PrefixSymbol = "a", PrefixBase = -18 });
            Add(new Prefix { PrefixName = "zepto", PrefixSymbol = "z", PrefixBase = -21 });
            Add(new Prefix { PrefixName = "yocto", PrefixSymbol = "y", PrefixBase = -24 });
            Add(new Prefix { PrefixName = "ronto", PrefixSymbol = "r", PrefixBase = -27 });
            Add(new Prefix { PrefixName = "quecto", PrefixSymbol = "q", PrefixBase = -30 });
        }
    }
    internal enum UnitTypes
    {
        None = 0,
        Length = 1,
        Data = 2,
        Temperature = 3
    }
    internal class BaseUnit
    {
        internal string BaseUnitNameSingular { get; set; }
        internal string BaseUnitNamePlural { get; set; }
        internal string BaseUnitSymbol { get; set; }
        internal string? BaseUnitOptionalSymbol { get; set; }
        internal UnitTypes UnitType { get; set; }
    }
    internal class BaseUnits : List<BaseUnit>
    {
        internal BaseUnits() {
            Add(new BaseUnit { BaseUnitSymbol = "m", BaseUnitNameSingular = "meter"      , BaseUnitNamePlural = "meters",                                    UnitType = UnitTypes.Length });
            Add(new BaseUnit { BaseUnitSymbol = "f", BaseUnitNameSingular = "foot"       , BaseUnitNamePlural = "feet",                                      UnitType = UnitTypes.Length });
            Add(new BaseUnit { BaseUnitSymbol = "i", BaseUnitNameSingular = "inch"       , BaseUnitNamePlural = "inches",                                    UnitType = UnitTypes.Length });
            Add(new BaseUnit { BaseUnitSymbol = "b", BaseUnitNameSingular = "bit"        , BaseUnitNamePlural = "bits",                                      UnitType = UnitTypes.Data });
            Add(new BaseUnit { BaseUnitSymbol = "B", BaseUnitNameSingular = "Byte"       , BaseUnitNamePlural = "Bytes",                                     UnitType = UnitTypes.Data });
            Add(new BaseUnit { BaseUnitSymbol = "C", BaseUnitNameSingular = "°Celsius"   , BaseUnitNamePlural = "Celsius"   , BaseUnitOptionalSymbol = "°C", UnitType = UnitTypes.Temperature });
            Add(new BaseUnit { BaseUnitSymbol = "F", BaseUnitNameSingular = "°Fahrenheit", BaseUnitNamePlural = "Fahrenheit", BaseUnitOptionalSymbol = "°F", UnitType = UnitTypes.Temperature });
        }
    }
    internal class UnitItem
    {
        internal string Prefix { get; set; }
        internal string Unit { get; set; }
        internal string BaseUnitSymbol { get; set; }
        internal int PrefixBase { get; set; }
        internal UnitTypes UnitType { get; set; }
    }
    internal class UnitList : List<UnitItem>
    {
        // list of all units with/without prefix, singular/plural, name/symbol, corresponding base unit and prefix base, e.g. { kilo, meter, m, 3 } or { milli, meters, m, -3 }
        internal UnitList()
        { 
            BaseUnits baseUnits = new BaseUnits();
            PrefixList prefixList = new PrefixList();
            foreach (BaseUnit bu in baseUnits)
            {
                foreach (Prefix px in prefixList)
                {
                    // combine prefix names and symbols with base unit names and symbols
                    Add(new UnitItem { Prefix = px.PrefixName,   Unit = bu.BaseUnitNameSingular, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = px.PrefixBase, UnitType = bu.UnitType });
                    if (bu.BaseUnitNamePlural != bu.BaseUnitNameSingular)
                    {
                        Add(new UnitItem { Prefix = px.PrefixName, Unit = bu.BaseUnitNamePlural, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = px.PrefixBase, UnitType = bu.UnitType });
                    }
                    Add(new UnitItem { Prefix = px.PrefixSymbol, Unit = bu.BaseUnitSymbol,       BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = px.PrefixBase, UnitType = bu.UnitType });
                    if (bu.BaseUnitOptionalSymbol != null)
                    {
                        Add(new UnitItem { Prefix = px.PrefixSymbol, Unit = bu.BaseUnitOptionalSymbol, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = px.PrefixBase, UnitType = bu.UnitType });
                    }
                }
                // include also unprefixed base units
                Add(new UnitItem { Prefix = string.Empty, Unit = bu.BaseUnitSymbol,       BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = 0, UnitType = bu.UnitType });
                Add(new UnitItem { Prefix = string.Empty, Unit = bu.BaseUnitNameSingular, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = 0, UnitType = bu.UnitType });
                if (bu.BaseUnitNamePlural != bu.BaseUnitNameSingular)
                {
                    Add(new UnitItem { Prefix = string.Empty, Unit = bu.BaseUnitNamePlural, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = 0, UnitType = bu.UnitType });
                }
                if (bu.BaseUnitOptionalSymbol != null)
                {
                    Add(new UnitItem { Prefix = string.Empty, Unit = bu.BaseUnitOptionalSymbol, BaseUnitSymbol = bu.BaseUnitSymbol, PrefixBase = 0, UnitType = bu.UnitType });
                }
            }
        }
    }
}
