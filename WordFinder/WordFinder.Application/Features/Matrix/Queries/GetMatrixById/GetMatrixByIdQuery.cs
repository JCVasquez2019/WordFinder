using MediatR;
using WordFinder.Application.Features.Matrix.Queries.Vms;

namespace WordFinder.Application.Features.Matrix.Queries.GetMatrixById
{
    public class GetMatrixByIdQuery :  IRequest<MatrixVm>
    {
        public int _ID { get; set; }
        public GetMatrixByIdQuery(int? ID)
        {
            _ID= ID ?? throw new ArgumentNullException(nameof(ID));
        }
    }
}