using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ValidationPOC.ValidationService
{
    public class ValidationService : IValidationService
    {
        readonly IObjectModelValidator _objectModelValidator;
        public ValidationService(IObjectModelValidator objectModelValidator)
        {
            this._objectModelValidator = objectModelValidator;
        }

        public ValidationResponse Validate<T>(T item) where T : class
        {
            var validationResults = new Dictionary<string, string[]>();

            ActionContext actionContext = new ActionContext();
            _objectModelValidator.Validate(actionContext, null, null, item);

            if (!actionContext.ModelState.IsValid)
            {

                validationResults = actionContext.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            }

            var validationResponse = new ValidationResponse();
            validationResponse.IsValid = actionContext.ModelState.IsValid;
            validationResponse.ValidationResults = validationResults;
            return validationResponse;
        }
    }
}
