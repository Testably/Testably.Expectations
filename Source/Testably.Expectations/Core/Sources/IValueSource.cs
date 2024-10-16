using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

public interface IValueSource<TValue>
{
	Task<(TValue?, Exception?)> GetValue();
}
