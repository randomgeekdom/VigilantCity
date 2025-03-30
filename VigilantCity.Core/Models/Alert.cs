using System;
using System.Collections.Generic;
using System.Text;

namespace VigilantCity.Core.Models
{
    public record Alert : Entity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
