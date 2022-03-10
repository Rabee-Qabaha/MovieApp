using AutoMapper;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.Movie;
using MovieApp.Core.DTO.Producer;
using MovieApp.Core.Models;

namespace MovieApp.EF.Profiles
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Producer Mapping 
            CreateMap<Producer, ProducerResponseDto>();
            CreateMap<ProducerRequestDto, Producer>();

            //Actor Mapping
            CreateMap<Actor, ActorResponseDto>();
            CreateMap<ActorRequestDto, Actor>();

            //Movie Mapping
            CreateMap<Movie, MovieResponseDto>();
            CreateMap<MovieRequestDto, Movie>();
        }
    }
}
