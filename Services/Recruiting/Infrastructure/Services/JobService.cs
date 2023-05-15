using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class JobService : IJobService
	{
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task< List<JobResponseModel>> GetAllJobs()
        {
            /*
            //have some fummy data
            var jobs = new List<JobResponseModel>()
            {
                new JobResponseModel {Id = 1, Title=".NET Developer", Description = "Need to be good with C# and EF Core and .NET"},
                new JobResponseModel { Id = 2, Title = "Full Stack .NET Developer", Description = "Need to be good with Typescript, C# and EF Core and .NET" },
                new JobResponseModel {Id = 3, Title="Java Developer", Description = "Need to be good with Java"},
                new JobResponseModel {Id = 4, Title="JavaScript Developer", Description = "Need to be good with JavaScript"}

            };
            return jobs;
            */
            var jobs = await _jobRepository.GetAllJobs();
            
            var jobResponseModel = new List<JobResponseModel>();
            foreach (var job in jobs)
            {
                jobResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id, Description = job.Description, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), NumberOfPositions = job.NumberOfPositions
                });
            }
            return jobResponseModel;
            
            /*
             // LINQ
            return jobs.Select(job => new JobResponseModel
                { Id = job.Id, Description = job.Description, Title = job.Title }).ToList();
            */
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            // return  new JobResponseModel { Id = 4, Title = "JavaScript Developer", Description = "Need to be good with JavaScript" };
            var job = await _jobRepository.GetJobById(id);
            if (job == null)
            {
                return null;
            }
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description
            };
            return jobResponseModel;
        }

        public async Task<int> AddJob(JobRequestModel model)
        {
            // call the repository that will use EF Core to save the data
            var jobEntity = new Job
            {
                Title = model.Title, StartDate = model.StartDate, Description = model.Description,
                CreatedOn = DateTime.UtcNow, NumberOfPositions = model.NumberOfPositions, JobStatusLookUpId = 1
            };

            var job = await _jobRepository.AddSync(jobEntity);
            return job.Id;
        }
    }
}

