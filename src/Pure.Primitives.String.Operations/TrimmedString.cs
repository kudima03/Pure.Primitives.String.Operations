using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TrimmedString : IString
{
    private readonly IString _text;

    public TrimmedString(IString text)
    {
        _text = text;
    }

    public string TextValue => _text.TextValue.Trim();

    public IEnumerator<IChar> GetEnumerator()
    {
        return TextValue.Select(symbol => new Char.Char(symbol)).GetEnumerator();
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
