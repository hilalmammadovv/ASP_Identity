using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ASP_Identity.Extensions;

public static class ModelStateExtentions
{

    public static void  AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
    {
        errors.ForEach(x =>
        {

            modelState.AddModelError(string.Empty, x);

        });

    }
}
