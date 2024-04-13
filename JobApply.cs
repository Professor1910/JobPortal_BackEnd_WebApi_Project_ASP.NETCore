using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models
{
    public class JobApply
    {
        [Key]
        public int JobApplicationId { get; set; }
        public int JobId { get; set; }
        [Required]
        public string JobSeekerEmailId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Applied_Date { get; set; }
        //public Jobs Jobs { get; set; }
        //public JobSeeker JobSeeker { get; set; }
        //public string CoverLetter {  get; set; }
    }
}
