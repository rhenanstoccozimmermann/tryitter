using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using System.Diagnostics.CodeAnalysis;

namespace tryitter.Models
{
    // os posts precisam ter um tamanho máximo de 300
    // [ExcludeFromCodeCoverage]
    public class Post
    {
    // internal object content;

        [Key]
        public int PostId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        // public virtual Account? Account {get; set; }
        
        [Column(TypeName = "varchar(300)")]
        public string Image {get; set;} = string.Empty;
        
        [Required, MaxLength(300, ErrorMessage="Número máximo atingido"), 
        Column(TypeName = "varchar(300)")]
        public string Content {get; set;} = string.Empty;
    }
}
