using E= WordFinder.Domain.Entities;

namespace WordFinder.Application.Specifications.Matrix
{
    public class MatrixSpecification : BaseSpecification<E.Matrix>
    {
        public MatrixSpecification(MatrixSpecificationParams matrixParams)
        	: base(x => string.IsNullOrEmpty(matrixParams.Search)
        			|| x.Id!.ToString() == matrixParams.Search
        			|| x.Name!.Contains(matrixParams.Search)
        			|| x.Items!.Contains(matrixParams.Search)
        		)
        {
            ApplyPaging(matrixParams.PageSize * (matrixParams.PageIndex - 1), matrixParams.PageSize);

            if (!string.IsNullOrEmpty(matrixParams.Sort))
            {
                switch (matrixParams.Sort)
                {
                    case "IdAsc":
                    	AddOrderBy(p => p.Id!);
                    	break;

                    case "IdDesc":
                    	AddOrderByDescending(p => p.Id!);
                    	break;

                    case "NameAsc":
                    	AddOrderBy(p => p.Name!);
                    	break;

                    case "NameDesc":
                    	AddOrderByDescending(p => p.Name!);
                    	break;

                    case "ItemsAsc":
                    	AddOrderBy(p => p.Items!);
                    	break;

                    case "ItemsDesc":
                    	AddOrderByDescending(p => p.Items!);
                    	break;

                    default:
                    	AddOrderBy(p => p.Name!);
                    	break;

                }
            }
        }
    }
}