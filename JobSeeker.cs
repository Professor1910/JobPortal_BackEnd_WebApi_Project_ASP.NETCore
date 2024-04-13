using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models
{
    public class JobSeeker
    {
        [Key]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [Column(TypeName="Date")]
        public DateTime DOB { get; set; }
        [Required]
        public string ResumePath { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Education { get; set; }
        [NotMapped]
        public int JobId { get; set; }
        [NotMapped]
        public string JobName { get; set; }
        //public ICollection<JobApply> JobApply { get; set; }
        //public string? CurrentPassword { get; set; }
        //public string? NewPassword { get; set; }

    }

}    
