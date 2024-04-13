using JobPortalApplication.Models.Repository;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortalApplication.Models.DataManager;

namespace JobPortalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IDataJob<Jobs> _repository;
        public JobController(IDataJob<Jobs> repository)
        {
            _repository = repository;
        }
        [HttpPost("create")]
        public IActionResult CreateJob(Jobs job, string providerEmail)
        {
            try
            {
                _repository.CreateJob(job, providerEmail);
                return Ok("Job created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating job: {ex.Message}");
            }
        }

        [HttpGet("{jobId}")]
        public IActionResult GetJob(int jobId, string providerEmail)
        {
            var job = _repository.GetJob(jobId, providerEmail);
            if (job != null)
            {
                return Ok(job);
            }
            return NotFound();
        }

        [HttpPut("update")]
        public IActionResult UpdateJob(Jobs job, string providerEmail)
        {
            try
            {
                _repository.UpdateJob(job, providerEmail);
                return Ok("Job updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating job: {ex.Message}");
            }
        }

        [HttpDelete("delete/{jobId}")]
        public IActionResult DeleteJob(int jobId, string providerEmail)
        {
            try
            {
                _repository.DeleteJob(jobId, providerEmail);
                return Ok("Job deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting job: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllJobs()
        {
            var jobs = _repository.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("provider/{providerEmail}")]
        public IActionResult GetJobsByProviderEmail(string providerEmail)
        {
            var jobs = _repository.GetJobsByProviderEmail(providerEmail);
            return Ok(jobs);
        }
    }
}

