```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-MEZYON : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=10  

```
| Method                | Mean     | Error    | StdDev   | Gen0        | Gen1       | Allocated     |
|---------------------- |---------:|---------:|---------:|------------:|-----------:|--------------:|
| Update_With_Related   | 17.590 s | 0.9034 s | 0.5976 s | 758000.0000 | 98000.0000 | 6254107.98 KB |
| Update_With_Execution |  1.975 s | 0.3315 s | 0.2193 s |           - |          - |      29.04 KB |
