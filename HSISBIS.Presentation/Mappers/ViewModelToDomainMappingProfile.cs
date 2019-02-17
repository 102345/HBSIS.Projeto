using AutoMapper;
using HBSIS.Domain.Entities;
using HBSIS.Presentation.ViewModels;

namespace HBSIS.Presentation.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {


        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Livro, LivroViewModel>();
            
        }


       
    }
}