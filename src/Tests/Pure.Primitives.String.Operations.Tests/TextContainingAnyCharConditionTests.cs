using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextContainingAnyCharConditionTests
{
    [Fact]
    public void TakesPositiveResultOnFirstGivenChar()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("a:b"),
            new String(":@")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnLastGivenChar()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("a@b"),
            new String(":@")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnGivenCharAtStart()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("@ab"),
            new String(":@")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTextOfGivenCharsOnly()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("@:@"),
            new String(":@")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNoGivenChars()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("ab"),
            new String(":@")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentCase()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("abc"),
            new String("B")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnEmptyChars()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new String("ab"),
            new EmptyString()
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnEmptyText()
    {
        IBool condition = new TextContainingAnyCharCondition(
            new EmptyString(),
            new String(":@")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextContainingAnyCharCondition(
                new EmptyString(),
                new EmptyString()
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextContainingAnyCharCondition(
                new EmptyString(),
                new EmptyString()
            ).ToString()
        );
    }
}
