using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace medicinepricechecker
{
    public class RequestProvider : IRequestProvider
    {

        #region Public Methods

        const string Url = "https://mpr.code4sa.org/api/v2/";
        private string requestURI;

        #endregion 

        public string RequestURI
        {
            private get
            {
                return string.Concat(Url, requestURI);
            }
            set
            {
                this.requestURI = value;
            }
        }



        #region interfaces

        public Task<TResult> DeleteAsync<TResult>(string relativeUri, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> GetAsync<TResult>(string relativeUri)
        {
            requestURI = relativeUri;

            HttpClient client = this.CreateHttpClient();
            HttpResponseMessage response = await client.GetAsync(RequestURI);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                       JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }

        public Task<TResult> PutAsync<TResult>(int id, TResult data)
        {
            throw new NotImplementedException();
        }


        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }
        #endregion

        #region public functions

        private async Task HandleResponse(HttpResponseMessage response)
        {

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new HttpRequestException("Request unauthorized");
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException("Internal server error");
                }
            }
        }

        #endregion
    }
}
