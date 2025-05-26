using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record NewLineJoinedString : IString
{
    private readonly IString _joinedString;

    public NewLineJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public NewLineJoinedString(IEnumerable<IString> values)
    {
        _joinedString = new JoinedString(new NewLineString(), values);
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