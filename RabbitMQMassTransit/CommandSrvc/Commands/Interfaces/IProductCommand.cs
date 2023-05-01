using CommandSrvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSrvc.Commands.Interfaces
{
    public interface IProductCommand
    {
        Task<ProductCommandModel> AddProductAsync(ProductCommandModel model);
        Task<bool> UpdateProductAsync(ProductCommandModel model);
        Task<bool> DeleteProductAsync(int Id);
    }
}
