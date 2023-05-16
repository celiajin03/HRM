using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ICandidateService
	{
		Task<List<CandidateResponseModel>> GetAllCandidates();
		
		Task<CandidateResponseModel> GetCandidateById(int id);

		Task<int> AddCandidate(CandidateRequestModel model);
	}
}

