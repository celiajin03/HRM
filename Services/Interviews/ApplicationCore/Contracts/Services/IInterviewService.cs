using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IInterviewService
	{
		Task<List<InterviewResponseModel>> GetAllInterviews();
		
		Task<InterviewResponseModel> GetInterviewById(int id);

		Task<int> AddInterview(InterviewRequestModel model);
	}
}

