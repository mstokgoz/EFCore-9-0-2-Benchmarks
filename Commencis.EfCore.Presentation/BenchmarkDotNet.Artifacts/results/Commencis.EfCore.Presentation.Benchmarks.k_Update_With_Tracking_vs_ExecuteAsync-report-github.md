```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-TDVNSZ : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=10  

```
| Method                | Mean      | Error     | StdDev    | Gen0     | Gen1     | Allocated  |
|---------------------- |----------:|----------:|----------:|---------:|---------:|-----------:|
| Update_With_Related   | 12.281 ms | 0.3761 ms | 0.2238 ms | 625.0000 | 187.5000 | 5140.58 KB |
| Update_With_Execution |  3.577 ms | 0.3619 ms | 0.2394 ms |        - |        - |   25.48 KB |
