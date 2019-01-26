using System.Linq;
using System.Threading.Tasks;
using Entity.Context;
using Microsoft.AspNetCore.Identity;

namespace Domain.AppUser.Service
{
    public class AplicationUserService : IAplicationUserService
    {
        public AplicationUserService()
        {
        }
        public bool GetAuthentication(string user, string password)
        {
            return true;
        }
    }
}