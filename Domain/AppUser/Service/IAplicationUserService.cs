using System.Threading.Tasks;

namespace Domain.AppUser.Service
{
    public interface IAplicationUserService
    {
        bool GetAuthentication(string user, string password);
    }
}