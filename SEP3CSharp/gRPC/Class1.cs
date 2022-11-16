using Grpc.Net.Client;

namespace gRPC;
public static class Class1
{
    public static async Task<PingResponse> PingServerAsync()
    {
        AppContext.SetSwitch(
            "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        
        using var channel = GrpcChannel.ForAddress("http://localhost:9090");
        var client = new Ping.PingClient(channel);
        var reply = await client.pingAsync(new PingRequest { DateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() });
        return reply;
    } 
}