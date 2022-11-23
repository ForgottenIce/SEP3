using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceImplementations; 

public class LoginService : ILoginService {
	public Task<Employee> ValidateEmployeeAsync(EmployeeLoginDto dto) {
		throw new NotImplementedException();
	}

	public Task RegisterEmployee(EmployeeCreationDto dto) {
		throw new NotImplementedException();
	}
}