using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.DTO
{
    public class RequestDTO
    {
        public HttpStatusCode Status { get; set; }

        public string Message {get; set; }
    }
}
