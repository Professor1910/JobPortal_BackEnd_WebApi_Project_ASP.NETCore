using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models
{
    public class Jobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        [Required]
        public string Company {  get; set; }
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        [DataType(DataType.Date)]
        public DateTime InterviewDate { get; set; }
        public string JobProviderEmailId { get; set; }
        //public JobProvider JobProvider { get; set; }
        //public ICollection<JobApply> JobApply { get; set; }

    }
}
