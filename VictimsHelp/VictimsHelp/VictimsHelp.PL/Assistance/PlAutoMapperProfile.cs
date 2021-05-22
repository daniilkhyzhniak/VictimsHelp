using AutoMapper;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Account;

namespace VictimsHelp.PL.Assistance
{
    public class PlAutoMapperProfile : Profile
    {
        public PlAutoMapperProfile()
        {
            CreateMap<RegisterViewModel, UserModel>();

            CreateMap<LoginViewModel, UserModel>();

            CreateMap<UserModel, ProfileViewModel>();
        }
    }
}
