```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-BGESAV : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method                   | Mean     | Error    | StdDev  | Gen0       | Gen1      | Gen2     | Allocated |
|------------------------- |---------:|---------:|--------:|-----------:|----------:|---------:|----------:|
| Get_With_For_Each        | 147.7 ms | 36.52 ms | 9.48 ms | 12000.0000 | 6000.0000 | 250.0000 |  97.87 MB |
| Get_With_Enumerable_Join | 117.1 ms |  9.30 ms | 1.44 ms |  9600.0000 | 5000.0000 | 400.0000 |  77.64 MB |
