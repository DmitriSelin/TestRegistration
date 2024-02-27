using System.ComponentModel.DataAnnotations;

namespace TestRegistration.Web.Requests;

public sealed record RegisterRequest([EmailAddress(ErrorMessage = "Некорректый email")]string Email);