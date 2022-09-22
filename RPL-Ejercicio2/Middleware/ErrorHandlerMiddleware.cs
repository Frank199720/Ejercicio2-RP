using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RP.Domain.Exceptions.Api;
using RP.Domain.Exceptions.Core.Business;
using RP.Domain.Exceptions.Core.Persistence;
using RP.Domain.Exceptions.Core.Validation;
using RP.Domain.Wrappers;

namespace RPL_Ejercicio2.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public ErrorHandlerMiddleware() { }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                

                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case ValidateException e:
                        // custom application error
                        response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        var errors = e.ErrorsDictionary.Select(x => x.Value).ToList();
                        responseModel.Errors = new List<string>();
                        for (int i = 0; i < errors.Count; i++)
                        {
                            var valueError = errors[i];
                            var errorAdd = valueError.FirstOrDefault();
                            responseModel.Errors.Add(errorAdd);

                        }
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case EntityNotFoundException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case EntityNotEnabledException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status423Locked;
                        break;

                    case EntityDuplicatedException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case EntityAlreadyExistException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case BusinessException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status406NotAcceptable;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings()
                {
                    Culture = System.Globalization.CultureInfo.CurrentCulture,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    FloatParseHandling = FloatParseHandling.Decimal,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }
        }
    }
}
