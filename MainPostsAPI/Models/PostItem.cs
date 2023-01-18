using MainPostsAPI.Models.Enum;
using MainPostsAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainPostsAPI.Models
{
    public class PostItem : BaseEntity
    {
        [ForeignKey("post_id")]
        public long PostId { get; set; }
        [Column("post_type")]
        [Required]
        public ItemType PostType { get; set; }
        [Column("subtitle")]
        public string Subtitle { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("adress")]
        public string Adress { get; set; }
    }
}
