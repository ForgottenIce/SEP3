using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces; 

public interface ILoginService {
	Task<Employee> ValidateEmployeeAsync(EmployeeLoginDto dto);
	Task RegisterEmployee(EmployeeCreationDto dto);
}