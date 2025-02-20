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

public class p3 {
     public int PunishmentNumber(int n) {
        int total=0;
        for (int i = 1; i <=n; i++)
        {
            int square=i*i;
            string s=square.ToString();
            // Check if the square can be partitioned into substrings summing to i
            if(CanBePartion(s,i,0,0)) total+=square;
        }
        return total;
    }

    private bool CanBePartion(string s, int target, int index, int curr)
    {
        // Base case: If we reach the end of the string, check if the sum equals the target number
        if(index==s.Length) return curr==target;
        // Variable to hold the current number being formed
        int n=0;
        for (int j = index; j < s.Length; j++)
        {
            n=n*10+(s[j]-'0'); // Convert substring to an integer
            // If the sum exceeds the target, stop exploring this path
            if(curr+n>target) return false;
             // Recursively check the remaining part of the string
             if(CanBePartion(s,target,j+1,curr+n)) return true;
        }
        return false;
    }

    public class TrieNode {
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
   public List<string> Words = new List<string>(); // Store lexicographically sorted words
}
    public class Trie {
        private TrieNode root;
    public Trie() {
        root=new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode node=root;
        foreach (var c in word)
        {
            if(!node.Children.ContainsKey(c)) node.Children[c]=new TrieNode();
            node=node.Children[c];
             node.Words.Add(word);
             node.Words.Sort();
              // Maintain only top 3 lexicographical words
            if(node.Words.Count>3) node.Words.RemoveAt(3);//keep first 3 only
        }
    }
    
       public List<string> GetSuggestions(string prefix) {
        TrieNode node=root;
         foreach (var c in prefix)
             {
                  if(!node.Children.ContainsKey(c)) return new List<string>();
                  node=node.Children[c];  
             }
             return node.Words;
    }
}
     public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Trie trie=new Trie();
         // Insert all words into Trie (sorted order to ensure lexicographical order)
         Array.Sort(products);
         foreach (var item in products)
         {
            trie.Insert(item);
         }
         // Find suggestions for each prefix of searchWord
        List<IList<string>> result = new List<IList<string>>();
        string prefix = "";
        foreach (var c in searchWord)
        {
            prefix+=c;
            result.Add(trie.GetSuggestions(prefix));
        }
        return result;
     }

    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length==0) return 0;
        // Step 1: Sort intervals by their ending time
        //sorting by end times helps us keep the most intervals while removing the least.
         //Sorting helps us pick the maximum number of non-overlapping intervals while minimizing removals
        Array.Sort(intervals,(a,b)=>a[1].CompareTo(b[1]));
        int answer=0;
        int previs=intervals[0][1];
        // 2 3 3 4
        for (int i = 1; i < intervals.Length; i++)
        {
            // If current interval starts before the last one ends, remove it
            //if i sarted at 1 and the previous end was 2 thats not fine
            //if i start at 3 previous end was 2 then thats fine
            if(intervals[i][0]<previs) answer++;
            else previs=intervals[i][1];
        }
        return answer;
    }
     public int FindMinArrowShots(int[][] points) {
         if (points.Length == 0) return 0;
         // Step 1: Sort balloons by their ending coordinate
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
         int arrows = 1;  // At least one arrow is needed
         int arrowPos = points[0][1];  // Position of the first arrow (at first balloon's end)
         foreach (var balloon in points) {
             // Step 2: If the current balloon starts AFTER the last arrow position, shoot a new arrow
            if(balloon[0]>arrowPos){
                 arrows++;
                 arrowPos=balloon[1];// Update arrow position to the new balloon's end
            }
         }
        return arrows;
    } 
       public int[] DailyTemperatures(int[] temperatures) {
        int n =temperatures.Length;
        int[] answers=new int[n];
        Stack<int>s=new Stack<int>();
        for (int i = 0; i < n; i++)
        {    // Pop stack if current temp is warmer than temp at stack top
            while (s.Count>0&&temperatures[i]>temperatures[s.Peek()])
            {
                int prev=s.Pop();
                answers[prev]=i-prev;
            }
            s.Push(i);
        }   
        return answers;
    }  
    public class StockSpanner {
         private Stack<(int price, int span)> stack;
    public StockSpanner() {
         stack = new Stack<(int, int)>();
    }
    
    public int Next(int price) {
        int span=1;
         // Pop elements from the stack while the top price is <= current price
         while(stack.Count>0&&stack.Peek().price<=price)
         {
            span+=stack.Pop().span;
         }
         // Push the new price with its calculated span
         stack.Push((price,span));
         return span;
    }
}
    public int[] ConstructDistancedSequence(int n) {
        int s=2*n-1;
        int[] res=new int[s];
        bool []used=new bool[n+1];
        Backtrack(res,used,0,n);
        return res;    
    }

    private bool Backtrack(int[] res, bool[] used, int index, int n)
    {
        // Skip already filled indices
        while (index < res.Length && res[index] != 0) {
            index++;
        }
        // If we filled the entire array, return true
        if (index == res.Length) {
            return true;
        }
        // Try placing numbers from largest to smallest
         for (int num = n; num >= 1; num--) {
             if (used[num]) continue;
            // If num == 1, place it in the first empty spot
            if (num == 1) {
                res[index] = 1;
                used[1] = true;
                if (Backtrack(res, used, index + 1, n)) {
                    return true;
                }
                // Backtrack
                res[index] = 0;
                used[1] = false;
            }  
            else if(index + num < res.Length && res[index + num] == 0) {
                 // Otherwise, place num at index and index + num
                res[index] = res[index + num] = num;
                used[num] = true;

                if (Backtrack(res, used, index + 1, n)) {
                    return true;
                }

                // Backtrack
                res[index] = res[index + num] = 0;
                used[num] = false;
            }
         }  
         return false;   
    }
    public int NumTilePossibilities(string tiles) {
        Dictionary<char,int>freq= new Dictionary<char, int>();
        foreach (var c in tiles)
        {
            if(!freq.ContainsKey(c)) freq[c]=0;
            freq[c]++;
        }   
        return Bactrack(freq);
    }

    private int Bactrack(Dictionary<char, int> freq)
    {
        int answer=0;
        foreach (var key in freq.Keys)
        {
            if(freq[key]>0)
            {
                freq[key]--;
                answer+=1+Bactrack(freq);
                freq[key]++;
            }
        }
        return answer;
    }

    public string SmallestNumber(string pattern) {
        Stack<int> stack = new Stack<int>(); // Stack to handle decreasing sequences
        StringBuilder result = new StringBuilder(); // Stores the final smallest number
        int num = 1; // Start numbering from 1

        // Iterate through the pattern, processing each character
        for (int i = 0; i <= pattern.Length; i++) {
            stack.Push(num++); // Always push the next number onto the stack

            // If we encounter 'I' or reach the end, pop all elements in stack
            if (i == pattern.Length || pattern[i] == 'I') {
                while (stack.Count > 0) {
                    result.Append(stack.Pop()); // Pop stack elements to reverse 'D' sequences
                }
            }
        }

        return result.ToString(); // Convert StringBuilder to string and return
    }
    public string FindDifferentBinaryString(string[] nums) {
        int n=nums.Length;
        char[]res=new char[n];
        for (int i = 0; i < n; i++)
        {
            // Flip the diagonal bit: If nums[i][i] is '0', make it '1', otherwise make it '0'
            res[i]=nums[i][i]=='0'?'1':'0';
        }
        return new string(res);
    }
}

