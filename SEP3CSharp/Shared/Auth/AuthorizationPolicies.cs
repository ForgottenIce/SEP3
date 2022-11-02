using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth; 

public static class AuthorizationPolicies {
	public static void AddPolicies(IServiceCollection services) {
		services.AddAuthorizationCore(options => {
			options.AddPolicy("MustBeManager",a => 
				a.RequireAuthenticatedUser().RequireClaim("Role","Manager"));
			
			options.AddPolicy("MustBeOfWarehouseTeam",a => 
				a.RequireAuthenticatedUser().RequireClaim("Role", "Warehouse"));
			
			options.AddPolicy("MustBeCashier",a => 
				a.RequireAuthenticatedUser().RequireClaim("Role", "Cashier"));
		});
	}
}