﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected ApplicatonProcessBl _bl;
        protected ILogger _logger;

        public BaseController(ApplicatonProcessBl bl, ILogger logger)
        {
            _bl = bl;
            _logger = logger;
        }
    }
}
