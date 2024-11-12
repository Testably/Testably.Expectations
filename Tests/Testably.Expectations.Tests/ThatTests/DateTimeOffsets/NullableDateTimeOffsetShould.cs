﻿namespace Testably.Expectations.Tests.ThatTests.DateTimeOffsets;

public sealed partial class NullableDateTimeOffsetShould
{
	/// <summary>
	///     Use a fixed random time in each test run to ensure, that the tests don't rely on special times.
	/// </summary>
	private static readonly Lazy<DateTimeOffset?> CurrentTimeLazy = new(
		() => DateTimeOffset.MinValue.AddSeconds(new Random().Next(100, 100000)));

	private static DateTimeOffset? CurrentTime()
		=> CurrentTimeLazy.Value;

	private static DateTimeOffset? EarlierTime(int seconds = 1)
		=> CurrentTime()?.AddSeconds(-1 * seconds);

	private static DateTimeOffset? LaterTime(int seconds = 1)
		=> CurrentTime()?.AddSeconds(seconds);
}
