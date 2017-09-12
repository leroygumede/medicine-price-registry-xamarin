using System.Collections.Generic;
using System.Threading.Tasks;
using FreshMvvm;
using medicinepricechecker.Models;

namespace medicinepricechecker.Services
{
	public class ProductServices : IProductServices
	{

		#region Private members 

		private readonly RequestProvider _requestProvider;
		private Repository _repository = FreshIOC.Container.Resolve<Repository>();

		#endregion

		public ProductServices(RequestProvider requestProvider)
		{
			_requestProvider = requestProvider;
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			var response = await _repository.GetAllProducts();
			return response;
		}

		public async Task<Product> GetProductDetailsAsync(string code)
		{
			var response = await _repository.GetProduct(code);

			if (response[0].name != null)
			{
				return response[0];
			}
			else
			{
				return null;
			}
		}
	}
}
