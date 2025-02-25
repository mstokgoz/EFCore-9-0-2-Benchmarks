```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD


```
| Method                        | Mean | Error |
|------------------------------ |-----:|------:|
| Insert_Student_NormalGuid     |   NA |    NA |
| Insert_Student_SequentialGuid |   NA |    NA |

Benchmarks with issues:
  InsertQuerySequential_vs_NormalGuid.Insert_Student_NormalGuid: DefaultJob
  InsertQuerySequential_vs_NormalGuid.Insert_Student_SequentialGuid: DefaultJob
