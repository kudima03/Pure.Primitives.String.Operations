using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextContainingWhitespaceConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSpace()
    {
        IBool condition = new TextContainingWhitespaceCondition(
            new String("Hello world")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnUnicodeWhitespace()
    {
        IBool condition = new TextContainingWhitespaceCondition(
            new String("Hello world"),
            new String(" ")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllValuesContainingWhitespace()
    {
        IBool condition = new TextContainingWhitespaceCondition(
            new String(" leading"),
            new String("trailing\t"),
            new String("in\nside")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNoWhitespace()
    {
        IBool condition = new TextContainingWhitespaceCondition(new String("Hello"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnEmptyValue()
    {
        IBool condition = new TextContainingWhitespaceCondition(new EmptyString());

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllContainingOneNot()
    {
        IBool condition = new TextContainingWhitespaceCondition(
            new String("Hello world"),
            new String("Hello\tworld"),
            new String("Hello")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new TextContainingWhitespaceCondition();

        _ = Assert.Throws<ArgumentException>(() => condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextContainingWhitespaceCondition(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextContainingWhitespaceCondition(new EmptyString()).ToString()
        );
    }
}
