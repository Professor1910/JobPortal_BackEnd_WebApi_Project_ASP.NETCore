namespace JobPortalApplication.Models.Repository
{
    public interface IDataJob<Jobs>
    {
        void CreateJob(Jobs job,string proivderemail);
        Jobs GetJob(int jobId, string providerEmail);
        void UpdateJob(Jobs job,string providerEmail);
        void DeleteJob(int jobId,string providerEmail);
        IEnumerable<Jobs> GetAllJobs();
        IEnumerable<Jobs> GetJobsByProviderEmail(string provideremail);
    }
}
