using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations.Internal.Tests.Results;

public class ExpectationResultTests
{
	[Theory]
	[AutoData]
	public async Task GetResult_ShouldIncrementIndex(int index)
	{
		IThat<bool> should = That(true).Should();
		should.BeTrue();
		ExpectationResult expectationResult = new(should.ExpectationBuilder);

		Expectation.Result result = await expectationResult.GetResult(index);

		await That(result.SubjectLine).Should()
			.Be($" [{index + 1:00}] Expected {should.ExpectationBuilder.Subject} to");
	}
}
