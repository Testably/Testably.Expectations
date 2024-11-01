using System.Runtime.CompilerServices;

namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	[Fact]
	public async Task ShouldSupportNestedChecks()
	{
		Exception exception = new CustomException("outer",
			new SubCustomException("inner1",
				// ReSharper disable once NotResolvedInText
				new ArgumentException("inner2", paramName: "param2")));
		void Act() => throw exception;

		CustomException result = await That(Act).Should().Throw<CustomException>()
			.WithInnerException(e1 => e1
				.HaveMessage("inner1").And
				.HaveInner<ArgumentException>(e2 => e2
					.HaveParamName("param2").And.HaveMessage("inner2*").AsWildcard()));

		await That(result).Should().BeSameAs(exception);
	}

	private class CustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: Exception(message, innerException);

	private class OtherException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: Exception(message, innerException);

	private class OuterException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: Exception(message, innerException);

	private class SubCustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
		: CustomException(message, innerException);
}
