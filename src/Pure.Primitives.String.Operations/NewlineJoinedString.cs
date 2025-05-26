using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record NewLineJoinedString : IString
{
    private readonly IString _separator;

    public NewLineJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public NewLineJoinedString(IEnumerable<IString> values)
    {
        _separator = new NewLineString();
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