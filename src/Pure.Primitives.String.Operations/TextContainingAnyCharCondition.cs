using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record TextContainingAnyCharCondition : IBool
{
    private readonly IString _text;

    private readonly IString _characters;

    public TextContainingAnyCharCondition(IString text, IString characters)
    {
        _text = text;
        _characters = characters;
    }

    public bool BoolValue => _text.TextValue.Any(_characters.TextValue.Contains);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
