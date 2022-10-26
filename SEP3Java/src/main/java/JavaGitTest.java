import io.grpc.Server;
import io.grpc.ServerBuilder;

public class JavaGitTest
{
  public static void main(String[] args) throws Exception {
    Server server = ServerBuilder.forPort(9090)
        .addService(new PingServiceImpl()).build();
    server.start();
    server.awaitTermination();
  }
}
