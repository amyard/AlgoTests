``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1526 (21H1/May2021Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  DefaultJob : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT


```
|                              Method |       Mean |    Error |   StdDev | Rank |  Gen 0 | Allocated |
|------------------------------------ |-----------:|---------:|---------:|-----:|-------:|----------:|
|               SimpleSortedIteration |   523.2 ns |  5.27 ns |  4.67 ns |    1 | 0.4072 |      1 KB |
|           BinarySearchOnSortedArray | 1,083.9 ns | 10.37 ns |  9.19 ns |    2 | 0.3681 |      1 KB |
|    BinarySearchOnSortedArrayHashSet | 1,137.7 ns | 11.68 ns | 10.35 ns |    3 | 0.5455 |      2 KB |
| BinarySearchOnSortedArrayDictionary | 1,158.9 ns |  9.41 ns |  8.80 ns |    4 | 0.5779 |      2 KB |
|                     SimpleIteration | 1,936.3 ns | 28.60 ns | 26.75 ns |    5 | 0.4539 |      1 KB |
