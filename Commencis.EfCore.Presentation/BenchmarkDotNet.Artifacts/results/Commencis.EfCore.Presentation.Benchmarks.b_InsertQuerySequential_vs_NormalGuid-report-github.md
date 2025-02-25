```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  Job-ZAPWKA : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD

IterationCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0      | Gen1    | Gen2    | Allocated |
|------------------------------ |---------:|---------:|---------:|----------:|--------:|--------:|----------:|
| Insert_Student_NormalGuid     | 16.91 ms | 24.82 ms | 1.361 ms | 2166.0156 | 87.8906 | 41.0156 |  17.65 MB |
| Insert_Student_SequentialGuid | 10.67 ms | 10.58 ms | 0.580 ms | 1328.1250 | 70.3125 | 23.4375 |  10.72 MB |
