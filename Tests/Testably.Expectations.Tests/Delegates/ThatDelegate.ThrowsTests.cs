﻿namespace Testably.Expectations.Tests.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class ThrowsTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Other_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected that action
			                          throws a CustomException,
			                          but it did throw an OtherException:
			                            {nameof(Fails_For_Code_With_Other_Exceptions)}
			                          at Expect.That(action).Throws<CustomException>()
			                          """;
			Exception exception = CreateOtherException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).Throws<CustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_With_Supertype_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected that action
			                          throws a SubCustomException,
			                          but it did throw a CustomException:
			                            {nameof(Fails_For_Code_With_Supertype_Exceptions)}
			                          at Expect.That(action).Throws<SubCustomException>()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Func<Task<SubCustomException>> sut = async ()
				=> await Expect.That(action).Throws<SubCustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected that action
			                         throws a CustomException,
			                         but it did not
			                         at Expect.That(action).Throws<CustomException>()
			                         """;
			Action action = () => { };

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).Throws<CustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			CustomException result = await Expect.That(action).Throws<CustomException>();

			await Expect.That(result).IsSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Exact_Exceptions()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).Throws<CustomException>();

			await Expect.That(sut).DoesNotThrow();
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Subtype_Exceptions()
		{
			Exception exception = CreateSubCustomException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).Throws<CustomException>();

			await Expect.That(sut).DoesNotThrow();
		}
	}
}
