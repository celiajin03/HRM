using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  IInterviewRepository:IBaseRepository<Interview>
	{
		Task<List<Interview>> GetAllInterviews();

		Task<Interview> GetInterviewById(int id);
	}
}

