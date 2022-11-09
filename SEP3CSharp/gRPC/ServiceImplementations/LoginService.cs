using gRPC.ServiceInterfaces;
using Shared.Dtos;

namespace gRPC.ServiceImplementations; 

public class LoginService : ILoginService {
	public Task<bool> ValidateUserAsync(UserLoginDto dto) {
		throw new NotImplementedException();
	}

	public Task RegisterUser(UserCreationDto dto) {
		throw new NotImplementedException();
	}
}