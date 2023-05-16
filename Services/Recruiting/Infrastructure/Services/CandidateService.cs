using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _CandidateRepository;

        public CandidateService(ICandidateRepository CandidateRepository)
        {
            _CandidateRepository = CandidateRepository;
        }

        public async Task< List<CandidateResponseModel>> GetAllCandidates()
        {
            var Candidates = await _CandidateRepository.GetAllCandidates();
            
            var CandidateResponseModel = new List<CandidateResponseModel>();
            foreach (var Candidate in Candidates)
            {
                CandidateResponseModel.Add(new CandidateResponseModel
                {
                    Id = Candidate.Id,
                    FirstName = Candidate.FirstName,
                    MiddleName = Candidate.MiddleName,
                    LastName = Candidate.LastName,
                    Email = Candidate.Email,
                    ResumeURL = Candidate.ResumeURL,
                    CreatedOn = Candidate.CreatedOn
                });
            }
            return CandidateResponseModel;
        }

        public async Task<CandidateResponseModel> GetCandidateById(int id)
        {
            var Candidate = await _CandidateRepository.GetCandidateById(id);
            if (Candidate == null)
            {
                return null;
            }
            var CandidateResponseModel = new CandidateResponseModel
            {
                Id = Candidate.Id,
                FirstName = Candidate.FirstName,
                MiddleName = Candidate.MiddleName,
                LastName = Candidate.LastName,
                Email = Candidate.Email,
                ResumeURL = Candidate.ResumeURL,
                CreatedOn = Candidate.CreatedOn,
            };
            return CandidateResponseModel;
        }

        public async Task<int> AddCandidate(CandidateRequestModel model)
        {
            var CandidateEntity = new Candidate
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                ResumeURL = model.ResumeURL,
                CreatedOn = DateTime.UtcNow,
            };

            var Candidate = await _CandidateRepository.AddSync(CandidateEntity);
            return Candidate.Id;
        }
    }
}

