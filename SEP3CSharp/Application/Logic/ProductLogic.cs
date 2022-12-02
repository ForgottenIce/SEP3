﻿using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;
public class ProductLogic : IProductLogic {
    private readonly IProductService productService;

    public ProductLogic(IProductService productService) {
        this.productService = productService;
    }

    public async Task<Product> CreateProductAsync(ProductCreationDto dto) {
        Product product = await productService.CreateProductAsync(dto);
        return product;
    }

    public async Task<Product> GetProductByIdAsync(long id) {
        Product product = await productService.GetProductByIdAsync(id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync() {
        IEnumerable<Product> products = await productService.GetProductsAsync();
        return products;
    }
}
