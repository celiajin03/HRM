using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewFeedbackModel
{
    public string Feedback { get; set; }
    public int Rating { get; set; }
}