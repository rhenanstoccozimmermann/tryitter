using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Module { get; set; }
        public string Password { get; set; }
        
    }
}
