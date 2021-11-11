using Catalog.Entities;

namespace Catalog.Repository;


public class InMemItemsRepository : IInItemsRepository
{
    private readonly List<Item> items = new()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
        new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 14, CreatedDate = DateTimeOffset.UtcNow },
    };

    public IEnumerable<Item> GetItems()
    {
        return items;
    }

    public Item GetItem(Guid id)
    {
        return items.Where(item => item.Id == id).SingleOrDefault<Item>();
    }

    public void CreatedItem(Item item)
    {
        items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        var index = items.FindIndex(value => value.Id == item.Id);
        items[index] = item;
    }

    public void DeleteItem(Guid id)
    {
        var index = items.FindIndex(value => value.Id == id);
        items.RemoveAt(index);
    }
}