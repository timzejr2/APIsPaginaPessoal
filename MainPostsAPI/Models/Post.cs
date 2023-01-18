using MainPostsAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainPostsAPI.Models
{
    public class Post : BaseEntity
    {
        [Column("post_title")]
        [Required]
        [StringLength(50)]
        public string PostTitle { get; set; }
        [Column("post_image")]
        public string PostImage { get; set; }
        [Column("post_description")]
        [StringLength(500)]
        public string PostDescription { get; set; }
        [Column("is_a_project")]
        public bool IsAProject { get; set; }
        [Column("post_active")]
        public bool PostActive { get; set; }
        [Column("post_date")]
        public DateTime PostDate { get; set; }
        [Required]
        public virtual IEnumerable<PostItem> PostItens { get; set; }
    }
}
