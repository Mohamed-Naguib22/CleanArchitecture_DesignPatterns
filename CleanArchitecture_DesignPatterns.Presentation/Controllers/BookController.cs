using CleanArchitecture_DesignPatterns.Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture_DesignPatterns.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
