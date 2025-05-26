using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record WhitespaceJoinedString : IString
{
    private readonly IString _separator;

    private readonly IEnumerable<IString> _values;

    public WhitespaceJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public WhitespaceJoinedString(IEnumerable<IString> values)
    {
        _separator = new WhitespaceString();
        _values = values;
    }

    string IString.Value
    {
        get
        {
            IString joinedString = new JoinedString(_separator, _values);

            return joinedString.Value;
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}