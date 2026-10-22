using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record StartsWithConditionTests
{
    [Fact]
    public void TakesPositiveResultOnMatchingPrefix()
    {
        IBool condition = new StartsWithCondition(
            new String("Hello, world!"),
            new String("Hello")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnPrefixEqualToText()
    {
        IBool condition = new StartsWithCondition(
            new String("Hello"),
            new String("Hello")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnEmptyPrefix()
    {
        IBool condition = new StartsWithCondition(new String("Hello"), new EmptyString());

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnEmptyTextAndEmptyPrefix()
    {
        IBool condition = new StartsWithCondition(new EmptyString(), new EmptyString());

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentPrefix()
    {
        IBool condition = new StartsWithCondition(
            new String("Hello, world!"),
            new String("world")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnPrefixLongerThanText()
    {
        IBool condition = new StartsWithCondition(
            new String("Hello"),
            new String("Hello, world!")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnEmptyText()
    {
        IBool condition = new StartsWithCondition(new EmptyString(), new String("a"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentCase()
    {
        IBool condition = new StartsWithCondition(
            new String("Hello"),
            new String("hello")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ComparesOrdinally()
    {
        IBool condition = new StartsWithCondition(
            new String("Ångstrom"),
            new String("Å")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new StartsWithCondition(new EmptyString(), new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new StartsWithCondition(new EmptyString(), new EmptyString()).ToString()
        );
    }
}
