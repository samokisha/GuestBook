using System;

namespace MessageContracts.Comments
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}