using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record ColonSeparatedStringTests
{
    [Fact]
    public void JoinCorrectly()
    {
        string separator = ":";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new ColonSeparatedString(
            [new String(a), new String(b), new String(c)]
        );
        Assert.Equal(string.Join(separator, a, b, c), str.TextValue);
    }

    [Fact]
    public void HandlesEmptyStringsInCollection()
    {
        const string a = "Hello";
        const string b = "";
        const string c = "World";

        IString str = new ColonSeparatedString(
            [new String(a), new String(b), new String(c)]
        );
        Assert.Equal("Hello::World", str.TextValue);
    }

    [Fact]
    public void JoinSingleElement()
    {
        const string a = "Hello";
        IString str = new ColonSeparatedString([new String(a)]);
        Assert.Equal(a, str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        string separator = ":";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new ColonSeparatedString(
            [new String(a), new String(b), new String(c)]
        );

        Assert.True(
            string.Join(separator, a, b, c).SequenceEqual(str.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        string separator = ":";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IEnumerable str = new ColonSeparatedString(
            [new String(a), new String(b), new String(c)]
        );

        ICollection<IChar> symbols = [];

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(
            string.Join(separator, a, b, c)
                .SequenceEqual(symbols.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void ProduceEmptyStringOnEmptyArguments()
    {
        IString str = new ColonSeparatedString([]);
        Assert.Empty(str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ColonSeparatedString([]).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ColonSeparatedString([]).ToString()
        );
    }
}
