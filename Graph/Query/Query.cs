using MarketGraphQL.Abstraction;
using MarketGraphQL.Dto;
using MarketGraphQL.Repository;

namespace MarketGraphQL.Graph.Query
{
    public class Query(IProductRepository productRepository)
    {
        public IEnumerable<ProductDto> GetProducts() => productRepository.GetAllProducts();
        public IEnumerable<ProductGroupDto> GetProductGroups([Service] ProductGroupRepository groupRepository) => groupRepository.GetAllProductsGroup();
        public IEnumerable<StorageDto> GetStorages([Service] StorageRepository storageRepository) => storageRepository.GetAllStorage();
    }
}
