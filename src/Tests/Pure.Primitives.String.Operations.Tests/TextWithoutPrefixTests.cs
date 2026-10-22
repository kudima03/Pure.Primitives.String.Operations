using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextWithoutPrefixTests
{
    [Fact]
    public void RemovesPrefix()
    {
        IString str = new TextWithoutPrefix(
            new String("prefix-value"),
            new String("prefix-")
        );

        Assert.Equal("value", str.TextValue);
    }

    [Fact]
    public void RemovesPrefixOnlyOnce()
    {
        IString str = new TextWithoutPrefix(new String("ababc"), new String("ab"));

        Assert.Equal("abc", str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnPrefixEqualToText()
    {
        IString str = new TextWithoutPrefix(new String("prefix"), new String("prefix"));

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void KeepsTextOnEmptyPrefix()
    {
        IString str = new TextWithoutPrefix(new String("value"), new EmptyString());

        Assert.Equal("value", str.TextValue);
    }

    [Fact]
    public void ProducesEmptyStringOnEmptyTextAndEmptyPrefix()
    {
        IString str = new TextWithoutPrefix(new EmptyString(), new EmptyString());

        Assert.Equal(string.Empty, str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnTextNotStartingWithPrefix()
    {
        IString str = new TextWithoutPrefix(
            new String("value-prefix"),
            new String("prefix")
        );

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnPrefixLongerThanText()
    {
        IString str = new TextWithoutPrefix(new String("pre"), new String("prefix"));

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnPrefixOfDifferentCase()
    {
        IString str = new TextWithoutPrefix(
            new String("Prefix-value"),
            new String("prefix-")
        );

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyText()
    {
        IString str = new TextWithoutPrefix(new EmptyString(), new String("prefix"));

        _ = Assert.Throws<ArgumentException>(() => str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString str = new TextWithoutPrefix(
            new String("prefix-value"),
            new String("prefix-")
        );

        Assert.True("value".SequenceEqual(str.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable str = new TextWithoutPrefix(
            new String("prefix-value"),
            new String("prefix-")
        );

        ICollection<IChar> symbols = [];

        foreach (object symbol in str)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True("value".SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextWithoutPrefix(new EmptyString(), new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextWithoutPrefix(new EmptyString(), new EmptyString()).ToString()
        );
    }
}
