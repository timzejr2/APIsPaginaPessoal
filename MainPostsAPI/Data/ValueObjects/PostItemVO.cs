using MainPostsAPI.Models.Enum;

namespace MainPostsAPI.Data.ValueObjects
{
    public class PostItemVO
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public ItemType PostType { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
