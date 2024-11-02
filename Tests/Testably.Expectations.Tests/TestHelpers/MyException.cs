using System.Runtime.CompilerServices;

namespace Testably.Expectations.Tests.TestHelpers;

internal class MyException(
	[CallerMemberName] string message = "",
	Exception? innerException = null)
	: Exception(message, innerException);
