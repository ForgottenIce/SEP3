using Application.LogicInterfaces;
using gRPC;
using gRPC.ServiceInterfaces;

namespace Application.Logic; 

public class PingLogic : IPingLogic {
	private IPingService _client;

	public PingLogic(IPingService client) {
		_client = client;
	}

	public async Task<PingResponse> PingAsync() {
		var reply = await _client.pingAsync();
		return reply;
	}
}