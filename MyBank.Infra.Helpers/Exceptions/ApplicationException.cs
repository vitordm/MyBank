using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyBank.Infra.Helpers.Exceptions
{
    public class ApplicationException : Exception
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Code { get; }
        public ApplicationException() : base()
        {

        }

        public ApplicationException(int code, string message, Exception innerException = null) : base(message, innerException)
        {
            Code = code;
        }

        public ApplicationException(string message, Exception innerException = null) : base(message,innerException)
        {

        }

        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(IList<FluentValidation.Results.ValidationFailure> failures) : this(FluentFailuresToString(failures))
        {
        }

        private static string FluentFailuresToString(IList<FluentValidation.Results.ValidationFailure> failures)
        {
            string message = string.Empty;
            foreach (var fail in failures)
            {
                message += $"{fail.ErrorCode} - {fail.ErrorMessage}\r\n";
            }
            return message;

        }
    }
}
