using System.Threading.Tasks;
using SMB.Infrastructure.Dto;

namespace SMB.Infrastructure.Services
{
    public interface IAuthenticateService
    {
        Task<AuthenticateResponse> Authenticate(UserCredentialsDto request);
    }
}