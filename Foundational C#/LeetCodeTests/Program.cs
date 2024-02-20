public class Program
{
    static void Main(string[] args)
    {
        var leetCode = new LeetCode();

        // leetCode.Merge([1,2,3,0,0,0], 3, [2,5,6], 3); leetCode.Merge([1], 1, [0], 0); leetCode.Merge([0], 0, [1], 1);
    }


    
}

public class LeetCode 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int j = nums1.Length - 1;
        int k = nums2.Length - 1;
        for (int i = 0; i < n; i++) 
        {
            nums1[j] = nums2[k];
            j--;
            k--;
        }
        Array.Sort(nums1);
        foreach(var num in nums1) {
            Console.Write(num + ", ");
        }
    }
}

