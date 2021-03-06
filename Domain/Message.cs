using System;
namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Contet { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppUser Sender { get; set; }

        public string SenderId { get; set; }
        public Channel Channel { get; set; }
        public Guid ChannelId { get; set; }
        public MessageType MessageType { get; set; }
    }
}
