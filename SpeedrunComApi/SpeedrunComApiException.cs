using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi
{
    /// <summary>
    /// SpeedrunComApi exception.
    /// </summary>
    public class SpeedrunComApiException : Exception
    {
        /// <summary>HTTP error code returned by the Riot API, causing this exception.</summary>
        public readonly HttpStatusCode HttpStatusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public SpeedrunComApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
