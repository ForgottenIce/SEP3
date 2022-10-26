using Grpc.Net.Client;
using gRPC;

namespace gRPC;
public class Class1
{
    public async Task<PingResponse> PingServerAsync()
    {
        using var channel = GrpcChannel.ForAddress("");
        var client = new Ping.PingClient(channel);
        var reply = await client.pingAsync(new PingRequest { DateTime = 2 });
        return reply;
    } 
}