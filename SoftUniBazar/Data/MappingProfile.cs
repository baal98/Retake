using AutoMapper;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;

namespace SoftUniBazar.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ad, AdViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner.UserName));

            CreateMap<Ad, AdAddEditViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<AdAddEditViewModel, Ad>()
                .ForMember(dest => dest.OwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.Owner, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Ad, AdListingViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner.UserName));

            CreateMap<Category, CategoryDropdownViewModel>();
        }
    }
}