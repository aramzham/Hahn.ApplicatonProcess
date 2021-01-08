using System;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;
using Hahn.ApplicatonProcess.December2020.Web.Models;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Hahn.ApplicatonProcess.December2020.Web.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    public class ApplicantsController : BaseController
    {
        private readonly IMapper _mapper;

        public ApplicantsController(ApplicatonProcessBl bl, ILogger logger, IMapper mapper) : base(bl, logger)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, SwaggerResponseDescriptions.GetById, typeof(ApplicantAddRequestModel))]
        [SwaggerResponse(404, SwaggerResponseDescriptions.NotFound, typeof(NotFoundErrorModel))]
        [SwaggerResponse(500, type: typeof(ErrorModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var applicantModel = await _bl.ApplicantBl.Get(id);
                if (applicantModel is null)
                    return NotFound();

                return Ok(_mapper.Map<ApplicantResponseModel>(applicantModel));
            }
            catch (Exception e)
            {
                _logger.Error(e, Verbs.Get);
                throw;
            }
        }

        [HttpPost("Add")]
        [SwaggerRequestExample(typeof(ApplicantAddRequestModel), typeof(ApplicantAddRequestModelExample))]
        [SwaggerResponse(201, SwaggerResponseDescriptions.Created)]
        [SwaggerResponse(400, SwaggerResponseDescriptions.ValidationError, typeof(ValidationErrorModel))]
        [SwaggerResponse(500, type: typeof(ErrorModel))]
        public async Task<IActionResult> Post([FromBody] ApplicantAddRequestModel requestModel)
        {
            try
            {
                var applicantModel = _mapper.Map<ApplicantModel>(requestModel);
                var id = await _bl.ApplicantBl.Add(applicantModel);
                return CreatedAtRoute(string.Empty, new { id });
            }
            catch (Exception e)
            {
                _logger.Error(e, Verbs.Post);
                throw;
            }
        }

        [HttpPut("{id}")]
        [SwaggerRequestExample(typeof(ApplicantUpdateRequestModel), typeof(ApplicantUpdateRequestModelExample))]
        [SwaggerResponse(204, SwaggerResponseDescriptions.Updated)]
        [SwaggerResponse(400, SwaggerResponseDescriptions.ValidationError, typeof(ValidationErrorModel))]
        [SwaggerResponse(404, SwaggerResponseDescriptions.NotFound, typeof(NotFoundErrorModel))]
        [SwaggerResponse(500, type: typeof(ErrorModel))]
        public async Task<IActionResult> Put([FromBody] ApplicantUpdateRequestModel requestModel, int id)
        {
            try
            {
                var applicantModel = _mapper.Map<ApplicantModel>(requestModel);
                var isUpdated = await _bl.ApplicantBl.Update(applicantModel, id);
                if (!isUpdated)
                    return NotFound();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.Error(e, Verbs.Put);
                throw;
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204, SwaggerResponseDescriptions.Deleted)]
        [SwaggerResponse(404, SwaggerResponseDescriptions.NotFound, typeof(NotFoundErrorModel))]
        [SwaggerResponse(500, type: typeof(ErrorModel))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _bl.ApplicantBl.Remove(id);
                if (!isDeleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.Error(e, Verbs.Delete);
                throw;
            }
        }
    }
}