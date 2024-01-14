using MediatR;

namespace WordFinder.Application.Features.Matrix.Commands.CreateMatrix
{
    public class CreateMatrixCommand : IRequest<int>
    {
        public string Name { get; set; }
        public IEnumerable<string> Items { get; set; }

    }
}