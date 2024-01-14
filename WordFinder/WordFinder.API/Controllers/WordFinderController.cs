using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WordFinder.Application.Features.WordFinder.Commands.Finder;

namespace WordFinder.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WordFinderController : ControllerBase
    {
        private IMediator _mediator;
        public WordFinderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "FindWord")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<string>> FindWord([FromBody] WordFinderCommand command)
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
