```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-LZDSTL : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=0  

```
| Method          | Mean     | Error     | StdDev    | Gen0     | Gen1    | Allocated |
|---------------- |---------:|----------:|----------:|---------:|--------:|----------:|
| Get_With_EfCore | 3.644 ms | 0.2640 ms | 0.1571 ms | 117.1875 | 23.4375 |  997.9 KB |
| Get_With_Dapper | 1.081 ms | 0.1199 ms | 0.0793 ms |  13.6719 |       - | 121.88 KB |
