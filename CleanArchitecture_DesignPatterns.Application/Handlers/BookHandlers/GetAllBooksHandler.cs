using AutoMapper;
using CleanArchitecture_DesignPatterns.Application.Contract.IRepositories.ICommon;
using CleanArchitecture_DesignPatterns.Application.Dtos.BookDtos;
using CleanArchitecture_DesignPatterns.Application.Queries.BookQueries;
using CleanArchitecture_DesignPatterns.Application.Specifications.BookSpecification;
using CleanArchitecture_DesignPatterns.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Handlers.BookHandlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetBookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var specifications = new GetAllBooksSpecification();

            var books = await _unitOfWork.GetRepository<Book>().GetAllAsync(specifications);

            return _mapper.Map<IEnumerable<GetBookDto>>(books);
        }
    }
}
