using MainPostsAPI.Data.ValueObjects;
using MainPostsAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MainPostsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository _repository;
        

        public PostController(IPostRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_posts")]
        public async Task<ActionResult<IEnumerable<PostVO>>> FindAllPosts()
        {
            var posts = await _repository.FindAllPosts();
            return Ok(posts);
        }

        [HttpGet("get_projects")]
        public async Task<ActionResult<IEnumerable<PostVO>>> FindAllProjects()
        {
            var posts = await _repository.FindAllProjects();
            return Ok(posts);
        }

        [HttpGet("get_post/{id}")]
        public async Task<ActionResult<PostVO>> FindPostById(long id)
        {
            var post = await _repository.FindPostById(id);
            if(post.Id <= 0 || post == null) return NotFound();
            return Ok(post);
        }

        [HttpGet("get_post_itens/{id}")]
        public async Task<ActionResult<IEnumerable<PostItemVO>>> FindPostItens(long id)
        {
            var itens = await _repository.FindPostItens(id);

            return Ok(itens);
        }

        /*[HttpPost("new_post")]
        public async Task<ActionResult<PostVO>> CreateNewPost(PostVO vo)
        {
            if (vo == null) return BadRequest();
            var post = await _repository.CreateNewPost(vo);
            return Ok(post);
        }

        [HttpPut("update_post")]
        public async Task<ActionResult<PostVO>> UpdatePost(PostVO vo)
        {
            if (vo == null) return BadRequest();
            var post = await _repository.UpdatePost(vo);
            return Ok(post);
        }

        [HttpDelete("delete_post/{id}")]
        public async Task<ActionResult<bool>> DeletePost(long id)
        {
            var status = await _repository.DeletePost(id);
            if(!status) return BadRequest();
            return Ok(status);
        }*/
    }
}
