using System;
using System.Collections.Generic;
using WordFinder.Domain.Common;

namespace WordFinder.Domain.Entities
{
    public partial class Matrix : EntityBase
    {
        public string? Name { get; set; }
        public string? Items { get; set; }
    }
}