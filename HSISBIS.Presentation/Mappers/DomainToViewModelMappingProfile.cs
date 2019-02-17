using HBSIS.Presentation.ViewModels;
using AutoMapper;
using HBSIS.Domain.Entities;

namespace HBSIS.Presentation.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LivroViewModel, Livro>();
        }
    }
}