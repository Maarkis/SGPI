// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using SGPI.Application.Benchmark;


// Debug 
// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

//Benchmarking REST API
BenchmarkRunner.Run<GetAllProductsApiBenchmark>();
