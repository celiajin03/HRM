using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  IJobRepository:IBaseRepository<Job>
	{
		// List<Job> GetAllJobs();
		Task<List<Job>> GetAllJobs();
		
		Task<List<Job>> GetJobsByPagination(int skipCount, int pageSize);

		Task<List<Job>> GetJobsByTittleOrDescription(string keyword);

		Task<Job> GetJobById(int id);
	}
}

