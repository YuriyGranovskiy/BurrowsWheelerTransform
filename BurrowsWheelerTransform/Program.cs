using System;

namespace BurrowsWheelerTransform
{
    class Program
    {
        private const string TransformKey = "--transform";
        private const string RevertKey = "--revert";
        private const string VerboseKey = "-v";
        
        static void Main(string[] args)
        {
            if (args.Length < 2 || (!string.Equals(args[0], TransformKey) && !string.Equals(args[0], RevertKey)))
            {
                PrintUsage();
                return;
            }

            var method = args[0];
            var inputString = args[1];
            bool verbose = args.Length >= 3 && string.Equals(args[2], VerboseKey);

            switch (method)
            {
                case TransformKey:
                {
                    var transformedString = BurrowsWheelerTransformHelper.Transform(inputString, verbose);
                    Console.WriteLine(transformedString);
                    break;
                }
                case RevertKey:
                {
                    var revertedString = BurrowsWheelerTransformHelper.Revert(inputString, verbose);
                    Console.WriteLine(revertedString);
                    break;
                }
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("USAGE:");
            Console.WriteLine($"\t{TransformKey}|{RevertKey} {{string to process}} [-v]");
        }
    }
}