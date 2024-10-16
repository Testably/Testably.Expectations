using System;
namespace Testably.Expectations.Core;
internal record struct SourceValue<TValue>(TValue? Value, Exception? Exception);
