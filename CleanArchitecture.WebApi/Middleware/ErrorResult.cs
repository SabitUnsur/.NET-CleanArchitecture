

using Newtonsoft.Json;

namespace CleanArchitecture.WebApi.Middleware
{
    public sealed class ErrorResult : ErrorStatusCode
    {
        public string? Message { get; set; }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        //Serialize yapılma sebebi, response olarak json döneceğiz.
    }

    public sealed class ValidationErrorResultDetails : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    }
}
