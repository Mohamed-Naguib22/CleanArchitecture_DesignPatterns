using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
