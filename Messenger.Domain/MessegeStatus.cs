using System;

namespace Messenger.Domain
{
    public class MessegeStatus
    {
        //Properties
        public Guid Id { get; set; }
        public Guid RecipientId { get; set; }
        public int Status { get; set; }

        //Foreign key
        public Guid MessegeId { get; set; }

        //Navigation properties
        public Messege Messege { get; set; }
    }
}
