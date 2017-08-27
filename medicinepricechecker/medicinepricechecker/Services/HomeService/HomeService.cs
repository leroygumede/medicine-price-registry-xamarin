using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;

namespace medicinepricechecker
{
    public class HomeService : IHomeService
    {
        #region Private members 

        private readonly RequestProvider _requestProvider;
        ConnectionHelper _connectionHelper;

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
                var response = await _requestProvider.GetAsync<List<Product>>("search-lite?q=lamictin");
                bool isEmpty = !response.Any();

                if (!isEmpty)
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new NoInternetConnectionException();
            }
        }
        #endregion
    }
}