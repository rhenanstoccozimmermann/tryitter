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
        public string Image {get; set;}
        // public List<Post> Posts { get; set; } = default!;
        [MaxLength(300, ErrorMessage="Número máximo atingido")]
        public string PostText {get; set;}
    }
}
