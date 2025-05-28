using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using System.Collections;

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

    string IString.TextValue => ValueInternal;

    private string ValueInternal
    {
        get
        {
            return _source.TextValue.Substring(_startIndex.NumberValue, _length.NumberValue);
        }
    }

    public IEnumerator<IChar> GetEnumerator()
    {
        return ValueInternal.Select(symbol => new Char.Char(symbol)).GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}