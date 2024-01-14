using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WordFinder.Application.Contracts.Persistence;
using Entitites = WordFinder.Domain.Entities;

namespace WordFinder.Application.Features.Matrix.Commands.CreateMatrix
{
    public class CreateMatrixCommandHandler : IRequestHandler<CreateMatrixCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMatrixCommandHandler> _logger;
        public CreateMatrixCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,  ILogger<CreateMatrixCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateMatrixCommand request, CancellationToken cancellationToken)
        {
            var MatrixEntity = _mapper.Map<Entitites.Matrix>(request);

            _unitOfWork.Repository<Entitites.Matrix>().AddEntity(MatrixEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new Exception($"Matrix can't be added");
       
            _logger.LogInformation($"{MatrixEntity.Id} succesfully created");

            return MatrixEntity.Id;
        }
    }
}