using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class GroupMembership
    {
        //Properties
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string EmpployeeName { get; set; }
        public DateTime EntryDate { get; set; }

        //Foreign key
        public Guid GroupId { get; set; }

        //Navigation properties
        public List<Group> Group { get; set; }
    }
}
