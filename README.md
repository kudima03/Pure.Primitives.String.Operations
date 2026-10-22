# Pure.Primitives.String.Operations

String operations for **Pure** `IString` primitives — composable, immutable value objects for string manipulation and comparison.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.String.Operations)](https://www.nuget.org/packages/Pure.Primitives.String.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.String.Operations` provides sealed record types that perform concatenation, joining, slicing, trimming, encoding, measuring, and comparison operations over `IString` values. All types return `IString`, `IBool`, or `INumber<int>`, keeping results composable within the Pure type system.

## Types

### String-returning (`IString`)

| Type | Description |
|------|-------------|
| `ConcatenatedString` | Concatenates a sequence of `IString` values |
| `WhitespaceJoinedString` | Joins strings with a space separator |
| `CommaJoinedString` | Joins strings with a comma separator |
| `SemicolonJoinedString` | Joins strings with a semicolon separator |
| `ColonJoinedString` | Joins strings with a colon separator |
| `WrappedString` | Wraps a string with prefix and suffix delimiters |
| `Substring` | Returns a slice of an `IString` |
| `HexString` | Encodes a byte sequence as a hex `IString` |
| `TrimmedString` | Removes leading and trailing whitespace |
| `TextBefore` | Part before the first occurrence of a separator (ordinal) |
| `TextAfter` | Part after the first occurrence of a separator (ordinal) |
| `TextBeforeLast` | Part before the last occurrence of a separator (ordinal) |
| `TextAfterLast` | Part after the last occurrence of a separator (ordinal) |
| `TextWithoutPrefix` | Removes a prefix the text must start with (ordinal) |

`TextBefore`, `TextAfter`, `TextBeforeLast`, and `TextAfterLast` throw `ArgumentException` when the separator is absent; an empty result (separator at the start or end) is valid. `TextWithoutPrefix` throws `ArgumentException` when the text does not start with the prefix.

### Number-returning (`INumber<int>`)

| Type | Description |
|------|-------------|
| `TextLength` | Number of characters in an `IString` |

### Condition-returning (`IBool`)

| Type | True when |
|------|-----------|
| `EqualCondition` | All supplied `IString` values are equal |
| `NotEqualCondition` | Not all supplied `IString` values are equal |
| `EmptyTextCondition` | All supplied `IString` values are empty |
| `BlankTextCondition` | All supplied `IString` values are empty or whitespace-only |
| `TextContainingWhitespaceCondition` | All supplied `IString` values contain a whitespace character |
| `AsciiWordCharactersCondition` | All supplied `IString` values consist only of ASCII letters, digits, and `_` (an empty value qualifies) |
| `StartsWithCondition` | The text starts with the prefix (ordinal) |
| `TextLongerThanCondition` | The text has more characters than the limit |
| `TextContainingAnyCharCondition` | The text contains at least one of the given characters |

Conditions taking a set of values throw `ArgumentException` when no values are supplied.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — `IString`, `IBool`, and `INumber<T>` interfaces
