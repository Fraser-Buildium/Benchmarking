using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedInstantiationBenchmark
{
    [Benchmark(Baseline = true)]
    public void NonSealed()
    {
        _ = new NonSealedClass();
    }

    [Benchmark]
    public void Sealed()
    {
        _ = new SealedClass();
    }

    /*[Benchmark]
    public void NonSealedCastToBase()
    {
        BaseType baseInstance = new NonSealedClass();
    }

    [Benchmark]
    public void SealedCastToBase()
    {
        BaseType baseInstance = new SealedClass();
    }*/
}