using System;
using System.Threading.Tasks;

namespace medicinepricechecker.Helpers
{
    public interface IConnectionHelper
    {
        Task<bool> IsConnected();
    }
}
