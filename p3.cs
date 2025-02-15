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


}