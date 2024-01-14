using MediatR;

namespace WordFinder.Application.Features.WordFinder.Commands.Finder
{
    public class MatrixCommand : IRequest<int>
    {
        public string Name { get; set; }
        public IEnumerable<string> Items { get; set; }

    }
}