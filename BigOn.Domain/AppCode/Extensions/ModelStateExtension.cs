using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        public static IEnumerable<ValidetionError> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = (
                   from key in modelState.Keys
                   where modelState[key] != null && modelState[key].Errors.Count>0
                   select new ValidetionError(key, modelState[key].Errors[0].ErrorMessage)
                   ).ToList();
            return errors;

        }

    }


    public class ValidetionError
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public ValidetionError(string FieldName, string message)
        {
            this.FieldName = FieldName;
            this.Message = message;
        }
    }
}