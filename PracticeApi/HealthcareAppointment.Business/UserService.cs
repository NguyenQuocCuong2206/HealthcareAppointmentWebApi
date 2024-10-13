using HealthcareAppointment.Data;
using PraticeWebApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task Add(Users users)
        {
            await userRepository.Add(users);
        }

        public async Task Delete(Guid id)
        {
            await userRepository.Delete(id);
        }


        public async Task<List<Users>> GetAllDoctors()
        {
            return await userRepository.GetAllDoctors();
        }

        public async Task<List<Users>> GetAllPatients()
        {
            return await userRepository.GetAllPatients();
        }

        public async Task<Users> GetById(Guid id)
        {
           return await userRepository.GetById(id);
        }

        public async Task Update(Guid id, Users user)
        {
            var userUpdate = await userRepository.GetById(id);
            if (userUpdate != null) 
            {
                userUpdate.Name = user.Name;
                userUpdate.Email = user.Email;
                userUpdate.DateOfBirth = user.DateOfBirth;
                userUpdate.Password = user.Password;
                userUpdate.Specialization = user.Specialization;
                await userRepository.Update(userUpdate);
            } 
        }
    }
}
