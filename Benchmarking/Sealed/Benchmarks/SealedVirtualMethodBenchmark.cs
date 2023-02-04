using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedVirtualMethodBenchmark
{
    private readonly NonSealedClass m_nonSealedClass = new();
    private readonly TestClasses.SealedClass m_sealedClass = new();

    [Benchmark(Baseline = true)]
    public void NonSealedVirtualMethods()
    {
        m_nonSealedClass.VirtualMethod();
    }

    [Benchmark]
    public void SealedVirtualMethods()
    {
        m_sealedClass.VirtualMethod();
    }
}