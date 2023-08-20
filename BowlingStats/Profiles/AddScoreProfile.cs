using AutoMapper;
using BowlingStats.Models;
using Entities;

namespace BowlingStats.Profiles
{
    public class AddScoreProfile : Profile
    {
        public AddScoreProfile() 
        {
            CreateMap<Score, AddScoreViewModel>().ReverseMap();
        }
    }
}
