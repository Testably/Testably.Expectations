![Testably.Expectations](https://raw.githubusercontent.com/Testably/Testably.Expectations/main/Docs/Images/social-preview.png)  
[![Nuget](https://img.shields.io/nuget/v/Testably.Expectations)](https://www.nuget.org/packages/Testably.Expectations)
[![Build](https://github.com/Testably/Testably.Expectations/actions/workflows/build.yml/badge.svg)](https://github.com/Testably/Testably.Expectations/actions/workflows/build.yml)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/36bdcc367ba44d8b902dfc4897f1c0af)](https://app.codacy.com/gh/Testably/Testably.Expectations/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Testably_Testably.Expectations&branch=main&metric=coverage)](https://sonarcloud.io/summary/overall?id=Testably_Testably.Expectations&branch=main)
[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTestably%2FTestably.Expectations%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/Testably/Testably.Expectations/main)

This library is used to assert unit tests in natural language by specifying expectations.

## Examples

  ```csharp
  [Fact]
  public void SomeMethod_ShouldThrowArgumentNullException()
  {
    Expect.That(SomeMethod).Should().Throw<ArgumentNullException>()
      .Which.HaveMessage("Value cannot be null");
  }
  ```
