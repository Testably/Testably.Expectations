![Testably.Expectations](https://raw.githubusercontent.com/Testably/Testably.Expectations/main/Docs/Images/social-preview.png)  
[![Nuget](https://img.shields.io/nuget/v/Testably.Expectations)](https://www.nuget.org/packages/Testably.Expectations)
[![Build](https://github.com/Testably/Testably.Expectations/actions/workflows/build.yml/badge.svg)](https://github.com/Testably/Testably.Expectations/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Testably_Testably.Expectations&branch=main&metric=alert_status)](https://sonarcloud.io/summary/overall?id=Testably_Testably.Expectations)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/36bdcc367ba44d8b902dfc4897f1c0af)](https://app.codacy.com/gh/Testably/Testably.Expectations/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_coverage)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTestably%2FTestably.Expectations%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/Testably/Testably.Expectations/main)

This library is used to assert unit tests in natural language by specifying expectations.
It tries to take the best from [fluentassertions](https://github.com/fluentassertions/fluentassertions) and [TUnit](https://github.com/thomhurst/TUnit) and combine them to a new assertion library.

## Architecture

### Async everything
All expectations are completely async. This allows complete support of `IAsyncEnumerable` as well es `HttpResponseMessage` or similar async types.
No need to distinguish between `action.Should().Throw()` and `await asyncAction.Should().ThrowAsync()`!

### Delayed evaluation
By using `await`, the evaluation is only triggered after the complete fluent chain is loaded, which has some nice benefits:
- `Because` can be registered once as a general method that can be applied at the end of the expectation instead of cluttering all methods with the `because` and `becauseArgs` parameters
- `WithCancellation` can also be registered at the end an applies a `CancellationToken` to all async methods which allows cancellation of `IAsyncEnumerable` evaluations
- Expectations can be combined directly (via `Expect.ThatAll`) instead of relying on global state (e.g. assertion scopes)

### Extensibility
Fluentassertions have a proven way of extensibility via extension methods on `.Should()`. A similar approach is used here:
- Extensions can be written for new types (by writing a `.Should()` extension methods for `IExpectSubjectThat<TType>`)...
- and also for existing types (by writing an extension method on `IThat<TType>`)

## Usage

By adding `global using static Testably.Expectations.Expect;` anywhere in the test project, that `await` can be part of the sentence of the expectation.

  ```csharp
  [Fact]
  public async Task SomeMethod_ShouldThrowArgumentNullException()
  {
    await That(SomeMethod).Should().Throw<ArgumentNullException>()
      .WithMessage("Value cannot be null")
	  .Because("we tested the null edge case");
  }
  ```

## Features
Find [here](Docs/FeatureComparisonWithFluentAssertions.md) a comparison of the features and syntax from fluentassertions and Testably.Expectations.
