namespace TestRegistration.Web.Exceptions;

public sealed class AuthorizationException : Exception
{
	public AuthorizationException(string message) : base(message) { }
}