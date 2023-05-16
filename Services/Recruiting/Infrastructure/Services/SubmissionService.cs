using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
	public class SubmissionService
	{
		private RecruitingDbContext _dbContext;

		public SubmissionService()
		{
		}
		
		// public async Task<int> AddSubmission(SubmissionRequestModel model)
		// {
		// 	// Check if the email exists in the Candidate table
		// 	int candidateId = _dbContext.Candidates.Where(c => c.Email == model.Email).Select(c=>c.Id).FirstOrDefault();
		// 	bool hasExistingSubmission = _dbContext.Submissions.Any(s => s.CandidateId == candidateId);
		//
		// 	if (hasExistingSubmission)
		// 	{
		// 		// Email exists in the Candidate table
		//
		// 	}
		// 	var SubmissionEntity = new Submission
		// 	{
		// 		FirstName = model.FirstName, LastName = model.LastName, Email=model.Email, SubmittedOn = model.SubmittedOn
		// 	};
		//
		// 	// var job = await _jobRepository.AddSync(jobEntity);
		// 	// return job.Id;
		// }
	}
}

