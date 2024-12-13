﻿using System.Collections.Immutable;
using System.Security.Principal;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.Design;

public class Solution {
    public string MergeAlternately(string word1, string word2) {
        int i = 0, j = 0;
        string result = "";
        
        // Alternately add characters from both strings until one is exhausted
        while (i < word1.Length && j < word2.Length)
        {
            result += word1[i++];
            result += word2[j++];
        }
        
        // If there are remaining characters in word1
        while (i < word1.Length)
        {
            result += word1[i++];
        }
        
        // If there are remaining characters in word2
        while (j < word2.Length)
        {
            result += word2[j++];
        }
        
        return result;
    }
   
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int max= candies.Max();
        bool[] result = new bool[candies.Length];
        for (int i = 0; i < candies.Length; i++)
        {
            if(candies[i]+extraCandies> max){
                result[i]=true;
            }
            else{
                result[i]=false;
            }
        }
        return result;
        
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int count=0;
        for(int i=0;i<flowerbed.Length;i++){
            if(flowerbed[i]==0){
                if((i==0 || flowerbed[i-1]==0)&&(i==flowerbed.Length-1 || flowerbed[i+1]==0 )){
                    count++;
                    flowerbed[i]=1;

                }    
            //The current position is either at the start or has no flower to the left
            //, and either at the end or has no flower to the right
            }  
        }
        
        return count<=n;
        
    }

    public string ReverseWords(string s) {
          string answer = string.Empty;
          var words=s.Trim().Split(' ');
          foreach (var word in words)

          {
            if(string.IsNullOrEmpty(word)){
                continue;
            }
            answer=word+' '+answer;            
          }

          return answer.Trim();
    }

    public string ReverseVowels(string s) {
        char[] chars=s.ToCharArray();
        string vowels = "aeiouAEIOU";
        for(int left = 0, right=s.Length-1; left<right ;){
            if(!vowels.Contains(chars[left])){
                left++;
            }
            else if(!vowels.Contains(chars[right])){
                right--;
            }
            else{
                char temp= chars[left];
                chars[left]=chars[right];
                chars[right]=temp;
                left++;
                right--;
            }

        }
        return new string(chars);
    }
    public int[] ProductExceptSelf(int[] nums) {
        int Length = nums.Length;
        int[] answers = new int[Length];
        for (int i = 0; i < Length; i++)
        {
            answers[i] = 1;
        }
        for (int i = 1; i < Length;i++) {
            answers[i]=answers[i-1]*nums[i-1];
        }
        int right=nums[Length-1];
        for (int i = Length-2; i >= 0; i--)
        {
            answers[i]= answers[i]*right;
            right=right * nums[i];
        }
        return answers;
    }
    public bool IncreasingTriplet(int[] nums) {
        int first =nums[0];
        int second = int.MaxValue;
        foreach (var third in nums)
        {
            if(first<second && second<third){
                return true;
            }
            else if(first<third && third<second){
                    second=third;
            }else if (third<first){
                first=third;
            }
                   
            
        }
        return false;
        
    }



 public string ReverseVowels2(string s) {
    char[] chars = s.ToCharArray();
    string vowels = "aeiouAEIOU";
    for (int left = 0, right = s.Length - 1; left < right;) {
        // Move left pointer to the next vowel
        //im only swapping when i have 2 vowels
        if (!vowels.Contains(chars[left])) {
            left++;
        }
        // Move right pointer to the previous vowel
        else if (!vowels.Contains(chars[right])) {
            right--;
        }
        // Swap vowels when both pointers point to vowels
        else {
            // Swap chars[left] and chars[right]
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
            left++;
            right--;
        }
    }
    return new string(chars);

}
 public int Compress(char[] chars) {
        int n = chars.Length;
        int idx = 0;
        for (int i = 0; i < n; i++) {
            char ch = chars[i];
            int count = 0;
            while (i < n && chars[i] == ch) {
                count++;
                i++;
            }
            if (count == 1) {
                chars[idx++] = ch;
            } else {
                chars[idx++] = ch;
                foreach (char digit in count.ToString()) {
                    chars[idx++] = digit;
                }
            }
            i--;
        }
        Array.Resize(ref chars, idx);
        return idx;
    }

     public void MoveZeroes(int[] nums) {
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if(nums[right] != 0)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left ++;
            }
        }
    }
     public void MoveZeroees(int[] nums) {
        int left = 0;
        for (int right = 0; right < nums.Length; right++) {
            if (nums[right] != 0) {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
            }
        }
    }

    //  public bool IsSubsequence(string s, string t) {
    //     int j=0;
    //     for(int i=0;i<t.Length;i++){
    //        if(s[j]==t[i]){
    //         j++;
    //        }
    //     }
    //     return s.Length==j;
    // }
        public bool IsSubsequence(string s, string t) {
        if(s == "")
            return true;
        int j=0;
        for(int i=0;i<t.Length&&j<s.Length;i++){
           if(s[j]==t[i]){
            j++;
           }
        }
        return s.Length==j;
    }
     public int MaxArea(int[] height) {
        int Max_Area=0;
        int left=0;
        int right = height.Length-1;
        while(left<right){
            Max_Area=Math.Max(Max_Area,(right-left)*Math.Min(height[right],height[left]));
            if(height[left]<height[right]){
                left++;
            }else{
                right--;
            }
        }
        return Max_Area;
        
    }


    public int MaxOperations(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int count = 0;

        foreach (int num in nums) {
            int remaining = k - num;
            if (map.ContainsKey(remaining) && map[remaining] > 0) {
                count++;
                map[remaining]--;
                if (map[remaining] == 0) {
                    map.Remove(remaining);
                }
            } else {
                if (map.ContainsKey(num)) {
                    map[num]++;
                } else {
                    map[num] = 1;
                }
            }
        }

        return count;
    }

     public double FindMaxAverage(int[] nums, int k) {
        int maxsum=nums.Take(k).Sum();
        int currentsum=maxsum;
        for(int i=k;i<nums.Length;i++){
            currentsum=currentsum+nums[i]-nums[i-k];
            if(currentsum>maxsum){
                maxsum=currentsum;
            }
        }
        return (double)maxsum/k;
        
    }
   
    
    public int MaxVowels(string s, int k) {
        int max=0;
        int current=0;
        for(int i=0;i<k;i++){
            if(checkvowel(s[i])){
                current++;
            }
        }
        max = current;
        for(int i=k;i<s.Length;i++){
            if(checkvowel(s[i-k])){
                current--;
            }
            if(checkvowel(s[i])){
                current++;
            }
            max=Math.Max(max,current);
        }
        return max;   
    } 
    public  bool checkvowel(char c){
        return "aeiou".Contains(c);
    }  
    public int LongestOnes(int[] nums, int k)
    {
        int i = 0, j = 0,  maxLength = 0;// Pointers for the sliding window

        // Iterate through the array using the `j` pointer
        while (j < nums.Length)
        {
            // If the current element is 0, decrement `k` (use one of the allowed flips)
            if (nums[j] == 0)
            {
                k--;
            }

            // If `k` becomes negative, move the left pointer `i` to restore the allowed flips
            if (k < 0)
            {
                if (nums[i] == 0)
                {
                    k++; // Recover the flip when moving past a zero
                }
                i++; // Shrink the window from the left
            }

            // Move the right pointer to expand the window
            j++;
            maxLength = Math.Max(maxLength, j - i);
        }

        // The size of the longest subarray with at most `k` flips is the distance between `j` and `i`
        return maxLength;
    }
    public int LongestOnesSpeical(int[] nums)
    {
        int i = 0, j = 0,  maxLength = 0;
        // Pointers for the sliding window
        int k=1;

        // Iterate through the array using the `j` pointer
        while (j < nums.Length)
        {
            // If the current element is 0, decrement `k` (use one of the allowed flips)
            if (nums[j] == 0)
            {
                k--;
            }

            // If `k` becomes negative, move the left pointer `i` to restore the allowed flips
            if (k < 0)
            {
                if (nums[i] == 0)
                {
                    k++; // Recover the flip when moving past a zero
                }
                i++; // Shrink the window from the left
            }

            // Move the right pointer to expand the window
            j++;
            maxLength = Math.Max(maxLength, j - i);
        }

        // The size of the longest subarray with at most `k` flips is the distance between `j` and `i`
        return maxLength-1;
    }
       public int LongestqSubarray(int[] nums){
        int curr=0;
        int pre=0;
        int max =0;
        for (int i=0;i<nums.Length;i++){
            if(nums[i]==0){
                max=Math.Max(max, curr+pre);
                pre=curr;
                curr=0;
            }else{
                curr++;
            }
        }
        if(curr==nums.Length){
            return curr-1;
        }
        max=Math.Max(max,curr+pre);
        return max;
                
    }

       
    public int LongestSubarray(int[] nums)
    {
        int previous = 0;
        int current = 0;
        int max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                max = Math.Max(max, previous + current);
                previous = current;
                current = 0;
            }
            else
            {
                current++;
            }
        }

        if (current == nums.Length)
        {
            return current - 1;
        }

        max = Math.Max(max, previous + current);

        return max;
    }
    public int LargestAltitude(int[] gain) {
        int max=0;
        int sum=0;
        for (int i=0;i<gain.Length;i++){
            sum=sum+gain[i];
            max=Math.Max(max,sum);
        }
        return max;
    }
    public int PivotIndex(int[] nums) {
        int totalSum = 0, leftSum = 0;
        //total sum of the whole array
        foreach (int num in nums) {
            totalSum += num;
        }

        for (int i = 0; i < nums.Length; i++) {
            //-num[i] bec its should not be inculded in the right or left sum
            if (leftSum == totalSum - leftSum - nums[i]) {
                return i;
            }
            leftSum += nums[i];
        }

        return -1;
    }
    public long PickGifts(int[] gifts, int k)
    {
    var maxHeap = new PriorityQueue<int, int>();
    foreach (var gift in gifts)
    {
        maxHeap.Enqueue(gift, -gift);
         // Enqueue the gift with its negative value to make it a max-heap
         //by def PQ takes the smallest prio in Enqueue
    }
    for (int i = 0; i < k; i++)
    {
        int largest = maxHeap.Dequeue();
        int newValue = (int)Math.Sqrt(largest);
        maxHeap.Enqueue(newValue, -newValue);
    }
    long total = 0;
    while (maxHeap.Count > 0)
    {
        total += maxHeap.Dequeue();
    }
    return total;
    } 
    //hashmap 
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        HashSet<int> a=nums1.ToHashSet();
        HashSet<int>b=nums2.ToHashSet();
        a.ExceptWith(nums2);
        b.ExceptWith(nums1);
        return new List<List<int>> {a.ToList(),b.ToList()}.ToArray();
        // HashSet<int> A  = nums1.ToHashSet();
        // HashSet<int> B = nums2.ToHashSet();
        // A.ExceptWith(nums2);
        // B.ExceptWith(nums1);
        // return  (new List<List<int>>{A.ToList(), B.ToList()}).ToArray();
    }
    public bool UniqueOccurrences(int[] arr) {
        
        Dictionary<int, int> occurrences = new Dictionary<int, int>();
        HashSet<int> uniqueOccurrences = new HashSet<int>();

        foreach (var num in arr) {
            occurrences[num] = occurrences.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var count in occurrences.Values) {
            if (!uniqueOccurrences.Add(count)) {
                return false;
            }
        }

        return true;
    }
    //13\12\2024
    public bool CloseStrings(string word1, string word2) {
        int length= word1.Length;
        if(length!=word2.Length){
            return false;
        }
        int[] chars1=new int[26];
        int[] chars2=new int[26];
        //because theres 26 letters in the alphabet
        int [] values=new int[length+1];
        int [] values2=new int[length+1];
        //why +1?
        //because String: "aaaa" has Length = 4. but Possible character frequencies: 0, 1, 2, 3, 4.(4+1)
        getvalues(chars1,values,word1);
        getvalues(chars2,values2,word2);
        for (int i = 0; i <26; i++)
        {
            // chars1[i] > 0 (a character appears in word1) but chars2[i] == 0 
            //it doesn't appear in word2, the words cannot be equivalent.
                if(chars1[i]>0&& chars2[i]==0){
                    return false;}
        }
        //If the number of characters that appear with specific frequencies is not the same, 
        //the words cannot be rearranged to become equivalent.
        for (int i = 0; i < length; i++)
        {
            if(values[i]!=values2[i]){
                return false;
            }
        }
        return true;
    }

    private void getvalues(int[] chars, int[] values, string word)
    //chars: Tracks how many times each character appears in the input string.
    //values: Tracks how many characters appear at a specific frequency.
        {
        foreach (var c in word)
        {
            chars[c-'a']++;
            values[chars[c-'a']]++;
        }
    }
    public int EqualPairs(int[][] grid) {
        var result = 0;
        var rowdict = new Dictionary<string, int>();
        var cloumdict = new Dictionary<string, int>();
        for (int i = 0; i < grid.Length; i++)
        {
            var rowstr="";
            var coulmstr="";
            for (int j = 0; j < grid.Length; j++)
            {
                rowstr=rowstr+","+grid[i][j].ToString();
                coulmstr=coulmstr+","+grid[j][i].ToString();   
            }
            if(!rowdict.ContainsKey(rowstr)){
                rowdict.Add(rowstr,1);
            }else{
                rowdict[rowstr]++;
            }
            if(!cloumdict.ContainsKey(coulmstr)){
                cloumdict.Add(coulmstr,1);
            }else{
                cloumdict[coulmstr]++;
            }
        }
        foreach (var dict in cloumdict)
        {
            if(rowdict.ContainsKey(dict.Key)){
                result=result+rowdict[dict.Key]*cloumdict[dict.Key];
            }            
        }
        return result;
    }
    //another soultion with hash code bec i dont like the other oneis slow =)
    public int EqualPairsHash(int[][] grid) {
        var size = grid.Length;
        var rowHashes = new int[size];
        var columnHashes = new int[size];
        var result=0;
        for (int i = 0; i < grid.Length; i++)
        {
            var rowhash=new HashCode();
            var coulmhash=new HashCode();
            for (int j = 0; j < grid.Length; j++)
            {
                rowhash.Add(grid[i][j]);
                coulmhash.Add(grid[j][i]);   
            }
        rowHashes[i]=rowhash.ToHashCode();
        columnHashes[i]=coulmhash.ToHashCode();
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if(rowHashes[i]==columnHashes[j]){
                    result++;
                }
            }
        }
        return result;
    }
    //basic idea (time limit exceed)
    public long FindScore(int[] nums) {
        long score=0;
        var index=GetSmallestElementIndex(nums);;
        while(index!=-1){
           
            score=score+nums[index];
            nums[index]=-1;
            SafeModifyNeighbors(nums,index);
            index=GetSmallestElementIndex(nums);
        }

        return score;
        
    }
     static int GetSmallestElementIndex(int[] nums)
    {
        // Check if the array is empty or contains only -1 values
        // if (numbers.Length == 0 || Array.TrueForAll(numbers, x => x == -1))
        // {
        //     return -1; 
        // }
        // int smallestIndex = 0;
        // for (int i = 1; i < numbers.Length; i++)
        // {
        //     if (numbers[i] < numbers[smallestIndex])
        //     {
        //         smallestIndex = i;
        //     }
        // }
        // return smallestIndex;
        int smallestIndex = -1;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != -1 && (smallestIndex == -1 || nums[i] < nums[smallestIndex])) {
                    smallestIndex = i;
                }
            }
            return smallestIndex;
    }
    static void SafeModifyNeighbors(int[] nums, int index)
    {
        // Check if index-1 is within bounds
        if (index - 1 >= 0)
        {
            nums[index - 1] = -1;
        }

        // Check if index+1 is within bounds
        if (index + 1 < nums.Length)
        {
            nums[index + 1] = -1;
        }
    }
    //another soultionusing System;

    public long FindddScore(int[] nums) {
        PriorityQueue<int, int> pq = new();
        bool[] marked = new bool[nums.Length];
        for(int i=0; i<nums.Length; i++)
            pq.Enqueue(i, nums[i] * 10 + i);
        
        long res = 0;
        while(pq.Count > 0) {
            int index = pq.Dequeue();
            if(!marked[index]) {
                res += nums[index];
                marked[index] = true;
                if (index - 1 >= 0) marked[index - 1] = true;
                if (index + 1 < nums.Length) marked[index + 1] = true;
            }
        }

        return res;
    }
}


