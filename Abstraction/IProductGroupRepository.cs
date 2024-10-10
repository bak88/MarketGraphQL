using MarketGraphQL.Dto;
using MarketGraphQL.Models;

namespace MarketGraphQL.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductsGroup();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroup(int id);
    }
}
