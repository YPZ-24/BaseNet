using FluentValidation;
using IntranetCorrespondencia.api.Controllers.Base;
using IntranetCorrespondencia.api.Middleware.Models;
using IntranetCorrespondencia.api.Util;

namespace IntranetCorrespondencia.api.Middleware.Utils
{
    public class ExceptionGenerators
    {
        public static ApiResponse<int> GenerateInternalException()
        {
            return new ApiResponse<int>(
                StatusCodes.Status500InternalServerError,
                Constants.ExceptionMessage.Exception500
            );
        }

        public static ApiResponse<ValidationDataModel> GenerateValidationException(ValidationException validation)
        {
            return new ApiResponse<ValidationDataModel>(
                StatusCodes.Status400BadRequest,
                Constants.ExceptionMessage.Exception400,
                validation.Errors.Select(x => new ValidationDataModel(x.PropertyName, x.ErrorMessage)).ToList()
            );
        }
    }
}
