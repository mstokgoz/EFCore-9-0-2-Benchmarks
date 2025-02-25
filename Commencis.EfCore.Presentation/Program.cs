using BenchmarkDotNet.Running;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Domain.ValueObjects;
using Commencis.EfCore.Infrastructure;
using Commencis.EfCore.Presentation.Benchmarks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


BenchmarkRunner.Run<e_AsNoTracking_vs_Normal_v4>();

