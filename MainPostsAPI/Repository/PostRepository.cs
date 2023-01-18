using AutoMapper;
using MainPostsAPI.Data.ValueObjects;
using MainPostsAPI.Models;
using MainPostsAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace MainPostsAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlContext _context;
        private IMapper _mapper;

        public PostRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostVO>> FindAllPosts()
        {

            IEnumerable<Post> posts = await _context.Posts.Where(p => p.IsAProject == false).OrderByDescending(x => x.Id).ToListAsync();
            
            return _mapper.Map<IEnumerable<PostVO>>(posts);
        }

        public async Task<IEnumerable<PostVO>> FindAllProjects()
        {
            List<Post> posts = await _context.Posts.Where(p => p.IsAProject == true).ToListAsync();

            return _mapper.Map<List<PostVO>>(posts);
        }

        public async Task<PostVO> FindPostById(long id)
        {
            Post post = await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<PostVO>(post);
        }

        public async Task<IEnumerable<PostItemVO>> FindPostItens(long id)
        {
            IEnumerable<PostItem> itens = await _context.PostItems.Where(p => p.PostId == id).ToListAsync();

            return _mapper.Map<List<PostItemVO>>(itens);
        }

        public async Task<PostVO> CreateNewPost(PostVO vo)
        {
            Post post = _mapper.Map<Post>(vo);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostVO>(post);
        }

        public async Task<PostVO> UpdatePost(PostVO vo)
        {
            Post post = _mapper.Map<Post>(vo);
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostVO>(post);
        }

        public async Task<bool> DeletePost(long id)
        {
            try
            {
                Post post = await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (post.Id <= 0) return false;
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
