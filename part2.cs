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
}