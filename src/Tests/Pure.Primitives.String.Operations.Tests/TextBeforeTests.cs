using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextBeforeTests
{
    [Fact]
    public void TakesPartOnSingleSeparator()
    {
        IString str = new TextBefore(new String("key::value"), new String("::"));

        Assert.Equal("key", str.TextValue);
    }

    [Fact]
    public void TakesPartOnRepeatedSeparator()
    {
        IString str = new TextBefore(new String("a::b::c"), new String("::"));

        Assert.Equal("a", str.TextValue);
    }

    [Fact]
    public void TakesPartOnSeparatorAtStart()
    {
        IString str = new TextBefore(new String("::value"), new String("::"));

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void TakesPartOnSeparatorAtEnd()
    {
        IString str = new TextBefore(new String("key::"), new String("::"));

        Assert.Equal("key", str.TextValue);
    }

    [Fact]
    public void TakesPartOnEmptySeparator()
    {
        IString str = new TextBefore(new String("abc"), new EmptyString());

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnSeparatorOnly()
    {
        IString str = new TextBefore(new String("::"), new String("::"));

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnEmptyTextAndEmptySeparator()
    {
        IString str = new TextBefore(new EmptyString(), new EmptyString());

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnMissingSeparator()
    {
        IString str = new TextBefore(new String("key-value"), new String("::"));

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyText()
    {
        IString str = new TextBefore(new EmptyString(), new String("::"));

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnSeparatorOfDifferentCase()
    {
        IString str = new TextBefore(new String("keyXvalue"), new String("x"));

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString str = new TextBefore(new String("a::b::c"), new String("::"));

        Assert.True("a".SequenceEqual(str.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable str = new TextBefore(new String("a::b::c"), new String("::"));

        ICollection<IChar> symbols = [];

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True("a".SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextBefore(new EmptyString(), new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextBefore(new EmptyString(), new EmptyString()).ToString()
        );
    }
}
