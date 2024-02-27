using System.ComponentModel.DataAnnotations;

namespace TestRegistration.Web.Requests;

public sealed record VerifingEmailRequest(
    [Required (ErrorMessage = "Отсутствует идентификатор пользователя")]Guid UserId,
    [Required (ErrorMessage = "Отсутствует код подтверждения регистрации")]int Code);