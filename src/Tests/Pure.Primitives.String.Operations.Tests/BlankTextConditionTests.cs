using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record BlankTextConditionTests
{
    [Fact]
    public void TakesPositiveResultOnEmptyValue()
    {
        IBool condition = new BlankTextCondition(new EmptyString());

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnWhitespaceValue()
    {
        IBool condition = new BlankTextCondition(new String(" \t\n\r\v\f"));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnUnicodeWhitespaceValue()
    {
        IBool condition = new BlankTextCondition(new String("  　"));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnEmptyAndWhitespaceValues()
    {
        IBool condition = new BlankTextCondition(
            new EmptyString(),
            new String("   "),
            new String("\t")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTextSurroundedByWhitespace()
    {
        IBool condition = new BlankTextCondition(new String("  a  "));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllBlankOneNot()
    {
        IBool condition = new BlankTextCondition(
            new EmptyString(),
            new String(" "),
            new String("Hello, world!")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new BlankTextCondition();

        _ = Assert.Throws<ArgumentException>(() => condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new BlankTextCondition(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new BlankTextCondition(new EmptyString()).ToString()
        );
    }
}
