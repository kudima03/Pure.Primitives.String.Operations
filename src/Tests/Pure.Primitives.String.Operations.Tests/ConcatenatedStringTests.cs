using Pure.Primitives.Abstractions.String;

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