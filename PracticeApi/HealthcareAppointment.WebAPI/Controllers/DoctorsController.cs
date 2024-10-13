using HealthcareAppointment.Business;
using HealthcareAppointment.Models.DTOs;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraticeWebApi1.Models;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUserService _userService;

        public DoctorsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var patients = await _userService.GetAllDoctors();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(UserDTO userDTO)
        {
            Users user = Mapper.DoctorToUserModel(userDTO);
            await _userService.Add(user);
            return CreatedAtAction(nameof(GetDoctor), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, UserDTO userDTO)
        {
            if(_userService.GetById(id).Result.Role == EnumRole.Patient)
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
            if (_userService.GetById(id).Result.Role == EnumRole.Patient)
            {
                return NotFound();
            }
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
