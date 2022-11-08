namespace AlgorithmEfficiency;

public class MergeSort : ISortingAlgorithm
{
    public void Sort(int[] arr)
    {
        MergeSortMethod(arr, 0, arr.Length - 1);
    }
    
    private void MergeSortMethod(int[] arr, int l, int r)
    {   
        if (l < r) {
            int m = l + (r - l) / 2;
 
            MergeSortMethod(arr, l, m);
            MergeSortMethod(arr, m + 1, r);
 
            MergeSortMergeArrays(arr, l, m, r);
        }
    }
    
    private static void MergeSortMergeArrays(int[] arr, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;
 
        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;
 
        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];
 
        // Merge the temp arrays
 
        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;
 
        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }
 
        // Copy remaining elements
        // of L[] if any
        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }
 
        // Copy remaining elements
        // of R[] if any
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }
}