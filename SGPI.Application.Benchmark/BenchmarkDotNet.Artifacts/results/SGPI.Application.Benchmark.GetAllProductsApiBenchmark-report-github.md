```

BenchmarkDotNet v0.13.12, Ubuntu 24.04 LTS (Noble Numbat)
Intel Core i7-14700K, 1 CPU, 28 logical and 20 physical cores
.NET SDK 8.0.105
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method              | IterationCount | Mean      | Error    | StdDev   |
|-------------------- |--------------- |----------:|---------:|---------:|
| **GetAllProductsAsync** | **300**            |  **48.10 ms** | **0.958 ms** | **1.627 ms** |
| GetProductByIdAsync | 300            |  55.14 ms | 1.068 ms | 1.566 ms |
| GetExtractAsync     | 300            |  74.40 ms | 1.418 ms | 2.446 ms |
| **GetAllProductsAsync** | **400**            |  **64.46 ms** | **1.263 ms** | **1.551 ms** |
| GetProductByIdAsync | 400            |  72.92 ms | 1.441 ms | 2.067 ms |
| GetExtractAsync     | 400            |  97.92 ms | 1.930 ms | 3.329 ms |
| **GetAllProductsAsync** | **500**            |  **80.13 ms** | **1.601 ms** | **1.966 ms** |
| GetProductByIdAsync | 500            |  93.78 ms | 1.856 ms | 3.486 ms |
| GetExtractAsync     | 500            | 121.32 ms | 2.380 ms | 4.585 ms |
