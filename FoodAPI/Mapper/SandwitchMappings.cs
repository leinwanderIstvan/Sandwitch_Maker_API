using AutoMapper;
using FoodAPI.Models;
using FoodAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Mapper
{
    public class SandwitchMappings : Profile
    {
        public SandwitchMappings()
        {
            CreateMap<Sandwich, SandwichDto>().ReverseMap();
        }
    }
}
