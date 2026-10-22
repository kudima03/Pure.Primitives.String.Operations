using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TextLength : INumber<int>
{
    private readonly IString _text;

    public TextLength(IString text)
    {
        _text = text;
    }

    public int NumberValue => _text.TextValue.Length;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
