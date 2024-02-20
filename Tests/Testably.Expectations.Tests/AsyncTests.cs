using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests;
public sealed class AsyncTests
{
	[Fact]
	public async Task Throw_ExceptionAsync_ShouldWorkAsynchronouslyAlsoWithWhichStatement()
	{
		async Task Sut()
		{
			await Task.Delay(100);
			throw new ArgumentException("foo");
		}

		await Expect.That(Sut,
			Should.Throw.ExceptionAsync().Which(p => p.Message, Should.Be.EqualTo("foo")));
	}

	[Fact]
	public async Task Throw_ExceptionAsync_ShouldWorkAsynchronously()
	{
		async Task Sut()
		{
			await Task.Delay(100);
			throw new ArgumentException("foo");
		}

		await Expect.That(Sut,
			Should.Throw.ExceptionAsync());
	}
}
