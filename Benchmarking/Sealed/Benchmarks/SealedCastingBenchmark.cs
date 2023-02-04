using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedCastingBenchmark
{
    private readonly BaseType m_baseInstance = new();

    [Benchmark(Baseline = true)]
    public bool IsSealed() => m_baseInstance is SealedClass;

    [Benchmark]
    public bool IsNonSealed() => m_baseInstance is NonSealedClass;
}