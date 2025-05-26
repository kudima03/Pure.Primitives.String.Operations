using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record NotEqualConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new NotEqualCondition(
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"));

        Assert.False(equality.Value);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new NotEqualCondition(new String("Hello, world!"), new String("Hello, world!"));

        Assert.False(equality.Value);
    }

    [Fact]
    public void TakesPositiveResultOnDifferentValues()
    {
        IBool equality = new NotEqualCondition(
            new String("Hello, world!1"),
            new String("Hello, world!2"),
            new String("Hello, world!3"),
            new String("Hello, world!4"),
            new String("Hello, world!5"));

        Assert.True(equality.Value);
    }

    [Fact]
    public void TakesPositiveResultOnAllSameOneDifferentValue()
    {
        IBool equality = new NotEqualCondition(
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!1"));

        Assert.True(equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnSingleElementInCollection()
    {
        IBool equality = new NotEqualCondition(new EmptyString());
        Assert.Throws<ArgumentException>(() => equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool equality = new NotEqualCondition();
        Assert.Throws<ArgumentException>(() => equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new EmptyString()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new EmptyString()).ToString());
    }
}