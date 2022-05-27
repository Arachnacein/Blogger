using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<PostDTO> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public PostDTO GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDTO>(post);
        }
    }
}
