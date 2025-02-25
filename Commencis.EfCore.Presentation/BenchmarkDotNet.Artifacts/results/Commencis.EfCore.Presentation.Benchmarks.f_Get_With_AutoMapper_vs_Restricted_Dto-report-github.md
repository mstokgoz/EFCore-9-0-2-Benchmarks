```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-GHMQTB : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method                 | Mean     | Error    | StdDev   | Gen0      | Gen1      | Gen2     | Allocated |
|----------------------- |---------:|---------:|---------:|----------:|----------:|---------:|----------:|
| Get_With_AutoMapper    | 55.49 ms | 28.81 ms | 1.579 ms | 4100.0000 | 1900.0000 | 900.0000 |  26.32 MB |
| Get_With_RestrictedDto | 27.17 ms | 12.98 ms | 0.711 ms | 2093.7500 |  906.2500 | 406.2500 |  14.83 MB |
