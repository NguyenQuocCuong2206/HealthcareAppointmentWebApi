using HealthcareAppointment.Data;
using HealthcareAppointment.Data.Heplers;
using HealthcareAppointment.Models.DTOs;
using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository) 
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task Add(Appointments appointments)
        {
            await _appointmentRepository.Add(appointments);
        }

        public async Task Cancel(Guid id)
        {
           await _appointmentRepository.Cancel(id);
        }

        public async Task Delete(Guid id)
        {
            await _appointmentRepository.Delete(id);
        }

        public async Task<List<AppointmentDTO>> GetAll()
        {
            return await _appointmentRepository.GetAll();
        }

        public Task<List<AppointmentDTO>> GetByDoctorId(Guid id, QueryAppoinment queryAppoinment)
        {
            return _appointmentRepository.GetByDoctorId(id, queryAppoinment);
        }

        public async Task<Appointments> GetById(Guid id)
        {
            return await _appointmentRepository.GetById(id);
        }

        public async Task Update(Appointments appointments)
        {
            await _appointmentRepository.Update(appointments);
        }
    }
}
