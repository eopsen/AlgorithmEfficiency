namespace AlgorithmEfficiency;

public static class Generators
{
    public static int[] GenerateRandom(int size, int minVal, int maxVal)
    {
        int[] a = new int[size];
        var rnd = new Random();
        
        for (int i = 0; i < size; i++)
        {
            a[i] = rnd.Next(minVal, maxVal);
        }
        
        return a;
    }
    
    public static int[] GenerateSorted(int size, int minVal, int maxVal)
    {
        int[] a = GenerateRandom(size, minVal, maxVal);
        Array.Sort(a);
        return a;
    }
    
    public static int[] GenerateReversed(int size, int minVal, int maxVal)
    {
        int[] a = GenerateSorted(size, minVal, maxVal);
        Array.Reverse(a);
        return a;
    }
    
    public static int[] GenerateAlmostSorted(int size, int pairsToSwap)
    {
        int[] a = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            a[i] = i;
        }

        var rnd = new Random();
        for (int i = 0; i < pairsToSwap; i++)
        {
            int sourceIdx = rnd.Next(0, size);
            int destinationIdx = rnd.Next(0, size);

            int temp = a[sourceIdx];
            a[sourceIdx] = a[destinationIdx];
            a[destinationIdx] = temp;
        }

        return a;
    }
    
}