#if NET6_0_OR_GREATER
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;

namespace Testably.Expectations.Tests.Core.Ambient;

public sealed class InitializationTests
{
	[Fact]
	public void AssemblyWithoutReferenceOnSupportedFramework_ShouldThrowExpectationException()
	{
		if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			// *.exe files only work on windows!
			return;
		}

		const string fallbackTestPath = @"..\..\TestFramework.FallbackTest.exe";

		Process fallbackTestProcess = new();
		fallbackTestProcess.StartInfo.CreateNoWindow = true;
		fallbackTestProcess.StartInfo.FileName = fallbackTestPath;
		fallbackTestProcess.Start();
		fallbackTestProcess.WaitForExit(30000);

		Expect.That(fallbackTestProcess.ExitCode, Should.Be.EqualTo(1));
	}
}
#endif
