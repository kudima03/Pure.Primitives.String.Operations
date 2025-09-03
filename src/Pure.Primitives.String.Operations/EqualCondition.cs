using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record EqualCondition : IBool
{
    private readonly IEnumerable<IString> _values;

    public EqualCondition(params IEnumerable<IString> values)
    {
        _values = values;
    }

    bool IBool.BoolValue =>
        !_values.Any()
            ? throw new ArgumentException()
            : _values.DistinctBy(x => x.TextValue).Count() == 1;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
