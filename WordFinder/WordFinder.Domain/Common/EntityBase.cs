using System;
using System.ComponentModel.DataAnnotations;

namespace WordFinder.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
    }
}
