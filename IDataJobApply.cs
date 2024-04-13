namespace JobPortalApplication.Models.Repository
{
    public interface IDataJobApply<JobApply>
    {
        //bool Add(JobApply jobApply);
        bool Add(JobApply jobApply,string jobTitle,string Companyname);
    }
}
