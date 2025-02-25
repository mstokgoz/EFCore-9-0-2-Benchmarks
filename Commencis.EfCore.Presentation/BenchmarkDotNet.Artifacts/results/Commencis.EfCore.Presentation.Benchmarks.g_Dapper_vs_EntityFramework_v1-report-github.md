```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-AFZYEB : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method          | Mean     | Error     | StdDev    | Gen0    | Gen1   | Allocated |
|---------------- |---------:|----------:|----------:|--------:|-------:|----------:|
| Get_With_EfCore | 1.396 ms | 1.9915 ms | 0.1092 ms | 19.5313 | 1.9531 | 171.76 KB |
| Get_With_Dapper | 1.280 ms | 0.4666 ms | 0.0256 ms | 11.7188 |      - | 107.13 KB |
