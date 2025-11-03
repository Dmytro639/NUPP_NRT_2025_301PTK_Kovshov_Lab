using System;
using System.Threading;


namespace Lab2Plants
{
// Simple thread-safe random singleton
public sealed class ThreadSafeRandom
{
private static readonly ThreadLocal<Random> _rng = new(() => new Random(Guid.NewGuid().GetHashCode()));
public static Random Instance => _rng.Value;
}
}
