using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Entities;
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
        public PostDTO AddNewPost(CreatePostDTO newpost)
        {
            if(string.IsNullOrEmpty(newpost.Title))
            {
                throw new Exception("Post cannot have an empty Title");
            }

            var post = _mapper.Map<Post>(newpost);
            _postRepository.Add(post);
            return _mapper.Map<PostDTO>(post);

        }

        public void UpdatePost(UpdatePostDTO updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            _postRepository.Delete(_postRepository.GetById(id));
        }
    }
}
