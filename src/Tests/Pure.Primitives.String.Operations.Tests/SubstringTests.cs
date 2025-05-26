using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record SubstringTests
{
    [Fact]
    public void TakesSubstring()
    {
        IString source = new String("Hello, word!");

        const ushort startIndex = 6;
        const ushort length = 4;

        IString str = new Substring(source, new UShort(startIndex), new UShort(length));
        Assert.Equal(source.Value.Substring(startIndex, length), str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnLargeLength()
    {
        IString source = new String("Hello, word!");

        const ushort startIndex = 6;
        const ushort length = 7;

        IString str = new Substring(source, new UShort(startIndex), new UShort(length));
        Assert.Throws<ArgumentOutOfRangeException>(() => str.Value);
    }

    [Fact]
    public void ThrowsExceptionOnBadStartPosition()
    {
        IString source = new String("Hello, word!");

        const ushort startIndex = 13;
        const ushort length = 4;

        IString str = new Substring(source, new UShort(startIndex), new UShort(length));
        Assert.Throws<ArgumentOutOfRangeException>(() => str.Value);
    }

    [Fact]
    public void TakesEmptySubstringOnZeroLength()
    {
        IString source = new String("Hello, word!");

        const ushort startIndex = 5;
        const ushort length = 0;

        IString str = new Substring(source, new UShort(startIndex), new UShort(length));
        Assert.Equal(string.Empty, str.Value);
    }
    

    [Fact]
    public void TakesEmptySubstringFromEmptyStringOnZeroLength()
    {
        IString source = new EmptyString();

        const ushort startIndex = 0;
        const ushort length = 0;

        IString str = new Substring(source, new UShort(startIndex), new UShort(length));
        Assert.Equal(string.Empty, str.Value);
    }
    
    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Substring(new EmptyString(), new UShort(0), new UShort(0)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Substring(new EmptyString(), new UShort(0), new UShort(0)).ToString());
    }
}