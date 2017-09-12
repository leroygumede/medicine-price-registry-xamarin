using System.Collections.Generic;
using System.Threading.Tasks;
using medicinepricechecker.Models;

namespace medicinepricechecker.Services
{
	public interface IProductServices
	{
		Task<List<Product>> GetProductsAsync();
		Task<Product> GetProductDetailsAsync(string code);
	}
}
