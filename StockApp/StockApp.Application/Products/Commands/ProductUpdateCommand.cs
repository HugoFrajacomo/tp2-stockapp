﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductsCommand
    {
        public int Id { get; set; }
    }
}
