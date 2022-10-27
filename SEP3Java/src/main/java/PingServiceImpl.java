
import grpc.PingGrpc;
import grpc.PingOuterClass;
import io.grpc.stub.StreamObserver;

import java.time.Instant;

public class PingServiceImpl extends PingGrpc.PingImplBase {
  @Override public void ping(PingOuterClass.PingRequest request,
      StreamObserver<PingOuterClass.PingResponse> responseObserver) {
    PingOuterClass.PingResponse response = PingOuterClass.PingResponse.newBuilder()
        .setOriginDate(request.getDateTime())
        .setReturnDate(Instant.now().toEpochMilli()).build();
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
}
