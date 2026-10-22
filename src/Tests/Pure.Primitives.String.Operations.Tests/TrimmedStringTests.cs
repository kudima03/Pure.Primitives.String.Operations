using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TrimmedStringTests
{
    [Fact]
    public void RemovesLeadingAndTrailingWhitespace()
    {
        IString str = new TrimmedString(new String(" \t Hello, world! \n "));

        Assert.Equal("Hello, world!", str.TextValue);
    }

    [Fact]
    public void KeepsInnerWhitespace()
    {
        IString str = new TrimmedString(new String("  Hello   world  "));

        Assert.Equal("Hello   world", str.TextValue);
    }

    [Fact]
    public void RemovesUnicodeWhitespace()
    {
        IString str = new TrimmedString(new String("  Hello　"));

        Assert.Equal("Hello", str.TextValue);
    }

    [Fact]
    public void KeepsTextWithoutSurroundingWhitespace()
    {
        IString str = new TrimmedString(new String("Hello"));

        Assert.Equal("Hello", str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnWhitespaceOnly()
    {
        IString str = new TrimmedString(new String(" \t\n "));

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnEmptyString()
    {
        IString str = new TrimmedString(new EmptyString());

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString str = new TrimmedString(new String("  Hello, world!  "));

        Assert.True("Hello, world!".SequenceEqual(str.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable str = new TrimmedString(new String("  Hello, world!  "));

        ICollection<IChar> symbols = [];

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True("Hello, world!".SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TrimmedString(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TrimmedString(new EmptyString()).ToString()
        );
    }
}
