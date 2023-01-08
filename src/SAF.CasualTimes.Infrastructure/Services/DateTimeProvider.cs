using SAF.CasualTimes.Application.Common.Interfaces.Services;

namespace SAF.CasualTimes.Infrastructure.Services;

internal class DateTimeProvider : IDateTimeProvider
{
	public DateTime UtcNow => DateTime.UtcNow;
}
