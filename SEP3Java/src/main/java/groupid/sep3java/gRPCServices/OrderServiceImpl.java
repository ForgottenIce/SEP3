package groupid.sep3java.gRPCServices;

import groupid.sep3java.exceptions.NotFoundException;
import groupid.sep3java.gRPCFactory.GRPCOrderFactory;
import groupid.sep3java.models.Customer;
import groupid.sep3java.models.Order;
import groupid.sep3java.repositories.CustomerRepository;
import groupid.sep3java.repositories.OrderRepository;
import grpc.Order.*;
import grpc.OrderGrpcServiceGrpc.*;
import io.grpc.Metadata;
import io.grpc.Status;
import io.grpc.protobuf.ProtoUtils;
import io.grpc.reflection.v1alpha.ErrorResponse;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;

import java.util.List;

@GrpcService
public class OrderServiceImpl extends OrderGrpcServiceImplBase {
	private final CustomerRepository customerRepository;
	private final OrderRepository orderRepository;

	public OrderServiceImpl(CustomerRepository customerRepository,
			OrderRepository orderRepository) {
		this.customerRepository = customerRepository;
		this.orderRepository = orderRepository;
	}

	@Override public void createOrder(CreateOrderRequest request,
			StreamObserver<OrderResponse> responseObserver) {
		try {
			Customer customer = customerRepository.findById(request.getCustomerId()).orElseThrow(() -> new NotFoundException("Customer with id:" + request.getCustomerId() + "was not found"));
			Order orderToCreate = GRPCOrderFactory.create(customer,request);
			Order order = orderRepository.save(orderToCreate);

			OrderResponse response = GRPCOrderFactory.createOrderResponse(order);
			responseObserver.onNext(response);
			responseObserver.onCompleted();
		}
		catch (NotFoundException e) {
			Metadata.Key<ErrorResponse> errorResponseKey = ProtoUtils.keyForProto(ErrorResponse.getDefaultInstance());
			ErrorResponse errorResponse = ErrorResponse.newBuilder().setErrorMessage(e.getMessage()).build();
			Metadata metadata = new Metadata();
			metadata.put(errorResponseKey, errorResponse);
			responseObserver.onError(Status.NOT_FOUND.withDescription("Customer was not found")
					.asRuntimeException(metadata));
		}
	}

	@Override public void getOrder(GetOrderRequest request,
			StreamObserver<OrderResponse> responseObserver) {
		try {
			Order order = orderRepository.findById(request.getId()).orElseThrow(() -> new NotFoundException("Customer with id:" + request.getId() + "was not found"));
			OrderResponse response = GRPCOrderFactory.createOrderResponse(order);
			responseObserver.onNext(response);
			responseObserver.onCompleted();
		}
		catch (NotFoundException e) {
			Metadata.Key<ErrorResponse> errorResponseKey = ProtoUtils.keyForProto(ErrorResponse.getDefaultInstance());
			ErrorResponse errorResponse = ErrorResponse.newBuilder().setErrorMessage(e.getMessage()).build();
			Metadata metadata = new Metadata();
			metadata.put(errorResponseKey, errorResponse);
			responseObserver.onError(Status.NOT_FOUND.withDescription("Order was not found")
					.asRuntimeException(metadata));
		}
	}

	@Override public void getOrders(GetOrdersRequest request,
			StreamObserver<GetOrdersResponse> responseObserver) {
		List<Order> orders = orderRepository.findAll();

		GetOrdersResponse response = GRPCOrderFactory.createGetOrdersResponse(orders);
		responseObserver.onNext(response);
		responseObserver.onCompleted();
	}
}
