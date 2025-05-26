using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record EqualCondition : IBool
{
    private readonly IEnumerable<IString> _values;

    public EqualCondition(params IString[] values) : this(values.AsReadOnly()) { }

    public EqualCondition(IEnumerable<IString> values)
    {
        _values = values;
    }

    bool IBool.Value
    {
        get
        {
            if (_values.Take(2).Count() < 2)
            {
                throw new ArgumentException();
            }

            return _values.DistinctBy(x => x.Value).Count() == 1;
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