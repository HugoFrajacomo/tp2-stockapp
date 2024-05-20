using StockApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Products.Queries
{
    public class GetProdutctByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public int GetProductByIdQuery(int id)
        {
            Id = id;
            return Id;
        }
    }
}
