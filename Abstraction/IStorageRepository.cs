using MarketGraphQL.Dto;

namespace MarketGraphQL.Abstraction
{
    public interface IStorageRepository
    {
        IEnumerable<StorageDto> GetAllStorage();
        int AddStorage(StorageDto storageDto);
        void DeleteStorage(int id);
    }
}
