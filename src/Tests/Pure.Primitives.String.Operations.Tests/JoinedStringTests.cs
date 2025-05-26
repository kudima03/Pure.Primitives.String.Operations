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

        IString str = new JoinedString(new String(separator), [new String(a), new String(b), new String(c)]);
        Assert.Equal($"{a}{separator}{b}{separator}{c}", str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IString str = new JoinedString(new EmptyString(), []);
        Assert.Throws<ArgumentException>(() => str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new JoinedString(new EmptyString(), []).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new JoinedString(new EmptyString(), []).ToString());
    }
}