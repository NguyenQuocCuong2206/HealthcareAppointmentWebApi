using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraticeWebApi1.Models;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentService.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment.ToAppoinmentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentAddDTO appointmentAddDto)
        {
            var appointment = Mapper.ToAppoinmentModel(appointmentAddDto);
            await _appointmentService.Add(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment.ToAppoinmentDTO());
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, AppointmentAddDTO appointmentAddDto)
        {
            var appointment = await _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            Mapper.UpdateAppoinmentModel(appointment, appointmentAddDto);
            await _appointmentService.Update(appointment);
            return Ok(appointment.ToAppoinmentDTO());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            if (await _appointmentService.GetById(id) == null)
            {
                return NotFound();
            }
            await _appointmentService.Delete(id);

            return NoContent();
        }


        [HttpPatch("{id}")]
        public async  Task<IActionResult> CancelAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            await _appointmentService.Cancel(id);
            return Ok(appointment.ToAppoinmentDTO());
        }


    }
}
