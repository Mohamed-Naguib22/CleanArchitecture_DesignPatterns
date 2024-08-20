using CleanArchitecture_DesignPatterns.Application.Dtos.BookDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Queries.BookQueries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetBookDto>>
    {
    }
}
