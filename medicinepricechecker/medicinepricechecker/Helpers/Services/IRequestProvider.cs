using System;
using System.Threading.Tasks;

namespace medicinepricechecker
{
    public interface IRequestProvider
    {
        string RequestURI { set; }

        Task<TResult> GetAsync<TResult>(); 

        Task<TResult> PutAsync<TResult>(int id, TResult data); 

        Task<TResult> DeleteAsync<TResult>(string relativeUri, int id);
    }
}
