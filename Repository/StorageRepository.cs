using AutoMapper;
using MarketGraphQL.Abstraction;
using MarketGraphQL.Data;
using MarketGraphQL.Dto;
using MarketGraphQL.Models;

namespace MarketGraphQL.Repository
{
    public class StorageRepository : IStorageRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;
        public StorageRepository (StorageContext storageContext, IMapper mapper)
        {
            this.storageContext = storageContext;
            this._mapper = mapper;
        }
        public int AddStorage(StorageDto storageDto)
        {
            if (storageContext.Storages.Any(p => p.Id == storageDto.Id))
                throw new Exception("Уже есть продукт с таким Id");

            var entity = _mapper.Map<Storage>(storageDto);
            storageContext.Storages.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;
        }

        public void DeleteStorage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StorageDto> GetAllStorage()
        {
            var listDto = storageContext.Storages.Select(_mapper.Map<StorageDto>).ToList();
            return listDto;
        }
    }
}
