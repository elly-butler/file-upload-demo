using Microsoft.AspNetCore.Mvc;
using Nexul.Demo.MvcWeb.Models;
using System.Linq;

namespace Nexul.Demo.MvcWeb.Filters
{
    public class ValidationStateResult<T> : ObjectResult
    {
        public ValidationStateResult(int statusCode, string message)
            :base(new ValidationStateModel(message))
        {
            StatusCode = statusCode;
        }
        public ValidationStateResult(ValidationState<T> model, object displayModel)
            : base(model)
        {
            StatusCode = model.Errors.Count == 0 ? 200
                    : model.Errors.Max(x => x.StatusCode);
            if (StatusCode != 200)
                Value = model.SerializeErrors();
            else
            {
                Value = new
                {
                    success = model.Errors.Count == 0,
                    messages = model.SerializeErrors(),
                    item = displayModel
                };
            }
        }
    }
}
