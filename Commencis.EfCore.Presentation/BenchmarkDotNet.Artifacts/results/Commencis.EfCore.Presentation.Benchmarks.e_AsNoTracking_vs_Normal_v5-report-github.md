```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-XACXWH : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=10  WarmupCount=10  

```
| Method                                      | Mean     | Error     | StdDev    | Gen0     | Gen1     | Allocated |
|-------------------------------------------- |---------:|----------:|----------:|---------:|---------:|----------:|
| Get_With_AsNoTrackingWithIdentityResolution | 9.672 ms | 0.2745 ms | 0.1633 ms | 812.5000 | 390.6250 |   6.56 MB |
| Get_With_Tracking                           | 7.234 ms | 1.5717 ms | 1.0396 ms | 226.5625 |  15.6250 |   1.83 MB |
