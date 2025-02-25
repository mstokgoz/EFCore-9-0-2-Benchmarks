```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-JSWVBU : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=5  WarmupCount=5  

```
| Method               | Mean     | Error     | StdDev    | Gen0     | Gen1    | Allocated  |
|--------------------- |---------:|----------:|----------:|---------:|--------:|-----------:|
| Get_With_Over_Where  | 4.519 ms | 0.3820 ms | 0.0992 ms |  39.0625 |  7.8125 |  359.06 KB |
| Get_With_Query_Index | 8.414 ms | 1.8179 ms | 0.4721 ms | 250.0000 | 62.5000 | 2291.24 KB |
