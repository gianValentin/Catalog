using Catalog.Entities;

namespace Catalog.Repository;
public interface IInItemsRepository
{
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
    void CreatedItem(Item item);
    void UpdateItem(Item item);
    void DeleteItem(Guid id);
}