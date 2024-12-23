using System.Collections.Immutable;
using System.Security.Principal;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;

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
}


