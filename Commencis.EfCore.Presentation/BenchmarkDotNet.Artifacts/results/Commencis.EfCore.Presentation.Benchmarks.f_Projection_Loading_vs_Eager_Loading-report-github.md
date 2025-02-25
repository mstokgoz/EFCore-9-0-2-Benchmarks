```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-HOYXXT : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method                      | Mean    | Error    | StdDev   | Gen0        | Gen1       | Gen2      | Allocated |
|---------------------------- |--------:|---------:|---------:|------------:|-----------:|----------:|----------:|
| Get_With_Eager_Loading      | 6.030 s | 0.6721 s | 0.1040 s | 362000.0000 | 96000.0000 | 6000.0000 |   2.78 GB |
| Get_With_Projection_Loading | 5.092 s | 0.5416 s | 0.0838 s | 252000.0000 | 65000.0000 | 5000.0000 |   1.93 GB |
