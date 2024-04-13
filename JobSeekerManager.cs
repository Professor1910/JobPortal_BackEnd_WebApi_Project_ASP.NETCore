using JobPortalApplication.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Models.DataManager
{
    public class JobSeekerManager : IDataJobSeeker<JobSeeker>
    {
        ProjectContext _db;
        
        public JobSeekerManager(ProjectContext db)
        {
            _db = db;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }
        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
        public void Register(JobSeeker jobSeeker)
        {
            if (jobSeeker == null)
            {
                throw new ArgumentNullException(nameof(jobSeeker), "Job provider object cannot be null.");
            }
            if (!IsValidEmail(jobSeeker.EmailId))
            {
                throw new ArgumentException("Invalid email format.", nameof(jobSeeker.EmailId));
            }
            string hashedPassword = HashPassword(jobSeeker.Password);
            jobSeeker.Password = hashedPassword;
            _db.tblJobSeekers.Add(jobSeeker);
            _db.SaveChanges();
            Console.WriteLine("Job provider registered successfully!");
        }
        public JobSeeker Login(string emailId, string password)
        {
            var jobSeeker = _db.tblJobSeekers.FirstOrDefault(j => j.EmailId == emailId);
            if (jobSeeker == null)
            {
                throw new ArgumentException("Invalid email or password.");
            }
            if (!VerifyPassword(password, jobSeeker.Password))
            {
                throw new ArgumentException("Invalid email or password.");
            }
            return jobSeeker;
        }
        public void ForgotPassword(string emailId, string password)
        {
            var user = _db.tblJobSeekers.FirstOrDefault(u => u.EmailId == emailId);

            if (user != null)
            {
                user.Password = HashPassword(password);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }
        public void Update(JobSeeker jobSeeker)
        {
            if (jobSeeker == null)
            {
                throw new ArgumentNullException(nameof(jobSeeker), "Job seeker object cannot be null.");
            }
            var existingJobSeeker = _db.tblJobSeekers.FirstOrDefault(j => j.EmailId == jobSeeker.EmailId);
            if (existingJobSeeker == null)
            {
                throw new InvalidOperationException("Job seeker not found.");
            }
            existingJobSeeker.FirstName = jobSeeker.FirstName;
            existingJobSeeker.LastName = jobSeeker.LastName;
            existingJobSeeker.Address = jobSeeker.Address;
            existingJobSeeker.PhoneNumber = jobSeeker.PhoneNumber;
            existingJobSeeker.DOB = jobSeeker.DOB;
            existingJobSeeker.ResumePath = jobSeeker.ResumePath;
            existingJobSeeker.Experience = jobSeeker.Experience;
            existingJobSeeker.Skills = jobSeeker.Skills;
            existingJobSeeker.Education = jobSeeker.Education;
            _db.Entry(existingJobSeeker).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}

