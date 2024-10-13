using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public interface IUserService
    {
        Task<List<Users>> GetAllPatients();
        Task<List<Users>> GetAllDoctors();
        Task<Users> GetById(Guid id);
        Task Add(Users users);
        Task Update(Guid id, Users users);
        Task Delete(Guid id);
    }
}
