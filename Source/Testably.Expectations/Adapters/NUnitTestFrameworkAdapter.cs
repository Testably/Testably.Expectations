using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Testably.Expectations.TestFrameworks;

/// <summary>
/// Implements the NUnit test framework adapter.
/// </summary>
/// <remarks>
/// <see href="https://github.com/nunit/nunit"/>
/// </remarks>
internal class NUnitTestFrameworkAdapter : ITestFrameworkAdapter
{
	private Assembly? assembly;

	public bool IsAvailable
	{
		get
		{
			const string prefix = "nunit.framework,";

			assembly = AppDomain.CurrentDomain
				.GetAssemblies()
				.Where(a => a.FullName?.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) == true)
				.FirstOrDefault();

			return assembly is not null;
		}
	}

	[DoesNotReturn]
	[StackTraceHidden]
	public void Throw(string message)
	{
		Type exceptionType = assembly?.GetType("NUnit.Framework.AssertionException")
			?? throw new NotSupportedException("Failed to create the NUnit assertion type");

		throw (Exception)Activator.CreateInstance(exceptionType, message)!;
	}
}
