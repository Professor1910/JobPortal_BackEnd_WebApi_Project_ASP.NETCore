using JobPortalApplication.Models;
using JobPortalApplication.Models.DataManager;
using JobPortalApplication.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProviderController : ControllerBase
    {
        IDataJobProvider<JobProvider> _repository;
        public JobProviderController(IDataJobProvider<JobProvider> repository)
        {
            _repository = repository;
        }
        [HttpPost("register")]
        public IActionResult Register(JobProvider jobProvider)
        {
            try
            {
                _repository.Register(jobProvider);
                return Ok("Job provider registered successfully!");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(string emailId, string password)
        {
            try
            {
                var jobProvider = _repository.Login(emailId, password);
                return Ok(jobProvider);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("forgotpassword")]
        public IActionResult ForgotPassword(string email, string newPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
                {
                    return BadRequest("Email and new password are required.");
                }
                _repository.ForgotPassword(email, newPassword);
                return Ok("Password reset successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        public IActionResult GetApplicationByProvider(string provider)
        {
            try
            {
                IEnumerable<JobSeeker> jobSeekers = _repository.GetApplicationByProvider(provider);
                return Ok(jobSeekers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

