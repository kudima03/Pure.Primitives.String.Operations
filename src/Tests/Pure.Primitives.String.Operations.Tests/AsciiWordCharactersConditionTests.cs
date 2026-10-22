using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.String.Operations.Tests;

public sealed record AsciiWordCharactersConditionTests
{
    [Fact]
    public void TakesPositiveResultOnLettersDigitsAndUnderscores()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("Hello_World_123"));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnUnderscoresOnly()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("__"));

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnEmptyValue()
    {
        IBool condition = new AsciiWordCharactersCondition(new EmptyString());

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllValidValues()
    {
        IBool condition = new AsciiWordCharactersCondition(
            new String("abc"),
            new String("XYZ"),
            new String("0123456789"),
            new String("_")
        );

        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnWhitespace()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("Hello World"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnPunctuation()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("Hello-World"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNonAsciiLetter()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("café"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnCyrillicLetters()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("привет"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNonAsciiDigit()
    {
        IBool condition = new AsciiWordCharactersCondition(new String("１"));

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllValidOneNot()
    {
        IBool condition = new AsciiWordCharactersCondition(
            new String("abc"),
            new String("_1"),
            new String("a.b")
        );

        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new AsciiWordCharactersCondition();

        _ = Assert.Throws<ArgumentException>(() => condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AsciiWordCharactersCondition(new EmptyString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AsciiWordCharactersCondition(new EmptyString()).ToString()
        );
    }
}
