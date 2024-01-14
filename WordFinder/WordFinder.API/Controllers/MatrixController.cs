using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WordFinder.Application.Features.Matrix.Commands.CreateMatrix;
using WordFinder.Application.Features.Matrix.Queries.GetMatrixById;
using WordFinder.Application.Features.Matrix.Queries.Vms;
using ValidationException = WordFinder.Application.Exceptions.ValidationException;

namespace WordFinder.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MatrixController : ControllerBase
    {
        private IMediator _mediator;
        public MatrixController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetMatrixById")]
        public async Task<ActionResult<MatrixVm>> GetMatrixById(int id)
        {
            var query = new GetMatrixByIdQuery(id);
            var queryResult = await  _mediator.Send(query);
            return Ok(queryResult);
        }

        [HttpPost(Name = "CreateMatrix")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMatrix([FromBody] CreateMatrixCommand command)
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}