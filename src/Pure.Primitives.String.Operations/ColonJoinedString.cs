using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record ColonJoinedString : IString
{
    private readonly IString _joinedString;

    private ColonJoinedString(IString joinedString)
    {
        _joinedString = joinedString;
    }

    public ColonJoinedString(params IEnumerable<IString> values) :
        this(new JoinedString(new ColonString(), values))
    { }

    public string TextValue => _joinedString.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _joinedString.GetEnumerator();
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
