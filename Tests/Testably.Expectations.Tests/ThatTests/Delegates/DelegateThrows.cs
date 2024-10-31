namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
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
