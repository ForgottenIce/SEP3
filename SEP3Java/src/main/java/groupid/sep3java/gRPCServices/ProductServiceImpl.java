package groupid.sep3java.gRPCServices;

import groupid.sep3java.gRPCFactory.GRPCProductFactory;
import groupid.sep3java.models.Product;
import groupid.sep3java.repositories.ProductRepository;
import grpc.Product.*;
import grpc.ProductGrpcServiceGrpc;
import io.grpc.stub.StreamObserver;

import java.util.List;

public class ProductServiceImpl extends
		ProductGrpcServiceGrpc.ProductGrpcServiceImplBase {
	private final ProductRepository repository;

	public ProductServiceImpl(ProductRepository repository) {
		this.repository = repository;
	}

	@Override public void createProduct(CreateProductRequest request,
			StreamObserver<ProductResponse> responseObserver) {
		Product productToSave = GRPCProductFactory.create(request);
		Product newProduct = repository.save(productToSave);

		ProductResponse response = GRPCProductFactory.createProductResponse(newProduct);
		responseObserver.onNext(response);
		responseObserver.onCompleted();
	}

	@Override public void getProduct(GetProductRequest request,
			StreamObserver<ProductResponse> responseObserver) {
		Product product = repository.findById(request.getId())
				.orElseThrow();
		ProductResponse productResponse = GRPCProductFactory.createProductResponse(product);
		responseObserver.onNext(productResponse);
		responseObserver.onCompleted();
	}

	@Override public void getProducts(GetProductsRequest request,
			StreamObserver<GetProductsResponse> responseObserver) {
		List<Product> products = repository.findAll();

		GetProductsResponse getProductsResponse = GRPCProductFactory.createGetProductsResponse(products);
		responseObserver.onNext(getProductsResponse);
		responseObserver.onCompleted();
	}
}
