using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.String.Operations.Tests;
public sealed record ConcatenatedStringTests
{
    [Fact]
    public void ConcatCorrectly()
    {
        const string a = "Hello";
        const string b = " ";
        const string c = "World";
        const string d = " ";
        const string e = "!";

        IString str = new ConcatenatedString(
            new String(a),
            new String(b),
            new String(c),
            new String(d),
            new String(e));

        Assert.Equal(string.Concat(a, b, c, d, e), str.Value);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        const string a = "Hello";
        const string b = " ";
        const string c = "World";
        const string d = " ";
        const string e = "!";

        IString str = new ConcatenatedString(
            new String(a),
            new String(b),
            new String(c),
            new String(d),
            new String(e));

        Assert.True(string.Concat(a, b, c, d, e).SequenceEqual(str.Select(x => x.Value)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const string a = "Hello";
        const string b = " ";
        const string c = "World";
        const string d = " ";
        const string e = "!";

        IEnumerable str = new ConcatenatedString(
            new String(a),
            new String(b),
            new String(c),
            new String(d),
            new String(e));

        ICollection<IChar> symbols = new List<IChar>();

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(string.Concat(a, b, c, d, e).SequenceEqual(symbols.Select(x => x.Value)));
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IString str = new ConcatenatedString();
        Assert.Throws<ArgumentException>(() => str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new ConcatenatedString().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new ConcatenatedString().ToString());
    }
}