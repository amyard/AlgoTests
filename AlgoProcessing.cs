using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Algo
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn()]
    public class AlgoProcessing
    {
        [Benchmark]
        public void SimpleIteration()
        {
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};
            List<int> indexes = new List<int>();
            int maxValue = 10;

            List<List<int>> res = new List<List<int>>();
            
            while(indexes.Count != arr.Length)
            {
                List<int> resultArray = new List<int>();
                int sumInArray = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (indexes.Contains(i))
                    {
                        continue;
                    }

                    if ((arr[i] + sumInArray) <= maxValue || (arr[i] >= maxValue && resultArray.Count == 0))
                    {
                        sumInArray += arr[i];
                        indexes.Add(i);
                        resultArray.Add(arr[i]);
                    }
                }

                res.Add(resultArray);
            }
        }
        
        [Benchmark]
        public void SimpleSortedIteration()
        {
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};
            Array.Sort(arr); 
            int maxValue = 10;

            List<List<int>> res = new List<List<int>>();
            
            List<int> resultArray = new List<int>();
            int sumInArray = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= maxValue && resultArray.Count == 0)
                {
                    res.Add(new List<int>(){ arr[i] });
                    continue;
                }
                
                if ((arr[i] + sumInArray) <= maxValue)
                {
                    sumInArray += arr[i];
                    resultArray.Add(arr[i]);
                    continue;
                }
                
                res.Add(resultArray);
                resultArray = new List<int>(){arr[i]};
                sumInArray = arr[i];
            }
            
            if(resultArray.Count > 0)
                res.Add(resultArray);
        }

        [Benchmark]
        public void BinarySearchOnSortedArray()
        {
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};
            List<int> indexes = new List<int>(arr.Length);
            int maxValue = 10;
            int defaultSubValue = 0;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> resultArray = new List<int>();

                if (indexes.Contains(i)) continue;

                indexes.Add(i);
                resultArray.Add(arr[i]);
                
                int numberToFind = defaultSubValue == 0 ? maxValue - arr[i] : defaultSubValue;

                int l = i + 1;
                int r = arr.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;

                    if (indexes.Contains(r))
                    {
                        r = mid - 1; continue;
                    }

                    if (indexes.Contains(l))
                    {
                        l = mid + 1; continue;
                    }

                    if ((numberToFind - arr[mid]) >= 0)
                    {
                        resultArray.Add(arr[mid]);
                        numberToFind -= arr[mid];
                        r = arr.Length - 1;
                        indexes.Add(mid);
                        continue;
                    }

                    if (numberToFind < arr[mid])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
        }
        
        [Benchmark]
        public void BinarySearchOnSortedArrayDictionary()
        {
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            
            int maxValue = 10;
            int defaultSubValue = 0;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> resultArray = new List<int>();

                if (dict.ContainsKey(i)) continue;

                dict[i] = true;
                resultArray.Add(arr[i]);
                
                int numberToFind = defaultSubValue == 0 ? maxValue - arr[i] : defaultSubValue;

                int l = i + 1;
                int r = arr.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;

                    if (dict.ContainsKey(r))
                    {
                        r = mid - 1; continue;
                    }

                    if (dict.ContainsKey(l))
                    {
                        l = mid + 1; continue;
                    }

                    if ((numberToFind - arr[mid]) >= 0)
                    {
                        resultArray.Add(arr[mid]);
                        numberToFind -= arr[mid];
                        r = arr.Length - 1;
                        dict[mid] = true;
                        continue;
                    }

                    if (numberToFind < arr[mid])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
        }
        
        [Benchmark]
        public void BinarySearchOnSortedArrayHashSet()
        {
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};
            HashSet<int> hashSet = new HashSet<int>();

            int maxValue = 10;
            int defaultSubValue = 0;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> resultArray = new List<int>();

                if (hashSet.Contains(i)) continue;

                hashSet.Add(i);
                resultArray.Add(arr[i]);
                
                int numberToFind = defaultSubValue == 0 ? maxValue - arr[i] : defaultSubValue;

                int l = i + 1;
                int r = arr.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;

                    if (hashSet.Contains(r))
                    {
                        r = mid - 1; continue;
                    }

                    if (hashSet.Contains(l))
                    {
                        l = mid + 1; continue;
                    }

                    if ((numberToFind - arr[mid]) >= 0)
                    {
                        resultArray.Add(arr[mid]);
                        numberToFind -= arr[mid];
                        r = arr.Length - 1;
                        hashSet.Add(mid);
                        continue;
                    }

                    if (numberToFind < arr[mid])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
        }

        // TODO --> Find the closest array to maxValue
        // TODO --> some shit if one value
        // public void TwoPointerSimple(int[] arr)
        // {
        //     Console.WriteLine(string.Join(", ", arr)); 
        //     
        //     List<int> indexes = new List<int>();
        //     int maxValue = 10;
        //
        //     while (indexes.Count != arr.Length)
        //     {
        //         //Console.WriteLine($"{indexes.Count} - {arr.Length}");
        //         int left = 0;
        //         int right = arr.Length - 1;
        //         int defaultSubValue = 0;
        //         
        //         List<int> resultArray = new List<int>();
        //         while (left < right)
        //         {
        //             int sum = defaultSubValue;
        //             if (indexes.Contains(left))
        //             {
        //                 left++;
        //                 continue;
        //             }
        //             
        //             if (indexes.Contains(right))
        //             {
        //                 right--;
        //                 continue;
        //             }
        //
        //             if (arr[left] >= maxValue && defaultSubValue == 0)
        //             {
        //                 resultArray.Add(arr[left]);
        //                 indexes.Add(left);
        //                 break;
        //             }
        //             
        //             if (arr[right] >= maxValue && defaultSubValue == 0)
        //             {
        //                 resultArray.Add(arr[right]);
        //                 indexes.Add(right);
        //                 break;
        //             }
        //             
        //             sum += arr[left];
        //             sum += arr[right];
        //             // if (!indexes.Contains(left))
        //             // {
        //             // }
        //             //
        //             // if (!indexes.Contains(right))
        //             // {
        //             // }
        //             
        //             if (sum <= maxValue)
        //             {
        //                 if (!indexes.Contains(left))
        //                 {
        //                     resultArray.Add(arr[left]);
        //                     indexes.Add(left);
        //                     defaultSubValue += arr[left];
        //                 }
        //                 
        //                 if (!indexes.Contains(right))
        //                 {
        //                     resultArray.Add(arr[right]);
        //                     indexes.Add(right);
        //                     defaultSubValue += arr[right];
        //                 }
        //             }
        //
        //             if (sum < maxValue)
        //                 left++;
        //             else
        //                 right--;
        //         }
        //         
        //         Console.WriteLine(string.Join(", ", resultArray));
        //         Thread.Sleep(2000);
        //     }
        //     
        // }
    }
}