namespace SAF.CasualTimes.Application.Common.Interfaces.Persistence;

using SAF.CasualTimes.Domain.Entities;

public interface IUserRepository
{
	User? GetUserByEmail(string email);

	void Add(User user);
}
