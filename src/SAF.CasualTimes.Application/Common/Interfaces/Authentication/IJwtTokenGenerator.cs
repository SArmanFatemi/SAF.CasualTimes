using SAF.CasualTimes.Domain.Entities;

namespace SAF.CasualTimes.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	string GenerateToken(User user);
}
