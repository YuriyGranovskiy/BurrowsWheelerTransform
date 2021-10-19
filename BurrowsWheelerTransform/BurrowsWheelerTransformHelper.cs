using System;
using System.Collections.Generic;
using System.Linq;

namespace BurrowsWheelerTransform
{
    public static class BurrowsWheelerTransformHelper
    {
        public static string Transform(string inputString, bool verbose = false)
        {
            var rotations = new List<string>();
            var currentRotation = inputString;
            for (int i = 0; i < inputString.Length; i++)
            {
                rotations.Add(currentRotation);
                currentRotation = currentRotation.Substring(1, currentRotation.Length - 1) + currentRotation[0];
            }
            
            rotations.Sort(StringComparer.Ordinal);

            if (verbose)
            {
                foreach (var rotation in rotations)
                {
                    Console.WriteLine($"'{rotation}'");
                }
            }

            return string.Join("", rotations.Select(r => r[^1]));
        }

        public static string Revert(string inputSting, bool verbose = false)
        {
            var L = new List<BIndex>();
            foreach (var t in inputSting)
            {
                var i = L.Count(l => l.Symbol == t);
                L.Add(new BIndex(t, i) );
            }

            var F = new List<BIndex>();
            var uniqueSortedChars = L.Where(l => l.Index == 0).Select(bi => bi.Symbol).OrderBy(c => c).ToList();
            foreach (var uniqueChar in uniqueSortedChars)
            {
                F.AddRange(L.Where( l => l.Symbol == uniqueChar).OrderBy(l => l.Index));
            }

            var restore = new List<BIndex>();
            var start = F[0];
            var current = start;

            if (verbose)
            {
                Console.WriteLine($"Initial string: {inputSting}");
                for (int i = 0; i < L.Count; i++)
                {
                    Console.WriteLine($"{F[i].Symbol}({F[i].Index})\t{L[i].Symbol}({L[i].Index})");
                }
            }

            do
            {
                restore.Add(current);
                var fIndex = F.IndexOf(current);
                current = L[fIndex];

            } while (current != start);

            var restoredString = string.Join("", restore.Select(r => r.Symbol));
            var restoredRevertedString = string.Join("", restoredString.Reverse());

            if (restoredRevertedString.Length < inputSting.Length)
            {
                throw new Exception(
                    $"Input string cant be reverted. It's length is {restoredString.Length}. Content {restoredRevertedString}");
            }

            return restoredRevertedString;
        }
    }
}