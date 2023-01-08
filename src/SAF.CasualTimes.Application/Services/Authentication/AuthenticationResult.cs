using SAF.CasualTimes.Domain.Entities;

namespace SAF.CasualTimes.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);
