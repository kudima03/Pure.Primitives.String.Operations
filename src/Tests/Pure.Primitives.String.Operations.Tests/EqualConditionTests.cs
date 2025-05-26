using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new EqualCondition(
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"));

        Assert.True(equality.Value);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new EqualCondition(new String("Hello, world!"), new String("Hello, world!"));

        Assert.True(equality.Value);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition(
            new String("Hello, world!1"),
            new String("Hello, world!2"),
            new String("Hello, world!3"),
            new String("Hello, world!4"),
            new String("Hello, world!5"));

        Assert.False(equality.Value);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new EqualCondition(
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!"),
            new String("Hello, world!1"));

        Assert.False(equality.Value);
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
        IBool equality = new EqualCondition();
        Assert.Throws<ArgumentException>(() => equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new EmptyString()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new EmptyString()).ToString());
    }
}