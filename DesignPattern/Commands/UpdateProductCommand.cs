using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Commands
{
    public class UpdateProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly DBFPTSHOPEntities _dbContext;

        public UpdateProductCommand(Product product, DBFPTSHOPEntities dbContext)
        {
            _product = product;
            _dbContext = dbContext;
        }

        public void Execute()
        {
            var existingProduct = _dbContext.Products.Find(_product.ProID);
            if (existingProduct != null)
            {
                existingProduct.ProName = _product.ProName;
                existingProduct.RemainQuantity = _product.RemainQuantity;
                existingProduct.CatID = _product.CatID;
                _dbContext.SaveChanges();
            }
        }
    }
}