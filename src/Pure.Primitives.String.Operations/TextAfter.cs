using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TextAfter : IString
{
    private readonly IString _text;

    private readonly IString _separator;

    public TextAfter(IString text, IString separator)
    {
        _text = text;
        _separator = separator;
    }

    public string TextValue =>
        _text.TextValue.IndexOf(_separator.TextValue, StringComparison.Ordinal)
            is var index
                and >= 0
            ? _text.TextValue[(index + _separator.TextValue.Length)..]
            : throw new ArgumentException();

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
