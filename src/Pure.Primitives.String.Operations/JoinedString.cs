using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record JoinedString : IString
{
    private readonly IString _separator;

    private readonly IEnumerable<IString> _values;

    public JoinedString(IString separator, IEnumerable<IString> values)
    {
        _separator = separator;
        _values = values;
    }

    string IString.Value
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            return string.Join(_separator.Value, _values.Select(x => x.Value));
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