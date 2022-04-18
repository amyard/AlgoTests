using System;
using System.Collections.Generic;
using System.Threading;
using BenchmarkDotNet.Running;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            // sort alg 1
            int[] arr = new int[] {1,10,11,3,5,6,7,8,4,0,3,5,7,8,9,8};

            AlgoProcessing algoProcessing = new AlgoProcessing();
            
            // Console.WriteLine("SimpleIteration algo.");
            // algoProcessing.SimpleIteration(arr);
            
            // Console.WriteLine("SimpleIteration algo.");
            // algoProcessing.SimpleSortedIteration(arr);

            // Console.WriteLine("TwoPointerSimple algo.");
            // algoProcessing.TwoPointerSimple(arr);
            
            // Duplicate values
            // Console.WriteLine("BinarySearchSimple algo.");
            // algoProcessing.BinarySearchOnSortedArray(arr);

            BenchmarkRunner.Run<AlgoProcessing>();
            
            Console.WriteLine("Finish!!!");
            
        }
    }
}
