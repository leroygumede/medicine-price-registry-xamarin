using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FreshMvvm;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;
using System.Diagnostics;

namespace medicinepricechecker
{
	public class HomeService : IHomeService
	{
		#region Private members 

		private readonly RequestProvider _requestProvider;
		ConnectionHelper _connectionHelper;

		private Repository _repository = FreshIOC.Container.Resolve<Repository>();

		#endregion

		public HomeService(RequestProvider requestProvider, ConnectionHelper connectionHelper)
		{
			_requestProvider = requestProvider;
			_connectionHelper = connectionHelper;
		}

		#region Public Methods
		public async Task<List<Product>> GetProductsAsync()
		{
			if (await _connectionHelper.IsConnected())
			{

				int tableExsists = await _repository.TableExists();
				if (tableExsists == 0)
				{
					var response = await _requestProvider.GetAsync<List<Product>>("search-lite?q=Xyl");
					bool isEmpty = !response.Any();
					foreach (var item in response)
					{
						await _repository.CreateContact(item);
					}

					return await _repository.GetAllProducts();

				}
				else
				{
					return await _repository.GetAllProducts();
				}
				//var response = await _requestProvider.GetAsync<List<Product>>("search-lite?q=Xyl");
				//bool isEmpty = !response.Any();

				//foreach (var item in response)
				//{
				//	await _repository.CreateContact(item);
				//}


				//if (!isEmpty)
				//{

				//}
				//else
				//{
				//	return null;
				//}
			}
			else
			{
				throw new NoInternetConnectionException();
			}
		}
		#endregion
	}
}