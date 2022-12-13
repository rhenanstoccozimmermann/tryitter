using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using System.Diagnostics.CodeAnalysis;

namespace tryitter.Models
{
    // [ExcludeFromCodeCoverage]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string Module { get; set; } = default!;
        [Required]
        public int Status { get; set; } = default!;
        // public List<Post> Posts { get; set; } = default!;
    }
}
