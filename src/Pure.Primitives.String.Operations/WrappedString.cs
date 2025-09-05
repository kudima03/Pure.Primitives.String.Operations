using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.String.Operations;

public sealed record WrappedString : IString
{
    private readonly IString _prefix;

    private readonly IString _wrappedValue;

    private readonly IString _suffix;

    public WrappedString(IString encloser, IString wrappedValue) : this(encloser, wrappedValue, encloser)
    {
        
    }

    public WrappedString(IString prefix, IString wrappedValue, IString suffix)
    {
        _prefix = prefix;
        _wrappedValue = wrappedValue;
        _suffix = suffix;
    }

    private IString InternalValue =>
        new ConcatenatedString(_prefix, _wrappedValue, _suffix);

    string IString.TextValue => InternalValue.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return InternalValue.GetEnumerator();
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
