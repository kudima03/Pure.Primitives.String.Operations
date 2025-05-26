using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record WhitespaceJoinedString : IString
{
    private readonly IString _joinedString;

    public WhitespaceJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public WhitespaceJoinedString(IEnumerable<IString> values)
    {
        _joinedString = new JoinedString(new WhitespaceString(), values);
    }

    string IString.Value => _joinedString.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}