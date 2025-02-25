```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-RZOOGD : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  WarmupCount=0  

```
| Method                  | Mean     | Error    | StdDev   | Gen0         | Gen1       | Gen2      | Allocated   |
|------------------------ |---------:|---------:|---------:|-------------:|-----------:|----------:|------------:|
| Get_With_Multiple_Joins | 71.772 s | 3.3576 s | 0.1840 s | 3837000.0000 | 79000.0000 | 4000.0000 | 30541.59 MB |
| Get_With_Split_Query    |  2.929 s | 0.8134 s | 0.0446 s |   46000.0000 | 17000.0000 | 5000.0000 |   375.02 MB |
