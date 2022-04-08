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

        public IDictionary<string,string[]> Validate<T>(T item) where T : class
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

            return validationResults;
        }
    }
}
