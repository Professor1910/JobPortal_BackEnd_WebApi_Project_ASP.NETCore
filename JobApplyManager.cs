using JobPortalApplication.Models.Repository;

namespace JobPortalApplication.Models.DataManager
{
    public class JobApplyManager : IDataJobApply<JobApply>
    {
        ProjectContext _db;
        public JobApplyManager(ProjectContext db)
        {
            _db = db;
        }
        //public bool Add(JobApply jobApply)
        //{
        //    try
        //    {
        //        _db.tblJobApply.Add(jobApply);
        //        _db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public bool Add(JobApply jobApply, string jobTitle, string Companyname)
        {
            try
            {
                string titlenormalized = jobTitle.Replace(" ", "").ToLower();
                string companynamenormalized = Companyname.Replace(" ", "").ToLower();
                var job = _db.tblJob.FirstOrDefault(j => j.JobTitle.Replace(" ", "").ToLower() == titlenormalized && j.Company.Replace(" ", "").ToLower() == companynamenormalized);
                if (job != null)
                {
                    var existingApplication = _db.tblJobApply.FirstOrDefault(a =>
                        a.JobId == job.JobId &&
                        a.JobSeekerEmailId == jobApply.JobSeekerEmailId);
                    if (existingApplication != null)
                    {
                        return false;
                    }
                    jobApply.JobId = job.JobId;
                    _db.tblJobApply.Add(jobApply);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
