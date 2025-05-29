using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.String.Operations;

public sealed record HexString : IString
{
    private readonly IEnumerable<byte> _value;

    public HexString(IEnumerable<byte> value)
    {
        _value = value;
    }

    private string InternalValue => Convert.ToHexString(_value.ToArray());

    string IString.TextValue => InternalValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return InternalValue.Select(symbol => new Char.Char(symbol)).GetEnumerator();
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