using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record NotEqualCondition : IBool
{
    private readonly IEnumerable<IString> _values;

    public NotEqualCondition(params IString[] values) : this(values.AsReadOnly()) { }

    public NotEqualCondition(IEnumerable<IString> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            return _values.DistinctBy(x => x.TextValue).Count() > 1;
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