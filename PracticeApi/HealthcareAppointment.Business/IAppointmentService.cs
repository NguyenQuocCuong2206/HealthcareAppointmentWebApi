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
    public interface IAppointmentService
    {
        Task<List<AppointmentDTO>> GetAll();
        Task<List<AppointmentDTO>> GetByDoctorId(Guid id, QueryAppoinment queryAppoinment);
        Task<Appointments> GetById(Guid id);
        Task Add(Appointments appointments);
        Task Update(Appointments appointments);
        Task Cancel(Guid id);
        Task Delete(Guid id);
    }
}
