using Grpc.Net.Client;
using gRPC;

namespace gRPC;
public static class Class1
{
    public static async Task<PingResponse> PingServerAsync()
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:9090");
        var client = new Ping.PingClient(channel);
        var reply = await client.pingAsync(new PingRequest { DateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() });
        return reply;
    } 
}