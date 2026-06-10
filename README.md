# Pure.Primitives.String.Operations

String operations for **Pure** `IString` primitives — composable, immutable value objects for string manipulation and comparison.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.String.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.String.Operations)](https://www.nuget.org/packages/Pure.Primitives.String.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.String.Operations` provides sealed record types that perform concatenation, joining, slicing, encoding, and comparison operations over `IString` values. All types return either `IString` or `IBool`, keeping results composable within the Pure type system.

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

### Condition-returning (`IBool`)

| Type | True when |
|------|-----------|
| `EqualCondition` | All supplied `IString` values are equal |
| `NotEqualCondition` | Not all supplied `IString` values are equal |

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — `IString` and `IBool` interfaces
