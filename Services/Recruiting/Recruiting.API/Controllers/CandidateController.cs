using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        // add references for ApplicationCore and Infra Projects
        // copy all the DI registrations including DbContext into API project program.cs
        // copy the connection string from MVC appSettings to API appSettings

        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        
        // http:localhost/api/candidates
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();

            if (!candidates.Any())
            {
                // no candidates exists, then 404
                return NotFound(new { error = "No open candidate found, please try later" });
            }
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(candidates);
        }
        
        // http:localhost/api/candidates/4
        [HttpGet]
        [Route("{id:int}", Name="GetCandidateDetails")]
        public async Task<IActionResult> GetCandidateDetails(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound(new { errorMessage = "No candidate found for this id" });
            }

            return Ok(candidate);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var candidate = await _candidateService.AddCandidate(model);
            return CreatedAtAction("GetCandidateDetails", new { controller = "Candidate", id = candidate }, "Candidate Created");
        }
    }
}
