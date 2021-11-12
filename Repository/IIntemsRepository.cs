using Catalog.Entities;

namespace Catalog.Repository;
public interface IInItemsRepository
{
    Task<Item> GetItemAsync(Guid id);
    Task<IEnumerable<Item>> GetItemsAsync();
    Task CreatedItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}