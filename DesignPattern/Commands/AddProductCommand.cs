using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Commands
{
    public class AddProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly DBFPTSHOPEntities _dbContext;

        public AddProductCommand(Product product, DBFPTSHOPEntities dbContext)
        {
            _product = product;
            _dbContext = dbContext;
        }

        public void Execute()
        {
            _dbContext.Products.Add(_product);
            _dbContext.SaveChanges();
        }
    }
}