using System;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Common.Models;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Hahn.ApplicatonProcess.December2020.Web.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
                _logger.Error(e, "Get");
                throw;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] ApplicantAddRequestModel requestModel)
        {
            try
            {
                var applicantModel = _mapper.Map<ApplicantModel>(requestModel);
                var id = await _bl.ApplicantBl.Add(applicantModel);
                return CreatedAtRoute("", new {id});
            }
            catch (Exception e)
            {
                _logger.Error(e, "Post");
                throw;
            }
        }

        [HttpPut("{id}")]
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
                _logger.Error(e, "Put");
                throw;
            }
        }

        [HttpDelete("{id}")]
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
                _logger.Error(e, "Delete");
                throw;
            }
        }
    }
}