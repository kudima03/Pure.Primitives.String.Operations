using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record BlankTextCondition : IBool
{
    private readonly IEnumerable<IString> _values;

    public BlankTextCondition(params IEnumerable<IString> values)
    {
        _values = values;
    }

    public bool BoolValue =>
        !_values.Any()
            ? throw new ArgumentException()
            : _values.All(x => string.IsNullOrWhiteSpace(x.TextValue));

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
