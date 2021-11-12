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
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
        return items;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
    {
        var item = await repository.GetItemAsync(id);

        if (item is null)
            return NotFound();

        return item.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto createItemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = createItemDto.Name,
            Price = createItemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };

        await repository.CreatedItemAsync(item);
        return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
    {
        var existItem = await repository.GetItemAsync(id);

        if (existItem is null)
            return NotFound();

        Item updatedItem = existItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };

        await repository.UpdateItemAsync(updatedItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
        var existItem = await repository.GetItemAsync(id);

        if (existItem is null)
            return NotFound();        

        await repository.DeleteItemAsync(id);

        return NoContent();
    }
}