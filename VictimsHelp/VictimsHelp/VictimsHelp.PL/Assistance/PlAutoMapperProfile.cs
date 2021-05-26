using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Account;
using VictimsHelp.PL.ViewModels.Calendar;
using VictimsHelp.PL.ViewModels.Psychologist;
using VictimsHelp.PL.ViewModels.User;

namespace VictimsHelp.PL.Assistance
{
    public class PlAutoMapperProfile : Profile
    {
        public PlAutoMapperProfile()
        {
            CreateMap<RegisterViewModel, UserModel>();

            CreateMap<LoginViewModel, UserModel>();

            CreateMap<UserModel, ProfileViewModel>()
                .ReverseMap();

            CreateMap<UserModel, UserViewModel>()
                .ReverseMap();

            CreateMap<UserModel, UserEditorViewModel>()
                .ReverseMap();

            CreateMap<UserModel, PsychologistViewModel>()
                .ReverseMap();

            CreateMap<Event, EventViewModel>()
                .ForMember(e => e.Start, opt => opt.MapFrom(e => e.Start.DateTime))
                .ForMember(e => e.End, opt => opt.MapFrom(e => e.End.DateTime));
        }
    }
}
