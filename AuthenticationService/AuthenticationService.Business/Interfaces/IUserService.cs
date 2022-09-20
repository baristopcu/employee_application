using System.Threading.Tasks;

namespace AuthenticationService.Business.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
    }
}

