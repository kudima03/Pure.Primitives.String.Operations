using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record SemicolonJoinedString : IString
{
    private readonly IString _joinedString;

    private SemicolonJoinedString(IString joinedString)
    {
        _joinedString = joinedString;
    }

    public SemicolonJoinedString(params IEnumerable<IString> values) :
        this(new JoinedString(new SemicolonString(), values))
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
