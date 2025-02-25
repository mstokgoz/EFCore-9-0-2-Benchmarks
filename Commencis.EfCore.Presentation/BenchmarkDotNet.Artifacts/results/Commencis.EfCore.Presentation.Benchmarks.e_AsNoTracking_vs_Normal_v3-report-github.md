```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-FOQMBB : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=10  

```
| Method                | Mean     | Error   | StdDev  | Gen0       | Gen1      | Gen2      | Allocated |
|---------------------- |---------:|--------:|--------:|-----------:|----------:|----------:|----------:|
| Get_With_AsNoTracking | 171.7 ms | 5.59 ms | 3.70 ms | 14333.3333 | 5333.3333 | 2000.0000 | 103.69 MB |
| Get_With_Tracking     | 172.8 ms | 6.93 ms | 4.58 ms |  9666.6667 |  333.3333 |         - |  78.67 MB |
