using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class DelegateExpectations
{
	public sealed class WithoutValue : DelegateExpectations
	{
		internal WithoutValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		/// <summary>
		///     Verifies that the delegate does not throw any exception.
		/// </summary>
		public AssertionResult DoesNotThrow()
			=> new(_expectationBuilder.Add(
				new DoesNotThrowExpectation<object?>(),
				b => b.AppendMethod(nameof(DoesNotThrow))));
	}
}
