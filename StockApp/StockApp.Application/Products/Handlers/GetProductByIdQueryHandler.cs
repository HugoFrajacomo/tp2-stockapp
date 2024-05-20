using MediatR;
using StockApp.Application.Products.Queries;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProdutctByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProdutctByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(request.Id);
        }
    }
}
