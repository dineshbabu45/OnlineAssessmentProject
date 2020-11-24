using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineAssessmentApplication.ViewModel
{
    public class TestViewModel
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        [MaxLength(25, ErrorMessage = "Only 25 characters allowed")]
        [Display(Name = "Name of the Test")]
        public string TestName { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date")]
        public DateTime TestDate { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        [Range(1, 20, ErrorMessage = "Choose Subject")]
        public Subject Subject { get; set; }
        [Required(ErrorMessage = "Choose Start Time")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Choose End Time")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Required]
        public int Passcode { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        [Required]
        public DateTime ModifiedTime { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ModifiedBy { get; set; }
        [Required]
        [Range(1, 15, ErrorMessage = "Choose Grade")]
        public Grade Grade { get; set; }
    }

    public enum Subject
    {
        English = 1, Tamil, Maths, Science,
        [Display(Name = "Computer Science")]
        ComputerScience, Geography
    }
    public class FilterPanel
    {
        public string SearchBy { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
    }


}

