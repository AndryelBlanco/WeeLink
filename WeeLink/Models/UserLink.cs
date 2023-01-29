using System.ComponentModel.DataAnnotations;

namespace WeeLink.Models
{
    public class UserLink
    {
        [Required]
        public string userID { get; set; }

        [Required]
        public string userLink { get; set; }
    }
}
