using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestRegistration.Web.Extensions;

public static class ErrorValidationExtension
{
    public static IEnumerable<ModelError> GetErrors(this ModelStateDictionary modelState)
    {
        IEnumerable<ModelError> errors = modelState.Values.SelectMany(v => v.Errors);
        return errors;
    }
}