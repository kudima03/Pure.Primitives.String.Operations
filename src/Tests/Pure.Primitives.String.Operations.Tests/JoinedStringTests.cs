using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record JoinedStringTests
{
    [Fact]
    public void JoinCorrectly()
    {
        const string separator = "__";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new JoinedString(
            new String(separator),
            [new String(a), new String(b), new String(c)]
        );
        Assert.Equal(string.Join(separator, a, b, c), str.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        const string separator = "__";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new JoinedString(
            new String(separator),
            [new String(a), new String(b), new String(c)]
        );

        Assert.True(
            string.Join(separator, a, b, c).SequenceEqual(str.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const string separator = "__";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IEnumerable str = new JoinedString(
            new String(separator),
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
        IString str = new JoinedString(new EmptyString(), []);
        Assert.Empty(str.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new JoinedString(new EmptyString(), []).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new JoinedString(new EmptyString(), []).ToString()
        );
    }
}
