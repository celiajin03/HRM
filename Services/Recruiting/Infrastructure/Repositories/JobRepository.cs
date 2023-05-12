using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class JobRepository: IJobRepository
	{
		private RecruitingDbContext _dbContext;
		public JobRepository(RecruitingDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		/*
		 // synchronous version
		public List<Job> GetAllJobs()
		{
			// go to the database and get the data
			// EF Core with LINQ
			var jobs = _dbContext.Jobs.ToList();
			return jobs;
		}
		*/
		public async Task<List<Job>> GetAllJobs()
		{
			// go to the database and get the data
			// EF Core with LINQ
			var jobs = await _dbContext.Jobs.ToListAsync();
			return jobs;
		}

		public async Task<Job> GetJobById(int id)
		{
			var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
			return job;
		}
	}
}

