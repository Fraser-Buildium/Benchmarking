using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedListBenchmark
{
    [Benchmark(Baseline = true)]
    public void BaseListAddNonSealed()
    {
        _ = new List<BaseType> {new NonSealedClass()};
    }

    [Benchmark]
    public void BaseListAddSealed()
    {
        _ = new List<BaseType> {new SealedClass()};
    }

    [Benchmark]
    public void NonSealedAddList()
    {
        _ = new List<NonSealedClass> {new NonSealedClass()};
    }

    [Benchmark]
    public void SealedAddList()
    {
        _ = new List<SealedClass> {new SealedClass()};
    }
}