using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
    }
}
