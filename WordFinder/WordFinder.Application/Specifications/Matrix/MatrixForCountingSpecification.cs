using E= WordFinder.Domain.Entities;

namespace WordFinder.Application.Specifications.Matrix
{
    public class MatrixForCountingSpecification : BaseSpecification<E.Matrix>
    {
        public MatrixForCountingSpecification(MatrixSpecificationParams matrixParams)
        	: base(x => string.IsNullOrEmpty(matrixParams.Search)
        			|| x.Id!.ToString() == matrixParams.Search
        			|| x.Name!.Contains(matrixParams.Search)
        			|| x.Items!.Contains(matrixParams.Search)
        		)
        { }

    }
}