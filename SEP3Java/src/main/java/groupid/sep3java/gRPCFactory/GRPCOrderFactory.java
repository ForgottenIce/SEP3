package groupid.sep3java.gRPCFactory;

import groupid.sep3java.models.Customer;
import groupid.sep3java.models.Order;
import grpc.Order.*;

import java.util.Date;
import java.util.List;

public class GRPCOrderFactory {
	private GRPCOrderFactory() {
	}

	public static Order create(Customer customer,CreateOrderRequest request){
		Order order = new Order(customer,new Date(request.getDateTimeOrdered()),
				request.getIsPacked(), new Date(request.getDateTimeSent()));
		return order;
	}

	public static OrderResponse createOrderResponse(Order order) {
		Customer customer = order.getCustomer();
		OrderResponse orderResponse = OrderResponse.newBuilder()
				.setId(order.getId()).setCustomerId(customer.getId())
				.setFullname(customer.getFullName()).setPhoneNo(customer.getPhoneNo())
				.setAddress(customer.getAddress()).setMail(customer.getMail())
				.setDateTimeOrdered(order.getDateTimeOrdered().getTime())
				.setIsPacked(order.isPacked())
				.setDateTimeSent(order.getDateTimeSent().getTime()).build();
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
