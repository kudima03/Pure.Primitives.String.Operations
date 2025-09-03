using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record ConcatenatedString : IString
{
    private readonly IEnumerable<IString> _parameters;

    public ConcatenatedString(params IEnumerable<IString> parameters)
    {
        _parameters = parameters;
    }

    string IString.TextValue => ValueInternal;

    private string ValueInternal => string.Concat(_parameters.Select(x => x.TextValue));

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
