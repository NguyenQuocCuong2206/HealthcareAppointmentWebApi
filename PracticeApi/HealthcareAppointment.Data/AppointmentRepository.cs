using HealthcareAppointment.Data.Heplers;
using HealthcareAppointment.Models;
using HealthcareAppointment.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using PraticeWebApi1.Data;
using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public readonly HealthcareDbContext context;

        public AppointmentRepository(HealthcareDbContext context)
        {
            this.context = context;
        }
        public async Task Add(Appointments appointment)
        {
            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
        }

        public async Task Cancel(Guid id)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.Status = EnumStatus.Cancelled;
                context.Appointments.Update(appointment);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            if(context.Appointments.Find(id) != null)
            {
                context.Remove(context.Appointments.Find(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<AppointmentDTO>> GetAll()
        {
            var appoinments =  await context.Appointments.ToListAsync();
            return appoinments.Select(a => a.ToAppoinmentDTO()).ToList();
        }

        public async Task<List<AppointmentDTO>> GetByDoctorId(Guid id, QueryAppoinment queryAppoinment)
        {
            var appointment = context.Appointments.Where(a => a.DoctorId.Equals(id));
            if (!string.IsNullOrEmpty(queryAppoinment.Date))
            {
                appointment = appointment.Where(a => a.Date.Equals(DateTime.Parse(queryAppoinment.Date)));
            }
            if (!string.IsNullOrEmpty(queryAppoinment.Status))
            {
                appointment = appointment.Where(a => a.Status == (EnumStatus)Enum.Parse(typeof(EnumStatus),queryAppoinment.Status));
            }

            var skipNumber = (queryAppoinment.PageNumber - 1 ) * queryAppoinment.PageSize;
            return await appointment.Skip(skipNumber).Take(queryAppoinment.PageSize).Select(a => a.ToAppoinmentDTO()).ToListAsync();
        }

        public async Task<Appointments?> GetById(Guid id)
        {
            var appointment = await context.Appointments.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }

        public async Task Update(Appointments appointment)
        {
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
        }
    }
}
