using System;
using System.Threading.Tasks;
using ValidationPOC.Domain;
using ValidationPOC.Domain.Shared;
using ValidationPOC.ValidationService;

namespace ValidationPOC.BL
{
    public class ForecastService : IForecastService
    {
        readonly IValidationService _validationService;
        public ForecastService(IValidationService validationService)
        {
            this._validationService = validationService;
        }

        public OperationResult Update(Forecast forecast)
        {
            var operationResult = new OperationResult();

            var validationResult = _validationService.Validate(forecast);

            if (!validationResult.IsValid)
            {
                operationResult.Success = validationResult.IsValid;
                operationResult.ValidationResult = validationResult;
                return operationResult;
            }

            // Do some other work
            // DoWork();
            operationResult.Success = true;
            return operationResult;
        }
    }
}
