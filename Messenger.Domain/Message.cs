using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Message
    {
        //Properties
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Context { get; set; }

        //Navigation properties
        public List<File> AttachedFile { get; set; }
        public Group Group { get; set; }
    }
}
