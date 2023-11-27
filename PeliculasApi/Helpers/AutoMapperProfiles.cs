using AutoMapper;
using PeliculasApi.DTOs;
using PeliculasApi.Models;

namespace PeliculasApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroPostDTO, Genero>();
        }
    }
}
