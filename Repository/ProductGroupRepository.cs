using AutoMapper;
using MarketGraphQL.Abstraction;
using MarketGraphQL.Data;
using MarketGraphQL.Dto;
using MarketGraphQL.Models;


namespace MarketGraphQL.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;
        public ProductGroupRepository( IMapper mapper)
        {
            // this.storageContext = storageContext;
            this._mapper = mapper;
        }
        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            using(storageContext = new())
            {
                if (storageContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
                    throw new Exception("Уже есть продукт с таким именем");

                var entity = _mapper.Map<ProductGroup>(productGroupDto);
                storageContext.ProductGroups.Add(entity);
                storageContext.SaveChanges();
                return entity.Id;
            }

            
        }

        public void DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupDto> GetAllProductsGroup()
        {
            using (storageContext = new())
            {
                var listDto = storageContext.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
                return listDto;

            }

            
        }
    }
}
