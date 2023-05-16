using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class InterviewRepository: BaseRepository<Interview>, IInterviewRepository
	{
		private InterviewsDbContext _dbContext;
		public InterviewRepository(InterviewsDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Interview>> GetAllInterviews()
		{
			var Interviews = await _dbContext.Interviews.ToListAsync();
			return Interviews;
		}

		public async Task<Interview> GetInterviewById(int id)
		{
			var Interview = await _dbContext.Interviews.FirstOrDefaultAsync(i => i.Id == id);
			return Interview;
		}
	}
}

