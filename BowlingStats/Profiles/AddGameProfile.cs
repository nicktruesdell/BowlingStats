using AutoMapper;
using BowlingStats.Models;
using Entities;

namespace BowlingStats.Profiles
{
    public class AddGameProfile : Profile
    {
        public AddGameProfile() 
        { 
            CreateMap<Game, AddGameViewModel>().ReverseMap();
        }
    }
}
