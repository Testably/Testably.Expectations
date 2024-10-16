//using AutoFixture.Xunit2;
//using System;
//using Xunit;

//namespace Testably.Expectations.Tests;

//public sealed class ExpectationExtensionsTests
//{
//	[Theory]
//	[AutoData]
//	public void WhichMessage_ShouldGiveAccessToTheMessageOfAnExceptionForExpectations(
//		string message)
//	{
//		void Act() => throw new ArgumentException(message);

//		ExpectVoid.That(Act, Should.Throw.TypeOf<ArgumentException>()
//			.WhichMessage(Should.Contain.Substring(message)));
//	}

//	[Theory]
//	[AutoData]
//	public void WhichMessage_ShouldGiveAccessToTheMessageOfAnExceptionForNullableExpectations(
//		string message)
//	{
//		void Act() => throw new ArgumentException(message);

//		ExpectVoid.That(Act, Should.Throw.TypeOf<ArgumentException>()
//			.WhichMessage(Should.Be.EqualTo(message)));
//	}
//}
