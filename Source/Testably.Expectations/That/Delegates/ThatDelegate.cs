using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on delegate values.
/// </summary>
public abstract class ThatDelegate(IExpectationBuilder expectationBuilder)
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	/// <summary>
	///     A delegate without value.
	/// </summary>
	public sealed class WithoutValue : ThatDelegate
	{
		internal WithoutValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}
	}

	/// <summary>
	///     A delegate with value of type <typeparamref name="TValue" />.
	/// </summary>
	public sealed class WithValue<TValue> : ThatDelegate
	{
		internal WithValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}
	}
}
