namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithMessageTests
	{
		[Fact]
		public async Task ShouldSupportNestedChecks()
		{
			Exception exception = new CustomException("outer",
				new SubCustomException("inner1",
					new ArgumentException("inner2", "param2")));
			void Act() => throw exception;

			CustomException result = await Expect.That(Act).Should().Throw<CustomException>()
				.WithInner<SubCustomException>(e1 => e1
					.HaveMessage("inner1").And
					.HaveInner<ArgumentException>(e2 => e2
						.HaveParamName("param2").And.HaveMessage("inner2*").AsWildcard()));

			await Expect.That(result).Should().BeSameAs(exception);
		}
	}
}
