using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.String.Operations;

public sealed record WhitespaceJoinedString : IString
{
    private readonly IString _joinedString;

    public WhitespaceJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public WhitespaceJoinedString(IEnumerable<IString> values)
    {
        _joinedString = new JoinedString(new WhitespaceString(), values);
    }

    string IString.TextValue => _joinedString.TextValue;

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