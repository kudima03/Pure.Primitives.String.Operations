using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record WhitespaceJoinedStringTests
{
    [Fact]
    public void JoinCorrectly()
    {
        const string separator = " ";
        const string a = "Hello";
        const string b = "World";
        const string c = "!";

        IString str = new WhitespaceJoinedString([new String(a), new String(b), new String(c)]);
        Assert.Equal(string.Join(separator, a, b, c), str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IString str = new WhitespaceJoinedString([]);
        Assert.Throws<ArgumentException>(() => str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new WhitespaceJoinedString([]).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new WhitespaceJoinedString([]).ToString());
    }
}