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

        if(item is null)
            return NotFound();

        return item.AsDto();
    }
}