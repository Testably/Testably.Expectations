using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class BooleanExpectationTests
{
	public sealed class Implies
	{
		[Fact]
		public async Task Fails_For_Not_Implying_Values()
		{
			bool antecedent = true;
			bool consequent = false;

			async Task Act()
				=> await Expect.That(antecedent).Implies(consequent);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that antecedent
				                   implies {consequent},
				                   but it did not
				                   at Expect.That(antecedent).Implies(consequent)
				                   """);
		}

		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task Succeeds_For_Implying_Values(bool antecedent, bool consequent)
		{
			async Task Act()
				=> await Expect.That(antecedent).Implies(consequent);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
