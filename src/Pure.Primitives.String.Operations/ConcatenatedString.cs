using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record ConcatenatedString : IString
{
    private readonly IEnumerable<IString> _parameters;

    public ConcatenatedString(params IString[] parameters) : this(parameters.AsReadOnly()) { }

    public ConcatenatedString(IEnumerable<IString> parameters)
    {
        _parameters = parameters;
    }

    string IString.Value
    {
        get
        {
            if (!_parameters.Any())
            {
                throw new ArgumentException();
            }

            return string.Concat(_parameters.Select(x => x.Value));
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