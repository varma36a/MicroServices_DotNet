using CommandSrvc.Commands.Interfaces;
using CommandSrvc.Models;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSrvc.Commands.Handlers
{
    public class ProductCommand: IProductCommand
    {
        AppDbContext _db;
        public ProductCommand(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ProductCommandModel> AddProductAsync(ProductCommandModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            model.ProductId = product.ProductId;
            return model;
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            Product product = _db.Products.Find(Id);
            if(product!=null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProductAsync(ProductCommandModel model)
        {
            try
            {
                Product product = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };
                _db.Products.Update(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
