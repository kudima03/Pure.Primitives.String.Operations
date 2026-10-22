using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record EmptyTextConditionTests
{
    [Fact]
    public void TakesPositiveResultOnEmptyValues()
    {
        IBool condition = new EmptyTextCondition(
            new EmptyString(),
            new String(string.Empty),
            new EmptyString()
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNonEmptyValue()
    {
        IBool condition = new EmptyTextCondition(new String("a"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnWhitespaceValue()
    {
        IBool condition = new EmptyTextCondition(new String(" "));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllEmptyOneNot()
    {
        IBool condition = new EmptyTextCondition(
            new EmptyString(),
            new EmptyString(),
            new String("Hello, world!")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool condition = new EmptyTextCondition(new EmptyString());

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new EmptyTextCondition();

        _ = Assert.Throws<ArgumentException>(() => condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EmptyTextCondition(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EmptyTextCondition(new EmptyString()).ToString()
        );
    }
}
