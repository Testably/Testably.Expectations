using System.Threading;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Sources;

internal interface IValueSource<TValue>
{
	Task<TValue?> GetValue(CancellationToken cancellationToken);
}
