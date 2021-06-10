using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.DTO
{
    public class RequestDTO<T>
    {
        public HttpStatusCode Status { get; set; }

        public string Message {get; set; }

        public T Data { get; set; }
    }
}
