```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-ZPEBKO : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method                    | Mean     | Error    | StdDev   | Gen0     | Gen1    | Allocated  |
|-------------------------- |---------:|---------:|---------:|---------:|--------:|-----------:|
| Get_With_Eager_Loading    | 16.40 ms | 0.258 ms | 0.067 ms |        - |       - |   25.61 KB |
| Get_With_Explicit_Loading | 32.59 ms | 7.688 ms | 1.997 ms | 187.5000 | 62.5000 | 1631.59 KB |
