﻿#if NET6_0_OR_GREATER
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateOnly
{
	/// <summary>
	/// Use a fixed random time in each test run to ensure, that the tests don't rely on special times.
	/// </summary>
	private static readonly Lazy<DateOnly> CurrentTimeLazy = new(
		() => DateOnly.MinValue.AddDays(new Random().Next(10000)));

	private static DateOnly EarlierTime(int days = 1)
		=> CurrentTime().AddDays((-1)*days);

	private static DateOnly CurrentTime()
		=> CurrentTimeLazy.Value;

	private static DateOnly LaterTime(int days = 1)
		=> CurrentTime().AddDays(days);
}
#endif
