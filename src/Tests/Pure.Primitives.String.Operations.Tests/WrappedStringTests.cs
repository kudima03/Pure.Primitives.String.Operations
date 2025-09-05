using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record WrappedStringTests
{
    [Fact]
    public void JoinCorrectly()
    {
        IString str = new WrappedString(new SingleQuoteString(), new String("value"));
        Assert.Equal("'value'", str.TextValue);
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable str = new NewLineJoinedString(
            new SingleQuoteString(),
            new String("value"),
            new RightSquareBracketString()
        );

        ICollection<IChar> symbols = [];

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True("'value]".SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new WrappedString(new EmptyString(), new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new WrappedString(new EmptyString(), new EmptyString()).ToString()
        );
    }
}
