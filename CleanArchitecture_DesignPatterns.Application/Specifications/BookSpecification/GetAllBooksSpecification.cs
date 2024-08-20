using CleanArchitecture_DesignPatterns.Application.Specifications.Common;
using CleanArchitecture_DesignPatterns.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Specifications.BookSpecification
{
    public class GetAllBooksSpecification : BaseSpecification<Book>
    {
        public GetAllBooksSpecification() : base()
        {
            AddIclude(e => e.Category);
            AddIclude(e => e.Author);
            AddOrderBy(e => e.Price);
        }
    }
}
