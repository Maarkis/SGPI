```

BenchmarkDotNet v0.13.12, Ubuntu 24.04 LTS (Noble Numbat)
Intel Core i7-14700K, 1 CPU, 28 logical and 20 physical cores
.NET SDK 8.0.105
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method              | IterationCount | Mean      | Error    | StdDev   | Median    |
|-------------------- |--------------- |----------:|---------:|---------:|----------:|
| **GetAllProductsAsync** | **300**            |  **46.29 ms** | **0.923 ms** | **2.495 ms** |  **45.54 ms** |
| GetProductByIdAsync | 300            |  53.57 ms | 1.062 ms | 1.915 ms |  53.50 ms |
| GetExtractAsync     | 300            |  97.32 ms | 1.790 ms | 1.674 ms |  96.88 ms |
| **GetAllProductsAsync** | **400**            |  **60.29 ms** | **1.195 ms** | **1.118 ms** |  **60.53 ms** |
| GetProductByIdAsync | 400            |  70.49 ms | 1.389 ms | 2.321 ms |  69.70 ms |
| GetExtractAsync     | 400            | 134.37 ms | 2.679 ms | 5.937 ms | 134.49 ms |
| **GetAllProductsAsync** | **500**            |  **78.11 ms** | **1.544 ms** | **2.214 ms** |  **78.16 ms** |
| GetProductByIdAsync | 500            |  90.47 ms | 1.652 ms | 2.316 ms |  89.93 ms |
| GetExtractAsync     | 500            | 164.03 ms | 3.090 ms | 2.890 ms | 164.00 ms |
