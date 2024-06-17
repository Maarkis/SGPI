```

BenchmarkDotNet v0.13.12, Ubuntu 24.04 LTS (Noble Numbat)
Intel Core i7-14700K, 1 CPU, 28 logical and 20 physical cores
.NET SDK 8.0.105
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method              | IterationCount | Mean      | Error    | StdDev   |
|-------------------- |--------------- |----------:|---------:|---------:|
| **GetAllProductsAsync** | **300**            |  **46.89 ms** | **0.887 ms** | **1.056 ms** |
| GetProductByIdAsync | 300            |  54.04 ms | 1.048 ms | 1.165 ms |
| GetExtractAsync     | 300            |  70.03 ms | 1.382 ms | 2.152 ms |
| **GetAllProductsAsync** | **400**            |  **60.56 ms** | **0.995 ms** | **1.184 ms** |
| GetProductByIdAsync | 400            |  71.69 ms | 1.365 ms | 1.676 ms |
| GetExtractAsync     | 400            |  96.16 ms | 1.864 ms | 2.789 ms |
| **GetAllProductsAsync** | **500**            |  **77.90 ms** | **1.535 ms** | **2.607 ms** |
| GetProductByIdAsync | 500            |  90.30 ms | 1.789 ms | 3.086 ms |
| GetExtractAsync     | 500            | 119.97 ms | 2.384 ms | 3.850 ms |
