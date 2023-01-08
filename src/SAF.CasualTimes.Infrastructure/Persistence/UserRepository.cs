using SAF.CasualTimes.Application.Common.Interfaces.Persistence;
using SAF.CasualTimes.Domain.Entities;

namespace SAF.CasualTimes.Infrastructure.Persistence;

internal class UserRepository : IUserRepository
{
	private static readonly List<User> users = new();

	public void Add(User user)
	{
		users.Add(user);
	}

	public User? GetUserByEmail(string email)
	{
		return users.SingleOrDefault(u => u.Email == email);
	}
}
