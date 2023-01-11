using UnitConverter;

namespace ConsoleAppConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Converter converter = new();

            Console.WriteLine("1 meter, foot = {0}", converter.Convert("1 meter", "foot")); // 3.28 foot
            Console.WriteLine("1 kilometer, feet = {0}", converter.Convert("1 kilometer", "feet")); // 3280.84 feet
            Console.WriteLine("1 kilometer, mm = {0}", converter.Convert("1 kilometer", "mm")); // 1000000.00 mm
            Console.WriteLine("1 foot, inches = {0}", converter.Convert("1 foot", "inches")); // 12.00 inches
            Console.WriteLine("10 inches, mm = {0}", converter.Convert("10 inches", "mm")); // 254.00 mm
            Console.WriteLine("3 kiloinches, meter = {0}", converter.Convert("3 kiloinches", "meter")); // 76.20 meter
            Console.WriteLine("20 F, C = {0}", converter.Convert("20 F", "C")); // -6.67 C
            Console.WriteLine("20 °C, °F = {0}", converter.Convert("20 °C", "°F")); // 68.00 °F
            Console.WriteLine("0 Fahrenheit, Celsius = {0}", converter.Convert("0 Fahrenheit", "Celsius")); // -17.78 Celsius
            Console.WriteLine("0 °Celsius, °Fahrenheit = {0}", converter.Convert("0 °Celsius", "°Fahrenheit")); // 32.00 °Fahrenheit
            Console.WriteLine("1000 bit, B = {0}", converter.Convert("1000 bit", "B")); // 125.00 B
            Console.WriteLine("100 Bytes, bits = {0}", converter.Convert("100 Bytes", "bits")); // 800.00 bits
        }
    }
}