using System;
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
        public async Task<Products> GetProductsAsync()
        {
            if (await _connectionHelper.IsConnected())
            {
                //var responseUser = await _requestProvider.GetAsync<User>(string.Format("api/user/me/"), username, password);
                //TODO: Create Factory
                var response = new Products();

                //bool isEmpty = !response.Any();

                if (response.ToString() != null)
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