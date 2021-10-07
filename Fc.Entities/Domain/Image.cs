using Fc.Entities.Abstractions;

namespace Fc.Entities.Domain
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}
