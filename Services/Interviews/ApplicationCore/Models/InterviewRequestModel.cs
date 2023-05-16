using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
	public class InterviewRequestModel
	{
		public int Id { get; set; }
		public DateTime BeginTime { get; set; }
		public string CandidateEmail { get; set; }
		public string CandidateFirstName { get; set; }
		public Guid CandidateIdentityId { get; set; }
		public string CandidateLastName { get; set; }
		public DateTime EndTime { get; set; }
		public string? Feedback { get; set; }
		public int InterviewerId { get; set; }
		// public Interviewer Interviewer { get; set; }
		public int InterviewTypeId { get; set; }
		// public InterviewTypeLookUp InterviewTypeLookUp { get; set; }
		public bool? Passed { get; set; }
		public int? Rating { get; set; }
		public int SubmissionId { get; set; }
	}
}

