using AutoMapper;
using System.Linq;
using VictimsHelp.BLL.Models;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.BLL.Assistance
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(r => r.Role.Name)));

            CreateMap<UserModel, User>()
                .ForMember(u => u.Password, opt => opt.MapFrom(u => BCrypt.Net.BCrypt.HashPassword(u.Password)))
                .ForMember(u => u.UserRoles, opt => opt.Ignore());

            CreateMap<Article, ArticleModel>()
                .ReverseMap();
        }
    }
}
