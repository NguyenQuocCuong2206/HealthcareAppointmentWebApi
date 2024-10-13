using HealthcareAppointment.Models.DTOs;
using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models
{
    public static class Mapper
    {
        public static Users PateintToUserModel(UserDTO userDTO)
        {
            return new Users()
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Email = userDTO.Email,
                DateOfBirth = userDTO.DateOfBirth,
                Password = userDTO.Password,
                Role = EnumRole.Patient,
                Specialization = userDTO.Specialization,
            };
        }

        public static Users DoctorToUserModel(UserDTO userDTO)
        {
            return new Users()
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Email = userDTO.Email,
                DateOfBirth = userDTO.DateOfBirth,
                Password = userDTO.Password,
                Role = EnumRole.Doctor,
                Specialization = userDTO.Specialization,
            };
        }

        public static AppointmentDTO ToAppoinmentDTO(this Appointments appointment)
        {
            return new AppointmentDTO()
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                Date = appointment.Date,
                Status = appointment.Status,
            };
        }

        public static Appointments ToAppoinmentModel(this AppointmentAddDTO appointmentAddDTO)
        {
            return new Appointments()
            {
                Id = Guid.NewGuid(),
                PatientId = appointmentAddDTO.PatientId,
                DoctorId = appointmentAddDTO.DoctorId,
                Date = appointmentAddDTO.Date,
                Status = appointmentAddDTO.Status,
            };
        }

        public static void UpdateAppoinmentModel(Appointments appointment, AppointmentAddDTO appointmentAddDTO)
        {
            appointment.PatientId = appointmentAddDTO.PatientId;
            appointment.DoctorId = appointmentAddDTO.DoctorId;
            appointment.Date = appointmentAddDTO.Date;
            appointment.Status = appointmentAddDTO.Status;
        }
    }
}
