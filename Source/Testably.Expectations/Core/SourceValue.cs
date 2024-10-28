using System;

namespace Testably.Expectations.Core;

/// <summary>
///     A source for the expectations can be either a <paramref name="Value" /> or an <paramref name="Exception" />.
/// </summary>
public record struct SourceValue<TValue>(in TValue? Value, Exception? Exception);
