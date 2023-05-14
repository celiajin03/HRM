using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IJobService
	{
		// List<JobResponseModel> GetAllJobs();
		Task<List<JobResponseModel>> GetAllJobs();
		
		Task<JobResponseModel> GetJobById(int id);

		Task<int> AddJob(JobRequestModel model);
	}
}

