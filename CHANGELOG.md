# Changelog

All notable changes to Pure.Primitives.String.Operations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [1.5.1] — 2026-06-25

- Maintenance release: dependency and build updates.

## [1.5.0] — 2026-05-20

### Added

- **`Substring`** gained a constructor overload,
  `Substring(IString source, INumber<ushort> length)`, that takes the
  substring from the start of the source string (equivalent to passing
  zero as the start index).

## [1.4.1] — 2025-11-23

### Changed

- Removed the direct `Microsoft.NET.ILLink.Tasks` package dependency.

## [1.4.0] — 2025-11-18

### Added

- The package now multi-targets `net7.0`, `net8.0`, `net9.0`, and
  `net10.0` (previously `net9.0` only).

## [1.3.0] — 2025-11-11

### Added

- **`ColonJoinedString`** — joins values with `:`.
- **`CommaJoinedString`** — joins values with `,`.
- **`SemicolonJoinedString`** — joins values with `;`.

## [1.2.0] — 2025-11-04

- Maintenance release: dependency and build updates.

## [1.1.0] — 2025-11-01

### Added

- `TextValue` on `ConcatenatedString`, `HexString`, `JoinedString`,
  `NewLineJoinedString`, `Substring`, `WhitespaceJoinedString`, and
  `WrappedString`, and `BoolValue` on `EqualCondition` and
  `NotEqualCondition`, are now public properties instead of being
  accessible only through explicit `IString`/`IBool` interface
  implementation.

## [1.0.0] — 2025-11-01

### Added

- Declared AOT-compatible (`IsAotCompatible`) for `net9.0`.

### Changed

- **Breaking:** `Pure.Primitives` is no longer a transitive package
  dependency (it is now referenced privately, at build time only);
  depend on it directly if your code relies on its types.
  `Pure.Primitives.Abstractions` is now referenced directly instead.

## [0.3.0] — 2025-09-05

### Added

- **`WrappedString`** — wraps a value between a prefix and a suffix
  (or a single encloser used for both).

### Changed

- **Breaking:** `ConcatenatedString`, `EqualCondition`,
  `NewLineJoinedString`, `NotEqualCondition`, and
  `WhitespaceJoinedString` now expose a single
  `params IEnumerable<IString>` constructor instead of separate
  `params IString[]` and `IEnumerable<IString>` overloads.

## [0.2.2] — 2025-07-08

- Maintenance release: dependency, metadata, and build updates.

## [0.2.1] — 2025-06-07

- Maintenance release: dependency updates.

## [0.2.0] — 2025-05-29

### Added

- **`HexString`** — renders a sequence of bytes as an uppercase
  hexadecimal string.

## [0.1.0] — 2025-05-28

### Added

- Initial release.
- **`ConcatenatedString`** — concatenates multiple `IString` values.
- **`JoinedString`** — joins `IString` values with a separator
  `IString`.
- **`WhitespaceJoinedString`** — joins values with a single
  whitespace separator.
- **`NewLineJoinedString`** — joins values with a newline separator.
- **`Substring`** — extracts a substring given a start index and
  length.
- **`EqualCondition`** — `IBool` that is `true` when all given
  `IString` values are equal.
- **`NotEqualCondition`** — `IBool` that is `true` when the given
  `IString` values are not all equal.
