using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Immutable;
using System.Security.Principal;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.Transactions;
using Microsoft.VisualBasic;
using System.Dynamic;
using System.Runtime.Intrinsics.Arm;

public class Solution {
     public int LongestMonotonicSubarray(int[] nums) {
        int hold=1;
        int inc=1;
        int dec=1;
        for (int i = 1; i < nums.Length; i++)
        {
            if(nums[i]>nums[i-1])
            {
                inc++;
                dec=1;
            }
            if(nums[i]<nums[i-1])
            {
                inc=1;
                dec++;
            }
            hold=Math.Max(hold,Math.Max(inc,dec));
            if (nums[i] == nums[i-1])  { dec = 1; inc = 1;}
        }
        return hold;
    }
    public int MinEatingSpeed(int[] piles, int h) {
        int low=1;
        int high=piles.Max();
        int res=high;
        while(low<=high)
        {
            int mid=low+(high-low)/2;
            // Calculate the total hours required to eat all piles at the current speed (mid).
            long hours=CalculateHours(piles,mid);
            // If the total hours are within the allowed time (h), update the result
            // and try to find a smaller valid speed by adjusting the search range.
            if(hours<=h)
            {
                //go low
                res=mid;
                high=mid-1;
            }
            else
            {
                //go higher
                low=mid+1;
            }
        }
        return res;
    }

    private long CalculateHours(int[] piles, int k)
    {
        long t=0;
        foreach (var p in piles)
        {
            // Use ceiling division to calculate the hours for the current pile.
            // For example, if pile = 7 and k = 3, (7 + 3 - 1) / 3 = 3 hours.

            t+=(long)(p+k-1)/k;
            /*The -1 in (pile + k - 1) / k is part of a clever trick to perform ceiling
             division using integer arithmetic. It ensures that the result is always rounded up 
             to the nearest integer, which is necessary to calculate the correct number of 
             hours Koko needs to eat all the bananas in a pile.*/
        }
        return t;
    }
    //back track
     public IList<string> LetterCombinations(string digits) {
        if(string.IsNullOrEmpty(digits)) return new List<string>();
          // Mapping from digit to corresponding letters.
        Dictionary<char, string> phone = new Dictionary<char, string> {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
        List<string>res=new List<string>();
        Backtrack(digits,0,"",phone,res);
        return res;
     }

    private void Backtrack(string digits, int index, string curr, Dictionary<char, string> phone, List<string> res)
    {
       if(index==digits.Length)
       {
        res.Add(curr);
        return;
       }
       //digit=23 index=0 => Phone[2]
       string letters=phone[digits[index]];
       foreach(var letter in letters)
       {
        Backtrack(digits,index+1,curr+letter,phone,res);
       }
    }
    public int MaxAscendingSum(int[] nums) {
        int track=nums[0];
        int max=track;
        for(int i=1; i<nums.Length;i++)
        {
            if(nums[i]>nums[i-1])
            {
                track+=nums[i];
            }
            else{
                 max=Math.Max(max,track);
                track=nums[i];
            }  
        }
        return Math.Max(max,track);
    }
 
  public IList<IList<int>> CombinationSum3(int k, int n) { 
        // This list will hold all valid combinations
        IList<IList<int>> results = new List<IList<int>>();
        backtrac(results,new List<int>(),k,n,1);
        return results;
    }

    private void backtrac(IList<IList<int>> results, List<int> curr, int k, int remaning, int start)
    {
        //base
       if(curr.Count==k&&remaning==0)
       {
        results.Add(new List<int>(curr));
        return;
       }
       // If the combination is complete or remaining becomes negative, no need to proceed.
        if(curr.Count==k||remaning<0)
       {
        return;
       }
       // Try numbers from 'start' to 9 to build a valid combination.
        for (int i = start; i <= 9; i++)
        {
           curr.Add(i);
           backtrac(results,curr,k,remaning-i,i+1);
           // Backtrack: remove the last number added to try the next candidate.
           //this line will excute only when whe hit the return conditions
            curr.RemoveAt(curr.Count - 1);
        }
    }
      public int Tribonacci(int n) {
        if(n==0) return 0;
        if(n==1||n==2) return 1;
        int a=0; int b=1; int c=1; int res=0;
        for (int i = 3; i <= n; i++)
        {
            res=a+b+c;
            a=b;
            b=c;
            c=res;
        }
        return res;
    }
      public int MinCostClimbingStairs(int[] cost) {
        int n=cost.Length;
        // Note: the "top" of the floor is at index n (one step past the last step).
        int [] dp= new int[n+1];
         // You can start at index 0 or index 1 for free.
        dp[0]=0;
        dp[1]=0;
        for (int i = 2; i <= n; i++)
        {
            // To reach step i, you could come from 
            //step i-1 (paying cost[i-1]) or step i-2 (paying cost[i-2])
            dp[i]=Math.Min(dp[i-1]+cost[i-1],dp[i-2]+cost[i-2]);
        }
        // The answer is the cost to reach the top (one step beyond the last element).
        return dp[n];
      }
 
 public int Rob(int[] nums) { 
     // If there are no houses, then there is no money to rob.
        if (nums == null || nums.Length == 0) return 0;
        if(nums.Length==1) return nums[0];
        int n=nums.Length;
        int[] dp=new int[n];
        dp[0]=nums[0];
        dp[1]=Math.Max(nums[0],nums[1]);
        for (int i = 2; i < n; i++)
        {
           // For house i, there are two choices:
            // 1. Do not rob house i, so the amount remains dp[i-1].
            // 2. Rob house i, then add the money at house i to dp[i-2] (skipping the adjacent house).
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]); 
        }
        return dp[n-1];
   }
   
 public int RobOptmizwSpace(int[] nums) { 
     // If there are no houses, then there is no money to rob.
        if (nums == null || nums.Length == 0) return 0;
        if(nums.Length==1) return nums[0];
        int n=nums.Length;
        int pre2=nums[0]; //This represents dp[0]
        int pre1=Math.Max(nums[0],nums[1]); // This represents dp[1]
        for (int i = 2; i < n; i++)
        {
           // For house i, there are two choices:
             // 1. Not robbing the current house (prev1)
            // 2. Robbing the current house (prev2 + nums[i])
           int curr = Math.Max(pre1, pre2 + nums[i]); 
             // Update prev2 and prev1 for the next iteration
             pre2=pre1;
             pre1=curr;
        }
         // prev1 now holds the maximum amount that can be robbed.
        return pre1;
   }
    public bool AreAlmostEqual(string s1, string s2) {
        if(s1==s2) return true;
        int diff=0;
        int first =-1;
        int second=-1;
        for(int i=0; i<s1.Length;i++)
        {
            if(s1[i]!=s2[i])
            {
                diff++;
                if(diff>2) return false;
                if(first==-1) first=i;
                else second=i;
            }
        }
        return diff==2 && s1[first]==s2[second]&&s1[second]==s2[first];  
    }
     public int[] QueryResults(int limit, int[][] queries) {
        Dictionary<int,int> dic=new Dictionary<int, int>();
        HashSet<int> colors= new HashSet<int>();
        List<int> res=new  List<int>();
        foreach (var q in queries)
        {
            int ball =q[0];
            int c=q[1];
           
            //if its already colored
            if(dic.ContainsKey(ball))
            {
                int old=dic[ball];
                dic.Remove(ball);
                //color doesnt  exitss in other balls?
                if(!dic.ContainsValue(old))
                {
                    colors.Remove(old);
                }
            }
            dic[ball]=c;
            colors.Add(c);
            res.Add(colors.Count);
        }
        return res.ToArray();
    }
    public int TupleSameProduct(int[] nums) {
        Dictionary<int,int> dic=new Dictionary<int, int>();
        int res=0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                int prod=nums[i]*nums[j];
                if(!dic.ContainsKey(prod)) dic[prod]=0;
                dic[prod]++; 
            }
        }
        foreach (int c in dic.Values)
        {
           if(c>1) res+=(c*(c-1)/2) *8; // C(count, 2) * 8 permutations
        }
        return res;
    }
    public class NumberContainers {
        // Maps each index to its latest assigned number.
    private Dictionary<int, int> indexToNumber;
    
    // Maps each number to a priority queue (min-heap) storing its indices.
    private Dictionary<int, PriorityQueue<int, int>> numberToIndices;
    public NumberContainers() {
         indexToNumber = new Dictionary<int, int>();
        numberToIndices = new Dictionary<int, PriorityQueue<int, int>>();
    }
    
    public void Change(int index, int number) {
        if(indexToNumber.ContainsKey(index))
        {
            int old=indexToNumber[index];
            if(numberToIndices.ContainsKey(old))
            {
                numberToIndices[old].Enqueue(index, int.MaxValue); // Mark as invalid
            }        
        }
        indexToNumber[index]=number;
        if(!numberToIndices.ContainsKey(number))
        {
            numberToIndices[number]=new PriorityQueue<int, int>();
        }  
            numberToIndices[number].Enqueue(index, index);      
    }
    
    public int Find(int number) {
         // If the number doesn't exist, return -1
        if (!numberToIndices.ContainsKey(number)) return -1;
        var pq=numberToIndices[number];
        // Remove invalid (outdated) indices
        while (pq.Count > 0 && indexToNumber[pq.Peek()] != number) {
            pq.Dequeue();
        }
         return pq.Count > 0 ? pq.Peek() : -1;
    }
}
   public long CountBadPairs(int[] nums) {
        int n=nums.Length;
        int total=n*(n-1)/2;
        int good=0;
        Dictionary<int,int> d=new Dictionary<int, int>();
       for (int i = 0; i < n; i++)
       {
            int key=nums[i]-i;
            if(d.ContainsKey(key)) good+=d[key];
            d[key] = d.GetValueOrDefault(key, 0) + 1;
       }
        return total-good;
    }
     public long CountBa2dPairs(int[] nums) {
        long n=nums.Length;
        long total=n*(n-1)/2;
        long good=0;
        Dictionary<long,long> d=new Dictionary<long, long>();
       for (int i = 0; i < n; i++)
       {
            long key=nums[i]-i;
            if(d.ContainsKey(key)) good+=d[key];
            d[key] = d.GetValueOrDefault(key, 0) + 1;
       }
        return total-good;
    }
      public string RemoveOccurrences(string s, string part) {
   
        int index;
        while((index=s.IndexOf(part))!=-1)
        {
          s=s.Remove(index,part.Length);
        }
         return s;
    }
  public string ClearDigits(string s) {
        string ans="";
        foreach (char c in s)
        {
            if(Char.IsDigit(c))
            {
                if(ans.Length>0)
                {
                   ans=ans.Remove(ans.Length-1);
                }
            }
            else
            {
                ans+=c;
            }
        }
       return ans;
    }
    static string Decipher(string ciphertext, string knownWord)
    {
        char[] original = new char[ciphertext.Length];
        int key = GetKey(ciphertext, knownWord);

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (ciphertext[i] == ' ')
            {
                // Keep spaces as they are
                original[i] = ' ';
            }
            else
            {
                // Shift back by key to decipher
                original[i] = (char)(ciphertext[i] - key);
            }
        }

        return new string(original);  // Correct way to convert char[] to string
    }

    static int GetKey(string ciphertext, string knownWord)
    {
        List<string> words = new List<string>();
        string[] splitWords = ciphertext.Split(' '); // Split ciphertext into words
        int knownLen = knownWord.Length;

        foreach (string word in splitWords)
        {
            if (word.Length == knownLen)  // Find word with same length as knownWord
            {
                int key = word[0] - knownWord[0]; // Compute shift key

                bool valid = true;
                for (int j = 1; j < knownWord.Length; j++)
                {
                    if ((word[j] - knownWord[j]) != key)
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid) return key; // Return key if matching pattern is found
            }
        }

        return 0; // Default case if no match is found
    }
      public int NumTilings(int n) {
        if(n==1)return 1;
        if (n==2) return 2;
        int MOD=1_000_000_007;
        int []dp=new int [n+1];   
        dp[0]=0;
        dp[1]=1;
        dp[2]=2;
        for(int i=3;i<=n;i++)
        {
            dp[i]=(int)((2.0*dp[i-1]+dp[i-3])%MOD);
        }
        return dp[n];
    }
      public int MaximumSum(int[] nums) {
        int max=-1;
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            int s=SumDigits(num);
            if(map.ContainsKey(s))
            {
                max=Math.Max(max,map[s]+num);
                map[s]=Math.Max(map[s],num);// Keep the largest number for this digit sum
            }
            else
            {
                map[s]=num;
            }
        } 
        return max;       
    }

    private int SumDigits(int v)
    {
        int s=0;
        while (v>0)
        {
            s+=v%10;
            v/=10;
        }
        return s;
    }
    public int UniquePaths(int m, int n) {
         // Create a 2D DP array where dp[i][j] stores the number of ways to reach cell (i, j)
        int[,] dp = new int[m, n];
         // Base case: There's only one way to reach any cell in the first row (move right only)
        for (int i = 0; i < m; i++) dp[i,0]=1;
        // Base case: There's only one way to reach any cell in the first column (move down only)
        for (int j = 0; j < n; j++) dp[0,j]=1;
         // dp[i][j] = dp[i-1][j] (coming from top) + dp[i][j-1] (coming from left)
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i,j]=dp[i-1,j]+dp[i,j-1];
            }
        }
         // The bottom-right corner contains the total number of unique paths
        return dp[m-1,n-1];
    }
    public int LongestCommonSubsequence(string text1, string text2) {
        int m=text1.Length; int n= text2.Length;
        int[,]dp=new int[m+1,n+1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <=n; j++)
            {
                if(text1[i-1]==text2[j-1])
                {
                    // If characters match, increase LCS length
                    dp[i,j]=1+dp[i-1,j-1];
                }
                else
                {
                     // Otherwise, take the max LCS by either excluding a character from text1 or text2
                    dp[i,j]=Math.Max(dp[i-1,j],dp[i,j-1]);
                }
            }        
        }
        return dp[m,n];   
    }
      public int MinOperations(int[] nums, int k) {
        PriorityQueue<long,long>pq=new PriorityQueue<long, long>();
        int operation=0;
        foreach (var n in nums)
        {
            pq.Enqueue(n,n);
        }
        while(pq.Count>=2&&pq.Peek()<k)
        {
            long x=pq.Dequeue();
            long y=pq.Dequeue();
            long val=Math.Min(x,y)*2+Math.Max(x,y);
            pq.Enqueue(val,val);
            operation++;
        }
        return operation;
    }
    public int MaxProfit(int[] prices, int fee) {
        int n=prices.Length;
        // If we buy on the first day
        // hold  The maximum profit we can have when we currently own a stock.
        int hold=-prices[0];
        //if we dont buy at all
        //The maximum profit we can have when we don’t own a stock.
        int cash=0;
        for(int i=1;i<n;i++)
        {
            cash=Math.Max(cash,hold+prices[i]-fee); // Sell and update cash
            hold=Math.Max(hold,cash-prices[i]);//buy and update hold
        }
        return cash;// Max profit when we are not holding any stock
    }
    public int MinDistance(string word1, string word2) {
        int m=word1.Length;
        int n=word2.Length;
        int[,]dp=new int[m+1,n+1];
        // Base case 1: If word1 is empty, we need to insert all characters of word2.
        for(int i=0;i<=m;i++) dp[i,0]=i;
         // Base case 2: If word2 is empty, we need to delete all characters of word1.
        for(int j=0;j<=n;j++) dp[0,j]=j;
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) 
            {
            // If the current characters match, no extra operation is needed.
            // We carry forward the previous result (diagonally left-up in the table).
                if(word1[i-1]==word2[j-1]) dp[i,j]=dp[i-1,j-1];
                else {
                // If the characters are different, we consider three possible operations:
                // 1. Delete a character from word1 (move up in the table)
                // 2. Insert a character into word1 (move left in the table)
                // 3. Replace the character (move diagonally left-up in the table)
                    dp[i,j]=Math.Min(dp[i-1,j]+1,//move up,
                            Math.Min(dp[i,j-1]+1,// move left
                                    dp[i-1,j-1]+1 ));//move diaognal
                }
            }
        }
        return dp[m,n];
    }
    public int[] CountBits(int n) {
        int []ans=new int[n+1];
        for (int i = 0; i <=n; i++)
        {
            ans[i]=Convert.ToString(i,2).Count(c=>c=='1');
        }
        return ans;
    }
      public int HammingWeight(int n) {
      return Convert.ToString(n,2).Count(c=>c=='1');   
    }
     public int SingleNumber(int[] nums) {
        int res=0;
        //Since every number appears twice, XOR cancels out the duplicate numbers
        foreach (var n in nums)
        {
            //1 ^ 1) ^ (2 ^ 2) ^ 4 = 0 ^ 0 ^ 4 = 4
            res^=n;
        }
        return res;   
    }
    public class ProductOfNumbers {
        private List<int>prefix;
    public ProductOfNumbers() {
        prefix=new List<int>{1};
    }
    
    public void Add(int num) {
        if(num==0)  prefix=new List<int>{1};
           // Multiply the last stored product with the new number and store it
        else prefix.Add(prefix[prefix.Count-1]*num);
    }
    
    public int GetProduct(int k) {
       int n=prefix.Count;
        // If k is greater than available elements (due to a zero reset), return 0
        if (k >= n) return 0;
        // Calculate the product of the last k elements using prefix division
       return prefix[n-1]/prefix[n-k-1]; 
    }
}
}
