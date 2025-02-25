```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-CCLOAX : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method                    | Mean       | Error     | StdDev   | Gen0    | Gen1   | Allocated |
|-------------------------- |-----------:|----------:|---------:|--------:|-------:|----------:|
| Get_With_Eager_Loading    |   681.8 μs |  16.56 μs |  4.30 μs |  7.8125 |      - |   70.9 KB |
| Get_With_Explicit_Loading | 3,622.7 μs | 389.85 μs | 60.33 μs | 31.2500 | 7.8125 | 301.77 KB |
