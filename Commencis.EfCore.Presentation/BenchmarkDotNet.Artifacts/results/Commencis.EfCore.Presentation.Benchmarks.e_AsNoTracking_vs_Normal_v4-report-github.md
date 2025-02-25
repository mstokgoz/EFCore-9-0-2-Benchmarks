```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD


```
| Method                | Mean     | Error   | StdDev  | Gen0   | Allocated |
|---------------------- |---------:|--------:|--------:|-------:|----------:|
| Get_With_AsNoTracking | 537.7 μs | 6.52 μs | 5.44 μs | 3.9063 |  36.46 KB |
| Get_With_Tracking     | 530.6 μs | 8.22 μs | 7.68 μs | 2.9297 |  29.38 KB |
