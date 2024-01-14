using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WordFinder.Application.Contracts.Persistence;
using Entitites = WordFinder.Domain.Entities;

namespace WordFinder.Application.Features.WordFinder.Commands.Finder
{
    public class WordFinderCommandHandler : IRequestHandler<WordFinderCommand, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WordFinderCommandHandler> _logger;
        private readonly IMapper _mapper;
        public WordFinderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,  ILogger<WordFinderCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<string>> Handle(WordFinderCommand request, CancellationToken cancellationToken)
        {
            var matrixRepository = _unitOfWork.Repository<Entitites.Matrix>();
            var matrixEntity = await matrixRepository.GetByIdAsync(request.MatrixId);
            var matrixResult = _mapper.Map<MatrixCommand>(matrixEntity);

            WordFinder wordFinder = new WordFinder(matrixResult.Items);
            IEnumerable<string> result = wordFinder.Find(request.NamesToFind,request.Top?? request.Top.Value);

            _logger.LogInformation($"{result.Count()} words were found");
            return result;
        }
    }
}