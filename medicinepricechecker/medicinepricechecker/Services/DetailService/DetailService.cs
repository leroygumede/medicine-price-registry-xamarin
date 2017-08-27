using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicinepricechecker.Helpers;
using medicinepricechecker.Models;

namespace medicinepricechecker
{
    public class DetailService : IDetailService
    {
        #region Private members 

        private readonly RequestProvider _requestProvider;
        ConnectionHelper _connectionHelper;

        #endregion

        public DetailService(RequestProvider requestProvider, ConnectionHelper connectionHelper)
        {
            _requestProvider = requestProvider;
            _connectionHelper = connectionHelper;
        }

        #region Public Methods
        public async Task<Product> GetProductAsync(string code)
        {
            if (await _connectionHelper.IsConnected())
            {
                var response = await _requestProvider.GetAsync<Product>("detail?nappi=" + code);
                if (response.name != null)
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