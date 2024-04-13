using JobPortalApplication.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Models.DataManager
{
    public class JobManager : IDataJob<Jobs>
    {
        ProjectContext _db;
        public JobManager(ProjectContext db)
        {
            _db = db;
        }
        public void CreateJob(Jobs job,string provideremail)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job), "Job object cannot be null.");
            }
            var provider = _db.tblJobProviders.FirstOrDefault(p => p.EmailId == provideremail);
            if (provider == null)
            {
                throw new InvalidOperationException("Job provider not found.");
            }
            job.JobProviderEmailId = provider.EmailId;
            _db.tblJob.Add(job);
            _db.SaveChanges();
        }
        public Jobs GetJob(int jobId, string providerEmail)
        {
            return _db.tblJob.FirstOrDefault(j => j.JobId == jobId && j.JobProviderEmailId == providerEmail);
        }
        public void UpdateJob(Jobs job, string providerEmail)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job), "Job object cannot be null.");
            }
            var existingJob = _db.tblJob.FirstOrDefault(j => j.JobId == job.JobId && j.JobProviderEmailId == providerEmail);
            if (existingJob == null)
            {
                throw new InvalidOperationException("Job not found or unauthorized to update.");
            }
            existingJob.JobTitle = job.JobTitle;
            existingJob.JobDescription = job.JobDescription;
            existingJob.Deadline = job.Deadline;
            _db.SaveChanges();
        }
        public void DeleteJob(int jobId, string providerEmail)
        {
            var jobToDelete = _db.tblJob.FirstOrDefault(j => j.JobId == jobId && j.JobProviderEmailId == providerEmail);
            if (jobToDelete == null)
            {
                throw new InvalidOperationException("Job not found or unauthorized to delete.");
            }

            _db.tblJob.Remove(jobToDelete);
            _db.SaveChanges();
        }
        public IEnumerable<Jobs> GetAllJobs()
        {
            return _db.tblJob.ToList();
        }
        public IEnumerable<Jobs> GetJobsByProviderEmail(string provideremail)
        {
            var provider = _db.tblJobProviders.FirstOrDefault(p => p.EmailId == provideremail);
            if (provider != null)
            {
                return _db.tblJob.Where(j => j.JobProviderEmailId == provider.EmailId).ToList();
            }
            else
            {
                return Enumerable.Empty<Jobs>();
            }
        }
    }
}
