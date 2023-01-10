using ErrorOr;

namespace SAF.CasualTimes.Domain.Common.Errors;

public static partial class Errors
{
	public static class Authentication
	{
		public static Error InvalidCredential => Error.Validation(
			code: "Authentication.InvalidCredential",
			description: "Invalid Credential"
		);
	}
}
