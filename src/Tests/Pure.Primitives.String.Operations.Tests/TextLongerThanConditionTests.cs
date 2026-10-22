using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record TextLongerThanConditionTests
{
    [Fact]
    public void TakesPositiveResultOnLongerText()
    {
        IBool condition = new TextLongerThanCondition(new String("abcd"), new Int(3));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTextOfLimitLength()
    {
        IBool condition = new TextLongerThanCondition(new String("abc"), new Int(3));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnShorterText()
    {
        IBool condition = new TextLongerThanCondition(new String("ab"), new Int(3));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnEmptyTextAndZeroLimit()
    {
        IBool condition = new TextLongerThanCondition(new EmptyString(), new Zero<int>());

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnEmptyTextAndNegativeLimit()
    {
        IBool condition = new TextLongerThanCondition(new EmptyString(), new Int(-1));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTextLongerThanUShortRange()
    {
        IBool condition = new TextLongerThanCondition(
            new String(new string('a', ushort.MaxValue + 1)),
            new Int(ushort.MaxValue)
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextLongerThanCondition(new EmptyString(), new Zero<int>()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TextLongerThanCondition(new EmptyString(), new Zero<int>()).ToString()
        );
    }
}
