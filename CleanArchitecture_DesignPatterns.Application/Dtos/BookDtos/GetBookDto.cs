using CleanArchitecture_DesignPatterns.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Dtos.BookDtos
{
    public class GetBookDto : BaseDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
