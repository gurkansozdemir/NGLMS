namespace NGLMS.Core.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            CreatedChats = new List<Chat>();
            ReceiverChats = new List<Chat>();
            SendMessages = new List<Message>();
            ReceiveMessages = new List<Message>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Chat> CreatedChats { get; set; }
        public virtual ICollection<Chat> ReceiverChats { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Message> ReceiveMessages { get; set; }

    }
}
