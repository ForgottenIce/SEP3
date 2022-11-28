using gRPC.ServiceInterfaces;

namespace gRPC.ServiceImplementations; 

public class PingService : IPingService{
	private Ping.PingClient _client;

	public PingService(Ping.PingClient client) {
		_client = client;
	}

	public async Task<PingResponse> pingAsync() {
		var reply = await _client.pingAsync(new PingRequest { DateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() });
		return reply;
	}
}