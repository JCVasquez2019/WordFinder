using FluentValidation;

namespace WordFinder.Application.Features.Matrix.Commands.CreateMatrix
{
    public class CreateMatrixCommandValidator : AbstractValidator<CreateMatrixCommand>
    {
        private bool ValidateItemsCount(IEnumerable<string> array)
        {
            return array != null && array.Count() > 1 && array.Count() < 65;
        }
        private bool ValidateItemsSize(IEnumerable<string> array)
        {
            return array != null && array.All(item => item.Length > 0 && item.Length < 64);
        }
        private bool ValidateSameLengthForAllItems(IEnumerable<string> array)
        {
            return array != null && array.All(item => item.Length == array.First().Length);
        }
        public CreateMatrixCommandValidator()
        {
            RuleFor(x => x.Items)
             .NotNull();
              
            RuleFor(x => x.Items)
             .Must(ValidateSameLengthForAllItems)
             .WithMessage("The Items must have the same size.");

            RuleFor(x => x.Items)
             .Must(ValidateItemsCount)
             .Must(ValidateItemsSize)
             .WithMessage("The size of the matrix must be greater than 1x1 and must not exceed 64x64.");

        
        }
    }
}