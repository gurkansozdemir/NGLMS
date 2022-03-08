using NGLMS.Core.Models;

namespace NGLMS.Core.DTOs
{
    public class ChatDto : BaseDto
    {
        public int? CreatedUserId { get; set; }
        public int? ReceiverId { get; set; }
        public ICollection<Message> Messages { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
