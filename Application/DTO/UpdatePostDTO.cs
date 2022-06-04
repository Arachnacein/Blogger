using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UpdatePostDTO : IMap
    {
        public int Id { get; set; } //id, by móc znaleźć posta do aktualizacji 
        public string Content { get; set; } //content, bo zakąłdamy, że można aktualizować tylko treść

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDTO, Post>();
        }
    }
}
