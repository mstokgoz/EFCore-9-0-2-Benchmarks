```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-IIDDUR : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=10  

```
| Method                | Mean     | Error     | StdDev    | Gen0     | Gen1     | Allocated |
|---------------------- |---------:|----------:|----------:|---------:|---------:|----------:|
| Get_With_AsNoTracking | 7.229 ms | 1.6290 ms | 1.0775 ms | 304.6875 | 101.5625 |   2.48 MB |
| Get_With_Tracking     | 4.191 ms | 0.1111 ms | 0.0661 ms | 234.3750 |  15.6250 |   1.89 MB |
