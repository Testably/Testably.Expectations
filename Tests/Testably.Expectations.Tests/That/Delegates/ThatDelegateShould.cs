using System.Runtime.CompilerServices;

namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class ThatDelegateShould
{
	private static CustomException CreateCustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
	{
		return new CustomException(message, innerException);
	}

	private static OtherException CreateOtherException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
	{
		return new OtherException(message, innerException);
	}

	private static SubCustomException CreateSubCustomException(
		[CallerMemberName] string message = "",
		Exception? innerException = null)
	{
		return new SubCustomException(message, innerException);
	}

	private class CustomException : Exception
	{
		public string Value => "Foo!";

		public CustomException(string message, Exception? innerException = null)
			: base(message, innerException)
		{
		}
	}

	private class SubCustomException : CustomException
	{
		public SubCustomException(string message, Exception? innerException = null)
			: base(message, innerException)
		{
		}
	}

	private class OtherException : Exception
	{
		public OtherException(string message, Exception? innerException = null)
			: base(message, innerException)
		{
		}
	}
}
