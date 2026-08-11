using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using HMSPracticeAPI.Models;
using HMSPracticeAPI.Services;

namespace HMSPracticeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMongoCollection<Patient> _patients;

        public PatientController(MongoDbService mongoDbService)
        {
            _patients = mongoDbService.Database.GetCollection<Patient>("Patients");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(patient.FirstName))
                {
                    return BadRequest(new { message = "First name is required" });
                }

                long count = await _patients.CountDocumentsAsync(FilterDefinition<Patient>.Empty);
                patient.PatientId = $"PAT-{(count + 1):D4}"; // e.g. PAT-0001

                patient.CreatedAt = DateTime.UtcNow;

                await _patients.InsertOneAsync(patient);

                return Ok(new { message = "Patient registered successfully", patientId = patient.PatientId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error", error = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patients.Find(_ => true).ToListAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error", error = ex.Message });
            }
        }
    }
}