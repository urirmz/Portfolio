public class Program
{
    static void Main(string[] args)
    {
        var leetCode = new LeetCode();

        // leetCode.Merge([1,2,3,0,0,0], 3, [2,5,6], 3); leetCode.Merge([1], 1, [0], 0); leetCode.Merge([0], 0, [1], 1);
        // leetCode.CanConstruct("ab", "a");
        leetCode.SummaryRanges([0,1,2,4,5,7]);
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

    public bool CanConstruct(string ransomNote, string magazine) {
        char[] noteLetters = ransomNote.ToCharArray();
        char[] magazineLetters = magazine.ToCharArray();
        
        int coincidences = 0;

        for (int i = 0; i < noteLetters.Length; i++)
        {
            for (int j = 0; j < magazineLetters.Length; j++)
            {
                if (noteLetters[i] == magazineLetters[j]) 
                {
                    magazineLetters[j] = '\0';
                    coincidences++;
                    break;
                }
            }
        }
        
        Console.Write(coincidences);
        
        return coincidences == noteLetters.Length;
    }

     public IList<string> SummaryRanges(int[] nums) {
        int a;
        int b;
        IList<string> range = new List<string>();
        
        for (int i = 0; i < nums.Length; i++) 
        {
            a = nums[i];
            
            int j = i;
            if (i < nums.Length - 1) 
            {
                j = i + 1;
            }            
            do
            {
                b = nums[j];
                if (j < nums.Length - 1) 
                {
                    j++;    
                }                                   
            } while ( b + 1 == nums[j]);
            i = j - 1;
            
            if (a == b)
            {
                range.Add(a.ToString()); 
            } 
            else
            {
                range.Add(a.ToString() + "->" + b.ToString());
            }
                
        }
        
        return range;
    }
}

