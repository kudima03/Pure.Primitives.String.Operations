using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record NewLineJoinedStringTests
{
    [Fact]
    public void JoinCorrectly()
    {
        string separator = Environment.NewLine;
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new NewLineJoinedString([new String(a), new String(b), new String(c)]);
        Assert.Equal(string.Join(separator, a, b, c), str.Value);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        string separator = Environment.NewLine;
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new NewLineJoinedString([new String(a), new String(b), new String(c)]);

        Assert.True(string.Join(separator, a, b, c).SequenceEqual(str.Select(x => x.Value)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        string separator = Environment.NewLine;
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IEnumerable str = new NewLineJoinedString([new String(a), new String(b), new String(c)]);

        ICollection<IChar> symbols = new List<IChar>();

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(string.Join(separator, a, b, c).SequenceEqual(symbols.Select(x => x.Value)));
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IString str = new NewLineJoinedString([]);
        Assert.Throws<ArgumentException>(() => str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NewLineJoinedString([]).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NewLineJoinedString([]).ToString());
    }
}