```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-IEUXYW : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=0  

```
| Method          | Mean       | Error     | StdDev    | Gen0     | Gen1    | Allocated |
|---------------- |-----------:|----------:|----------:|---------:|--------:|----------:|
| Get_With_EfCore | 3,759.1 μs | 239.16 μs | 158.19 μs | 121.0938 | 27.3438 |  999.5 KB |
| Get_With_Dapper |   966.2 μs |  16.09 μs |   9.58 μs |  13.6719 |       - | 122.07 KB |
