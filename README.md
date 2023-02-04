# Benchmarking

The purpose of this solution is to investigate the performance benefits of different C# functionality.

## Sealed Modifier Benchmarking
Disallowing inheritance for certain classes improves performance in a few key areas. This collection of benchmarks can be accessed via the commandline arguments that start with `sealed:`.

* **Argument:** `sealed:virtualMethods` - This runs the benchmarking for virtual method execution when the sealed modifier is applied.

> One reason sealing helps is that virtual methods on a sealed type are more likely to be devirtualized by the runtime. If the runtime can see that a given instance on which a virtual call is being made is actually sealed, then it knows for certain what the actual target of the call will be, and it can invoke that target directly rather than doing a virtual dispatch operation. Better yet, once the call is devirtualized, it might be inlineable, and then if it’s inlined, all the previously discussed benefits around optimizing the caller+callee combined kick in. ([Microsoft DevBlogs - Peanut Butter](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#peanut-butter))

* **Argument:** `sealed:casting` - This runs benchmarking for casting sealed vs non-sealed classes to their derived type.

> Another benefit of sealing is that it can make type checks a lot faster. When you write code like obj is SomeType, there are multiple ways that could be emitted in assembly. If `SomeType` is sealed, then this check can be implemented along the lines of `obj is not null && obj.GetType() == typeof(SomeType)`, where the latter clause can be implemented simply by comparing the type handle of obj against the known type handle of `SomeType`... ([Microsoft DevBlogs - Peanut Butter](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#peanut-butter))

* **Argument:** `sealed:arrays` - This runs benchmarking for setting a sealed and non-sealed object in an array.

> Arrays in .NET are covariant. That means that `BaseType[] value = new DerivedType[1]` is valid... The covariance comes with performance penalties... the JIT must check the type of the object before assigning an item to an array. ([Performance benefits of sealed class in .NET](https://www.meziantou.net/performance-benefits-of-sealed-class.htm#arrays))

* **Argument:** `sealed:spans` - This runs benchmarking for converting arrays to spans for sealed vs non-sealed types.

> You can convert arrays to `Span<T>` or `ReadOnlySpan<T>`. For the same reasons as the previous section, the JIT must check the type of the object before converting the array to a `Span<T>`. When using a sealed type, it can avoid the check and slightly improve the performance. ([Performance benefits of sealed class in .NET](https://www.meziantou.net/performance-benefits-of-sealed-class.htm#arrays))

* **Argument:** `sealed:list` - This runs benchmarking for instantiating a list with sealed and non-sealed types. This test did not find significant performance gains.
* **Argument:** `sealed:instantiation` - This runs benchmarking for instantiating sealed vs non-sealed types, and similar to above, no significant performance gains were found.