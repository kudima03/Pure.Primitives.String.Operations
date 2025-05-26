using Pure.Primitives.Abstractions.String;

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