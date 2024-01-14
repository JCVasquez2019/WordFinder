using AutoMapper;
using WordFinder.Application.Contracts.Persistence;
using WordFinder.Application.Features.Matrix.Queries.Vms;
using MediatR;
using E= WordFinder.Domain.Entities;

namespace WordFinder.Application.Features.Matrix.Queries.GetMatrixById
{
    public class GetMatrixByIdQueryHandler : IRequestHandler<GetMatrixByIdQuery, MatrixVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMatrixByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MatrixVm> Handle(GetMatrixByIdQuery request, CancellationToken cancellationToken)
        {
            var matrixResult = await _unitOfWork.Repository<E.Matrix>().GetByIdAsync(request._ID);
            var data = _mapper.Map<E.Matrix, MatrixVm>(matrixResult);


            return data;
        }
    }
}