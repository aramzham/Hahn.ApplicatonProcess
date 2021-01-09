using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController, Route(Constants.ControllerRoute), Produces(Constants.ContentType)]
    public class BaseController : ControllerBase
    {
        protected ApplicatonProcessBl _bl;
        protected ILogger<BaseController> _logger;

        public BaseController(ApplicatonProcessBl bl, ILogger<BaseController> logger)
        {
            _bl = bl;
            _logger = logger;
        }
    }
}