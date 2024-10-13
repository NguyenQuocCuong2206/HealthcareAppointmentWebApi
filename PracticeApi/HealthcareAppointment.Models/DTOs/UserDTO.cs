using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [DefaultValue("2024-10-13")]
        public DateOnly DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Specialization { get; set; }
    }
}
