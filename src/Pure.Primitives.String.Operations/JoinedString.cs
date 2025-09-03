using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record JoinedString : IString
{
    private readonly IString _separator;

    private readonly IEnumerable<IString> _values;

    public JoinedString(IString separator, IEnumerable<IString> values)
    {
        _separator = separator;
        _values = values;
    }

    string IString.TextValue => ValueInternal;

    private string ValueInternal =>
        string.Join(_separator.TextValue, _values.Select(x => x.TextValue));

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
