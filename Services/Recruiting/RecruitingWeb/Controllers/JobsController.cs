using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            //we need to get list of Jobs
            //AsyncCallback the Job Service
            //var jobsController = new JobsController(); [error]
            //jobsController.Index();
            //var jobsController = new JobsController();
            var jobs = _jobService.GetAllJobs();
            return View();
        }

        IActionResult Details(int id)
        {
            //get job by Id
            var jobs = _jobService.GetJobById(id);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

