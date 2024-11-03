using Testably.Expectations.Core;

namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationBuilderExtensionsTests
{
	[Fact]
	public async Task AppendGenericMethodStatement_1Generic_0MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_1Generic_0MethodParameter)}<int>()";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int>(
			nameof(AppendGenericMethodStatement_1Generic_0MethodParameter));

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_1Generic_1MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_1Generic_1MethodParameter)}<int>(foo)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int>(
			nameof(AppendGenericMethodStatement_1Generic_1MethodParameter), "foo");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_1Generic_2MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_1Generic_2MethodParameter)}<int>(foo, bar)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int>(
			nameof(AppendGenericMethodStatement_1Generic_2MethodParameter), "foo", "bar");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_1Generic_3MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_1Generic_3MethodParameter)}<int>(foo, bar, baz)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int>(
			nameof(AppendGenericMethodStatement_1Generic_3MethodParameter), "foo", "bar", "baz");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_2Generic_0MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_2Generic_0MethodParameter)}<int, string>()";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int, string>(
			nameof(AppendGenericMethodStatement_2Generic_0MethodParameter));

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_2Generic_1MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_2Generic_1MethodParameter)}<int, string>(foo)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int, string>(
			nameof(AppendGenericMethodStatement_2Generic_1MethodParameter), "foo");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_2Generic_2MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_2Generic_2MethodParameter)}<int, string>(foo, bar)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int, string>(
			nameof(AppendGenericMethodStatement_2Generic_2MethodParameter), "foo", "bar");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendGenericMethodStatement_2Generic_3MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendGenericMethodStatement_2Generic_3MethodParameter)}<int, string>(foo, bar, baz)";

		sut.ExpectationBuilder.AppendGenericMethodStatement<int, string>(
			nameof(AppendGenericMethodStatement_2Generic_3MethodParameter), "foo", "bar", "baz");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendMethodStatement_0MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendMethodStatement_0MethodParameter)}()";

		sut.ExpectationBuilder.AppendMethodStatement(
			nameof(AppendMethodStatement_0MethodParameter));

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendMethodStatement_1MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendMethodStatement_1MethodParameter)}(foo)";

		sut.ExpectationBuilder.AppendMethodStatement(
			nameof(AppendMethodStatement_1MethodParameter), "foo");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendMethodStatement_2MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendMethodStatement_2MethodParameter)}(foo, bar)";

		sut.ExpectationBuilder.AppendMethodStatement(
			nameof(AppendMethodStatement_2MethodParameter), "foo", "bar");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}

	[Fact]
	public async Task AppendMethodStatement_3MethodParameter()
	{
		IThat<bool> sut = That(true).Should();
		string expected =
			$".{nameof(AppendMethodStatement_3MethodParameter)}(foo, bar, baz)";

		sut.ExpectationBuilder.AppendMethodStatement(
			nameof(AppendMethodStatement_3MethodParameter), "foo", "bar", "baz");

		await That(async () => await sut.BeFalse()).Should().ThrowException()
			.WithMessage($"*{expected}*").AsWildcard();
	}
}
