using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllPatients();
        Task<List<Users>> GetAllDoctors();
        Task<Users> GetById(Guid id);
        Task Add(Users user);
        Task Update(Users user);
        
        Task Delete(Guid id);
    }
}
