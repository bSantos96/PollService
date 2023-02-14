// <copyright file="ValidateModelStateAttribute.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Attributes
{
    using System.Net;
    using Guards;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// The validate model state attribute.
    /// </summary>
    public sealed class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>
        /// The status message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the success message should be returned or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if  the success message should be returned or not; otherwise, <c>false</c>.
        /// </value>
        public bool PrintSuccessMessage { get; set; }

        /// <inheritdoc/>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Guard.ArgumentNotNull(context, nameof(context));

            if (!context.ModelState.IsValid)
            {
                context.Result = this.BuildFailureResult(context);
            }
            else if (this.PrintSuccessMessage)
            {
                context.Result = BuildSuccessResult();
            }
        }

        private static JsonResult BuildSuccessResult()
        {
            var responseObj = new
            {
                Status = "OK",
            };

            return new JsonResult(responseObj)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }

        private JsonResult BuildFailureResult(ActionExecutedContext context)
        {
            List<string> errors = context
                    .ModelState
                    .Values
                    .Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

            var responseObj = new
            {
                Status = this.ErrorMessage,
                Errors = errors,
            };

            return new JsonResult(responseObj)
            {
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
    }
}
