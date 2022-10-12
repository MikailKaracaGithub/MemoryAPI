using System;
using System.Collections.Generic;

namespace MemoryWebApi.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Image1 { get; set; } = null!;
        public bool? IsBack { get; set; }
        public string? Theme { get; set; }
    }
}
