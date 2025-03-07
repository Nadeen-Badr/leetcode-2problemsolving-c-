﻿using System.Runtime.InteropServices;
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
    //stack p24 p25 and  leetcode-day-14Dec2024 
    public string RemoveStars(string s) {

        Stack<char> answer= new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i]!='*'){
                //pushing vaild letters only
                answer.Push(s[i]);
            }else{
                answer.Pop();
            }   
        }
        StringBuilder str= new StringBuilder();
        while (answer.Count>0)
        {
            //Pop each character from the stack and insert 
            //it at the beginning of the StringBuilder. 
            //This restores the correct order.
            str.Insert(0,answer.Pop());

        }
        return str.ToString();
    }
    //another soultion
     public string RemoveStarss(string s) {
        StringBuilder sb = new StringBuilder();
        int stars = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] != '*')
            {
                if (stars > 0)
                {//If yes, skip the character (it’s being removed by a star) and decrement stars.
                    stars--;
                    continue;
                }
                else
                {
                    sb.Insert(0, s[i]);
                }        
            }
            else
            {
               stars++;  

            }      
        }
        return sb.ToString();
    }


// Depending on the collision, the negative asteroid might:
//Destroy smaller positive asteroids in the stack.
//Be destroyed by a larger positive asteroid in the stack.
//Remain in the stack if it survives all collisions.
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>();
        foreach (int ast in asteroids)
        {
            if(ast>0)
            {
                stack.Push(ast);
            }
            else
            {
                //if The top positive asteroid is smaller than the negative asteroid.
                while (stack.Count>0 && stack.Peek()>0&&stack.Peek()<Math.Abs(ast))
                {
                    stack.Pop();
                }
                //Remain in the stack if it survives all collisions.
                //was greater than all postive ast in the stack so the stack became empty
                if(stack.Count==0 || stack.Peek()<0)
                {
                    stack.Push(ast);
                }
                //both equal both destroy
                else if(stack.Peek()==Math.Abs(ast))
                {
                    stack.Pop();
                }
            }
            
        }
        int [] res=new int[stack.Count];
        for(int i= stack.Count-1;i>=0;i--){
            //fill the array from the end to the start
            res[i]=stack.Pop();

        }
        return res;
        
    }
    //JUST WHY? idk
    public long ContinuousSubarrays(int[] nums) {
        int left=0;
        long answer=0;
        //These variables track the minimum and maximum values in the current subarray
        int min=nums[0];
        int max=nums[0];
        for(int i=0;i<nums.Length;i++){
            min=Math.Min(min,nums[i]);
            max=Math.Max(max,nums[i]);
            //handle invaild cases
            while(max-min>2)
            {
                left++;
                min=nums[left];
                max=nums[left];
                for(int s=left;s<=i;s++){
                    min=Math.Min(min,nums[s]);
                    max=Math.Max(max,nums[s]);
                }
            }
            answer=answer+(i-left+1);
        }
        return answer;
    }
    //queue
    public class RecentCounter {
        Queue<int> q=new Queue<int>();

    public RecentCounter() {
        
    }
    
    public int Ping(int t) {
        q.Enqueue(t);
        //smth to note peek in a stack return the top/ peek in the queue return the bottom
        while(q.Peek()<3000-t){
            q.Dequeue();
        }
        return q.Count;
    }
}
    public string DecodeString(string s) {
        Stack<String> str= new Stack<string>();
        Stack<int> number =new Stack<int>();
        String currstr="";
        int currnum=0;
        foreach (char c in s)
        {
            if(c=='[')
            {
                str.Push(currstr);
                number.Push(currnum);
                currnum=0;
                currstr="";   
            }else if(c==']')
            {
                currstr=str.Pop()+string.Join("",Enumerable.Repeat(currstr,number.Pop()));
            }
            else if (c-'0'<=9 && c - '0' >= 0)
            {
                //in case multiple digits
                currnum = currnum * 10 + (c - '0');
            }else
            {
                currstr=currstr+c;
            }
        }
        return currstr;
    }
    // private string DecodeString(string s, int l, int r)
    // {
    //     var result = new StringBuilder();
    //     while (l < r) {
    //         if ('a' <= s[l] && s[l] <= 'z') {
    //             result.Append(s[l++]);
    //             continue;
    //         }
    //         int reps = 0;
    //         while (char.IsDigit(s[l]))
    //             reps = (reps * 10) + (s[l++] - '0');
    //         int ll = l, balance = 0;
    //         do {
    //             if (s[l] == '[') balance++;
    //             if (s[l] == ']') balance--;
    //             l++;
    //         } while (balance > 0);
    //         string inner = DecodeString(s, ll + 1, l - 1);
    //         while (reps-- > 0)
    //             result.Append(inner);
    //     }
    //     return result.ToString();
    // }

    // public string DecodeString(string s) {
    //     return DecodeString(s, 0, s.Length);
    // }
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        double answer =0;
        var heap= new PriorityQueue<(int pass,int total),double>();
        foreach( var c in classes)
        {
            int p=c[0];
            int t=c[1];
            heap.Enqueue((p,t),-Gain(p,t));
        }
        while(extraStudents-->0)
        {
            //get the highest gain 
            (int p , int t)=heap.Dequeue();
            ++p;
            ++t;
            //add student calc new gain and add the class to the heap agian with the new gain
             heap.Enqueue((p,t),-Gain(p,t));
        }
        //calcute final sum all class avg ratio
        while(heap.Count>0)
        {
            (int p , int t)=heap.Dequeue();
            answer=answer+(double)p/t;
        }
        return answer/classes.Length;
    }

   double Gain(int p, int t)=>(double)(p+1)/(t+1) -(double)p/t;
    public string PredictPartyVictory(string senate) {
    Queue<char> sen = new Queue<char>(senate);
    int R = senate.Count(x => x == 'R');
    int D = senate.Length - R;
    // + => R, - => D
    int scale = 0;

    while (R > 0 && D > 0) {
        char s = sen.Dequeue();
        if (s == 'R')
        {
            if (scale >= 0) 
            {
                D--; // Dire loses a member
                sen.Enqueue(s); // Radiant senator gets another turn
            }
            scale++; // Increment scale towards Radiant
        }
        else
        { // s == 'D'
            if (scale <= 0)
            {
                R--; // Radiant loses a member
                sen.Enqueue(s); // Dire senator gets another turn
            }
            scale--; // Decrement scale towards Dire
        }
    }

    return R == 0 ? "Dire" : "Radiant";
    }
    //daily leet
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        var Heap = new SortedSet<(int value, int index)>();
        for (int i = 0; i < nums.Length; i++)
        {
            Heap.Add((nums[i],i));
        }
        for(int i =0;i<k;i++)
        {
            var min=Heap.Min;
            Heap.Remove(min);
            var update=min.value*multiplier;
            nums[min.index]=update;
            Heap.Add((update,min.index));
        }
        return nums;  
    }
    //another soultion fatser beats 100%
     public int[] GetFinalState2(int[] nums, int k, int multiplier) {
        for(int i=0 ; i<k;i++)
        {   int min=Int32.MaxValue;
            int minIndex=0;
            for(int j=0;j<nums.Length;j++)
            {
                if(nums[j]<min)
                {
                    minIndex=j;
                    min=nums[j];
                }

            }
            nums[minIndex]=nums[minIndex]*multiplier;
        }
        return nums;
    }
    //linked list problems
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
  }
    public ListNode DeleteMiddle(ListNode head) {
        //If the list has only one node deleting the middle means the list becomes empty
        if(head.next==null)
        {
            return null;
        }
        //If the list has only two nodes
        if(head.next.next==null)
        {
            head.next=null;
            return head;
        }
        ListNode slow =head;
        ListNode fast =head;
        ListNode prev =null;
        //we will make fast moves twice faster than slow so when its null slow will ne at the middle
        while(fast !=null&& fast.next != null)
        {
            prev=slow;
            slow=slow.next;
            fast=fast.next.next;
        }
        //after finding the middle , delete it
        //The prev node's next pointer is updated to skip the slow node, effectively removing it from the list.
        prev.next=slow.next;
        //The slow.next is set to null to clean up the reference 
        slow.next=null;
        return head;   
    }
 public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null) {
        return head;
        }
        ListNode Odd =head;
        ListNode Even =head.next;
        //last of the odd will pont to the first of the even
        ListNode FirstEven =Even;
        while(Odd.next!=null && Even.next!=null)
        {
            Odd.next=Even.next;
            Odd=Odd.next;
            Even.next=Odd.next;
            Even=Even.next;
        }
        Odd.next=FirstEven;
        if(Odd.next==null)
        {
            Even.next=null;
        }
        return head;
        
    }
    //daily before bec i was sick 
     public string RepeatLimitedString(string inputString, int repeatLimit) {
        // Frequency array to count occurrences of each letter (0 for 'a', 25 for 'z')
        int[] letterFrequency = new int[26];
        
        // Count the frequency of each letter in the input string
        foreach (char letter in inputString) {
            letterFrequency[letter - 'a']++;
        }

        // StringBuilder to efficiently build the result string
        StringBuilder result = new StringBuilder();

        // Start with the largest letter (z has index 25)
        int currentLetterIndex = 25;

        while (true) {
            int lettersAddedInRow = 0; // Tracks how many times the current letter is added consecutively

            // Add the current letter up to the repeat limit, if available
            while (currentLetterIndex >= 0 && letterFrequency[currentLetterIndex] > 0 && lettersAddedInRow < repeatLimit) {
                result.Append((char)(currentLetterIndex + 'a')); // Add the letter to the result
                letterFrequency[currentLetterIndex]--; // Reduce the frequency
                lettersAddedInRow++;
            }

            // If we still have this letter left but cannot add more due to the repeat limit
            if (letterFrequency[currentLetterIndex] > 0) {
                int nextLargestLetterIndex = currentLetterIndex - 1; // Find the next largest letter

                // Skip letters that are unavailable (frequency is 0)
                while (nextLargestLetterIndex >= 0 && letterFrequency[nextLargestLetterIndex] == 0) {
                    nextLargestLetterIndex--;
                }

                // If no other letters are available, stop the loop
                if (nextLargestLetterIndex < 0) break;

                // Add the next largest letter to break the sequence
                result.Append((char)(nextLargestLetterIndex + 'a'));
                letterFrequency[nextLargestLetterIndex]--; // Reduce the frequency of the letter
            } else {
                // Move to the next smaller letter (reduce the current letter index)
                currentLetterIndex--;

                // Skip letters that are unavailable (frequency is 0)
                while (currentLetterIndex >= 0 && letterFrequency[currentLetterIndex] == 0) {
                    currentLetterIndex--;
                }

                // If no letters are available, stop the loop
                if (currentLetterIndex < 0) break;
            }
        }

        // Return the final result string
        return result.ToString();
    }
    //daily today was easy
    public int[] FinalPrices(int[] prices) {
        for (int i=0;i<prices.Length;i++)
        {
            for (int j=i+1;j<prices.Length;j++)
            {
                if(prices[j]<=prices[i])
                {
                    prices[i]=prices[i]-prices[j];
                    break;
                }

            }
        }
        return prices;    
    }
    //linked list
    public ListNode ReverseList(ListNode head) {
        ListNode previous= null;
        ListNode current =head;
        ListNode tempNext= null;
        while(current!= null)
        {
            tempNext=current.next;
            //points backward to the prev node instead of the next node in the original list.
            current.next=previous;
            //move pointers now
            previous=current;
            current=tempNext;
        }
        return previous;  
    }
    public int PairSum(ListNode head) {
        ListNode slow=head;
        ListNode fast=head;
        Stack<int> stack =new();
        int max=0;
        //reverse first half by pushing in stack
        while(fast!=null && fast.next!=null)
        {
            stack.Push(slow.val);
            slow=slow.next;
            fast=fast.next.next;
        }
        while(stack.Count>0)
        {
            max=Math.Max(max,stack.Pop()+slow.val);
            slow=slow.next;
        }
        return max;  
    }
    //binary tree - DFS
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
     public int MaxDepth(TreeNode root) {
        if(root==null)
        {
            return 0;
        }
        if(root.left==null&&root.right==null)
        {
            return 1;
        }
        return Math.Max(MaxDepth(root.left),MaxDepth(root.right))+1;  
    }
    public List<TreeNode> leaves1=new();
    public List<TreeNode> leaves2=new();
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        DepthFirstSearch(root1,leaves1);
        DepthFirstSearch(root2,leaves2);
        if(leaves1.Count!=leaves2.Count)
        {
            return false;
        }
        for(int i=0;i<leaves1.Count;i++)
        {
            if(leaves1[i].val!=leaves2[i].val)
            {
                return false;
            }
        }
        return true ;
        
    }

    private void DepthFirstSearch(TreeNode node, List<TreeNode> leaves)
    {
       if(node==null)
       {
        return;
       }
       if(node.left==null && node.right == null)
       {
        leaves.Add(node);
        return;
       }
       DepthFirstSearch(node.left,leaves);
       DepthFirstSearch(node.right,leaves);
    }
    //daily
     public int MaxChunksToSorted(int[] originalArray) {
        int len=originalArray.Length;
        int chunks=0;
        int orginalPrefixSum =0;
        int sortedPrefixSum=0;
        int[]SortedArray=(int[])originalArray.Clone();
        Array.Sort(SortedArray);
        for(int i=0;i<len;i++)
        {
            orginalPrefixSum=orginalPrefixSum+originalArray[i];
            sortedPrefixSum=sortedPrefixSum+SortedArray[i];
            if(orginalPrefixSum==sortedPrefixSum)
            {
                chunks++;
            }
        }
        return chunks;
     }
     //back to binary tree - DFS
     public int GoodNodes(TreeNode root) {
        return CountGoodNodes(root,Int32.MinValue);
    }

    private int CountGoodNodes(TreeNode node, int currenyMax)
    {
        if(node==null)
        {
            return 0;
        }
        int goodNodeCount = node.val >= currenyMax ? 1 : 0;
        currenyMax=Math.Max(currenyMax,node.val);
        goodNodeCount=goodNodeCount+CountGoodNodes(node.left,currenyMax);
        goodNodeCount=goodNodeCount+CountGoodNodes(node.right,currenyMax);
        return goodNodeCount;
    }
     public int PathSum(TreeNode root, int targetSum) {
        if (root==null)
        {
            return 0;
        }
        return CountPathFromNode(root,targetSum)
        +PathSum(root.right,targetSum)
        +PathSum(root.left,targetSum);
    }

    private int CountPathFromNode(TreeNode node, long remaingSum)
    {
        if(node==null)
        {
            return 0;
        }
        int pathcount= node.val==remaingSum? 1:0;
        pathcount=pathcount+CountPathFromNode(node.left,remaingSum-node.val);
        pathcount=pathcount+CountPathFromNode(node.right,remaingSum-node.val);
        return pathcount;
    }
 
    //break the binary tree routine =-=
    public void ReverseString(char[] s) {
        int left=0;
        int right= s.Length-1;
        while(left<right)
        {
            char temp= s[left];
            s[left]=s[right];
            s[right]=temp;
            left++;
            right--;
        }
    }
    //daily
        public TreeNode ReverseOddLevels(TreeNode root) {
            if(root==null)
            {
                return null;
            }
            ReverseODDLevelNodes(root.left,root.right,1);
            return root;
        
    }

    private void ReverseODDLevelNodes(TreeNode leftNode, TreeNode rightNode, int level)
    {
        if(leftNode==null||rightNode==null)
        {
            return;
        }
        if(level%2==1)
        {
            (leftNode.val,rightNode.val)=(rightNode.val,leftNode.val);
        }
         // Process the outer nodes (left child of leftNode, right child of rightNode)
        ReverseODDLevelNodes(leftNode.left,rightNode.right,level+1);
         // Process the inner nodes (right child of leftNode, left child of rightNode)
        ReverseODDLevelNodes(leftNode.right,rightNode.left,level+1);
    }
 
    public int LongestZigZag(TreeNode root) {
        return Math.Max(
            FindLongestZigZag(root.left,true,0),
            FindLongestZigZag(root.right,false,0));   
    }

    private int FindLongestZigZag(TreeNode node, bool camefromleft, int currentmax)
    {
        if(node==null)
        {
            return currentmax;
        }
        if(camefromleft)
        {
           //Reset if going left again, increment if going right
            return Math.Max(FindLongestZigZag(node.left,true,0),FindLongestZigZag(node.right,false,currentmax+1));
        }
        else
        {
            //Reset if going right again, increment if going left
            return Math.Max(FindLongestZigZag(node.left,true,currentmax+1),FindLongestZigZag(node.right,false,0));
        }
    }
    //very good expain of what id LCA https://youtu.be/gs2LMfuOR9k?si=cQqPLTKGMcwSpjkQ
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Base Case: If the current node is null or matches either of the target nodes, return it.
        if(root==null || root==p || root==q)
        {
            return root;
        }
        TreeNode LeftSubTree=LowestCommonAncestor(root.left,p,q);
        TreeNode RightSubTree=LowestCommonAncestor(root.right,p,q);
        // If both subtrees return non-null values, the current node is the LCA.
        if (LeftSubTree!=null && RightSubTree!=null)
        {
            return root;
        }
        // Otherwise, return the non-null subtree result (if any).
        return LeftSubTree ?? RightSubTree;   
    }
    //today is a hard problem Bote that a tree means theres no cycle
     public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
      {
        //build adjacent list
        List<int>[] graph = new List<int>[n];
        foreach(var edge in edges)
        {
            int node1=edge[0];
            int node2=edge[1];
            if(graph[node1]==null)
            {
                graph[node1]=new List<int>();
            }
            if(graph[node2]==null)
            {
                graph[node2]=new List<int>();
            }
            graph[node1].Add(node2);
            graph[node2].Add(node1);
        }
        int KDivisableComponentCount=0;
        //assume zero is the root and intiall parent
        DFS(0,-1);
        return KDivisableComponentCount;
        long DFS(int currentNode,int parentNode)
        {
            long SubTreeSum=values[currentNode];
            if(graph[currentNode]!=null)
            {
                foreach(var neighbor in graph[currentNode])
                {
                    //avoid the cycle
                    if(neighbor!=parentNode)
                    {
                        SubTreeSum=SubTreeSum+DFS(neighbor,currentNode);
                    }
                }
            }
            if(SubTreeSum%k==0)
            {
                KDivisableComponentCount++;
            }
            return SubTreeSum;
        }
      }
    // binary tree bfs- breadth first search
    //ill solve this one with DFS tho
    //  public int MaxLevelSum(TreeNode root) {
    //     Dictionary<int,int> SumOfLevels=new Dictionary<int, int>();
    //     void TraverseDFS(TreeNode node, int currentlevel)
    //     {
    //         if(node==null)
    //         {
    //             return;
    //         }
    //         if(!SumOfLevels.ContainsKey(currentlevel))
    //         {
    //             SumOfLevels[currentlevel]=0;
    //         }
    //         SumOfLevels[currentlevel]=SumOfLevels[currentlevel]+node.val;
    //         TraverseDFS(node.left,currentlevel+1);
    //         TraverseDFS(node.right,currentlevel+1);
    //     }
    //     TraverseDFS(root,1);
    //     //find max
    //     return SumOfLevels.MaxBy(x=>x.Value).Key;
    //  }
     //okay it was really slow so ill use BFS
     //actually really simple and MUCH faster
     public int MaxLevelSum(TreeNode root) {
        if(root==null)
        {
            return 0;
        }
        var nodeQueue=new Queue<TreeNode>();
        nodeQueue.Enqueue(root);
        int maxlevel=1;
        int maxsum =root.val;
        int currentlevel=0;
        while(nodeQueue.Count>0)
        {
           currentlevel++;
           int levelsize=nodeQueue.Count;
           int currentsum=0;
           //process the current level
           for(int i=0 ; i< levelsize;i++)
           {
            TreeNode currentNode=nodeQueue.Dequeue();
            currentsum=currentsum+currentNode.val;
            if(currentNode.left !=null)
            {
                nodeQueue.Enqueue(currentNode.left);
            }
            if(currentNode.right !=null)
            {
                nodeQueue.Enqueue(currentNode.right);
            }
           }
           if(currentsum>maxsum)
            {
                maxsum=currentsum;
                maxlevel=currentlevel;
            }
        }
        return maxlevel;
     }
 
    public IList<int> RightSideView(TreeNode root) {
        if(root==null)
        {
            return new List<int>();
        }
        var result=new List<int>();
        var Queue = new Queue<TreeNode>();
        Queue.Enqueue(root);
        while(Queue.Count>0)
        {
            int levelsize=Queue.Count;
            int rightmost=0;
            for(int i=0;i<levelsize;i++)
            {
                TreeNode current= Queue.Dequeue();
                rightmost=current.val;
                if(current.left!=null)
                {
                    Queue.Enqueue(current.left);
                }
                if(current.right!=null)
                {
                    Queue.Enqueue(current.right);
                }
            }
            result.Add(rightmost);
        }
        return result;  
    }
    //daily
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        int[] res = new int[queries.Length];
        Array.Fill(res, -1);

        // Dictionary to group queries by the right index
        var groups = new Dictionary<int, List<(int RequiredHeight, int QueryIndex)>>();

        // Process each query
        for (int i = 0; i < queries.Length; i++)
        {
            int l = Math.Min(queries[i][0], queries[i][1]);
            int r = Math.Max(queries[i][0], queries[i][1]);

            // If the query is trivial (same building or right is taller), resolve immediately
            if (l == r || heights[r] > heights[l])
            {
                res[i] = r;
            }
            else
            {
                // Determine the required height for this query
                int requiredHeight = Math.Max(heights[l], heights[r]);

                // Group the query by the right index
                if (!groups.ContainsKey(r))
                {
                    groups[r] = new List<(int, int)>();
                }
                groups[r].Add((requiredHeight, i));
            }
        }

        // Min-heap to process queries by required height
        var minHeap = new PriorityQueue<(int RequiredHeight, int QueryIndex), int>();

        // Iterate through each building's height
        for (int i = 0; i < heights.Length; i++)
        {
            // Add all queries ending at this building to the heap
            if (groups.ContainsKey(i))
            {
                foreach (var query in groups[i])
                {
                    minHeap.Enqueue(query, query.RequiredHeight);
                }
            }

            // Resolve queries in the heap while the current building satisfies their height requirement
            while (minHeap.Count > 0 && heights[i] > minHeap.Peek().RequiredHeight)
            {
                var (requiredHeight, queryIndex) = minHeap.Dequeue();
                res[queryIndex] = i; // Update the result for this query
            }
        }

        return res;
    }

    //binary search tree

     public TreeNode SearchBST(TreeNode root, int val) {
        if(root==null || root.val==val)
        {
            return root;
        }
        if(root.val>val)
        {
            return SearchBST(root.left,val);
        }
        else
        {
            return SearchBST(root.right,val);
        }
        
    }

public TreeNode DeleteNode(TreeNode root, int key)
{
    if (root == null)
    {
        return null;
    }

    // Search for the node to delete
    if (root.val > key)
    {
        root.left = DeleteNode(root.left, key);
    }
    else if (root.val < key)
    {
        root.right = DeleteNode(root.right, key);
    }
    else
    {
        // Node to be deleted is found
        if (root.left == null && root.right == null)
        {
            // No children (leaf node)
            return null;
        }
        else if (root.left == null)
        {
            // Only right child
            return root.right;
        }
        else if (root.right == null)
        {
            // Only left child
            return root.left;
        }
        else
        {
            // Node has two children: get the inorder successor (smallest in the right subtree)
            var hold = root.right;
            while (hold.left != null)
            {
                hold = hold.left;
            }
            
            // Copy the inorder successor's value to the current node
            root.val = hold.val;
            
            // Delete the inorder successor from the right subtree
            root.right = DeleteNode(root.right, hold.val);
        }
    }

    return root;
}
//daily headache=-= 
     public int MinimumOperations(TreeNode root) {
        if(root==null)
        {
            return 0;
        }
        Queue<TreeNode> q=new Queue<TreeNode>();
        q.Enqueue(root);
        int total=0;
        while(q.Count>0)
        {
            int levelsize=q.Count;
            List<int>values=new List<int>();
            for (int i = 0; i < levelsize; i++)
            {
                TreeNode node=q.Dequeue();
                values.Add(node.val);
                if(node.left!=null)
                {
                    q.Enqueue(node.left);
                }
                if(node.right!=null)
                {
                    q.Enqueue(node.right);
                }
                
            }
            total=total+GetSwap(values);
        }
        return total;   
    }

    private int GetSwap(List<int> values)
    {
        int size=values.Count;
        int swap=0;
        List<(int v,int i)> sort= new List<(int v, int i)>();
        for (int i = 0; i < size; i++)
        {
            sort.Add((values[i],i));
        }
        // Sort the list of value-index pairs by their values.
        sort.Sort((a,b)=> a.v.CompareTo(b.v));
        //Create a visited array to track whether elements are already processed
        bool[] visited= new bool[size];
        for (int i = 0; i < size; i++)
        {
            // If the element is already visited or is already in its correct position, skip it.
            if(visited[i]||sort[i].i==i)
            {
                continue;
            }
            //f a cycle has k elements, you only need 𝑘-1 swaps to sort all  elements because swapping the
            // elements inside the cycle effectively "rotates" them into their correct positions.
            int c=0 ;
            int j=i;
            while(!visited[j])
            {
                visited[j]=true;
                j=sort[j].i;
                c++;
            }
            if(c>1)
            {
                swap=swap+(c-1);
            }
        }
        return swap;
    }
    //graph
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var q= new Queue<IList<int>>();
        var visited=new bool [rooms.Count];
        q.Enqueue(rooms[0]);
        visited[0]=true;
        while(q.Count>0)
        {
            var size=q.Count;
            for (int i = 0; i < size; i++)
            {
                var keys=q.Dequeue();
                foreach (var key in keys)
                {
                    if(!visited[key])
                    {
                    visited[key]=true;
                    q.Enqueue(rooms[key]);
                    }    
                }    
            }
        }
        return !visited.Any(x=>x==false); 
    }
    // public int FindCircleNum(int[][] isConnected) {
    //     int count=0;
    //     HashSet<int> visited=new HashSet<int>();
    //     for (int i = 0; i < isConnected.Length; i++)
    //     {
    //        if(!visited.Contains(i))
    //        {
    //         visited.Add(i);
    //         condfs(isConnected,i,visited);
    //         count++;
    //         } 
    //     }
    //     return count;
    // }

    // private void condfs(int[][] graph, int i, HashSet<int> visited)
    // {
    //     for (int j= 0; j < graph[i].Length; j++)
    //     {
    //         if(i!=j &&graph[i][j]==1&!visited.Contains(j))
    //         {
    //             visited.Add(j);
    //             condfs(graph,j,visited);
    //         } 
    //     } 
    // }
    //another better soultion is
    private bool[] visited;
    private int[][] graph;
    private int size;
    public int FindCircleNum(int[][] isConnected) {
        size=isConnected.Length;
        graph=isConnected;
        visited=new bool[size];
        int count=0;
        for (int i = 0; i < size; i++)
        {
            if(!visited[i])
            {
                condfs(i);
                count++;
            }
        }
        return count;
    }

    private void condfs(int i)
    {
        visited[i]=true;
        for (int j = 0; j < size; j++)
        {
          if(graph[i][j]==1&&!visited[j])
          {
            condfs(j);
          }  
        }
    }
    //daily hard
    private(int,int) Findfarthestnode(int n,List<List<int>> adj,int source)
    {
        Queue<int> q=new Queue<int>();
        bool []visited=new bool[n];
        q.Enqueue(source);
        visited[source]=true;
        int maxDistance=0;
        int farthestnode=source;
        while(q.Count>0)
        {
            int size=q.Count;
            for(int i=0;i<size;i++)
            {
                int curr=q.Dequeue();
                farthestnode=curr;
                foreach (var neighbor in adj[curr])
                {
                    if(!visited[neighbor])
                    {
                        visited[neighbor]=true;
                        q.Enqueue(neighbor);
                    }
                }
            }
            if(q.Count>0)
            {
                maxDistance++;
            }
        }
        return(farthestnode,maxDistance); 
    }
    private int findDiamter(int n,List<List<int>> adj)
    {
        // First BFS to find the farthest node from an arbitrary starting node (e.g., node 0)
        (int far,int _)=Findfarthestnode(n,adj,0);
        // Second BFS to find the maximum distance starting from the farthest node found above
        (int _ , int maxDistance)=Findfarthestnode(n,adj,far);
        return maxDistance;
    }
    private List<List<int>> buildAdj(int size,int [][]edges)
    {
        List<List<int>> adj=new List<List<int>>();
        for(int i=0;i<size;i++)
        {
            adj.Add(new List<int>());
        }
        foreach(int [] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }
        return adj;
    }
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2) {
        int n=edges1.Length+1;
        int m=edges2.Length+1;
        List<List<int>> adj1=buildAdj(n,edges1);
        List<List<int>> adj2=buildAdj(m,edges2);
        int d1=findDiamter(n,adj1);
        int d2=findDiamter(m,adj2);
        int combine=1+(int)Math.Ceiling(d1/2.0)+(int)Math.Ceiling(d2/2.0);
        return Math.Max(Math.Max(d1,d2),combine);     
    }
//     public int MinReorder(int n, int[][] connections) {
//     List<int>[] graph = new List<int>[n];
//     HashSet<(int, int)> directEdge = new HashSet<(int, int)>(); 

//     // Initialize the graph for all n nodes
//     for (int i = 0; i < n; i++) {
//         graph[i] = new List<int>();
//     }

//     // Fill the graph with edges and store directed edges in directEdge
//     for (int i = 0; i < connections.Length; i++) {
//         graph[connections[i][0]].Add(connections[i][1]);
//         graph[connections[i][1]].Add(connections[i][0]);
//         directEdge.Add((connections[i][0], connections[i][1])); // Directed edge from connections[i][0] to connections[i][1]
//     }

//     int result = 0;
//     HashSet<int> visited = new HashSet<int>();
    
//     // Start DFS from node 0
//     dfsgraph(graph, directEdge, 0, visited, ref result);   
//     return result;
// }

// private void dfsgraph(List<int>[] graph, HashSet<(int, int)> directEdge, int curr, HashSet<int> visited, ref int result) {
//     visited.Add(curr);

//     // Traverse all the adjacent nodes
//     foreach (var next in graph[curr]) {
//         if (!visited.Contains(next)) {
//             // Check if we need to reverse the edge
//             if (directEdge.Contains((curr, next))) {
//                 result++; // Edge needs to be reversed
//             }

//             // Continue DFS on the next node
//             dfsgraph(graph, directEdge, next, visited, ref result);
//         }
//     }
// }
    int count = 0;

    public int MinReorder(int n, int[][] connections) {
        //graph is defined as an adjList with sign to denote if original (1) or fake (0) road
        // and connection to denote which city that road leads to
        List<List<(int sign, int conn)>> adj = new(); 

        for(int i = 0; i < n; i++)
        { 
            adj.Add(new List<(int sign, int conn)>()); 
        }

        foreach(int[] road in connections)
        {
            adj[road[0]].Add((1, road[1])); //Adding original road
            adj[road[1]].Add((0, road[0])); //Adding fake road
        }

        DFS(0, -1, adj); //DFS from 0. 
        return count;

    }
        
    private void DFS(int current, int parent, List<List<(int sign, int conn)>> adj)
    {   
        foreach((int sign, int conn) nei in adj[current])
        {
            if(nei.conn == parent) 
                continue; //Don't want to go in a loop => skip parent in child

            count += nei.sign; //Keep adding sign for wrong roots
            DFS(nei.conn, current, adj); //Do DFS on child using curr as parent
        }
    }
    //   public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
    //    // i want to map a->b,a/b
    //     Dictionary<string, Dictionary<string, double>> map = new(); 
    //     HashSet<string> visited=new();
    //     //Combines equations and values to iterate over the numerator, denominator, and result together.
    //     foreach (var (numenator , denamortor ,val) in equations.Zip(values,(e,v)=>(e[0],e[1],v)))
    //     {
    //         if(!map.ContainsKey(numenator)) map[numenator]=new();
    //         if(!map.ContainsKey(denamortor)) map[denamortor]=new();
    //         map[numenator][denamortor]=1/val;
    //         map[denamortor][numenator]=val;
    //     }
    //     return queries.Select(s=>Findress(s[1],s[0])).ToArray();    
    //      double Findress(string source, string target)
    //     {
    //         if(!map.ContainsKey(source)) return -1;
    //         if(source==target) return 1;
    //         double curr=-1;
    //         visited.Add(source);
    //         foreach (var key in map[source].Keys)
    //         {
    //             if(visited.Contains(key)) continue;
    //             curr=Findress(key,target);
    //             if(curr!=-1)
    //             {
    //                 curr=curr*map[source][key];
    //                 break;
    //             }   
    //         }
    //         visited.Remove(source);
    //         return curr;
    //     }
    // }
    // was not effeicent
    //this is probably bettter
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
         // Build adjacency list to represent the graph
        var graph = new Dictionary<string, List<(string neighbor, double weight)>>();  
        for(int i=0;i<equations.Count;i++)
        {
            string numerator=equations[i][0];
            string denominator=equations[i][1];
            double value = values[i];
            if(!graph.ContainsKey(numerator))
                graph[numerator]=new List<(string , double )>();
            graph[numerator].Add((denominator,value));
            if(!graph.ContainsKey(denominator))
                graph[denominator]=new List<(string , double )>();
            graph[denominator].Add((numerator,1/value));
        }
        var results=new double[queries.Count];
        for(int i=0;i<queries.Count;i++)
        {
            string start=queries[i][0];
            string end = queries[i][1];
            var visited=new HashSet<string>();
            results[i]=performDFS(start,end,visited,graph);
        }
        return results;
    }

    private double performDFS(string curr, string target, HashSet<string> visited, Dictionary<string, List<(string neighbor, double weight)>> graph)
    {
        if(!graph.ContainsKey(curr)) return -1.0;
        if(curr==target) return 1.0;
        visited.Add(curr);
        foreach (var (nei,weight) in graph[curr])
        {
            if(!visited.Contains(nei))
            {
                double result=performDFS(nei,target,visited,graph);
                if(result!=-1) return weight*result;//vaild path found
            }    
        }
        return-1.0;
    }
    //only daily bec sick
     public IList<int> LargestValues(TreeNode root) {
        List<int> result=new List<int>();
       if(root==null) return result;
       Queue <TreeNode> q=new Queue<TreeNode>();
       q.Enqueue(root);
       while(q.Count>0)
       {
        int levelsize=q.Count;
        int max=int.MinValue;
        for (int i = 0; i < levelsize; i++)
        {
            TreeNode curr=q.Dequeue();
            max=Math.Max(max,curr.val);
            if(curr.left!=null) q.Enqueue(curr.left);
            if(curr.right!=null) q.Enqueue(curr.right);
        }
        result.Add(max);
       }
       return result;   
    }
    // // daily with LINQ
    //   public int FindTargetSumWays(int[] nums, int target,int i=0) =>(i<nums.Length) ?
    //    FindTargetSumWays(nums,target-nums[i],i+1)+FindTargetSumWays(nums,target+nums[i],i+1) :target==0?1:0;
    //    //another way
    public int FindTargetSumWays(int[] nums, int target)
    {
        //sum the array
        int sum =0;
        foreach (int number in nums)
        {
            sum=sum+number;
        }
        // Step 2: Calculate the new target (subset sum) based on the equation:
        // P - N = target, P + N = sum(nums).
        // This simplifies to P = (target + sum(nums)) / 2.
        //p is postive n is negative
        int newtarget=(target+sum)/2;
        // - If (target + sum) is odd, it's impossible to split the array into subsets with the desired difference.
        // - If sum < |target|, we can't possibly reach the target sum.
        // - If sum < newTarget, it's also infeasible to form the subset.
        if((target+sum)%2==1||sum<Math.Abs(target)||sum<newtarget)
        {
            return 0;
        }
        // dp[i] represents the number of ways to form a subset sum of `i`.
        int [] dp=new int[newtarget+1];
        dp[0]=1;
        foreach (int number in nums)
        {

            // Traverse from `newTarget` down to `n` to ensure we don't overwrite results.
            for(int i=newtarget;i>=number;i--)
            {
            // Explanation: dp[i] += dp[i - n] means:
            // The number of ways to make sum `i` includes all the ways to make sum `i - n`
            // (by adding the current number `n` to those subsets).
                dp[i]=dp[i]+dp[i-number];
            }   
        }
        return dp[newtarget];
    }
    //daily
    public int MaxScoreSightseeingPair(int[] values) {
        int[] MaxAdjustedVal=new int[values.Length];
        int max=0;
        for(int i=1;i<values.Length;i++)
        {
            // Update maxAdjustedValue for the current index:
            // It's the maximum of:
            // - The previously stored maxAdjustedValue decreased by 1 (distance penalty).
            // - The value at the previous index decreased by 1 (adjusted for distance).
            MaxAdjustedVal[i]=Math.Max(MaxAdjustedVal[i-1]-1,values[i-1]-1);
            // Calculate the score for the sightseeing pair formed by the current element:
            // - `values[i]`: Value of the current element.
            // - `maxAdjustedValue[i]`: Best adjusted value up to the current index.
            max=Math.Max(max,values[i]+MaxAdjustedVal[i]);
        }
        return max;
    }
     public int NearestExit(char[][] maze, int[] entrance) {
        int rows=maze.Length;
        int cols=maze[0].Length;
        int[][] directions=new int[][]
        {
            new int[]{-1,0} ,//up
            new int[]{1,0},//down
            new int[]{0,-1} ,//left
            new int[]{0,1}//right
        };
        // Queue for BFS: stores (row, column, steps from the entrance)
        Queue<(int row,int col,int steps)>q=new Queue<(int , int , int )>();
        q.Enqueue((entrance[0],entrance[1],0));
        maze[entrance[0]][entrance[1]]='+';// Mark the entrance as visited
        while(q.Count>0)
        {
            var(currRow,currCol,steps)=q.Dequeue();
            foreach(var dir in directions)
            {
                int newRow=currRow+dir[0];
                int newcol=currCol+dir[1];
                // Check if the new position is within bounds and unvisited
                if(newRow>=0&&newRow<rows&&newcol>=0&&newcol<cols&&maze[newRow][newcol]=='.')
                {
                    // If the new position is on the border and not the entrance, it's an exit
                    if(newRow==0||newRow==rows-1||newcol==0||newcol==cols-1)
                    {
                        return steps+1;
                    }
                    maze[newRow][newcol]='+';
                    q.Enqueue((newRow,newcol,steps+1));
                }
            }
        }
        return -1;   
    }
    //3
    public int OrangesRotting(int[][] grid) {

        int rows=grid.Length;
        int cols=grid[0].Length;
        Queue<(int row,int col)>q=new Queue<(int row, int col)>();
        int fresh=0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
               if(grid[i][j]==2)
               {
                q.Enqueue((i,j));
               } 
               else if(grid[i][j]==1)
               {
                fresh++;
               }
            }   
        }
        List<(int dx,int dy)>direction =new List<(int dx, int dy)>{(-1,0),(1,0),(0,1),(0,-1)};
        int min=0;
        while(q.Count>0&&fresh>0)
        {
            int currlevel=q.Count;
            for(int i=0;i<currlevel;i++)
            {
                var(currRow,currCol)=q.Dequeue();
                foreach(var (dx,dy) in direction)
                {
                    int newRow=currRow+dx;
                    int newCol=currCol+dy;
                     // Skip if the cell is out of bounds or not a fresh orange
                     if(newRow<0||newCol<0||newRow>=rows||newCol>=cols||grid[newRow][newCol]!=1)
                     {
                        continue;
                     }
                     grid[newRow][newCol]=2;
                     q.Enqueue((newRow,newCol));
                     fresh--;
                }
            }
            min++;
        }
        return fresh>0 ? -1:min;
    }
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        int n=nums.Length;
        int []ans=[-1,-1,-1];
        long [] prefixSum=new long[n-k+1];// Prefix sums to store the sum of subarrays of length k
        int currSum=0;// Current sum of a sliding window of size k
        for (int i = 0; i < k; i++)
        {
            currSum=currSum+nums[i];
        }
        //fill using sliding window
        for (int i = k; i < n; i++)
        {
            prefixSum[i-k]=currSum;
            currSum=currSum+nums[i]-nums[i-k];    
        }
        prefixSum[n-k]=currSum;
        Dictionary<string,long>chace=new();
        int index=0;
        int count =0;
        while(index<=n-((3-count)*k)&&count<3)
        {
            // Calculate the maximum sum if we include or skip the current subarray
            var include=prefixSum[index]+GetMaxSUM(index+k,count+1);
            var skip=GetMaxSUM(index+1,count);
            if(include>=skip)
            {
                ans[count++]=index;
                index=index+k;
            }
            else
            {
                index++;
            }
        }
        return ans; 
        long GetMaxSUM(int i, int subarraycount)
        {
            if(subarraycount==3||i>n-((3-subarraycount)*k)) return 0;
            //unique key
            string key=i+"|"+subarraycount;
            // Check if the result for the current state is already computed
            if(chace.TryGetValue(key,out long sum)) return sum;
             // Calculate the sum if the current subarray is included or skipped
             var inculdesub=prefixSum[i]+GetMaxSUM(i+k,subarraycount+1);
             var skipsub=GetMaxSUM(i+1,subarraycount);
             return chace[key]=Math.Max(inculdesub,skipsub);
        }  
    }
    private const long modulus=1000000007;
    public int NumWays(string[] words, string target) {
            // Define a constant for modulus to handle large numbers and prevent overflow
      
          long[] dp = new long[target.Length];
         for (int i = 0; i < words[0].Length; i++)
         {
            // Calculate the frequency of each letter at the current position in all words
            int[] letterfreq=CalcLetterFreqAtIndex(words,i);
            // Traverse the target string from back to front to avoid overwriting values in dp
            for (int targewt = Math.Min(i,target.Length-1); targewt >= 0; targewt--)
            {
                // Get the index of the current letter in the target string
                int letterIndex=target[targewt]-'a';
                if(letterfreq[letterIndex]>0)
                {
                    // First character in target?
                    dp[targewt]+=(targewt==0)?letterfreq[letterIndex]:dp[targewt-1]*letterfreq[letterIndex];
                    // Apply modulus to keep the result within bounds
                    dp[targewt]%=modulus;
                }  
            }

         }
         return (int)dp[dp.Length-1];
    }

    private int[] CalcLetterFreqAtIndex(string[] words, int i)
    {
       int []letterfreq=new int[26];
       for (int j = 0; j < words.Length; j++)
       {
        // Count the occurrences of each letter at the specified position in all words
            letterfreq[words[j][i]-'a']++;
       }
       return letterfreq;
    }

//     public class Solution {
//     private const int MOD = 1000000007;
//     public int NumWays(string[] words, string target) {
//         int m = target.Length;
//         int n = words[0].Length;

//         var freq = new int[n, 26];

//         foreach (var word in words)
//         {
//             for (int i = 0; i < n; i++)
//             {
//                 freq[i, word[i] - 'a']++;
//             }
//         }

//         var dp = new long[m + 1];
//         dp[0] = 1;

//         for (int i = 0; i < n; i++)
//         {
//             for (int j = m - 1; j >= 0; j--)
//             {
//                 dp[j + 1] = (dp[j + 1] + dp[j] * freq[i, target[j] - 'a']) % MOD;
//             }
//         }

//         return (int)dp[m];
//     }
// }
     public int CountGoodStrings(int low, int high, int zero, int one) {
        const int mod=1000000007;
        int[]dp=new int[high+1];   
        dp[0]=1;
        for (int i = 1; i < high; i++)
        {
            if(i>=zero)
            {
                dp[i]=(dp[i]+dp[i-zero])%mod;
            }
            if(i>=one)
            {
                dp[i]=(dp[i]+dp[i-one])%mod;
            }   
        }
        int res=0;
        for (int i = low; i < high; i++)
        {
            res=(res+dp[i])%mod;
        }
        return res;     
    }
      public int MincostTickets(int[] days, int[] costs) {
        int MaxDays=365;
        bool[] travelday=new bool[MaxDays+1];
        foreach (var day in days)
        {
            travelday[day]=true;
        }
        int []dp=new int[MaxDays+1];
        dp[0]=0;
        for (int i = 1; i <= MaxDays; i++)
        {
            if(!travelday[i])
            {
                dp[i]=dp[i-1];
            }
            else
            {
                int cost1=dp[i-1]+costs[0];
                int cost7=dp[Math.Min(0,i-7)]+costs[1];
                int cost30=dp[Math.Min(0,i-30)]+costs[2];
                dp[i]=Math.Min(cost1,Math.Min(cost7,cost30));
            }
        }
        return dp[MaxDays]; 
    }
    public int MaxScore(string s) {
        int max=0;
        int zeros=0;
        int ones=0;
        foreach (var c in s)
        {
            if(c=='1') ones++;
        }
        for(int i=0;i<s.Length-1;i++)
        {
            if(s[i]=='0')
            {
                zeros++;
            }
            else
            {
                ones--;
            }
            int curr=zeros+ones;
            max=Math.Max(max,curr);
        }
        return max;
    }
    //daily
     public int WaysToSplitArray(int[] nums) {
        int l=nums.Length;
        long total=0;
        foreach (var n in nums)
        {
            total=total+n;
        }
        long leftsum=0;
        int vaild=0;
        for (int i = 0; i < l-1; i++)
        {
            leftsum=leftsum+nums[i];
            long right=total-leftsum;
            if(leftsum>=right)
            {
                vaild++;
            }  
        }
        return vaild; 
    }
 public int[] VowelStrings(string[] words, int[][] queries) {
    HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    int[] answer = new int[queries.Length];
    int[] prefix = new int[words.Length];
    int count = 0;

    for (int i = 0; i < words.Length; i++) {
        if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][words[i].Length - 1])) {
            count++;
        }
        prefix[i] = count;
    }

    for (int i = 0; i < queries.Length; i++) {
        if (queries[i][0] == 0) {
            answer[i] = prefix[queries[i][1]];
        } else {
            answer[i] = prefix[queries[i][1]] - prefix[queries[i][0] - 1];
        }
    }

    return answer;
}
 public int CountPalindromicSubsequence(string s) {
    //A valid palindrome of this type has the form x , y , x , 
    //where x is the same character at both ends, and y is any character in the middle.
    HashSet<string> uniquePlan=new HashSet<string>();
    int size=s.Length;
    for (char i = 'a'; i <= 'z'; i++)
    {
        int f=-1;
        int l=-1;
        for (int j = 0; j < size; j++)
        {
            if(s[j]==i)
            {
                if(f==-1) f=j;
                else l=j;
            }  
        }
        if(f!=-1&&l>f)
        {
            HashSet<char>middle=new HashSet<char>();
            for (int j = f+1; j < l; j++)
            {
                middle.Add(s[j]);   
            }
            foreach (var x in middle)
            {
                uniquePlan.Add($"{i}{x}{i}");
            }
        }   
    }
    return uniquePlan.Count;  
    }
    public string ShiftingLetters(string s, int[][] shifts) {
        int n=s.Length;
        int[] shiftcount=new int[n];// Array to store net shifts for each character
        foreach (var shift in shifts)
        {
            int start=shift[0];
            int end=shift[1];
            int direction=shift[2];
            // Update the shift count for each character in the range [start, end]
            for (int i = start; i <= end; i++)
            {
                 // Increment shift count for forward shift, decrement for backward
                 shiftcount[i]+=(direction==1)?1:-1;
            }
        }
        char[]res=s.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            int shift=shiftcount[i]%26;
            if(shift<0) shift+=26;
            // Shift the character and ensure it wraps around within 'a' to 'z'
            res[i]=(char)('a'+(res[i]-'a'+shift)%26);
        }
        return new string(res);
    }
    public int FindKthLargest(int[] nums, int k)
    {
        var minheap= new PriorityQueue<int,int>();
        foreach (var n in nums)
        {
            minheap.Enqueue(n,n);
             // If the heap size exceeds k, remove the smallest element.
            // This ensures the heap only contains the k largest elements.
            if(minheap.Count>k)
            {
                minheap.Dequeue();
            }
        }
        // The smallest element in the heap is the kth largest element in the array.
        return minheap.Dequeue();
    }

    public class SmallestInfiniteSet {
        private readonly PriorityQueue<int,int>_minheap;

    public SmallestInfiniteSet() {
        _minheap=new PriorityQueue<int, int>(Enumerable.Range(1,1000).Select(num=>(num,num)));
    }
    
    public int PopSmallest() {
       int smallest=_minheap.Dequeue();
       // Remove any duplicates of the smallest number (if they exist)
        while(_minheap.Count>0&&_minheap.Peek()==smallest)
        {
            _minheap.Dequeue();
        }
        return smallest;
    }
    
    public void AddBack(int num) {
        _minheap.Enqueue(num,num);
    }
}
    // o(n^2)
    //   public int[] MinOperations(string boxes) {
    //     int n=boxes.Length;
    //     int[] result=new int[n];
    //     for (int i = 0; i < n; i++)
    //     {
    //         int operations=0;
    //         for (int j = 0; j < n; j++)
    //         {
    //             if(boxes[j]=='1')
    //             {
    //                 operations+=Math.Abs(i-j);
    //             }
    //         }
    //         result[i]=operations;
    //     }
    //     return result;  
    // }
    //o(n)
     public int[] MinOperations(string boxes)
    {
        int n=boxes.Length;
        int[] result=new int[n];
        //left pass
        int balls=0;
        int operations=0;
        for (int i = 0; i < n; i++)
        {
            result[i]=result[i]+operations;
            // If the current box has a ball, increment the ball count
            if(boxes[i]=='1') balls++;
            //update operations for next element
            operations=operations+balls;
        }
        //right pass
        balls=0;
        operations=0;
        for (int i = n - 1; i >= 0 ; i--)
        {
            result[i]=result[i]+operations;
            if(boxes[i]=='1') balls++;
            //update operations for next element
            operations=operations+balls;
        }
        return result;
    }
     public IList<string> StringMatching(string[] words) {
        List<string> result=new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if(i!=j&&words[j].Contains(words[i]))
                {
                    result.Add(words[i]);
                    break;
                }
            }
        }
        return result;  
    }
 
    //or use linq return words.Where(x => words.Where(w => w != x).
    //Any(w => w.Contains(x))).ToList();
     public int CountPrefixSuffixPairs(string[] words) {
        int answer=0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i+1; j < words.Length; j++)
            {
                if(i<j)
                {
                    if(words[j].StartsWith(words[i]) && words[j].EndsWith(words[i]))
                    {
                        answer++;
                    }
                }
            }
        }
        return answer;   
    }
    //Back75
      public long MaxScore(int[] nums1, int[] nums2, int k) {
        List<(int,int)>lst=new();
        for (int i = 0; i < nums1.Length; i++)
        {
            lst.Add((nums1[i],nums2[i]));
        }
        lst=lst.OrderByDescending(x=>x.Item2).ToList();
        PriorityQueue<int,int>pq=new();
        long sum=0;
        int min=0;
        for (int i = 0; i < k; i++)
        {
         pq.Enqueue(lst[i].Item1,lst[i].Item1);
         sum=sum+lst[i].Item1;
         min=lst[i].Item2;   
        }
        long res=sum*min;
        for (int i = k; i < nums1.Length; i++)
        {
            sum=sum+lst[i].Item1-pq.Dequeue();
            pq.Enqueue(lst[i].Item1,lst[i].Item1);
            min=lst[i].Item2;
            res=Math.Max(res,sum*min);   
        }
        return res;
    }
     public int PrefixCount(string[] words, string pref) {
        int count=0;
        foreach (var word in words)
        {
            if(word.StartsWith(pref)) count++;
        }
        return count;
    }
     public int IsPrefixOfWord(string sentence, string searchWord) {
        string [] words=sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if(words[i].StartsWith(searchWord))
            {
                return i+1;
            }
        }
        return -1;
    }
    public int CountPrefixes(string[] words, string s) {
        int count=0;
        foreach (var word in words)
        {
            if(s.StartsWith(word)) count++;
        }
        return count;
    }
     public bool IsPrefixString(string s, string[] words) {
        StringBuilder str=new StringBuilder();
        foreach (var word in words)
        {
            str.Append(word);
            if(str.ToString()==s)return true;
        }
        return false; 
    }
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var res=new List<string>();
        int []maxfreq=new int[26];
        foreach (var word in words2)
        {
            int []count=Count(word);
            for (int i = 0; i < 26; i++)
            {
                maxfreq[i]=Math.Max(maxfreq[i],count[i]);
            }
        }
        foreach (var word in words1)
        {
            int [] count=Count(word);
            bool vaild=true;
            for (int i = 0; i < 26; i++)
            {
                if(count[i]<maxfreq[i])
                {
                    vaild=false;
                    break;
                }
            }
            if(vaild) res.Add(word);
        }
        return res;
    }
            private int[] Count(string word){
            int []count=new int[26];
            foreach (var c in word)
            {
                count[c-'a']++;
            }
            return count;
        }
         public bool CanConstruct(string s, int k) {
            if(s.Length<k) return false;
            int[]freq=new int[26];
            foreach(char c in s)
            {
                freq[c-'a']++;
            }
            var odd=0;
            for (int i = 0; i < 26; i++)
            {
                odd+= freq[i]%2 ==0? 0:1;
            }
            // A palindrome can only have one odd-frequency character at its center;
          return odd<=k;
    }
      public bool CanBeValid(string s, string locked) {
        if(s.Length%2==1) return false;
        var open=0; 
        var colse=0;
        for (int i = 0; i < s.Length; i++)
        {
            open+= (s[i]==')'&& locked[i]=='1') ? -1:1;
            if(open<0) return false;
        }
        for (int i = s.Length -1 ; i >=0; i--)
        {
            colse +=(s[i]=='('&&locked[i]=='1') ? -1 :1;
            if(colse<0) return false;
        }
        return true;
    }
    //back to 75
        public long TotalCost(int[] costs, int k, int candidates) {
            var PQ1=new PriorityQueue<int,int>();
            var PQ2=new PriorityQueue<int,int>();
            int i=0;
            int j= costs.Length-1;
            long totalcost=0;
            while(k>0)
            {
                while(PQ1.Count<candidates && i<=j)
                {
                    PQ1.Enqueue(costs[i],costs[i]);
                    i++;
                }
                  while(PQ2.Count<candidates && j>=i)
                {
                    PQ2.Enqueue(costs[j],costs[j]);
                    j--;
                }
                int val1=PQ1.Count>0?PQ1.Peek() : int.MaxValue;
                int val2=PQ2.Count>0?PQ2.Peek() : int.MaxValue;
                if(val1<=val2)
                {
                    totalcost+=val1;
                    PQ1.TryDequeue(out _, out _);
                }
                else
                {
                    totalcost+=val2;
                    PQ2.TryDequeue(out _, out _);
                }
                k--;
            }
            return totalcost;
    }
    //binary search
     public int GuessNumber(int n) {
        int left=0;
        int right =n;
        while(left<=right)  
        {
            var mid=left+(right-left)/2;
            var res=guess(mid);
            if(res==0) return mid;
            else if(res==-1) right=mid-1;
            else left=mid+1;
        } 
        throw new InvalidOperationException();
    }

    private int guess(int mid)
    {
        throw new NotImplementedException();
    }
      public int MinCost(int[][] grid) {
        int m=grid.Length;
        int n=grid[0].Length;
        int[,] cost=new int[m,n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cost[i,j]=int.MaxValue;
            }
        }
        cost[0,0]=0;
        var PQ=new PriorityQueue<(int,int),int>();
        PQ.Enqueue((0,0),0);
        int [] [] directions= [[0,1],[0,-1],[1,0],[-1,0]];
        while(PQ.Count>0)
        {
            var(x,y)=PQ.Dequeue();
            if(x==m-1 & y==n-1)
            return cost[x,y];
            int dir=grid[x][y]-1;
            int newx=x+directions[dir][0];
            int newy=y+directions[dir][1];
            if(IsInBound(newx,newy,m,n)&& cost[newx,newy]>cost[x,y])
            {
                cost[newx,newy]=cost[x,y];
                PQ.Enqueue((newx,newy),cost[newx,newy]);
            }
            for (int i = 0; i < 4; i++)
            {
                newx=x+directions[i][0];
                newy=y+directions[i][1];
                if(IsInBound(newx,newy,m,n)&&cost[newx,newy]>cost[x,y]+1)
                {
                    cost[newx,newy]=cost[x,y]+1;
                    PQ.Enqueue((newx,newy),cost[newx,newy]);
                }
            }
        }
        return -1;
    }

    private bool IsInBound(int x, int y , int m, int n)
    {
        return x>=0&& x<m && y>=0 && y<n;
    }
    public int TrapRainWater(int[][] heightMap) {
        // first of all Get the dimensions of the height map
        int m=heightMap.Length;
        int n=heightMap[0].Length;
        // Priority queue to store boundary points with their height
        // The queue is ordered by height (smallest height first)
        var pq=new PriorityQueue<(int x,int y,int val),int>
        (Comparer<int>.Create((a, b) => a.CompareTo(b)));
        // Step 1: Add all boundary points to the priority queue
        // Mark boundary points as visited by setting their height to -1
        for(int row=0;row<m;row++)
        {
            //left boundry
            pq.Enqueue((row,0,heightMap[row][0]),heightMap[row][0]);
            heightMap[row][0]=-1; //this is how i mark it as visited
            //right boundry
            pq.Enqueue((row,n-1,heightMap[row][n-1]),heightMap[row][n-1]);
            heightMap[row][n-1]=-1;
        }
        for(int col=1;col<n-1;col++)
        {
            //top boundry
            pq.Enqueue((0,col,heightMap[0][col]),heightMap[0][col]);
            heightMap[0][col]=-1; //this is how i mark it as visited
            //bottom boundry
            pq.Enqueue((m-1,col,heightMap[m-1][col]),heightMap[m-1][col]);
            heightMap[m-1][col]=-1;
        }
        // Directions for moving to adjacent cells (right, left, down, up)
        var dir=new(int dx,int dy)[]{(0,1),(0,-1),(1,0),(-1,0)};
        int result=0;
        // Step 2: Process the priority queue
        while(pq.Count>0)
        {
            var(x,y,val)=pq.Dequeue();
            // Step 3: Check all four neighbors of the current point
            foreach(var(dx,dy) in dir)
            {
                int nx=x+dx;
                int ny=y+dy;
                // Skip if the neighbor is out of bounds or already visited
                if(nx<0||nx>=m||ny<0||ny>=n||heightMap[nx][ny]==-1) continue;
                // The trapped water is the difference 
                //between the current boundary height and the neighbor's height
                result+=Math.Max(0,val-heightMap[nx][ny]);
                // Step 4: Add the neighbor to the priority queue with the updated height
                // The new height is the maximum of the current neighbor's height and the boundary heigh
                int newh=Math.Max(heightMap[nx][ny],val);
                pq.Enqueue((nx,ny,newh),newh);
                heightMap[nx][ny]=-1;
            }
        }
        return result;
    }

     public int FirstCompleteIndex(int[] arr, int[][] mat) {
        int m=mat.Length;//rows
        int n=mat[0].Length;//# of cols
        Dictionary<int,(int r,int c)> postions=new Dictionary<int, (int r, int c)>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                postions[mat[i][j]]=(i,j);
            }
        }
        int[]paintedrowcount=new int[m];
        int[] paintedcolcount=new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            (int row,int col)=postions[arr[i]];
            paintedrowcount[row]++;
            paintedcolcount[col]++;
            //Since n is the number of columns, 
            //this condition checks if every element in that row has been painted.
            //and viceversa
            if(paintedrowcount[row]==n || paintedcolcount[col]==m)
            return i;
        }
        return -1;
    }
    // public long GridGame(int[][] grid) {
    //     int n=grid[0].Length;
    //     long[] firstrowpreifx=new long[n];
    //     long[] secondrowpreifx=new long[n];
    //     firstrowpreifx[0]=grid[0][0];
    //     secondrowpreifx[0]=grid[1][0];
    //     for (int i = 1; i < n; i++)
    //     {
    //         firstrowpreifx[i]=firstrowpreifx[i-1]+grid[0][i];
    //         secondrowpreifx[i]=secondrowpreifx[i-1]+grid[1][i];
    //     }
    //     long sum=0; long index=-1;
    //     for (int i = 0; i < n; i++)
    //     {
    //         if(firstrowpreifx[i]+secondrowpreifx[i]>sum)
    //         {
    //             sum=firstrowpreifx[i]+secondrowpreifx[i];
    //             index=i;
    //         }
    //     }
    //     long answer=long.MaxValue;
    //     for (int i = 0; i < n; i++)
    //     {
    //         long top=firstrowpreifx[n-1]-firstrowpreifx[i];
    //         long bottom= i==0?0:secondrowpreifx[i-1];
    //         answer=Math.Min(answer,Math.Max(top,bottom));
    //     }
    //     return answer; 
    // }
    public long GridGame(int[][] grid)
    {
        long topRowSum = 0;
        // Calculate the sum of all elements in the top row (grid[0]), excluding the first element
        for (int i = 1; i < grid[0].Length; i++)
        {
            topRowSum=topRowSum+grid[0][i];
        }
          // Initialize the variables to track the remaining sum of the top row and the accumulated sum of the bottom row
        long bottomRowCumulativeSum = 0;

        long optimalResult = topRowSum; // Initially, the result is the total sum of the top row
        for (int col = 1; col < grid[0].Length; col++)
        {
            // Update the sum of the remaining elements in the top row as we move right
            topRowSum -= grid[0][col];

            // Update the cumulative sum of the bottom row as we progress through the columns
            bottomRowCumulativeSum += grid[1][col - 1];

            // The optimal result is the minimum of the previous result and the maximum of the current top row sum and the cumulative bottom row sum
            optimalResult = Math.Min(optimalResult, Math.Max(topRowSum, bottomRowCumulativeSum));
        }
        return optimalResult;
    }
      public int[][] HighestPeak(int[][] isWater) {
        int m=isWater.Length;
        int n=isWater[0].Length;
        int[][] hight=new int[m][];
        for (int i = 0; i < m; i++)
        {
            hight[i]=new int [n];
            Array.Fill(hight[i],-1);
        }
        var dir=new(int dx,int dy)[]{(0,1),(0,-1),(1,0),(-1,0)};
        Queue<(int,int)> q=new Queue<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(isWater[i][j]==1)
                {
                    hight[i][j]=0;
                    q.Enqueue((i,j));
                }
            }
        }
        while(q.Count>0)
        {
            var(x,y)=q.Dequeue();
            foreach (var (dx,dy) in dir)
            {
                int nx=x+dx;
                int ny=y+dy;
                if(nx>=0&&nx<m&&ny>=0&&ny<n&&hight[nx][ny]==-1)
                {
                    hight[nx][ny]=hight[x][y]+1;
                    q.Enqueue((nx,ny));
                }
            }
        }
        return hight;
    }
       public int CountServers(int[][] grid) {
        int m=grid.Length;//rows
        int n=grid[0].Length;
        int[]CountRow=new int[m];
        int[] CountCol=new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(grid[i][j]==1)
                {
                    CountRow[i]++;
                    CountCol[j]++;
                }
            }
        }
        int connect=0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(grid[i][j]==1&&(CountRow[i]>1 || CountCol[j]>1))
                {
                   connect++;
                }
            }
        }
        return connect;
    }
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        int [] sorted=(int []) nums.Clone();
        Array.Sort(sorted);
        int current=0;
        Dictionary<int,int> numgrops=new Dictionary<int, int>();
        Dictionary<int,Queue<int>> groups=new Dictionary<int, Queue<int>>();
        numgrops[sorted[0]]=current;
        groups[current]=new Queue<int>();
        groups[current].Enqueue(sorted[0]);
        for (int i = 1; i < sorted.Length; i++)
        {
            if(sorted[i]-sorted[i-1]>limit)
            {
                current++;
                groups[current]=new Queue<int>();
            }
            numgrops[sorted[i]]=current;
            groups[current].Enqueue(sorted[i]);
        }  
        for (int i = 0; i < nums.Length; i++)
        {
            int group=numgrops[nums[i]];
            nums[i]=groups[group].Dequeue();
        }
        return nums; 
    }
    public IList<int> EventualSafeNodes(int[][] graph) {
        var termianlNodeds=new HashSet<int>();
        var visited= new HashSet<int>();
        return Enumerable.Range(0,graph.Length).Where(Istermnal).ToArray();
        bool Istermnal(int node)
        {
            if(!visited.Contains(node))
            {
                visited.Add(node);
                if(graph[node].All(Istermnal))
                {
                    termianlNodeds.Add(node);
                }
            }
            return termianlNodeds.Contains(node);
        }   
    }
    public int MaximumInvitations(int[] favorite) {
        var g=new Dictionary<int,List<int>>();
        for (int i = 0; i < favorite.Length; i++)
        {
            var f=favorite[i];
            if(!g.ContainsKey(f))
            {
                g[f]=new List<int>();
            }
            g[f].Add(i);
        }  
        //find all 2-person seating arrangment
        var visted=new HashSet<int>();
        var maxinvites=0; 
        var twoman=0;
        for (int i = 0; i < favorite.Length; i++)
        {
            if(visted.Contains(i)) continue;
            var f=favorite[i];
            if(favorite[f]==i)
            {
                visted.Add(f);
                visted.Add(i);
                maxinvites+=Exten(i,visted,g);
                maxinvites+=Exten(f,visted,g);
                
            }
        }
        for (int i = 0; i < favorite.Length; i++)
        {
            if(!visted.Contains(i))
            {
                maxinvites=Math.Max(maxinvites,DepFS(i,favorite,visted,new List<int>(),new HashSet<int>()));
            }
        }
        return maxinvites;
    }
    public int Exten(int emp,HashSet<int>v,Dictionary<int,List<int>>g){
        var q=new Queue<int>();
        q.Enqueue(emp);
        int seat=0;
        while(q.Count>0)
        {
            seat++;
            int count=q.Count;
            for (int i = 0; i < count; i++)
            {
                var f=q.Dequeue();
                if(!g.ContainsKey(f)) continue;
                foreach (var next in g[f])
                {
                    if(!v.Contains(next))
                    {
                        v.Add(next);
                        q.Enqueue(next);
                    }
                }
            }
        }
        return seat;
    }
    public int DepFS(int i, int[] favorite, HashSet<int> visted, List<int> list, HashSet<int> hashSet)
    {
       if(visted.Contains(i))
       {
        if(!hashSet.Contains(i)) return 0;
        int index=0;
        for(index=0;index<list.Count;index++)
        {
            if(list[index]==i) break;
        }
        return list.Count-index;
       }
       visted.Add(i);
       hashSet.Add(i);
       list.Add(i);
       return DepFS(favorite[i],favorite,visted,list,hashSet);
    }
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var g=new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            g[i]=new List<int>();
        }
        foreach (var p in prerequisites)
        {
            g[p[0]].Add(p[1]);
        }
        var reachable=new HashSet<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            reachable[i]=new HashSet<int>();
        }
        void DFS(int course,int current)
        {
            foreach (var next in g[current])
            {
                if(!reachable[course].Contains(next))
                {
                    reachable[course].Add(next);
                    DFS(course,next);
                }
            }
        }
        for (int i = 0; i < numCourses; i++)
        {
            DFS(i,i);
        }
        var res=new List<bool>();
        foreach (var q in queries)
        {
           res.Add(reachable[q[0]].Contains(q[1])); 
        }
        return res;
    }
public int FindMaxFish(int[][] grid) {
    int m = grid.Length;
    if (m == 0) return 0;
    int n = grid[0].Length;
    int answer = 0;
    
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] > 0) {
                answer = Math.Max(DFFS(grid, i, j), answer);
            }
        }
    }
    
    return answer;
}

private int DFFS(int[][] grid, int i, int j) {
 // Check if the cell is out of bounds
    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) {
        return 0;
    }
    
    // Check if the cell is land or already visited
    if ( grid[i][j] == 0) {
        return 0;
    }
    
    // Collect fish in the current cell
    int fish = grid[i][j];
    
    // Mark the cell as visited by setting it to 0
    grid[i][j] = 0;
    
    // Explore all four directions
    fish += DFFS(grid, i + 1, j);
    fish += DFFS(grid, i - 1, j);
    fish += DFFS(grid, i, j + 1);
    fish += DFFS(grid, i, j - 1);
    
    return fish;
}
 public int MaxAreaOfIsland(int[][] grid) {
    int m = grid.Length;
    if (m == 0) return 0;
    int n = grid[0].Length;
    int answer = 0;
    
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                answer = Math.Max(DFFFS(grid, i, j), answer);
            }
        }
    }
    
    return answer;
        
    }
    private int DFFFS(int[][] grid, int i, int j) {
 // Check if the cell is out of bounds
    if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) {
        return 0;
    }
    
    // Check if the cell is land or already visited
    if ( grid[i][j] == 0) {
        return 0;
    }
    
    // Collect fish in the current cell
    int l = grid[i][j];
    
    // Mark the cell as visited by setting it to 0
    grid[i][j] = 0;
    
    // Explore all four directions
    l += DFFFS(grid, i + 1, j);
    l += DFFFS(grid, i - 1, j);
    l += DFFFS(grid, i, j + 1);
    l += DFFFS(grid, i, j - 1);
    
    return l;
}
    public int[] FindRedundantConnection(int[][] edges) {
        int n=edges.Length;
        int []parent=new int[n+1];
        //Initially, each node is its own parent (isolated)
        for (int i = 1; i <=n; i++)
        {
            parent[i]=i;
        }
        foreach (int[] edge in edges)
        {
            int a=edge[0];
            int b=edge[1];
            int rootA=FindDSU(parent,a);
            int rootB=FindDSU(parent,b);
            //perviously connected return the redant edge
            if(rootA==rootB)
            {
                return edge; // Cycle detected
            }
            // not connected union them
            parent[rootB]=rootA; // Union
        }
        return [];
    }

    private int FindDSU(int[] parent, int x)
    {
        //follow parent pointers until the root is found.
        if(parent[x]!=x){
        //Flatten the tree by making nodes point directly to the root 
        //during the search, speeding up future operations.
            parent[x]=FindDSU(parent,parent[x]);
        }
        return parent[x];
    }
    public int MagnificentSets(int n, int[][] edges) {
        //1-build adj list
        List<List<int>> adj=new List<List<int>>();
        for (int i = 0; i <=n ; i++)
        {
            adj.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            int a=edge[0];
            int b=edge[1];
            adj[a].Add(b);
            adj[b].Add(a);
        }
         //2-Initialize arrays for tracking colors and visited nodes
         // To track bipartition colors (0 = uncolored, 1 = color A, -1 = color B)
         int []colors=new int[n+1];
         bool[]visited=new bool[n+1];
         int total=0;
         //3-Process each connected component
         for(int i=1;i<=n;i++)
         {
            if(!visited[i])
            {
                //new component
                List<int>c=new List<int>();
                // If not bipartite, return -1 (grouping is impossible)
                if(!IsBipartite(i,adj,colors,visited,c))
                {
                    return -1;
                }
                //Calculate the maximum number of groups for this component
                int maxGroup=FindGroup(c,adj);
                total+=maxGroup;
            }
         }
         return total;
    }
    // check if a component is bipartite using BFS
    private bool IsBipartite(int start, List<List<int>> adj, int[] colors, bool[] visited, List<int> c)
    {
      Queue<int>q=new Queue<int>();
      q.Enqueue(start);
      colors[start]=1; // Assign the starting node a color (1 = color A)
      visited[start]=true;
      while(q.Count>0)
      {
        // Add the node to the current component
        int n=q.Dequeue();
        c.Add(n);
        // Process all neighbors of the current node
        foreach (var neighbor in adj[n])
        {
            if(colors[neighbor]==0)//un colored
            {
                colors[neighbor]=-colors[n];//assgin opp color
                visited[neighbor]=true;
                q.Enqueue(neighbor);
            }
            else if(colors[neighbor]==colors[n])
            {
                // If the neighbor has the same color, the graph is not bipartite
                return false;
            }
        }
      }
      return true;
    }
    private int FindGroup(List<int> c, List<List<int>> adj)
    {
        int max=0;
         // Perform BFS from each node in the component to find the maximum depth
         foreach (var node in c)
         {
            int depth=bfsDepth(node,adj);
            max=Math.Max(max,depth);
         }
         return max;
    }

    private int bfsDepth(int start, List<List<int>> adj)
    {
        Queue<int>q=new Queue<int>();
        Dictionary<int,int> cahce= new Dictionary<int, int>();
        q.Enqueue(start);
        cahce[start]=1;
        int max=1; // To track the maximum depth
        while(q.Count>0)
        {
            int n=q.Dequeue();
            int current=cahce[n];
            foreach (var neighbor in adj[n])
            {
                if(!cahce.ContainsKey(neighbor))
                {
                    cahce[neighbor]=current+1;
                    max=Math.Max(max,current+1);
                    q.Enqueue(neighbor);
                }
            }
        }
        return max;
    }
     public int LargestIsland(int[][] grid) {
        int n =grid.Length;
        // Arrays for Union-Find (DSU)
        int []parent=new int[n*n];
        int []size=new int[n*n];
        for (int i = 0; i < n*n; i++)
        {
            parent[i]=i;
            size[i]=1;
        }
        int[][] dirs = [[-1, 0],[1, 0],[0, -1],[0, 1]];
        // Union adjacent 1s using DSU
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(grid[i][j]==1)//part of an island
                {
                    int curr=i*n+j; // Convert 2D index to 1D for DSU
                
                    foreach (var dir in dirs)
                    {
                    int ni=i+dir[0];
                    int nj=j+dir[1];
                    // If the neighbor is within bounds and is also a 1
                        if(ni>=0&&ni<n&&nj>=0&&nj<n&&grid[ni][nj]==1)
                        {
                                int neighbor=ni*n+nj;
                                Union(curr,neighbor,parent,size);
                        } 
                     }
                }
            }
        }
        // Precompute island sizes
        Dictionary<int,int>islandsize=new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(grid[i][j]==1)
                {
                    int root=Finnd(i*n+j,parent);// Find the root of the island
                    islandsize[root]=size[root];
                }
            }
        }
        // Edge Case: If there are no 1s in the grid, flipping any 0 will create an island of size 1
        if(islandsize.Count==0) return 1;
         // Edge Case: If the entire grid is filled with 1s, the largest island is n * n
        if (islandsize.Count == 1 && islandsize.Values.First() == n * n) return n * n;
        int max=0;
         // Evaluate each 0 cell to find the maximum possible island size
         for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) { // If the cell is a 0
                HashSet<int> uniqueRoots = new HashSet<int>(); // To store unique island roots
                int sum=1;
                foreach (var dir in dirs) {
                        int ni = i + dir[0]; // Neighbor row
                        int nj = j + dir[1]; // Neighbor column
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n && grid[ni][nj] == 1) {
                            int root = Finnd(ni * n + nj, parent);
                             if (!uniqueRoots.Contains(root)) {   // Avoid counting the same island multiple times
                                uniqueRoots.Add(root);
                                sum += islandsize[root]; // Add the size of the neighboring island
                            }
                        }
                    }
                 max = Math.Max(max, sum);
                }
            }
         }
        // If no 0s exist, return the size of the largest island in the original grid
        return max == 0 ? islandsize.Values.Max() : max;
     }

    private void Union(int x, int y, int[] parent, int[] size)
    {
        int rootX = Finnd(x, parent); // Find root of x
        int rootY = Finnd(y, parent); // Find root of y
         if (rootX != rootY) { // If they are not already in the same set
            if (size[rootX] < size[rootY]) {
                // Attach the smaller tree to the larger tree
                parent[rootX] = rootY;
                size[rootY] += size[rootX]; // Update the size of the larger tree
                } else {
                // Attach the smaller tree to the larger tree
                parent[rootY] = rootX;
                size[rootX] += size[rootY]; // Update the size of the larger tree
            }
         }
    }

    private int Finnd(int x, int[] parent)
    {
        if(parent[x]!=x)
        {
            parent[x]=Finnd(parent[x],parent);
        }
        return parent[x];
    }
    //75 binary Search
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
     Array.Sort(potions);
     int n=spells.Length;
     int[]res=new int[n];
     for (int i = 0; i < n; i++)
     {
        int s=spells[i];
        // Formula: (success + spellStrength - 1) / spellStrength
         long r = (success + s - 1) / s;
        int first=FindFirstGreatOrEq(potions,r);
        //the number of valid potions is the total potions minus the index of the first valid potion
        res[i]=potions.Length-first;
     }
     return res;
    }

    private int FindFirstGreatOrEq(int[] potions, long t)
    {
        int low=0;
        int high=potions.Length;
        while(low<high)
        {
            int mid = low + (high - low) / 2;
            if(potions[mid]>=t)
            {
                // If the mid element is greater than or equal to the target, search the left half
                high=mid;
            }
            else{
                // Otherwise, search the right half
                low=mid+1;
            }
        }
        // Return the index of the first element >= target
        return low;
    }
    public int FindPeakElement(int[] nums) {
        int low=0;
        int high=nums.Length -1;
        while(low<high)
        {
            int mid=low+(high-low)/2;
            if(nums[mid]<nums[mid+1])
            {
                // Move towards the higher element in the right half
                low=mid+1;
            }
            else{
                // The peak is in the left half, including mid
                high=mid;
            }
        }
          // At this point, low == high, which is the peak index
          return low;
    }
}


    





