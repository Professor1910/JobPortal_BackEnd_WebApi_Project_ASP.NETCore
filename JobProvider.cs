using System.ComponentModel.DataAnnotations;

namespace JobPortalApplication.Models
{
    public class JobProvider
    {
        [Key]
        public string EmailId { get; set; }
        [Required]
        public string Password {  get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        //public ICollection<Jobs> Jobs { get; set; }
        //public string? CurrentPassword {  get; set; }
        //public string? NewPassword {  get; set; }
    }
}
