using JobPortalApplication.Models.Repository;
using System.Text.RegularExpressions;

namespace JobPortalApplication.Models.DataManager
{
    public class JobProviderManager : IDataJobProvider<JobProvider>
    {
        ProjectContext _db;
        public JobProviderManager(ProjectContext db)
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
        public void Register(JobProvider jobProvider)
        {
            if (jobProvider == null)
            {
                throw new ArgumentNullException(nameof(jobProvider), "Job provider object cannot be null.");
            }
            if (!IsValidEmail(jobProvider.EmailId))
            {
                throw new ArgumentException("Invalid email format.", nameof(jobProvider.EmailId));
            }
            string hashedPassword = HashPassword(jobProvider.Password);
            jobProvider.Password = hashedPassword;
            _db.tblJobProviders.Add(jobProvider);
            _db.SaveChanges();
            Console.WriteLine("Job provider registered successfully!");
        }
        public JobProvider Login(string emailId, string password)
        {
            var jobProvider = _db.tblJobProviders.FirstOrDefault(j => j.EmailId == emailId);
            if (jobProvider == null)
            {
                throw new ArgumentException("Invalid email or password.");
            }
            if (!VerifyPassword(password, jobProvider.Password))
            {
                throw new ArgumentException("Invalid email or password.");
            }
            return jobProvider;
        }
        public void ForgotPassword(string emailId, string password)
        {
            var user = _db.tblJobProviders.FirstOrDefault(u => u.EmailId == emailId);

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
        public IEnumerable<JobSeeker> GetApplicationByProvider(string provider)
        {
            var jobSeekerList = (from Jobs in _db.tblJob
                                 join JobApply in _db.tblJobApply
                                 on Jobs.JobId equals JobApply.JobId
                                 join JobSeeker in _db.tblJobSeekers
                                 on JobApply.JobSeekerEmailId equals JobSeeker.EmailId
                                 where Jobs.JobProviderEmailId == provider
                                 select new JobSeeker
                                 {
                                     EmailId = JobSeeker.EmailId,
                                     FirstName = JobSeeker.FirstName,
                                     LastName = JobSeeker.LastName,
                                     Address = JobSeeker.Address,
                                     Education = JobSeeker.Education,
                                     PhoneNumber = JobSeeker.PhoneNumber,
                                     DOB = JobSeeker.DOB,
                                     ResumePath = JobSeeker.ResumePath,
                                     Experience = JobSeeker.Experience,
                                     Skills = JobSeeker.Skills,
                                     JobId = Jobs.JobId
                                 }
                                 ).ToList();
            return jobSeekerList;
        }
    }
}
