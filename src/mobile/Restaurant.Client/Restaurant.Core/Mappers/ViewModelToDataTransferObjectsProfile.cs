using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Restaurant.Abstractions.Constants;
using Restaurant.Abstractions.DataTransferObjects;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;
using Restaurant.Core.ViewModels.Food;

namespace Restaurant.Core.Mappers
{
    [ExcludeFromCodeCoverage]
    public class ViewModelToDataTransferObjectsProfile : Profile
    {
        public ViewModelToDataTransferObjectsProfile()
        {
	        CreateMap<SignUpViewModel, RegisterDto>()
		        .ForMember(x => x.Email, map => map.MapFrom(x => x.Email))
		        .ForMember(x => x.Password, map => map.MapFrom(vm => vm.Password));

			CreateMap<SignInViewModel, LoginDto>()
                .ForMember(x => x.Login, map => map.MapFrom(vm => vm.Email))
                .ForMember(x => x.Password, map => map.MapFrom(vm => vm.Password));

	        CreateMap<UserProfileDto, UserInfoViewModel>();
	        CreateMap<UserDto, UserViewModel>().ForMember(x => x.UserInfoViewModel, 
				map => map.MapFrom(x => Mapper.Map<UserInfoViewModel>(x.Profile)));

            CreateMap<FoodDto, FoodViewModel>();

        }
    }
}