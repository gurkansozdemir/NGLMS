namespace NGLMS.Core.Models
{
    public class Message : BaseEntity
    {
        public int? SenderId { get; set; }
        public virtual User Sender { get; set; }
        public int? ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
    }
}
