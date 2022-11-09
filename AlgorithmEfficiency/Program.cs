using System.Diagnostics;
using AlgorithmEfficiency;

public class Test
{
    static void Main()
    {
        var caseIdx = 1;
        var arrayTypes = new string[] {"Random", "Sorted", "Reversed", "AlmostSorted", "FewUnique"};

        var testCases = new List<TestCase>()
        {
            new TestCase("Próba mała", 10, 1),
            new TestCase("Próba średnia", 1000, 50),
            new TestCase("Próba duża", 100000, 500)
        };
        
        foreach (var testCase in testCases)
        {
            foreach (var arrayType in arrayTypes)
            {
                var arrToSort = GetArrayToSort(testCase.Size, arrayType, testCase.PairsToSwap);
                
                Console.WriteLine();
                Console.WriteLine($"Test {caseIdx}: {testCase.Name} ({testCase.Size}), {arrayType}");
                
                CreateReport("InsertionSort", arrToSort, new InsertionSort());
                CreateReport("MergeSort", arrToSort, new MergeSort());
                CreateReport("QuickSortClassical", arrToSort, new QuickSortClassical());
                CreateReport("QuickSort", arrToSort, new QuickSort());
                caseIdx++;
            }
        }
    }

    private static int[] GetArrayToSort(int size, string arrayType, int pairsToReplace)
    {
        switch (arrayType)
        {
            case "Random":
                return Generators.GenerateRandom(size, 0, size);
            case "Sorted":
                return Generators.GenerateSorted(size, 0, size);
            case "Reversed":
                return Generators.GenerateReversed(size, 0, size);
            case "AlmostSorted":
                return Generators.GenerateAlmostSorted(size, pairsToReplace);
            case "FewUnique":
                return Generators.GenerateRandom(size, 0, pairsToReplace);
        }

        return new int[] { };
    }

    static void CreateReport(string algorithmName, int[] arr, ISortingAlgorithm sortingAlgorithm)
    {
        var sw = new Stopwatch();
        var result = new long[10];
        
        for (int i = 0; i < 10; i++)
        {
            int[] arrClone = (int[])arr.Clone();
            sw.Restart();
            sortingAlgorithm.Sort(arrClone);
            sw.Stop();
            result[i] = sw.ElapsedTicks;
        }

        var avgMs = result.Average() / TimeSpan.TicksPerMillisecond;
        var standardDeviation = result.StandardDeviation() / TimeSpan.TicksPerMillisecond;
        Console.WriteLine($"{algorithmName}: t = {Math.Round(avgMs, 4)}ms +/- {Math.Round(standardDeviation, 5)}ms");
    }
}

public class TestCase
{
    public string Name { get; set; }
    public int Size { get; set; }
    public int PairsToSwap { get; set; }

    public TestCase(string _name, int _size, int _pairs)
    {
        Name = _name;
        Size = _size;
        PairsToSwap = _pairs;
    }
}
public static class Extend
{
    public static double StandardDeviation(this IEnumerable<long> values)
    {
        var enumerable = values as long[] ?? values.ToArray();
        double avg = enumerable.Average();
        return Math.Sqrt(enumerable.Average(v=>Math.Pow(v-avg,2)));
    }
}