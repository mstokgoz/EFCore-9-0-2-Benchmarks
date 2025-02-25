```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-FQIBES : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method                                      | Mean     | Error     | StdDev    | Gen0     | Gen1     | Allocated |
|-------------------------------------------- |---------:|----------:|----------:|---------:|---------:|----------:|
| Get_With_AsNoTracking                       | 4.321 ms |  1.250 ms | 0.0685 ms | 164.0625 |  54.6875 |   1.33 MB |
| Get_With_AsNoTrackingWithIdentityResolution | 8.738 ms | 51.368 ms | 2.8156 ms | 453.1250 | 156.2500 |   3.66 MB |
