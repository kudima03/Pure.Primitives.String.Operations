using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record StartsWithCondition : IBool
{
    private readonly IString _text;

    private readonly IString _prefix;

    public StartsWithCondition(IString text, IString prefix)
    {
        _text = text;
        _prefix = prefix;
    }

    public bool BoolValue =>
        _text.TextValue.StartsWith(_prefix.TextValue, StringComparison.Ordinal);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
