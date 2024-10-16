using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class DelegateExpectations
{
	public sealed class WithValue<TValue> : DelegateExpectations
	{
		internal WithValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		/// <summary>
		///     Verifies that the delegate does not throw any exception.
		/// </summary>
		public AssertionResult<TValue> DoesNotThrow()
			=> new(_expectationBuilder.Add(
				new DoesNotThrowExpectation<TValue>(),
				b => b.AppendMethod(nameof(DoesNotThrow))));
	}
}
