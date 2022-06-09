using System;
using ValidationPOC.Domain;
using ValidationPOC.Domain.Shared;

namespace ValidationPOC.BL
{
    public interface IForecastService
    {
        OperationResult Update(Forecast forecast);
    }
}
