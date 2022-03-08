namespace NGLMS.Core.Models
{
    public class Chat : BaseEntity
    {
        public Chat()
        {
            Messages = new List<Message>();
        }
        public int? CreatedUserId { get; set; }
        public virtual User CreatedUser { get; set; }
        public int? ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
