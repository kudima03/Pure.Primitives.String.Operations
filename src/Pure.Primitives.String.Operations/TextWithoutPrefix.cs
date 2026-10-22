using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TextWithoutPrefix : IString
{
    private readonly IString _text;

    private readonly IString _prefix;

    public TextWithoutPrefix(IString text, IString prefix)
    {
        _text = text;
        _prefix = prefix;
    }

    public string TextValue =>
        new StartsWithCondition(_text, _prefix).BoolValue
            ? _text.TextValue[_prefix.TextValue.Length..]
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
