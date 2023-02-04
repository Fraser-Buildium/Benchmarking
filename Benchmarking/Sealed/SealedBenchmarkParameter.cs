namespace Benchmarking.Sealed;

public class SealedBenchmarkParameter
{
    public bool BenchmarkVirtualMethods { get; set; }
    public bool BenchmarkCasting { get; set; }
    public bool BenchmarkArrays { get; set; }
    public bool BenchmarkSpans { get; set; }
    public bool BenchmarkList { get; set; }
    public bool BenchmarkInstantiation { get; set; }
}