using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiVersion("1.0")]
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
            return Ok(posts);
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


        [SwaggerOperation(Summary = "Wyszukiwanie po frazie")]
        [HttpGet("Search/title")]
        public IActionResult Get(string phrase)
        {
            if (phrase != null)
            {
                var list = _postService.GetAllPosts().Where(x => x.Title.Contains(phrase));
                return Ok(list);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary ="Wyświetla post o 1 id większy niż wskazany")]
        [HttpGet("Search/{id}")]
        public IActionResult Get1(int id)
        {




            var item = _postService.GetPostById(id + 1);
            return Ok(item);

        }

    }
}
