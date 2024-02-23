public class Program
{
    static void Main(string[] args)
    {
        var leetCode = new LeetCode();

        // leetCode.Merge([1,2,3,0,0,0], 3, [2,5,6], 3); leetCode.Merge([1], 1, [0], 0); leetCode.Merge([0], 0, [1], 1);
        // leetCode.CanConstruct("ab", "a");
        // leetCode.SummaryRanges([0,1,2,4,5,7]); leetCode.SummaryRanges([0,2,3,4,6,8,9]); 
        // leetCode.IsValid("(([]){})"); 
        // leetCode.IsValid("(){}}{");
        leetCode.IsValid("[({(())}[()])]");
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
        IList<string> ranges = new List<string>();
        int a;
        int b;        
        
        for (int i = 0; i < nums.Length; i++) 
        {
            a = nums[i];
            b = a;

            int j = i;
            if (i != nums.Length - 1) // Next number exists
            {
                j = i + 1;
                while (b + 1 == nums[j])
                {
                    b = nums[j];
                    if (j != nums.Length - 1)
                    {
                        j++;
                    }
                }
                if (b != nums[nums.Length - 1]) 
                {
                    i = j - 1;
                } 
                else 
                {
                    i = nums.Length;
                }
            } 
            
            if (a == b)
            {
                ranges.Add(a.ToString()); 
            } 
            else
            {
                ranges.Add(a.ToString() + "->" + b.ToString());
            }
                
        }
        
        return ranges;
    }

    public bool IsValid(string s) {
        char[] parenthesesList = s.ToCharArray();
        IList<int[]> pairs = new List<int[]>();
        
        for (int i = 0; i < parenthesesList.Length; i++)
        {
            char closingChar = '\0';
            
            switch(parenthesesList[i])
            {
                case '(':
                    closingChar = ')';
                    break;
                case '{':
                    closingChar = '}';
                    break;
                case '[':
                    closingChar = ']';
                    break;
            }
            
            if (closingChar != '\0') 
            {
                int lastClosingCharIndex = -1;
                for (int j = i + 1; j < parenthesesList.Length; j++)
                {
                    if (parenthesesList[j] == closingChar)
                    {
                        lastClosingCharIndex = j;
                    }
                }
                if (lastClosingCharIndex != -1)
                {
                   pairs.Add([i, lastClosingCharIndex]);
                    parenthesesList[i] = '\0';
                    parenthesesList[lastClosingCharIndex] = '\0'; 
                }
            }            
        }
        
        bool rangeInterference = false;
        for (int i = 0; i < pairs.Count; i++)
        {
            int[] outsideRange = pairs[i];
            for (int j = i + 1; j < pairs.Count; j++)
            {
                 if (outsideRange[0] < pairs[j][0] && pairs[j][0] < outsideRange[1])
                 {
                     int[] insideRange = pairs[j];
                     if (insideRange[1] > outsideRange[1])
                     {
                         rangeInterference = true;
                     }
                 }
            
            }                
        }
        
        Console.WriteLine((float) pairs.Count);
        
        return !rangeInterference && ((float) pairs.Count == (float) s.Length / 2);
        
    }
}

