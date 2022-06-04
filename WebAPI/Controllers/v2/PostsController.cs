using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v2
{


    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Pokazuje wszystkie posty")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(
                new {
                    Posts = posts, 
                    Count = posts.Count()
                });
        }

        [SwaggerOperation(Summary = "Pokazuje post o podanym id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }


        [SwaggerOperation(Summary = "Dodaje nowy post")]
        [HttpPost]
        public IActionResult Create(CreatePostDTO newpost)
        {
            var post = _postService.AddNewPost(newpost);
            return Created($"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary = "Aktualizuje post")]
        [HttpPut]
        public IActionResult Update(UpdatePostDTO updatepost)
        {
            _postService.UpdatePost(updatepost);
            return NoContent();
        }

        [SwaggerOperation(Summary ="Usuwa post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return NoContent();


        }


    }
}
