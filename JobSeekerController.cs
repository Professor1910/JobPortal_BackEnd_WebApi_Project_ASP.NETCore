using JobPortalApplication.Models.Repository;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortalApplication.Models.DataManager;

namespace JobPortalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        IDataJobSeeker<JobSeeker> _repository;
        public JobSeekerController(IDataJobSeeker<JobSeeker> repository)
        {
            _repository = repository;
        }
        [HttpPost("register")]
        public IActionResult Register(JobSeeker jobSeeker)
        {
            try
            {
                _repository.Register(jobSeeker);
                return Ok("Job seeker registered successfully!");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while registering the job seeker.");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(string emailId, string password)
        {
            try
            {
                var jobSeeker = _repository.Login(emailId, password);
                return Ok(jobSeeker);
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
        [HttpPut("update")]
        public IActionResult UpdateJobSeeker(JobSeeker jobSeeker)
        {
            try
            {
                _repository.Update(jobSeeker);
                return Ok("Job seeker updated successfully.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the job seeker: {ex.Message}");
            }
        }
    }
}
