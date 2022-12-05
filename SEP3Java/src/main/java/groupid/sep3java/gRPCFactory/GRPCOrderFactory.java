package groupid.sep3java.gRPCFactory;

import groupid.sep3java.models.Customer;
import groupid.sep3java.models.Order;
import groupid.sep3java.util.DateTimeUtil;
import grpc.Order.*;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.ZoneOffset;
import java.util.List;

public class GRPCOrderFactory {
	private GRPCOrderFactory() {
	}

	public static Order create(Customer customer,CreateOrderRequest request){
		Order order = new Order(customer, LocalDateTime.ofEpochSecond(request.getDateTimeOrdered(), 0, ZoneOffset.UTC),
			request.getIsPacked(), LocalDateTime.ofEpochSecond(request.getDateTimeSent(), 0, ZoneOffset.UTC));
		return order;
	}

	public static OrderResponse createOrderResponse(Order order) {
		Customer customer = order.getCustomer();
		long dateTimeOrdered = 0;
		long dateTimeSent = 0;
		if (order.getDateOrdered() != null && order.getTimeOrdered() != null) {
			dateTimeOrdered = LocalDateTime.of(order.getDateOrdered(), order.getTimeOrdered()).toEpochSecond(ZoneOffset.UTC);
		}
		if (order.getDateSent() != null && order.getTimeSent() != null) {
			dateTimeSent = LocalDateTime.of(order.getDateSent(), order.getTimeSent()).toEpochSecond(ZoneOffset.UTC);
		}
		OrderResponse orderResponse = OrderResponse.newBuilder()
				.setId(order.getId())
				.setCustomer(grpc.Customer.CustomerResponse.newBuilder()
						.setId(customer.getId())
						.setFullname(customer.getFullName())
						.setPhoneNo(customer.getPhoneNo())
						.setAddress(customer.getAddress())
						.setMail(customer.getMail()).build())
				.setDateTimeOrdered(dateTimeOrdered)
				.setIsPacked(order.isPacked())
				.setDateTimeSent(dateTimeSent).build();
		return orderResponse;
	}

	public static GetOrdersResponse createGetOrdersResponse(List<Order> orders) {
		GetOrdersResponse.Builder builder = GetOrdersResponse.newBuilder();
		for (Order order : orders)
		{
		    builder.addOrders(createOrderResponse(order));
		}
		GetOrdersResponse response = builder.build();
		return response;
	}
}
