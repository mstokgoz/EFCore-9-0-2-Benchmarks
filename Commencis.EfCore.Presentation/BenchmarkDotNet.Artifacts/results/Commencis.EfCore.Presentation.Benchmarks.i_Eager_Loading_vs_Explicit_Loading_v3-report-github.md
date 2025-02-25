```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-SQFZJR : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method                    | Mean     | Error    | StdDev   | Allocated |
|-------------------------- |---------:|---------:|---------:|----------:|
| Get_With_Eager_Loading    | 18.42 ms | 0.312 ms | 0.081 ms |  125.6 KB |
| Get_With_Explicit_Loading | 16.16 ms | 5.553 ms | 1.442 ms |  28.16 KB |
