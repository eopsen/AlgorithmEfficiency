namespace AlgorithmEfficiency;

public class QuickSortClassical : ISortingAlgorithm
{
    public void Sort(int[] arr)
    {
        QuickSortClassicalMethod(arr, 0, arr.Length - 1);
    }
    
    public void QuickSortClassicalMethod(int[] arr, int low, int high)
    {
        if (low < high) {
  
            // pi is partitioning index, arr[p]
            // is now at right place
            int pi = Partition(arr, low, high);
  
            // Separately sort elements before
            // partition and after partition
            QuickSortClassicalMethod(arr, low, pi - 1);
            QuickSortClassicalMethod(arr, pi + 1, high);
        }
    }
    
    private static int Partition(int[] arr, int low, int high)
    {
  
        // pivot
        int pivot = arr[high];
  
        // Index of smaller element and
        // indicates the right position
        // of pivot found so far
        int i = (low - 1);
  
        for (int j = low; j <= high - 1; j++) {
  
            // If current element is smaller
            // than the pivot
            if (arr[j] < pivot) {
  
                // Increment index of
                // smaller element
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return (i + 1);
    }
    
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}