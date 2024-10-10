using Microsoft.AspNetCore.Mvc;
using MarketGraphQL.Dto;
using MarketGraphQL.Models;

namespace MarketGraphQL.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}
