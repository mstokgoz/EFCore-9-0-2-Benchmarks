```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-SGHNDI : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=0  

```
| Method          | Mean     | Error     | StdDev    | Gen0     | Gen1    | Allocated  |
|---------------- |---------:|----------:|----------:|---------:|--------:|-----------:|
| Get_With_EfCore | 3.733 ms | 0.5037 ms | 0.3332 ms | 187.5000 | 70.3125 | 1555.68 KB |
| Get_With_Dapper | 3.243 ms | 0.1752 ms | 0.1159 ms | 121.0938 | 46.8750 | 1002.27 KB |
