```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-OGGIEY : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=2  WarmupCount=0  

```
| Method                | Mean      | Error        | StdDev    | Gen0         | Gen1      | Gen2      | Allocated   |
|---------------------- |----------:|-------------:|----------:|-------------:|----------:|----------:|------------:|
| Delete_With_Related   | 126.963 s | 25,860.191 s | 57.4469 s | 3441000.0000 | 6000.0000 |         - | 27408.85 MB |
| Delete_With_Execution |   2.794 s |     15.370 s |  0.0341 s |    3000.0000 | 1000.0000 | 1000.0000 |    38.91 MB |
