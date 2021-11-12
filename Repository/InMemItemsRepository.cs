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

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await Task.FromResult(items);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
        var item = items.Where(item => item.Id == id).SingleOrDefault<Item>();
        return await Task.FromResult(item);
    }

    public async Task CreatedItemAsync(Item item)
    {
        items.Add(item);
        await Task.CompletedTask;
    }

    public async Task UpdateItemAsync(Item item)
    {
        var index = items.FindIndex(value => value.Id == item.Id);
        items[index] = item;
        await Task.CompletedTask;
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var index = items.FindIndex(value => value.Id == id);
        items.RemoveAt(index);
        await Task.CompletedTask;
    }
}