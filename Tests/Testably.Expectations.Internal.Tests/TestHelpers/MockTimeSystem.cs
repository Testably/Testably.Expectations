using Testably.Expectations.Core.TimeSystem;

namespace Testably.Expectations.Internal.Tests.TestHelpers;

internal class MockTimeSystem : ITimeSystem
{
	public MockTask Task { get; }
	public MockThread Thread { get; }
	private readonly MockStopwatchFactory _stopwatchFactory = new();

	public MockTimeSystem()
	{
		Thread = new MockThread(this);
		Task = new MockTask(this);
	}

	#region ITimeSystem Members

	/// <inheritdoc />
	public IStopwatchFactory Stopwatch => _stopwatchFactory;

	#endregion

	public MockTimeSystem ElapseTime(TimeSpan elapsed)
	{
		_stopwatchFactory.ElapseTime(elapsed);
		return this;
	}

	private class MockStopwatchFactory : IStopwatchFactory
	{
		private MockStopwatch _current = new();

		#region IStopwatchFactory Members

		/// <inheritdoc />
		public IStopwatch New()
		{
			return _current;
		}

		#endregion

		public void ElapseTime(TimeSpan elapsed)
		{
			_current.ElapseTime(elapsed);
		}
	}

	private class MockStopwatch : IStopwatch
	{
		private TimeSpan _elapsed = TimeSpan.Zero;
		private bool _isRunning = true;

		#region IStopwatch Members

		/// <inheritdoc />
		public TimeSpan Elapsed => _elapsed;

		/// <inheritdoc />
		public void Start()
		{
			_isRunning = true;
		}

		/// <inheritdoc />
		public void Stop()
		{
			_isRunning = false;
		}

		#endregion

		public void ElapseTime(TimeSpan elapsed)
		{
			if (_isRunning)
			{
				_elapsed += elapsed;
			}
		}
	}

	public class MockTask(MockTimeSystem mockTimeSystem)
	{
		public async Task Delay(int milliseconds)
		{
			mockTimeSystem.ElapseTime(TimeSpan.FromMilliseconds(milliseconds));
			await System.Threading.Tasks.Task.Yield();
		}
	}

	public class MockThread(MockTimeSystem mockTimeSystem)
	{
		public void Sleep(int milliseconds)
		{
			mockTimeSystem.ElapseTime(TimeSpan.FromMilliseconds(milliseconds));
		}
	}
}
