using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record WrappedString : IString
{
    private readonly IString _concatenated;

    public WrappedString(IString encloser, IString wrappedValue)
        : this(encloser, wrappedValue, encloser) { }

    public WrappedString(IString prefix, IString wrappedValue, IString suffix)
        : this(new ConcatenatedString(prefix, wrappedValue, suffix)) { }

    private WrappedString(IString concatenated)
    {
        _concatenated = concatenated;
    }

    public string TextValue => _concatenated.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _concatenated.GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
