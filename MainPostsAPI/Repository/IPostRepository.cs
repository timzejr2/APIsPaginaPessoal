using MainPostsAPI.Data.ValueObjects;

namespace MainPostsAPI.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostVO>> FindAllPosts();
        Task<IEnumerable<PostVO>> FindAllProjects();
        Task<PostVO> FindPostById(long id);
        Task<IEnumerable<PostItemVO>> FindPostItens(long id);
        Task<PostVO> CreateNewPost(PostVO vo);
        Task<PostVO> UpdatePost(PostVO vo);
        Task<bool> DeletePost(long id);
        
    }
}
