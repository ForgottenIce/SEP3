package groupid.sep3java.gRPCFactory;

import groupid.sep3java.models.*;
import grpc.WarehouseProduct.*;

import java.util.List;

public class GRPCWarehouseProductFactory {

	private GRPCWarehouseProductFactory() {
	}

	public static WarehouseProduct create(CreateWarehouseProductRequest request,
			Product product, Warehouse warehouse) {
		WarehouseProduct newWarehouseProduct = new WarehouseProduct(product,
				warehouse, request.getQuantity(), request.getMinimumQuantity(),
				request.getWarehousePosition());
		return newWarehouseProduct;
	}

	public static WarehouseProductResponse createWarehouseProductResponse(
			WarehouseProduct warehouseProduct) {
		Product product = warehouseProduct.getProductId();
		Warehouse warehouse = warehouseProduct.getWarehouseId();
		WarehouseProductResponse warehouseProductResponse = WarehouseProductResponse.newBuilder()
				.setProductId(product.getId()).setWarehouseId(warehouse.getId())
				.setMinimumQuantity(warehouseProduct.getMinimumQuantity())
				.setWarehousePosition(warehouseProduct.getWarehousePosition()).build();

		return warehouseProductResponse;
	}

	public static GetWarehouseProductsResponse createGetWarehouseProductsResponse(
			List<WarehouseProduct> warehouseProducts) {
		GetWarehouseProductsResponse.Builder builder = GetWarehouseProductsResponse.newBuilder();
		for (WarehouseProduct warehouseProduct : warehouseProducts) {
			builder.addWarehouseProducts(
					createWarehouseProductResponse(warehouseProduct));
		}
		GetWarehouseProductsResponse getWarehouseProductsResponse = builder.build();
		return getWarehouseProductsResponse;
	}

}




