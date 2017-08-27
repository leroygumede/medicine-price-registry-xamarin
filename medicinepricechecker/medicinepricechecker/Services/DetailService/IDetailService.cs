using System;
using System.Threading.Tasks;
using medicinepricechecker.Models;
using System.Collections.Generic;

namespace medicinepricechecker
{
    public interface IDetailService
    {
        Task<Product> GetProductAsync(string code);
    }
}
