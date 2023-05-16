using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _InterviewService;

        public InterviewController(IInterviewService InterviewService)
        {
            _InterviewService = InterviewService;
        }
        
        // http:localhost/api/Interviews
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            var Interviews = await _InterviewService.GetAllInterviews();

            if (!Interviews.Any())
            {
                // no Interviews exists, then 404
                return NotFound(new { error = "No Interviews found, please try later" });
            }
            return Ok(Interviews);
        }
        
        // http:localhost/api/Interviews/1
        [HttpGet]
        [Route("{id:int}", Name="GetInterviewDetails")]
        public async Task<IActionResult> GetInterviewDetails(int id)
        {
            var Interview = await _InterviewService.GetInterviewById(id);
            if (Interview == null)
            {
                return NotFound(new { errorMessage = "No Interview found for this id" });
            }

            return Ok(Interview);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var Interview = await _InterviewService.AddInterview(model);
            return CreatedAtAction("GetInterviewDetails", new { controller = "Interview", id = Interview }, "Interview Created");
        }
    }
}
