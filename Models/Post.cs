using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryitter.Models
{
    // os posts precisam ter um tamanho máximo de 300
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [ForeignKey("AccountId")]
        public int? AccountId { get; set; }
        public List<Post> Posts { get; set; } = default!;
    }
}
