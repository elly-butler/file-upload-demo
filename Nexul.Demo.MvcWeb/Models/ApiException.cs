using System;

namespace Nexul.Demo.MvcWeb.Models
{
    public class ApiException : Exception
    {
        public ApiException(Exception ex) : base("An exception occured.", ex)
        {
            StatusCode = 500;
        }
        public ApiException(Exception ex, object model) : base("An exception occured.", ex)
        {
            Model = model;
            StatusCode = 500;
        }
        public ApiException(Exception ex, int statusCode) : base("An exception occured.", ex)
        {
            StatusCode = statusCode;
        }
        public ApiException(Exception ex, object model, int statusCode) : base("An exception occured.", ex)
        {
            Model = model;
            StatusCode = statusCode;
        }
        public object Model { get; set; }
        public int StatusCode { get; set; }
    }
}
