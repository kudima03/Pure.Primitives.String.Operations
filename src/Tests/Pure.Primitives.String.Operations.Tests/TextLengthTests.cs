using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextLengthTests
{
    [Fact]
    public void ProducesNumberOfCharacters()
    {
        const string sample = "Hello, world!";

        INumber<int> length = new TextLength(new String(sample));

        Assert.Equal(sample.Length, length.NumberValue);
    }

    [Fact]
    public void CountsWhitespaceCharacters()
    {
        INumber<int> length = new TextLength(new String(" \t \n "));

        Assert.Equal(5, length.NumberValue);
    }

    [Fact]
    public void ProducesZeroOnEmptyString()
    {
        INumber<int> length = new TextLength(new EmptyString());

        Assert.Equal(0, length.NumberValue);
    }

    [Fact]
    public void ProducesLengthBeyondUShortRange()
    {
        const int size = ushort.MaxValue + 10;

        INumber<int> length = new TextLength(new String(new string('a', size)));

        Assert.Equal(size, length.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextLength(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextLength(new EmptyString()).ToString()
        );
    }
}
