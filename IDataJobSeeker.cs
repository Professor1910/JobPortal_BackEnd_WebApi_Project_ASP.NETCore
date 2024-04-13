namespace JobPortalApplication.Models.Repository
{
    public interface IDataJobSeeker<JobSeeker>
    {
        void Register(JobSeeker jobSeeker);
        JobSeeker Login(string emailId, string password);
        void ForgotPassword(string emailId, string password);
        void Update(JobSeeker jobSeeker);
    }
}
