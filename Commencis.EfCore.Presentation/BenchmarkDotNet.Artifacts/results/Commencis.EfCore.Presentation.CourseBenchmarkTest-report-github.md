```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.2 (9.0.225.6610), Arm64 RyuJIT AdvSIMD


```
| Method                     | Mean     | Error   | StdDev  | Gen0      | Gen1      | Gen2     | Allocated |
|--------------------------- |---------:|--------:|--------:|----------:|----------:|---------:|----------:|
| GetStudents_NormalGuid     | 167.9 ms | 1.74 ms | 1.36 ms | 5666.6667 | 2000.0000 | 666.6667 |  46.26 MB |
| GetStudents_SequentialGuid | 164.6 ms | 1.76 ms | 1.56 ms | 5666.6667 | 2000.0000 | 666.6667 |  46.26 MB |
