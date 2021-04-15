using System.ComponentModel.DataAnnotations;

namespace MessageContracts.Comments
{
    public class GuestModel
    {
        [Required]
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}