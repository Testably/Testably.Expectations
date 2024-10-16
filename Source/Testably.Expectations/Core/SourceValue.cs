using System;

namespace Testably.Expectations.Core;

public record struct SourceValue<TValue>(TValue? Value, Exception? Exception);
