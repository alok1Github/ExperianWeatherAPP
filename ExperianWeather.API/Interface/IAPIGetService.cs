using Experian.API.Request;

namespace Experian.API.Interface
{
    public interface IAPIGetService<T> where T : class
    {
        Task<T?> GetData(ServiceRequest request);
    }
}
