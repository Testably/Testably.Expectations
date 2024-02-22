using System.Diagnostics;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

/// <summary>
///     A simple nullable expectation on type <typeparamref name="TExpectation" />.
/// </summary>
[StackTraceHidden]
public class AsyncExpectation<TExpectation> : AsyncExpectation<TExpectation, TExpectation>
{
	internal AsyncExpectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
	}
}

/// <summary>
///     A complex nullable expectation from type <typeparamref name="TExpectation" /> to type
///     <typeparamref name="TProperty" />.
/// </summary>
[StackTraceHidden]
public class AsyncExpectation<TExpectation, TProperty> : IAsyncExpectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AsyncExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	#region IExpectation<TExpectation,TProperty> Members

	/// <inheritdoc />
	public Task<ExpectationResult> IsMetByAsync(TExpectation? actual)
		=> _expectationBuilder.IsMetByAsync(actual);

	#endregion

	/// <summary>
	///     Combines the expectation with another expectation using AND.
	/// </summary>
	/// <remarks>Both expectations must be met by the actual value.</remarks>
	public AsyncExpectationWhichShould<TExpectation, TProperty> And()
		=> new(_expectationBuilder.And());

	/// <summary>
	///     Combines the expectation with another expectation using OR.
	/// </summary>
	/// <remarks>At least one expectation must be met by the actual value.</remarks>
	public AsyncExpectationWhichShould<TExpectation, TProperty> Or()
		=> new(_expectationBuilder.Or());

	/// <inheritdoc />
	public override string ToString()
		=> $"Expect {_expectationBuilder}";
}
