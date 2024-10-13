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
    public class UserRepository : IUserRepository
    {
        private readonly HealthcareDbContext context;
        public UserRepository(HealthcareDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Users user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null) 
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Users>> GetAllDoctors()
        {
            return await context.Users.Where(u => u.Role == EnumRole.Doctor).ToListAsync();
        }

        public async Task<List<Users>> GetAllPatients()
        {
            return await context.Users.Where(u => u.Role == EnumRole.Patient).ToListAsync();
        }

        public async Task<Users> GetById(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task Update(Users user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
