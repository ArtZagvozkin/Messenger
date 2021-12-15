using System;

namespace Messenger.Domain
{
    public class MessageStatus
    {
        //Properties
        public Guid Id { get; set; }
        public Guid RecipientId { get; set; }
        public int Status { get; set; }

        //Foreign key
        public Guid MessageId { get; set; }

        //Navigation properties
        public Message Message { get; set; }
    }
}
