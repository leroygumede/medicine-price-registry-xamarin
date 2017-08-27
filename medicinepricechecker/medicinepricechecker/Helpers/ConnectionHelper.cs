using System.Threading.Tasks;
using Plugin.Connectivity;

namespace medicinepricechecker.Helpers
{
    public class ConnectionHelper : IConnectionHelper
    {
        public async Task<bool> IsConnected()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var connection = await CrossConnectivity.Current.IsRemoteReachable("https://www.google.co.za/");
                return connection;
            }
            else
            {
                return false;
            }
        }
    }
}