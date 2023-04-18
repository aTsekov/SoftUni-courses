﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() : base(HTTP.StatusCode.BadRequest)
        {
        }
    }
}
