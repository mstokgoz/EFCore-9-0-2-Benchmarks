```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-APRGTP : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method          | Mean     | Error    | StdDev   | Gen0      | Gen1     | Gen2     | Allocated |
|---------------- |---------:|---------:|---------:|----------:|---------:|---------:|----------:|
| Get_With_EfCore | 26.89 ms | 3.812 ms | 0.209 ms | 2093.7500 | 906.2500 | 406.2500 |  14.83 MB |
| Get_With_Dapper | 24.48 ms | 1.846 ms | 0.101 ms | 1343.7500 | 656.2500 | 250.0000 |   9.59 MB |
