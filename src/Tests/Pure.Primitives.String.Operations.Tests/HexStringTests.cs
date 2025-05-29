using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Text;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record HexStringTests
{
    [Fact]
    public void ProduceHex()
    {
        const string sample = "Hello, world!!!";
        byte[] sampleBytes = Encoding.UTF8.GetBytes(sample);

        IString str = new HexString(sampleBytes);
        Assert.Equal(Convert.ToHexString(sampleBytes), str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        const string sample = "Hello, world!!!";
        byte[] sampleBytes = Encoding.UTF8.GetBytes(sample);

        IString str = new HexString(sampleBytes);

        Assert.True(Convert.ToHexString(sampleBytes).SequenceEqual(str.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const string sample = "Hello, world!!!";
        byte[] sampleBytes = Encoding.UTF8.GetBytes(sample);

        IString str = new HexString(sampleBytes);

        ICollection<IChar> symbols = new List<IChar>();

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(Convert.ToHexString(sampleBytes).SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ProduceEmptyStringOnEmptyArguments()
    {
        IString str = new HexString([]);
        Assert.Empty(str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new HexString([]).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new HexString([]).ToString());
    }
}