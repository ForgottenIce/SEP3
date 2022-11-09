using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations; 

public class LoginService : ILoginService {
	public Task<User> ValidateUserAsync(UserLoginDto dto) {
		throw new NotImplementedException();
	}

	public Task RegisterUser(UserCreationDto dto) {
		throw new NotImplementedException();
	}
}