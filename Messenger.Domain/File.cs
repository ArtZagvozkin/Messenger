using System;

namespace Messenger.Domain
{
    public class File
    {
        //Properties
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime UploadDate { get; set; }
        public string Source { get; set; }
    }
}
