using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedArraysBenchmark
{
    private const int ArraySize = 100;
    private readonly SealedClass[] m_sealedArray = new SealedClass[ArraySize];
    private readonly NonSealedClass[] m_nonSealedArray = new NonSealedClass[ArraySize];

    [Benchmark(Baseline = true)]
    public void NonSealedArray()
    {
        m_nonSealedArray[0] = new NonSealedClass();
    }

    [Benchmark]
    public void SealedArray()
    {
        m_sealedArray[0] = new SealedClass();
    }
}