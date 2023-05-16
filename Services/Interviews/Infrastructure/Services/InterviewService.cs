using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class InterviewService : IInterviewService
	{
        private readonly IInterviewRepository _InterviewRepository;

        public InterviewService(IInterviewRepository InterviewRepository)
        {
            _InterviewRepository = InterviewRepository;
        }

        public async Task< List<InterviewResponseModel>> GetAllInterviews()
        {
            var Interviews = await _InterviewRepository.GetAllInterviews();
            
            var InterviewResponseModel = new List<InterviewResponseModel>();
            foreach (var Interview in Interviews)
            {
                InterviewResponseModel.Add(new InterviewResponseModel
                {
                    Id = Interview.Id, 
                    BeginTime = Interview.BeginTime, 
                    CandidateEmail = Interview.CandidateEmail, 
                    CandidateFirstName = Interview.CandidateFirstName, 
                    CandidateIdentityId = Interview.CandidateIdentityId, 
                    CandidateLastName = Interview.CandidateLastName,
                    EndTime = Interview.EndTime,
                    Feedback = Interview.Feedback,
                    InterviewerId = Interview.InterviewerId,
                    InterviewTypeId = Interview.InterviewTypeId,
                    Passed = Interview.Passed,
                    Rating = Interview.Rating,
                    SubmissionId = Interview.SubmissionId
                });
            }
            return InterviewResponseModel;
        }

        public async Task<InterviewResponseModel> GetInterviewById(int id)
        {
            var Interview = await _InterviewRepository.GetInterviewById(id);
            if (Interview == null)
            {
                return null;
            }
            var InterviewResponseModel = new InterviewResponseModel
            {
                Id = Interview.Id, 
                BeginTime = Interview.BeginTime, 
                CandidateEmail = Interview.CandidateEmail, 
                CandidateFirstName = Interview.CandidateFirstName, 
                CandidateIdentityId = Interview.CandidateIdentityId, 
                CandidateLastName = Interview.CandidateLastName,
                EndTime = Interview.EndTime,
                Feedback = Interview.Feedback,
                InterviewerId = Interview.InterviewerId,
                InterviewTypeId = Interview.InterviewTypeId,
                Passed = Interview.Passed,
                Rating = Interview.Rating,
                SubmissionId = Interview.SubmissionId
            };
            return InterviewResponseModel;
        }

        public async Task<int> AddInterview(InterviewRequestModel model)
        {
            var InterviewEntity = new Interview
            {
                Id = model.Id, 
                BeginTime = model.BeginTime, 
                CandidateEmail = model.CandidateEmail, 
                CandidateFirstName = model.CandidateFirstName, 
                CandidateIdentityId = model.CandidateIdentityId, 
                CandidateLastName = model.CandidateLastName,
                EndTime = model.EndTime,
                Feedback = model.Feedback,
                InterviewerId = model.InterviewerId,
                InterviewTypeId = model.InterviewTypeId,
                Passed = model.Passed,
                Rating = model.Rating,
                SubmissionId = model.SubmissionId
            };

            var Interview = await _InterviewRepository.AddSync(InterviewEntity);
            return Interview.Id;
        }
    }
}

