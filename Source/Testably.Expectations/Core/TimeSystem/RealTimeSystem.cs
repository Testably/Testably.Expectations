using System;
using System.Diagnostics;

namespace Testably.Expectations.Core.TimeSystem;

internal class RealTimeSystem : ITimeSystem
{
	public static ITimeSystem Instance { get; } = new RealTimeSystem();
	
	private class RealStopwatchFactory : IStopwatchFactory
	{
		/// <inheritdoc />
		public IStopwatch New()
			=> new RealStopwatch();
	}
	private class RealStopwatch : IStopwatch
	{
		private readonly Stopwatch _stopwatch = new();

		/// <inheritdoc />
		public void Start()
			=> _stopwatch.Start();

		/// <inheritdoc />
		public void Stop()
			=> _stopwatch.Stop();
	
		/// <inheritdoc />
		public TimeSpan Elapsed => _stopwatch.Elapsed;
	}

	/// <inheritdoc />
	public IStopwatchFactory Stopwatch { get; } = new RealStopwatchFactory();
}
