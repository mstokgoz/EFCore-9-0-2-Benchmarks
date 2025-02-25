```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-LMCBIE : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method                | Mean    | Error    | StdDev   | Gen0        | Gen1        | Gen2      | Allocated |
|---------------------- |--------:|---------:|---------:|------------:|------------:|----------:|----------:|
| Get_With_AsNoTracking | 6.218 s | 3.8353 s | 0.2102 s | 348000.0000 |  90000.0000 | 6000.0000 |   2.67 GB |
| Get_With_Tracking     | 7.370 s | 0.7079 s | 0.0388 s | 312000.0000 | 312000.0000 |         - |   2.44 GB |
