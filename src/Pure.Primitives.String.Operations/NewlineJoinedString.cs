﻿using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.String.Operations;

public sealed record NewLineJoinedString : IString
{
    private readonly IString _joinedString;

    public NewLineJoinedString(params IString[] values) : this(values.AsReadOnly()) { }

    public NewLineJoinedString(IEnumerable<IString> values)
    {
        _joinedString = new JoinedString(new NewLineString(), values);
    }

    string IString.TextValue => _joinedString.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _joinedString.GetEnumerator();
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