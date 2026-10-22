using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TextLongerThanCondition : IBool
{
    private readonly INumber<int> _length;

    private readonly INumber<int> _limit;

    public TextLongerThanCondition(IString text, INumber<int> limit)
        : this(new TextLength(text), limit) { }

    private TextLongerThanCondition(INumber<int> length, INumber<int> limit)
    {
        _length = length;
        _limit = limit;
    }

    public bool BoolValue => _length.NumberValue > _limit.NumberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
