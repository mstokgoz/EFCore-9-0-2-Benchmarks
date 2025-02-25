```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-WUJCLY : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  

```
| Method          | Mean      | Error    | StdDev   | Gen0      | Gen1      | Gen2     | Allocated |
|---------------- |----------:|---------:|---------:|----------:|----------:|---------:|----------:|
| Get_All_Columns | 154.25 ms | 15.01 ms | 0.823 ms | 9666.6667 |  333.3333 |        - |  78.67 MB |
| Get_Restricted  |  71.06 ms | 14.79 ms | 0.811 ms | 2857.1429 | 1142.8571 | 428.5714 |  22.29 MB |
