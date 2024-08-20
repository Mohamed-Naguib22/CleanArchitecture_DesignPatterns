using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
