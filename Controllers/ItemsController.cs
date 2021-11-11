using Microsoft.AspNetCore.Mvc;
using Catalog.Repository;
using Catalog.Entities;

namespace Catalog.Controllers;
[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly InMemItemsRepository inMemItemsRepository;

    public ItemsController()
    {
        inMemItemsRepository = new InMemItemsRepository();
    }

    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
        var items = inMemItemsRepository.GetItems();
        return items;
    }

    [HttpGet("{id}")]
    public Item GetItem(Guid id)
    {
        var item = inMemItemsRepository.GetItem(id);
        return item;
    }
}