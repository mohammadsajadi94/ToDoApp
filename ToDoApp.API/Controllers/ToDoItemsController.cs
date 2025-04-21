using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.ToDoItems.Commands;
using ToDoApp.Application.ToDoItems.Queries;
using ToDoApp.Domain.Entities;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoItemCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetAll()
        {
            var items = await _mediator.Send(new GetAllToDoItemsQuery());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetById(Guid id)
        {
            var item = await _mediator.Send(new GetToDoItemByIdQuery { Id = id });

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateToDoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteToDoItemCommand { Id = id });

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
