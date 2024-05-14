

// AdminService.cs
using System.Linq;
using MovieManagementSystem.Models;

namespace MovieManagementSystem.Data.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;

        public AdminService()
        {
            _context = new AppDbContext();
        }

        public Admin GetAdminByName(string name)
        {
            return _context.Admins.FirstOrDefault(a => a.Name == name);
        }

        public bool VerifyAdminCredentials(string name, string password)
        {
            var admin = GetAdminByName(name);
            return admin != null && admin.Password == password;
        }
    }
}
