using System;
using System.Net;
using System.Net.Http;
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
	public async Task SupportAsyncAndCombinationsOnRightNode()
	{
		var sut = new HttpResponseMessage(HttpStatusCode.Accepted) { Content = new StringContent("foo") };

		await Expect.That(sut,
			Should.Be.OfType<HttpResponseMessage>().Which(m => m.StatusCode, Should.Be.EqualTo(HttpStatusCode.Accepted)).And().Which(m => m.Content.ReadAsStringAsync(), Should.Be.EqualTo("foo")));
	}

	[Fact]
	public async Task SupportAsyncAndCombinationsOnLeftNode()
	{
		var sut = new HttpResponseMessage(HttpStatusCode.Accepted) { Content = new StringContent("foo") };

		await Expect.That(sut,
			Should.Be.OfType<HttpResponseMessage>().Which(m => m.Content.ReadAsStringAsync(), Should.Be.EqualTo("foo")).And().Which(m => m.StatusCode, Should.Be.EqualTo(HttpStatusCode.Accepted)));
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
