using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Benchmarking.Sealed.Benchmarks;

namespace Benchmarking.Sealed;

public static class SealedBenchmarkRunner
{
    public const string VirtualMethodKey = "sealed:virtualMethods";
    public const string CastingKey = "sealed:casting";
    public const string ArraysKey = "sealed:arrays";
    public const string SpansKey = "sealed:spans";
    public const string ListKey = "sealed:list";
    public const string InitializationKey = "sealed:instantiation";
    public static Dictionary<string, Summary> Run(SealedBenchmarkParameter parameter)
    {
        var summaries = new Dictionary<string, Summary>();
        
        if (parameter.BenchmarkVirtualMethods)
        {
            summaries[VirtualMethodKey] = BenchmarkRunner.Run<SealedVirtualMethodBenchmark>();
        }

        if (parameter.BenchmarkCasting)
        {
            summaries[CastingKey] = BenchmarkRunner.Run<SealedCastingBenchmark>();
        }

        if (parameter.BenchmarkArrays)
        {
            summaries[ArraysKey] = BenchmarkRunner.Run<SealedArraysBenchmark>();
        }

        if (parameter.BenchmarkSpans)
        {
            summaries[SpansKey] = BenchmarkRunner.Run<SealedArraysToSpansBenchmark>();
        }
        
        if (parameter.BenchmarkList)
        {
            summaries[ListKey] = BenchmarkRunner.Run<SealedListBenchmark>();
        }

        if (parameter.BenchmarkInstantiation)
        {
            summaries[InitializationKey] = BenchmarkRunner.Run<SealedInstantiationBenchmark>();
        }

        return summaries;
    }
}