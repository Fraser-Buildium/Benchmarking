// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Reports;
using Benchmarking.Sealed;

var allSummaries = new List<Dictionary<string, Summary>>();

// Parameters
SealedBenchmarkParameter sealedParameter = null;

Console.WriteLine(string.Join(", ", args));

// Evaluate arguments
foreach (var arg in args)
{
    switch (arg)
    {
        case SealedBenchmarkRunner.VirtualMethodKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkVirtualMethods = true;
            break;
        
        case SealedBenchmarkRunner.CastingKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkCasting = true;
            break;
        
        case SealedBenchmarkRunner.ArraysKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkArrays = true;
            break;
        
        case SealedBenchmarkRunner.SpansKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkSpans = true;
            break;
        
        case SealedBenchmarkRunner.ListKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkList = true;
            break;
        
        case SealedBenchmarkRunner.InitializationKey:
            sealedParameter ??= new SealedBenchmarkParameter();
            sealedParameter.BenchmarkInstantiation = true;
            break;
        
        default:
            Console.WriteLine($"Argument {arg} was not found.");
            break;
    }
}

if (sealedParameter != null)
{
    allSummaries.Add(SealedBenchmarkRunner.Run(sealedParameter));
}