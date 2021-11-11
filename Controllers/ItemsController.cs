using Microsoft.AspNetCore.Mvc;
using Catalog.Repository;
using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Controllers;
[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly IInItemsRepository repository;

    public ItemsController(IInItemsRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        var items = repository.GetItems().Select(item => item.AsDto());
        return items;
    }

    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
        var item = repository.GetItem(id);

        if (item is null)
            return NotFound();

        return item.AsDto();
    }

    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = createItemDto.Name,
            Price = createItemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };

        repository.CreatedItem(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
        var existItem = repository.GetItem(id);

        if (existItem is null)
            return NotFound();

        Item updatedItem = existItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };

        repository.UpdateItem(updatedItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
        var existItem = repository.GetItem(id);

        if (existItem is null)
            return NotFound();        

        repository.DeleteItem(id);

        return NoContent();
    }
}