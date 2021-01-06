﻿using System;
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
        public async Task<ApplicantResponseModel> Get(int id)
        {
            try
            {
                var applicantModel = await _bl.ApplicantBl.Get(id);
                return _mapper.Map<ApplicantResponseModel>(applicantModel);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Get");
                throw;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] ApplicantRequestModel requestModel)
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
        public async Task Put([FromBody] ApplicantRequestModel requestModel, int id)
        {
            try
            {
                var applicantModel = _mapper.Map<ApplicantModel>(requestModel);
                await _bl.ApplicantBl.Update(applicantModel, id);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Put");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _bl.ApplicantBl.Remove(id);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Delete");
                throw;
            }
        }
    }
}