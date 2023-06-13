using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewRescheduleModel
{
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
}