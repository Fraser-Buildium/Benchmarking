using BenchmarkDotNet.Attributes;
using Benchmarking.Sealed.TestClasses;

namespace Benchmarking.Sealed.Benchmarks;

public class SealedArraysToSpansBenchmark
{
    private const int ArraySize = 100;
    private readonly SealedClass[] m_sealedArray = new SealedClass[ArraySize];
    private readonly NonSealedClass[] m_nonSealedArray = new NonSealedClass[ArraySize];

    [Benchmark(Baseline = true)]
    public void NonSealedArrayToSpan()
    {
        Span<NonSealedClass> span = m_nonSealedArray; 
    }

    [Benchmark]
    public void SealedArrayToSpan()
    {
        Span<SealedClass> span = m_sealedArray;
    } 
}