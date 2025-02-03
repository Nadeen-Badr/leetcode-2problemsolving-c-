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
}