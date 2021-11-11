using Catalog.Entities;

namespace Catalog.Repository;
public interface IInItemsRepository
{
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
}