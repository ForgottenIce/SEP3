namespace gRPC.ServiceInterfaces; 

public interface IPingService {
	Task<PingResponse> pingAsync();
}