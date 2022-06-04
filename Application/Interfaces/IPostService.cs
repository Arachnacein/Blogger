using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAllPosts();
        PostDTO GetPostById(int id);
        PostDTO AddNewPost(CreatePostDTO newpost);
        void UpdatePost(UpdatePostDTO updatepost);
        void DeletePost(int id);
        
    }
}
