using Shared.Dtos;

namespace gRPC.ServiceInterfaces; 

public interface ILoginService {
	Task<bool> ValidateUserAsync(UserLoginDto dto);
	Task RegisterUser(UserCreationDto dto);
}