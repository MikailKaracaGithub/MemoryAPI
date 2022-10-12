using System;
using System.Collections.Generic;

namespace MemoryWebApi.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = null!;
        public int Score { get; set; }
    }
}
