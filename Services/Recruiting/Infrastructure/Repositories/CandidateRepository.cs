using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class CandidateRepository: BaseRepository<Candidate>, ICandidateRepository
	{
		private RecruitingDbContext _dbContext;
		public CandidateRepository(RecruitingDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Candidate>> GetAllCandidates()
		{
			var Candidates = await _dbContext.Candidates.ToListAsync();
			return Candidates;
		}

		public async Task<Candidate> GetCandidateById(int id)
		{
			var Candidate = await _dbContext.Candidates.FirstOrDefaultAsync(j => j.Id == id);
			return Candidate;
		}
	}
}

