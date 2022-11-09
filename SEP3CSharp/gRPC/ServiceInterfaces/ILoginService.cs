using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces; 

public interface ILoginService {
	Task<User> ValidateUserAsync(UserLoginDto dto);
	Task RegisterUser(UserCreationDto dto);
}