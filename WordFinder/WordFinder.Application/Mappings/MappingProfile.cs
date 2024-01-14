using AutoMapper;
using WordFinder.Application.Features.Matrix.Commands.CreateMatrix;
using WordFinder.Application.Features.Matrix.Queries.Vms;
using WordFinder.Application.Features.WordFinder.Commands.Finder;
using WordFinder.Domain.Entities;

namespace WordFinder.Application.Mappings
{
    public class MappingProfile : Profile
    {
        private IEnumerable<string> GetItems(string? values)
        {
            return values!.Split(',');
        }
        public MappingProfile()
        {
            CreateMap<CreateMatrixCommand, Matrix>().ForMember(u => u.Items, m => m.MapFrom(u => string.Join(",", u.Items)));
            CreateMap<Matrix, MatrixCommand>().ForMember(u => u.Items, m => m.MapFrom(u => GetItems(u.Items)));
            CreateMap<Matrix, MatrixVm>();
        }
    }
}