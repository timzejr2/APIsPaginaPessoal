using MainPostsAPI.Models;

namespace MainPostsAPI.Data.ValueObjects
{
    public class PostVO
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostImage { get; set; }
        public string PostDescription { get; set; }
        public bool IsAProject { get; set; }
        public bool PostActive { get; set; }
        public DateTime PostDate { get; set; }
        public virtual IEnumerable<PostItem> PostItens { get; set; }
    }
}
