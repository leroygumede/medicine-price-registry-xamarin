using System;
using System.Threading.Tasks;
using medicinepricechecker.Models;
namespace medicinepricechecker
{
    public interface IHomeService
    {
        Task<Products> GetProductsAsync();
    }
}
