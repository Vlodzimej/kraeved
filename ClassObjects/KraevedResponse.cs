using System.Net;

#pragma warning disable IDE1006 // Стили именования

namespace KraevedAPI.ClassObjects
{
    [Serializable]
    public class KraevedResponse
    {
        public KraevedResponse(string requestUrl, object? data, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            this.requestUrl = requestUrl;
            this.data = data;
            //this.error = error;
            // this.status = status;
            this.statusCode = httpStatusCode;
        }
        /// <summary>
        /// The Request Url
        /// </summary>
        public string requestUrl { get; set; }

        /// <summary>
        /// The Response Data
        /// </summary>
        public object? data { get; set; }

        /// <summary>
        /// The Response Error
        /// </summary>
        //public string? error { get; set; }

        /// <summary>
        /// The Response Status
        /// </summary>
        //public bool status { get; set; }

        /// <summary>
        /// The Response Http Status Code
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
    }
}

#pragma warning restore IDE1006 // Стили именования
