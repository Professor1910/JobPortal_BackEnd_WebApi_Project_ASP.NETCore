namespace JobPortalApplication.Models.Repository
{
    public interface IDataJobProvider<JobProvider>
    {
        void Register(JobProvider jobProvider);
        JobProvider Login(string emailId, string password);
        void ForgotPassword(string emailId, string password);
        IEnumerable<JobSeeker> GetApplicationByProvider(string provider);
    }
}
