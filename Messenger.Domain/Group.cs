using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Group
    {
        //Properties
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        //Navigation properties
        public List<GroupMembership> Memberships { get; set; }
        public List<Message> Messages { get; set; }
    }
}
