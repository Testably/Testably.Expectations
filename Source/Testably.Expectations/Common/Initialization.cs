using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Testably.Expectations.TestFrameworks;

namespace Testably.Expectations.Common;

internal static class Initialization
{
	public static Lazy<InitializationState> State { get; } = new Lazy<InitializationState>(Initialize);

	private static InitializationState Initialize()
	{
		var testFramework = DetectFramework();
		return new InitializationState(testFramework);
	}

	private static ITestFrameworkAdapter DetectFramework()
	{
		var frameworkInterface = typeof(ITestFrameworkAdapter);
		foreach (var frameworkType in frameworkInterface.Assembly
			.GetTypes()
			.Where(x => x.IsClass)
			.Where(frameworkInterface.IsAssignableFrom))
		{
			try
			{
				var testFramework = (ITestFrameworkAdapter?)Activator.CreateInstance(frameworkType);
				if (testFramework?.IsAvailable == true)
				{
					return testFramework;
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"Could not instantiate test framework '{frameworkType.Name}'!", ex);
			}
		}

		return new InternalTestFramework();
	}

	internal class InitializationState
	{
		private readonly ITestFrameworkAdapter testFramework;

		public InitializationState(ITestFrameworkAdapter testFramework)
		{
			this.testFramework = testFramework;
		}

		[DoesNotReturn]
		[StackTraceHidden]
		public void Throw(string message) => testFramework.Throw(message);
	}

	private class InternalTestFramework : ITestFrameworkAdapter
	{
		public bool IsAvailable => false;

		[DoesNotReturn]
		[StackTraceHidden]
		public void Throw(string message) => throw new ExpectationException(message);
	}
}
