﻿#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatTimeOnly
{
	/// <summary>
	/// Use a fixed random time in each test run to ensure, that the tests don't rely on special times.
	/// </summary>
	private static readonly Lazy<TimeOnly> CurrentTimeLazy = new(
		() => TimeOnly.MinValue.Add(TimeSpan.FromSeconds(new Random().Next(86400))));

	private static TimeOnly EarlierTime(int seconds = 1)
		=> CurrentTime().Add(TimeSpan.FromSeconds(-1*seconds));

	private static TimeOnly CurrentTime()
		=> CurrentTimeLazy.Value;

	private static TimeOnly LaterTime(int seconds = 1)
		=> CurrentTime().Add(TimeSpan.FromSeconds(seconds));
}
#endif
