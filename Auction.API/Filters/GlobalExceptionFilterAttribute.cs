using Auction.Application.Error;
using Auction.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Auction.API.Filters
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch (exception)
            {
                case ValidationException validationException:
                    HandleValidationException(context, validationException);
                    break;
                case DomainException domainException:
                    HandleDomainException(context, domainException);
                    break;
                default:
                    UnHandleException(context, exception);
                    break;
            }
        }

        private void HandleDomainException(ExceptionContext context, DomainException exception)
        {
            var applicationException = BuildErrorResponse(exception);
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Result = new JsonResult(applicationException);
            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context, ValidationException exception)
        {
            var applicationException = BuildErrorResponse(exception);
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new JsonResult(applicationException);
            context.ExceptionHandled = true;
        }

        private void UnHandleException(ExceptionContext context, Exception exception)
        {
            var applicationException = BuildErrorResponse(exception);
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(applicationException);
            context.ExceptionHandled = true;
        }

        private ErrorResponse BuildErrorResponse(Exception exception)
        {
            var error = new Dictionary<string, List<string>> { { "", new List<string> { exception.Message } } };
            return new ErrorResponse(error);
        }

        private ErrorResponse BuildErrorResponse(ValidationException exception)
        {
            var errors = new Dictionary<string, List<string>>();

            foreach (var item in exception.Errors)
            {
                if (errors.ContainsKey(item.PropertyName))
                {
                    errors[item.PropertyName].Add(item.ErrorMessage);
                }
                else
                {
                    errors.Add(item.PropertyName, new List<string> { item.ErrorMessage });
                }
            }

            return new ErrorResponse(errors);
        }

    }
}
