using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record Substring : IString
{
    private readonly IString _source;

    private readonly INumber<ushort> _startIndex;

    private readonly INumber<ushort> _length;

    public Substring(IString source, INumber<ushort> startIndex, INumber<ushort> length)
    {
        _source = source;
        _startIndex = startIndex;
        _length = length;
    }

    string IString.Value
    {
        get
        {
            return _source.Value.Substring(_startIndex.Value, _length.Value);
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}