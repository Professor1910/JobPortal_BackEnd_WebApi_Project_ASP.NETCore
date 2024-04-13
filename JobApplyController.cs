using JobPortalApplication.Models.Repository;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortalApplication.Models.DataManager;

namespace JobPortalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplyController : ControllerBase
    {
        IDataJobApply<JobApply> _repository;
        public JobApplyController(IDataJobApply<JobApply> repository)
        {
            _repository = repository;
        }
        [HttpPost("apply")]
        public IActionResult Add(JobApply jobApply,string jobTitle,string Companyname)
        {
            try
            {
                bool success = _repository.Add(jobApply,jobTitle,Companyname);
                if (success)
                {
                    return Ok("Job application submitted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to submit job application.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
