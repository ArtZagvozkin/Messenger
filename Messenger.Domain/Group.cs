using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Group
    {
        //Properties
        Guid Id { get; set; }
        Guid OwnerId { get; set; }
        string Name { get; set; }
        int Type { get; set; }
        DateTime CreationDate { get; set; }
        string Description { get; set; }

        //Navigation properties
        public List<GroupMembership> Memberships { get; set; }
        public List<Messege> Messeges { get; set; }
    }
}
