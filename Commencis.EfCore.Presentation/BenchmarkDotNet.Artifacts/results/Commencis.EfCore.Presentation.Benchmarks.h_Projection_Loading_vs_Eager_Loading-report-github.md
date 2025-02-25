```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-IMNZQT : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=100  WarmupCount=10  

```
| Method                      | Mean     | Error    | StdDev   | Gen0      | Gen1     | Gen2    | Allocated |
|---------------------------- |---------:|---------:|---------:|----------:|---------:|--------:|----------:|
| Get_With_Eager_Loading      | 31.94 ms | 0.334 ms | 0.893 ms | 1750.0000 | 562.5000 | 62.5000 |  13.78 MB |
| Get_With_Projection_Loading | 25.77 ms | 0.293 ms | 0.786 ms | 1187.5000 | 468.7500 |       - |    9.6 MB |
