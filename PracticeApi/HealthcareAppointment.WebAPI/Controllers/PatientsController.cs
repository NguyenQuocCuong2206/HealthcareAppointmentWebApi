using HealthcareAppointment.Business;
using HealthcareAppointment.Data;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraticeWebApi1.Models;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUserService _userService;

        public PatientsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _userService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(UserDTO userDTO)
        {
            Users user = Mapper.PateintToUserModel(userDTO);
            await _userService.Add(user);
            return CreatedAtAction(nameof(GetPatient), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, UserDTO userDTO)
        {
            if (_userService.GetById(id).Result.Role == EnumRole.Doctor)
            {
                return NotFound();
            }
            Users user = Mapper.PateintToUserModel(userDTO);
            await _userService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            if (_userService.GetById(id).Result.Role == EnumRole.Doctor)
            {
                return NotFound();
            }
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
