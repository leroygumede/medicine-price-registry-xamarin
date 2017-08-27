using System;
using System.Threading.Tasks;
using medicinepricechecker.Models;
using System.Collections.Generic;
namespace medicinepricechecker
{
    public interface IHomeService
    {
        Task<List<Products>> GetProductsAsync();
    }
}
