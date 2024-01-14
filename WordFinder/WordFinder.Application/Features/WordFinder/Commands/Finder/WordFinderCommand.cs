using MediatR;

namespace WordFinder.Application.Features.WordFinder.Commands.Finder
{
    public class WordFinderCommand : IRequest<IEnumerable<string>>
    {
        public int MatrixId { get; set; }
        public int? Top { get; set; } = 10;
        public IEnumerable<string> NamesToFind { get; set; }
    }
}