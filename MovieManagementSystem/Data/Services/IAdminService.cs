using System.Collections.Generic;
using MovieManagementSystem.Models;

namespace MovieManagementSystem.Data.Services
{
    public interface IAdminService
    {
        Admin GetAdminByName(string name);
        bool VerifyAdminCredentials(string name, string password);
    }
}