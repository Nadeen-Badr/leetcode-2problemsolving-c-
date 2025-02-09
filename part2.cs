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
}